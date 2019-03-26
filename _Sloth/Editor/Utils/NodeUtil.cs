using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class NodeUtil {
    public static void EnumGameObject(GameObject obj)
    {
        Dictionary<string, bool> mapNodeNames = new Dictionary<string, bool>();
        for (var i = 0; i < obj.transform.childCount; i++)
        {
            var currentGameObject = obj.transform.GetChild(i).gameObject;
            if (null == currentGameObject)
                continue;
            if (mapNodeNames.ContainsKey(currentGameObject.name))
            {
                currentGameObject.name += "_" + i.ToString();
            }
            mapNodeNames.Add(currentGameObject.name, true);
            EnumGameObject(currentGameObject);
        }
    }

    /// <summary>
    /// 删除绑定在对象身上，指定类型的脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static void RemoveActiveSceneGameObjectScript<T>() where T : MonoBehaviour
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in list)
        {
            T t = item.GetComponent<T>();
            if (t != null)
            {
                Object.DestroyImmediate(t);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsonUrl"></param>
    public static void AddActiveSceneGameObjectScript<T>(string jsonUrl) where T : MonoBehaviour
    {
        //AssetDatabase.LoadAssetAtPath(jsonUrl, );
    }
    /// <summary>
    /// 为指定的对象绑上脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    public static void AddActiveSceneGameObjectScriptFromPath<T>(string goPath) where T : MonoBehaviour
    {
        string p = goPath.Replace('#', '/');
        GameObject go = GameObject.Find(p);
        if (go != null)
        {
            go.AddComponent<T>();
        }
    }

    public static List<GameObject> UnActiveGameObjectCount()
    {
        List<GameObject> unActiveList = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        int count = 0;
        foreach (GameObject item in list)
        {
            if(item && !item.activeInHierarchy)
            {
                count++;
                unActiveList.Add(item);
            }
        }
        Debug.Log("未激活对象数量 : " +count);
        return unActiveList;
    } 

    public static List<GameObject> NoScriptNoChildNoNoNoObjectCount()
    {
        List<GameObject> noList = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        int count = 0;
        foreach (GameObject item in list)
        {
            if (!item.activeInHierarchy)
            {
                count++;
                noList.Add(item);
            }
        }
        Debug.Log("可清理的空对象数量 : " + count);
        return noList;
    }

    public static void CheckObjectName()
    {
        List<string> nlist = new List<string>();
        List<GameObject>  goList = SceneUtil.GetActiveSceneAllGO();
        int count = 0;
        foreach (GameObject item in goList)
        {
            string path = FileUtil.GetGameObjectPath(item);
            if (nlist.IndexOf(path) != -1)
            {
                Debug.LogError("重名:  " + path);
                count++;
            }
            else
            {
                nlist.Add(path);
            }
        }
        Debug.Log(string.Format("检查完毕{0}个重名", count));
    }
    private static int _renameIndex = 0;
    public static void RepetitionObjectName()
    {
        UnityEngine.SceneManagement.Scene s = EditorSceneManager.GetActiveScene();
        if (s != null)
        {
            _renameIndex = 0;
            List<GameObject> goList = new List<GameObject>();
            GameObject[] gos = s.GetRootGameObjects();
            Dictionary<int, List<GameObject>> dict = new Dictionary<int, List<GameObject>>();
            foreach (GameObject item in gos)
            {
                _CheckObjectName(item.transform, ref goList);
            }
            EditorUtility.DisplayDialog("", "改名完毕", "OK");
        }
    }

    private static void _CheckObjectName(Transform tf, ref List<GameObject> goList)
    {
        if(tf != null)
        {
            string path = string.Empty;
            Transform ctf = null;
            List<string> nameList = new List<string>();

            int length = tf.childCount;
            for (int i = 0; i < length; i++)
            {
                ctf = tf.GetChild(i);
                path = FileUtil.GetGameObjectPath(ctf.gameObject);
                if (nameList.Contains(path))
                {
                    _renameIndex++;
                    ctf.gameObject.name = ctf.gameObject.name + "_" + _renameIndex;
                    goList.Add(ctf.gameObject);
                    _CheckObjectName(ctf, ref goList);
                }
                else
                {
                    nameList.Add(path);
                    _CheckObjectName(ctf, ref goList);
                }
            }
        }
    }

}

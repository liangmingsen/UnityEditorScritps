﻿using Foundation.Editor.AssetAudit;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SceneUtil : MonoBehaviour {

    #region 导出选中所有对象，删除前/后 路径，最后找出已删除所有对象并导出路径。
    public static void ExportSceneSelectObjs(string nam)
    {
        Transform[] tfs = Selection.transforms;
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        foreach (var t in tfs)
        {
            string path = FileUtils.GetGameObjectPath(t.gameObject);
            rootJson.Add(path, path);
        }
        string file_path = Application.dataPath + string.Format("/_Sloth/Editor/select_{0}_{1}.txt", nam, System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute + "_" + System.DateTime.Now.Second);
        StreamWriter sw = new StreamWriter(file_path);
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(file_path);

        Debug.Log("数量：" + rootJson.Count);
    }
    public static void CheckDelectFormJSON()
    {
        object[] objs = Selection.objects;
        if (objs.Length == 2)
        {
            string a = objs[0].ToString();
            string b = objs[1].ToString();
            Umeng.JSONObject top = Umeng.JSONObject.Parse(a) as Umeng.JSONObject;
            Umeng.JSONObject back = Umeng.JSONObject.Parse(b) as Umeng.JSONObject;
            if (top != null && back != null)
            {
                List<string> del_list = new List<string>();
                int length = top.Count;
                for (int i = 0; i < length; i++)
                {
                    string top_path = top[i];
                    string back_path = back[top_path];
                    if (back_path != top_path)
                    {
                        del_list.Add(top_path);
                    }
                }
                Umeng.JSONArray rootJson = new Umeng.JSONArray();
                foreach (string item in del_list)
                {
                    Debug.Log("del ::  " + item);
                    rootJson.Add(item);
                }
                string file_path = Application.dataPath + string.Format("/_Sloth/Editor/select_{0}_{1}.txt", "del", System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute + "_" + System.DateTime.Now.Second);
                StreamWriter sw = new StreamWriter(file_path);
                sw.Write(rootJson.ToString());
                sw.Close();
                Application.OpenURL(file_path);

                Debug.Log("数量：" + rootJson.Count);
            }
        }
    }
    public static void HandleDelectObjects()
    {
        object[] objs = Selection.objects;
        if(objs.Length == 1)
        {
            string a = objs[0].ToString();
            Umeng.JSONArray dels = Umeng.JSONArray.Parse(a) as Umeng.JSONArray;
            if(dels != null)
            {
                int length = dels.Count;
                for (int i = 0; i < length; i++)
                {
                    string path = dels[i];
                    string new_path = path.Replace('#', '/');
                    
                    GameObject del_go = GameObject.Find(new_path);
                    if(del_go == null)
                    {
                        Debug.LogError("没找到对象:  " + new_path);
                        continue;
                    }


                }
            }
        }
    }
    #endregion


    public static void ExportGameobjectUID()
    {
        List<GameObject> list = GetActiveSceneAllGO();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        foreach (GameObject item in list)
        {
            if(item.GetComponent<MeshRenderer>() != null)
            {
                rootJson.Add(item.GetInstanceID().ToString(), FileUtils.GetGameObjectPath(item));
            }
        }
        StreamWriter sw = FileUtils.GetTempFile();
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());

        Debug.Log("数量：" + rootJson.Count);
    }

    public static void CheckTextureReferenceLose()
    {
        List<GameObject> goList = new List<GameObject>();
        List<GameObject> list = GetActiveSceneAllGO();
        foreach (GameObject item in list)
        {
            Renderer[] rends = item.GetComponents<Renderer>();
            foreach (Renderer r in rends)
            {
                if(r.material.mainTexture == null)
                {
                    goList.Add(item);
                }
            }
        }
        Selection.objects = goList.ToArray();
        Debug.Log("图片缺失:" + goList.Count);
    }

    /// <summary>
    /// 设置纹理可读属性 
    /// 依赖ImageTextureSettings 中重写  _settings.generalSettings.readable = true;
    /// </summary>
    public static void SetActiveSceneTextureRead()
    {
        if(EditorUtility.DisplayDialog("警告", "修改纹理属性，大概10分钟，是否继续", "确定", "取消"))
        {
            AssetProfile[] aps = Selection.GetFiltered<AssetProfile>(SelectionMode.TopLevel);
            EditorUtility.DisplayProgressBar("", "0/"+ aps.Length, 0.0f);
            int count = 0;
            foreach (AssetProfile item in aps)
            {
                if (item.defaultTextureImporterSettings.enabled)
                {
                    TextureSettings ts = item.defaultTextureImporterSettings.settings;
                    if (!ts.generalSettings.readable)
                    {
                        ts.generalSettings.readable = true;
                        ts.androidSettings.overridden = true;
                        ts.androidSettings.format = TextureImporterFormat.RGBA32;
                        ts.iosSettings.overridden = false;
                        item.defaultTextureImporterSettings.settings = ts;
                        _Apply(item, "t:Texture", AssetSettingsType.Texture);
                        count++;
                        EditorUtility.DisplayProgressBar("", count + "/" + aps.Length, 0.0f);
                    }
                }
            }
            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("提示", "修改完成", "确定");
        }
    }

    public static int GetActiveSceneAllGameObjectCount()
    {
        List<GameObject> list = GetActiveSceneAllGO();
        if(list != null)
        {
            return list.Count;
        }
        return 0;
    }

    /// <summary>
    /// 返回激活场景的所有对象
    /// </summary>
    /// <returns></returns>
	public static List<GameObject> GetActiveSceneAllGO()
    {
        UnityEngine.SceneManagement.Scene s = EditorSceneManager.GetActiveScene();
        if(s != null)
        {
            GameObject[] gos = s.GetRootGameObjects();
            int length = gos.Length;
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < length; i++)
            {
                _ForGameObjects(gos[i].transform, list);
            }
            return list;
        }
        return new List<GameObject>();
    }
    
    private static void _ForGameObjects(Transform tf, List<GameObject> list)
    {
        if (tf != null)
        {
            list.Add(tf.gameObject);
            int length = tf.childCount;
            for (int i = 0; i < length; i++)
            {
                _ForGameObjects(tf.GetChild(i), list);
            }
        }
    }

    public static Dictionary<string, GameObject> GetActiveSceneAllGODict()
    {
        UnityEngine.SceneManagement.Scene s = EditorSceneManager.GetActiveScene();
        if (s != null)
        {
            GameObject[] gos = s.GetRootGameObjects();
            int length = gos.Length;
            Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
            for (int i = 0; i < length; i++)
            {
                _ForGameObjectDict(gos[i].transform, dict);
            }
            return dict;
        }
        return new Dictionary<string, GameObject>();
    }

    private static void _ForGameObjectDict(Transform tf, Dictionary<string, GameObject> dict)
    {
        if (tf != null)
        {
            string pathName = FileUtils.GetGameObjectPath(tf.gameObject);
            if (dict.ContainsKey(pathName))
            {
                Debug.LogError("相同名字路径:" + pathName);
            }
            else
            {
                dict.Add(pathName, tf.gameObject);
            }
            int length = tf.childCount;
            for (int i = 0; i < length; i++)
            {
                _ForGameObjectDict(tf.GetChild(i), dict);
            }
        }
    }

    private static void _Apply(AssetProfile profile, string searchPattern, AssetSettingsType type)
    {
        if (string.IsNullOrEmpty(searchPattern))
            return;

        var profilePath = AssetDatabase.GetAssetPath(profile);
        profilePath = Path.GetDirectoryName(profilePath);
        var ass = AssetDatabase.FindAssets(searchPattern, new[] { profilePath });
        
        for (var i = 0; i != ass.Length; ++i)
        {
            var p = AssetDatabase.GUIDToAssetPath(ass[i]);
            AssetDatabase.ImportAsset(p, ImportAssetOptions.Default);
            AssetDatabase.Refresh();
        }
    }


}
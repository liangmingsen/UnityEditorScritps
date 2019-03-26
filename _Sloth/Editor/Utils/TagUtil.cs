using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TagUtil {
    public static void RemoveSlothTagMono()
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        SlothTagMono[] monos = null;
        int count = 0;
        foreach (GameObject item in list)
        {
            monos = item.GetComponents<SlothTagMono>();
            if (monos != null)
            {
                foreach (SlothTagMono stm in monos)
                {
                    GameObject.DestroyImmediate(stm);
                    count++;
                }
            }
        }
        Debug.Log("移除绑在对象身上的ShothTagMono脚本数量: " + count);
    }
   
    public static void UnTabObjectStatic()
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in list)
        {
            if(GameObjectUtility.AreStaticEditorFlagsSet(item, StaticEditorFlags.BatchingStatic))
            {
                StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags(item);
                flags &= ~StaticEditorFlags.BatchingStatic;
                GameObjectUtility.SetStaticEditorFlags(item, flags);
            }
        }
        Debug.Log("移除标记对象的静态属性: " + list.Count);
    }

    public static void TagObjectStatic()
    {
        TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>(FileUtil.GetTagStaticAssetPath());
        if (ta == null)
        {
            Debug.Log("读取文件信息失败");
            return;
        }
        Umeng.JSONObject jo = Umeng.JSONObject.Parse(ta.text) as Umeng.JSONObject;
        if (jo == null)
        {
            Debug.Log("从静态节点JSON转换失败");
            return;
        }
        Umeng.JSONArray ja = jo["tagStatic"] as Umeng.JSONArray;
        if(ja == null)
        {
            Debug.Log("没有静态标记列表");
            return;
        }

        Dictionary<string, GameObject> allDict = SceneUtil.GetActiveSceneAllGODict();
        string nam = "";
        GameObject go = null;
        int count = ja.Count;
        int length = 0;
        for (int i = 0; i < count; i++)
        {
            nam = ja[i];
            if (allDict.ContainsKey(nam))
            {
                go = allDict[nam];
                if(go != null)
                {
                    if(!GameObjectUtility.AreStaticEditorFlagsSet(go, StaticEditorFlags.BatchingStatic))
                    {
                        StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags(go);
                        flags |= StaticEditorFlags.BatchingStatic;
                        GameObjectUtility.SetStaticEditorFlags(go, flags);
                    }
                    length++;
                }
            }
            else
            {
                Debug.Log("找不到对象" +  nam);
            }
        }

        Debug.Log("标记对象的静态属性: " + length);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Umeng;

public class BakedLightmapUtil
{
    public static void WriteBakeLightmap()
    {
        TextAsset txt = AssetDatabase.LoadAssetAtPath<TextAsset>(FileUtil.GetLightmapDataPathAsset());
        if (txt == null)
        {
            Debug.LogError("找不到文件" + FileUtil.GetLightmapDataPathAsset());
            return;
        }
        Umeng.JSONObject jo = Umeng.JSONObject.Parse(txt.text) as Umeng.JSONObject;
        if (jo == null)
        {
            Debug.LogError("转JSON错误：" + FileUtil.GetLightmapDataPathAsset());
            return;
        }
        Umeng.JSONObject lightmapData = jo["lightmapData"] as Umeng.JSONObject;
        if (lightmapData == null)
        {
            Debug.LogError("JSON数据错误：" + FileUtil.GetLightmapDataPathAsset());
            return;
        }

        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        MeshRenderer mr = null;
        string key = "";
        string val = "";
        foreach (GameObject item in list)
        {
            mr = item.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                key = FileUtil.GetGameObjectPath(item);
                val = lightmapData[key];
                if (val != null && val.Length > 0)
                {
                    string[] vs = val.Split('#');
                    if (vs.Length < 5)
                    {
                        Debug.LogError("烘焙数据有误" + key);
                    }
                    else
                    {
                        if(!GameObjectUtility.AreStaticEditorFlagsSet(item, StaticEditorFlags.LightmapStatic))
                        {
                            StaticEditorFlags flgs = GameObjectUtility.GetStaticEditorFlags(item);
                            flgs |= StaticEditorFlags.LightmapStatic;
                            GameObjectUtility.SetStaticEditorFlags(item, flgs);
                        }
                        mr.lightmapIndex = int.Parse(vs[0]);
                        mr.lightmapScaleOffset = new Vector4(float.Parse(vs[2]), float.Parse(vs[3]), float.Parse(vs[4]), float.Parse(vs[1]));
                    }
                }
            }
        }
        Debug.Log("重置场景灯光烘焙完毕");
    }
    public static void ReadBakedLightmap()
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        MeshRenderer mr = null;
        List<MeshRenderer> mrList = new List<MeshRenderer>();
        foreach (GameObject item in list)
        {
            mr = item.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                if (GameObjectUtility.AreStaticEditorFlagsSet(item, StaticEditorFlags.LightmapStatic))
                {
                    mrList.Add(mr);
                }
            }
        }
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (MeshRenderer item in mrList)
        {
            string path = FileUtil.GetGameObjectPath(item.gameObject);
            string val = item.lightmapIndex
                + "#" + item.lightmapScaleOffset.w.ToString()
                + "#" + item.lightmapScaleOffset.x.ToString()
                + "#" + item.lightmapScaleOffset.y.ToString()
                + "#" + item.lightmapScaleOffset.z.ToString();
            if (dict.ContainsKey(path))
            {
                Debug.LogWarning("key重复了: " + path);
            }
            else
            {
                dict.Add(path, val);
            }
        }

        StreamWriter sw = FileUtil.GetLightmapDataFile();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();

        Umeng.JSONObject staticJson = new Umeng.JSONObject();
        foreach (KeyValuePair<string, string> item in dict)
        {
            staticJson.Add(item.Key, item.Value);
        }
        rootJson.Add("lightmapData", staticJson);

        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtil.GetLightmapDataPath());

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Umeng;
using UnityEditor.SceneManagement;

public class BakedLightmapUtil
{
    private static Dictionary<string, bool> _hasDict = new Dictionary<string, bool>();

    private static string GetLightmapDataPath()
    {
        string fileName = EditorSceneManager.GetActiveScene().name + "_lightmapData.txt";
        string lightmapDataFilePath = Application.dataPath + @"/_Sloth/ExportJson/" + fileName;
        return lightmapDataFilePath;
    }

    public static void WriteBakeLightmap()
    {
        string filePath = GetLightmapDataPath();
        if (!File.Exists(filePath))
        {
            Debug.LogError("找不到文件:" + filePath);
            return;
        }
        Debug.Log("start read lightmap data:" + filePath);
        // return;
        StreamReader sr = new StreamReader(filePath);
        string jsonStr = sr.ReadToEnd();
        sr.Close();
        Umeng.JSONObject jo = Umeng.JSONObject.Parse(jsonStr) as Umeng.JSONObject;
        if (jo == null)
        {
            Debug.LogError("转JSON错误：" + filePath);
            return;
        }
        Umeng.JSONObject lightmapData = jo["lightmapData"] as Umeng.JSONObject;
        if (lightmapData == null)
        {
            Debug.LogError("JSON数据错误：" + filePath);
            return;
        }
        _hasDict.Clear();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        MeshRenderer mr = null;
        string key = "";
        string childKey = "";
        string val = "";
        foreach (GameObject item in list)
        {
            mr = item.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                key = FileUtils.GetGameObjectPath(item);
                val = lightmapData[key];
                if (_WriteLightData(val, key, item, mr))
                    continue;

                childKey = key + "#model";
                val = lightmapData[childKey];
                if (_WriteLightData(val, childKey, item, mr))
                    continue;

                childKey = key + "#model#centerPart";
                val = lightmapData[childKey];
                if (_WriteLightData(val, childKey, item, mr))
                    continue;

                childKey = key + "#model#AiJi_ShaMo_Zhu01_1";
                val = lightmapData[childKey];
                if (_WriteLightData(val, childKey, item, mr))
                    continue;


            }
        }
        _ExportUnWriteLightData(lightmapData);
        Debug.Log("重置场景灯光烘焙完毕");
    }
    public static void ReadBakedLightmap(GameObject[] list = null, bool exportRealtime = false)
    {
        if (list == null)
        {
            list = SceneUtil.GetActiveSceneAllGO().ToArray();
        }
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
            if (exportRealtime)
            {
                Debug.Log("===>" + item.additionalVertexStreams);
                if (item.additionalVertexStreams != null)
                {
                    AssetDatabase.CreateAsset(item.additionalVertexStreams, assetPath);
                    AssetDatabase.ImportAsset(assetPath);
                }
            }

            string path = FileUtils.GetGameObjectPath(item.gameObject);
            string val = item.lightmapIndex
                + "#" + item.lightmapScaleOffset.w.ToString()
                + "#" + item.lightmapScaleOffset.x.ToString()
                + "#" + item.lightmapScaleOffset.y.ToString()
                + "#" + item.lightmapScaleOffset.z.ToString();
            if (exportRealtime)
            {
                val += "#" + item.realtimeLightmapIndex;
                val += "#" + item.realtimeLightmapScaleOffset.w.ToString();
                val += "#" + item.realtimeLightmapScaleOffset.x.ToString();
                val += "#" + item.realtimeLightmapScaleOffset.y.ToString();
                val += "#" + item.realtimeLightmapScaleOffset.z.ToString();
            }

            if (dict.ContainsKey(path))
            {
                Debug.LogWarning("key重复了: " + path);
            }
            else
            {
                dict.Add(path, val);
            }
        }

        string filePath = GetLightmapDataPath();
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        StreamWriter sw = new StreamWriter(filePath);
        Umeng.JSONObject rootJson = new Umeng.JSONObject();

        Umeng.JSONObject staticJson = new Umeng.JSONObject();
        foreach (KeyValuePair<string, string> item in dict)
        {
            staticJson.Add(item.Key, item.Value);
        }
        rootJson.Add("lightmapData", staticJson);

        sw.Write(rootJson.ToString());
        sw.Close();
        AssetDatabase.Refresh();
        Application.OpenURL(filePath);

    }
    const string assetPath = "_saving/meshData.asset";
    private static bool _WriteLightData(string val, string key, GameObject item, MeshRenderer mr)
    {
        if (val != null && val.Length > 0)
        {
            string[] vs = val.Split('#');
            if (vs.Length < 5)
            {
                Debug.LogError("烘焙数据有误" + key);
            }
            else
            {
                if (!GameObjectUtility.AreStaticEditorFlagsSet(item, StaticEditorFlags.LightmapStatic))
                {
                    StaticEditorFlags flgs = GameObjectUtility.GetStaticEditorFlags(item);
                    flgs |= StaticEditorFlags.LightmapStatic;
                    GameObjectUtility.SetStaticEditorFlags(item, flgs);
                }
                mr.lightmapIndex = int.Parse(vs[0]);
                mr.lightmapScaleOffset = new Vector4(float.Parse(vs[2]), float.Parse(vs[3]), float.Parse(vs[4]), float.Parse(vs[1]));
                if (vs.Length == 10)
                {
                    mr.realtimeLightmapIndex = int.Parse(vs[5]);
                    mr.realtimeLightmapScaleOffset = new Vector4(float.Parse(vs[7]), float.Parse(vs[8]), float.Parse(vs[9]), float.Parse(vs[6]));

                    MeshFilter mf = mr.transform.GetComponent<MeshFilter>();
                    if (mf != null)
                    {
                        //int length = mf.sharedMesh.vertexCount;
                        //Vector2[] testUV = new Vector2[length];
                        //for (int i = 0; i < length; i++)
                        //{
                        //    testUV[i] = mf.sharedMesh.uv3[i];
                        //}
                        //mf.sharedMesh.uv3 = testUV;

                        Mesh meshData = AssetDatabase.LoadAssetAtPath<Mesh>(assetPath);
                        if (meshData != null)
                        {
                            mr.additionalVertexStreams = meshData;
                            mf.sharedMesh.UploadMeshData(true);
                        }

                        //Mesh newMesh = new Mesh();
                        //newMesh.vertices = mf.sharedMesh.vertices;
                        //newMesh.uv3 = testUV;
                        //mr.additionalVertexStreams = newMesh;
                        //newMesh.UploadMeshData(true);
                    }
                }
                _hasDict.Add(key, true);
            }
            return true;
        }
        return false;
    }

    private static void _ExportUnWriteLightData(Umeng.JSONObject lightmapData)
    {
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        foreach (KeyValuePair<string, JSONNode> item in lightmapData)
        {
            if (!_hasDict.ContainsKey(item.Key))
            {
                rootJson.Add(item.Key, "no light data");
            }
        }
        StreamWriter sw = FileUtils.GetTempFile();
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());
        _hasDict.Clear();
    }

}

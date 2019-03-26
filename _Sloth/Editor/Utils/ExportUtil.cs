using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Umeng;

public class ExportUtil {



    public static void ExportTagSaticObject()
    {
        List<GameObject> staticList = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        SlothTagMono tagMono = null;
        foreach (GameObject item in list)
        {
            tagMono = item.GetComponent<SlothTagMono>();
            if (GameObjectUtility.AreStaticEditorFlagsSet(item, StaticEditorFlags.BatchingStatic) || tagMono != null)
            {
                MeshFilter mf = item.GetComponent<MeshFilter>();
                if (mf != null && mf.sharedMesh != null)
                {
                    staticList.Add(item);
                }
            }
        }
        StreamWriter sw = FileUtil.GetTagStaticFile();
        Umeng.JSONArray rootJson = new Umeng.JSONArray();

        foreach (GameObject item in staticList)
        {
            rootJson.Add(FileUtil.GetGameObjectPath(item));
        }
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtil.GetTagStaticPath());

        Debug.Log("标记静态数量：" + staticList.Count );

    }

    public static void ExportParticleObjects()
    {
        List<GameObject> particleList = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        if (list != null)
        {
            int length = list.Count;
            foreach (GameObject item in list)
            {
                ParticleSystem particle = item.GetComponent<ParticleSystem>();
                if (particle != null)
                {
                    particleList.Add(item);
                }
            }
            StreamWriter sw = FileUtil.GetParticleFile();
            Umeng.JSONObject rootJson = new Umeng.JSONObject();

            //粒子
            JSONArray psJson = new JSONArray();
            foreach (GameObject item in particleList)
            {
                psJson.Add(FileUtil.GetGameObjectPath(item));
            }
            rootJson.Add("particles", psJson);

            sw.Write(rootJson.ToString());
            sw.Close();
            Application.OpenURL(FileUtil.GetParticleFilePath());

            Debug.Log("粒子数量：" + psJson.Count);
        }
    }

    //public static void ExportTagSaticMeshParticleObject()
    //{
    //    List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
    //    List<GameObject> staticList = new List<GameObject>();
    //    List<GameObject> meshColliderList = new List<GameObject>();
    //    List<GameObject> particleList = new List<GameObject>();

    //    if (list != null)
    //    {
    //        int length = list.Count;
    //        foreach (GameObject item in list)
    //        {
    //            SlothTagMono stag = item.GetComponent<SlothTagMono>();
    //            if (stag && stag.TagStatic)
    //            {
    //                MeshFilter mf = item.GetComponent<MeshFilter>();
    //                MeshRenderer mr = item.GetComponent<MeshRenderer>();
    //                if (mf != null && mr != null)
    //                {
    //                    if (mf.mesh != null && mr.material != null)
    //                    {
    //                        item.isStatic = true;
    //                        staticList.Add(stag.gameObject);
    //                    }
    //                }
    //            }
    //            MeshCollider meshCollider = item.GetComponent<MeshCollider>();
    //            if (meshCollider != null)
    //            {
    //                meshColliderList.Add(item);
    //            }
    //            ParticleSystem particle = item.GetComponent<ParticleSystem>();
    //            if (particle != null)
    //            {
    //                particleList.Add(item);
    //            }
    //        }
    //        StreamWriter sw = FileUtil.GetTempFile();
    //        Umeng.JSONObject rootJson = new Umeng.JSONObject();

    //        //标记静态
    //        JSONArray staticJson = new JSONArray();
    //        foreach (GameObject item in staticList)
    //        {
    //            staticJson.Add(FileUtil.GetGameObjectPath(item));
    //        }
    //        rootJson.Add("tagStatic", staticJson);

    //        //网格碰撞
    //        JSONArray mcJson = new JSONArray();
    //        foreach (GameObject item in meshColliderList)
    //        {
    //            mcJson.Add(FileUtil.GetGameObjectPath(item));
    //        }
    //        rootJson.Add("meshCollider", mcJson);

    //        //粒子
    //        JSONArray psJson = new JSONArray();
    //        foreach (GameObject item in particleList)
    //        {
    //            psJson.Add(FileUtil.GetGameObjectPath(item));
    //        }
    //        rootJson.Add("particle", psJson);

    //        sw.Write(rootJson.ToString());
    //        sw.Close();
    //        Application.OpenURL(FileUtil.GetTagStaticPath());

    //        Debug.Log("标记静态：" + staticJson.Count + "   网格碰撞：" + mcJson.Count + "   粒子数：" + psJson.Count);
    //    }
    //}


}

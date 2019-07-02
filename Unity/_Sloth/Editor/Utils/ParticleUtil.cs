using System.Collections;
using System.Collections.Generic;
using System.IO;
using Umeng;
using UnityEngine;
using UnityEditor;

public class ParticleUtil : MonoBehaviour
{

    private static Dictionary<string, List<GameObject>> _meshDict = new Dictionary<string, List<GameObject>>();//相同Mesh
    private static List<Mesh> _unMeshList = new List<Mesh>();//设置了mesh渲染模式，但没附网格的

    private static Dictionary<string, List<GameObject>> _materialDict = new Dictionary<string, List<GameObject>>();//相同材质
    private static List<GameObject> _unMaterialList = new List<GameObject>();

    private static int _particleCount = 0;

    public static void GetParticleCount()
    {
        GetParticleSystemAllGO();
    }

    public static void ExportActiveSceneParticleListUnMaterial()
    {
        _materialDict.Clear();
        _unMaterialList.Clear();
        List<ParticleSystem> psGo = GetParticleSystemAllGO();
        foreach (ParticleSystem item in psGo)
        {
            ParticleSystemRenderer prs = item.gameObject.GetComponent<Renderer>() as ParticleSystemRenderer;
            if (prs != null && item.gameObject.activeInHierarchy)
            {
                _SetParticleSystemMaterialObject(prs);
            }
        }
        
        StreamWriter sw = FileUtils.GetTempFile();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        Umeng.JSONArray ja = new Umeng.JSONArray();
        foreach (GameObject item in _unMaterialList)
        {
            ja.Add(FileUtils.GetGameObjectPath(item));
        }
        rootJson.Add("unMaterial", ja);

        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());
        Selection.objects = _unMaterialList.ToArray();
        Debug.Log("粒子总数:" + _particleCount + " 没有附材质的粒子数量 :" + _unMaterialList.Count);
    }

    public static void ExportActiveSceneParticleListMaterial()
    {
        _materialDict.Clear();
        List<ParticleSystem> psGo = GetParticleSystemAllGO();
        foreach (ParticleSystem item in psGo)
        {
            ParticleSystemRenderer prs = item.gameObject.GetComponent<Renderer>() as ParticleSystemRenderer;
            if (prs != null && item.gameObject.activeInHierarchy)
            {
                _SetParticleSystemMaterialObject(prs);
            }
        }
        StreamWriter sw = FileUtils.GetTempFile();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        Umeng.JSONArray keys = new Umeng.JSONArray();
        int count = 0;
        foreach (KeyValuePair<string, List<GameObject>> item in _materialDict)
        {
            Umeng.JSONArray ja = new Umeng.JSONArray();
            count += item.Value.Count;
            foreach (GameObject go in item.Value)
            {
                ja.Add(FileUtils.GetGameObjectPath(go));
            }
            rootJson.Add(item.Key, ja);
            keys.Add(item.Key);
        }
        rootJson.Add("keys", keys);

        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());

        Debug.Log("粒子总数:" + _particleCount + " 使用了材质的粒子数:" + _materialDict.Count);
    }

    public static void ExportActiveSceneParticleListMesh()
    {
        _meshDict.Clear();
        _unMeshList.Clear();

        List<ParticleSystem> psGo = GetParticleSystemAllGO();
        foreach (ParticleSystem item in psGo)
        {
            ParticleSystemRenderer prs = item.gameObject.GetComponent<Renderer>() as ParticleSystemRenderer;
            if (prs != null)
            {
                _SetParticleSystemMeshObject(prs);
            }
        }
        StreamWriter sw = FileUtils.GetTempFile();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();
        int count = 0;
        foreach (KeyValuePair<string, List<GameObject>> item in _meshDict)
        {
            Umeng.JSONArray ja = new Umeng.JSONArray();
            count += item.Value.Count;
            foreach (GameObject go in item.Value)
            {
                ja.Add(FileUtils.GetGameObjectPath(go));
            }
            rootJson.Add(item.Key, ja);
        }
        rootJson.Add("网格种类数:", _meshDict.Count);
        rootJson.Add("网格总粒子数:", count);
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());

        Debug.Log("粒子总数:" + _particleCount + " 使用了网格的粒子数:" + _meshDict.Count);
    }
    public static void ExportActiveSceneParticleList()
    {
        //_meshDict.Clear();
        //_unMeshList.Clear();

        //StreamWriter sw = FileUtil.GetTempFile();
        //Umeng.JSONObject rootJson = new Umeng.JSONObject();

        //List<ParticleSystem> psGo = GetParticleSystemAllGO();
        //foreach (ParticleSystem item in psGo)
        //{
        //    string psPath = FileUtil.GetGameObjectPath(item.gameObject);
        //    Umeng.JSONObject jo = new Umeng.JSONObject();
        //    ParticleSystemRenderer pr = item.gameObject.GetComponent<Renderer>() as ParticleSystemRenderer;
        //    if(pr != null)
        //    {
        //        Mesh mesh = _SetParticleSystemMeshObject(pr);
        //        string meshPath = AssetDatabase.GetAssetPath(mesh);
        //        Debug.Log("meshPath:   " + meshPath);
        //        jo.Add("mesh", meshPath);
        //        Umeng.JSONObject ja = new Umeng.JSONObject();
        //        _SetParticleSystemMaterialObject(pr, ref ja);
        //        jo.Add("materials", ja);
        //    }
        //    rootJson.Add(psPath,jo);
        //}
        //sw.Write(rootJson.ToString());
        //sw.Close();
        //Application.OpenURL(FileUtil.GetTempFilePath());

        //Debug.Log("粒子:" + _particleCount);
        //Debug.Log("网格渲染粒子种类:" + _meshDict.Count);
        //Debug.Log("网格渲染粒子无网格种类:" + _unMeshList.Count);
        //Debug.Log("材质粒子种类:" + _materialDict.Count);
        //Debug.Log("轨迹材质粒子种类:" + _trailMaterialDict.Count);
    }

    public static void DestroyActiveSceneUnActiveParticle()
    {
        List<GameObject> unList = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        int count = 0;
        int length = list.Count;
        for (int i = 0; i < length; i++)
        {
            GameObject go = list[i];
            if (go && !go.activeInHierarchy && go.GetComponent<ParticleSystem>() != null)
            {
                DestroyImmediate(go);
                unList.Add(go);
                count++;
            }
        }
        Selection.objects = unList.ToArray();
        Debug.Log("删除未激活的粒子数量:" + count);
    }

    public static void DestroyActiveSceneParticle()
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        int count = 0;
        int length = list.Count;
        for (int i = 0; i < length; i++)
        {
            GameObject go = list[i];
            if (go && go.GetComponent<ParticleSystem>() != null)
            {
                DestroyImmediate(go);
                count++;
            }
        }
        Debug.Log("删除粒子数量:" + count);
    }

    public static List<ParticleSystem> GetParticleSystemAllGO()
    {
        _particleCount = 0;
        List<ParticleSystem> psGo = new List<ParticleSystem>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in list)
        {
            if (item.GetComponent<ParticleSystem>())
            {
                psGo.Add(item.GetComponent<ParticleSystem>());
            }
        }
        _particleCount = psGo.Count;
        Debug.Log("粒子数量: " + _particleCount);
        return psGo;
    }

    private static void _SetParticleSystemMaterialObject(ParticleSystemRenderer prs)
    {
        string mainNam = "";
        string path = "";
        Debug.Log(prs.materials + "=====  " + prs.materials.Length);//没有材质，自动加上
        //if (prs.material.name.Contains("Default-Material"))
        //{
        //    _unMaterialList.Add(prs.gameObject);
        //}
        //else
        {
            if (prs.material != null)
            {
                if (prs.material.name.Contains("Default-Material"))
                {
                    path = "defaultMaterial";
                    if (!_materialDict.ContainsKey(path))
                    {
                        _materialDict.Add(path, new List<GameObject>());
                    }
                    _materialDict[path].Add(prs.gameObject);
                }
                else
                {
                    mainNam = prs.material.name;
                    mainNam = mainNam.Replace("(Instance)", "").TrimEnd();
                    path = mainNam;
                    if (!_materialDict.ContainsKey(path))
                    {
                        _materialDict.Add(path, new List<GameObject>());
                    }
                    _materialDict[path].Add(prs.gameObject);
                }
                
            }
            //if (prs.trailMaterial != null && !prs.trailMaterial.name.Contains("Default-Material"))
            //{
            //    string trailNam = prs.trailMaterial.name;
            //    trailNam = trailNam.Replace("(Instance)", "").TrimEnd();
            //    if (trailNam != mainNam)
            //    {
            //        path = trailNam;
            //        if (!_materialDict.ContainsKey(path))
            //        {
            //            _materialDict.Add(path, new List<GameObject>());
            //        }
            //        _materialDict[path].Add(prs.gameObject);
            //    }
            //}
        }
    }

    private static void _SetParticleSystemMeshObject(ParticleSystemRenderer prs)
    {
        if (prs.renderMode == ParticleSystemRenderMode.Mesh)
        {
            if (prs.meshCount > 0 && prs.mesh != null)
            {
                string path = AssetDatabase.GetAssetPath(prs.mesh);
                if (!_meshDict.ContainsKey(path))
                {
                    _meshDict.Add(path, new List<GameObject>());
                }
                _meshDict[path].Add(prs.gameObject);
            }
            else
            {
                _unMeshList.Add(prs.mesh);
                Debug.LogError("粒子设置了网格渲染，但没有附网格" + FileUtils.GetGameObjectPath(prs.gameObject));
            }
        }
    }




    public static void CheckParticleType()
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
            foreach (GameObject item in particleList)
            {
                if(item != null)
                {
                    ParticleSystemRenderer prs = item.gameObject.GetComponent<Renderer>() as ParticleSystemRenderer;
                    if(prs != null && prs.material != null)
                    {
                        if (prs.material.name.Contains("Default-Material") || prs.trailMaterial.name.Contains("Default-Material"))
                        {

                        }
                    }
                }
            }

        }
    }



}

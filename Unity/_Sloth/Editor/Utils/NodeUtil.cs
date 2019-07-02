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
            string path = FileUtils.GetGameObjectPath(item);
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
                path = FileUtils.GetGameObjectPath(ctf.gameObject);
                if (nameList.Contains(path))
                {
                    _renameIndex++;
                    ctf.gameObject.name = "@" + ctf.gameObject.name + "_" + _renameIndex;
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

    #region 节点类型统计

    public static void StatisticalNodeType()
    {
        GameObject root = Selection.activeGameObject;
        if (root != null)
        {
            Dictionary<string, List<GameObject>> dict = new Dictionary<string, List<GameObject>>();
            BaseElement[] elements = root.GetComponentsInChildren<BaseElement>();
            if(elements != null)
            {
                string key = "";
                foreach (BaseElement item in elements)
                {
                    key = item.GetType().ToString();
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, new List<GameObject>());
                    }
                    dict[key].Add(item.gameObject);
                }

                List<string> key_list = new List<string>();
                foreach (KeyValuePair<string, List<GameObject>> item in dict)
                {
                    string k = item.Key;
                    int v = item.Value.Count;
                    key_list.Add(k + "$" + v);
                }

                _BubbleSortStatisticalNodeList(key_list);

                StreamWriter sw = FileUtils.GetTempFile();
                Umeng.JSONObject jo = new Umeng.JSONObject();
                jo.Add("typeCount", dict.Count);

                int length = key_list.Count;
                for (int i = 0; i < length; i++)
                {
                    string[] kvs = key_list[i].Split('$');
                    string ke = kvs[0];
                    int iv = int.Parse(kvs[1]);
                    
                    Umeng.JSONObject cjo = new Umeng.JSONObject();
                    jo.Add(ke, cjo);
                    cjo.Add("count", iv);
                    int childNum = 0;
                    foreach (GameObject go in dict[ke])
                    {
                        Transform[] tfs = go.GetComponentsInChildren<Transform>();
                        childNum = Mathf.Max(tfs.Length, childNum);
                        cjo.Add(FileUtils.GetGameObjectPath(go), tfs.Length);
                    }
                }
                //foreach (KeyValuePair<string, List<GameObject>> item in dict)
                //{
                //    Umeng.JSONObject cjo = new Umeng.JSONObject();
                //    jo.Add(item.Key, cjo);
                //    cjo.Add("count", item.Value.Count);
                //    int childNum = 0;
                //    foreach (GameObject go in item.Value)
                //    {
                //        Transform[] tfs = go.GetComponentsInChildren<Transform>();
                //        childNum = Mathf.Max(tfs.Length, childNum);
                //        cjo.Add(FileUtils.GetGameObjectPath(go), tfs.Length);
                //    }
                //}
                sw.Write(jo.ToString());
                sw.Close();
                Application.OpenURL(FileUtils.GetTempFilePath());

            }
            Debug.Log("节点总量：" + dict.Count);
        }
    }

    private static void _BubbleSortStatisticalNodeList(List<string> list)
    {
        int length = list.Count;
        for (int i = 0; i < length-1; i++)
        {
            for (int j = 0; j < length -1- i; j++)
            {
                int a = int.Parse(list[j].Split('$')[1]);
                int b = int.Parse(list[j+1].Split('$')[1]);
                if(b > a)
                {
                    string temp = list[j + 1];
                    list[j + 1] = list[j];
                    list[j] = temp;
                }
            }
        }
    }

    public static void CheckSelectNodesCount()
    {
        Transform[] tfs = Selection.transforms;
        Debug.Log("obj count: " + tfs.Length);
    }

    #endregion

    #region 移节点
    public static void ChangeNodeParent()
    {
        GameObject[] gos = Selection.gameObjects;
        Transform parent = null;
        GameObject newParent2 = null;
        GameObject newParent3 = null;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            parent = tf.parent;
            newParent2 = GameObject.Find(parent.name + "_2");
            newParent3 = GameObject.Find(parent.name + "_3");

            float posZ = tf.position.z;

            if (newParent3 != null && posZ >= newParent3.transform.position.z)
            {
                tf.SetParent(newParent3.transform, true);
                Debug.Log(go.name + " ->移动到-> " + newParent3.name);
            }
            else if(newParent2 != null && posZ >= newParent2.transform.position.z)
            {
                tf.SetParent(newParent2.transform, true);
                Debug.Log(go.name + " ->移动到-> " + newParent2.name);
            }
        }
    }

    public static void WriteNewGridGroudChild(int level)
    {
        string url = FileUtils.GetNewGridGroupPathAsset(level.ToString());
        TextAsset txt = AssetDatabase.LoadAssetAtPath<TextAsset>(url);
        if (txt == null)
        {
            Debug.LogError("找不到文件" + url);
            return;
        }
        Umeng.JSONObject jo = Umeng.JSONObject.Parse(txt.text) as Umeng.JSONObject;
        if (jo == null)
        {
            Debug.LogError("转JSON错误：" + url);
            return;
        }
        Umeng.JSONArray grids = jo["grids"] as Umeng.JSONArray;
        if (grids == null)
        {
            Debug.LogError("JSON数据错误 grids：" + url);
            return;
        }

        GameObject root = GameObject.Find("GridGroup");
        if (root == null)
        {
            return;
        }
        _GridChilds.Clear();
        int length = grids.Count;
        List<string> keys = new List<string>();

        for (int i = length-1; i >= 0; i--)
        {
            Umeng.JSONObject gd = grids[i] as Umeng.JSONObject;
            if (gd == null)
            {
                Debug.LogError("没找到grid ");
                continue;
            }
            string gnam = "Grid_" + (i + 1);

            GameObject ggo = GameObject.Find("GridGroup/" + gnam);
            User.TileMap.Grid grid = ggo.GetComponent<User.TileMap.Grid>();
            grid.m_id = int.Parse(gd["m_id"]);
            grid.m_x = int.Parse(gd["m_x"]);
            grid.m_y = int.Parse(gd["m_y"]);
            grid.m_samplingInterval = int.Parse(gd["m_samplingInterval"]);
            grid.m_samplingCenterY = int.Parse(gd["m_samplingCenterY"]);
            grid.m_isFrist = bool.Parse(gd["m_isFrist"]);
            ggo.transform.localPosition = new Vector3(float.Parse(gd["pos_x"]), float.Parse(gd["pos_y"]), float.Parse(gd["pos_z"]));

            keys.Add(gnam);
            if (!_GridChilds.ContainsKey(gnam))
            {
                _GridChilds.Add(gnam, new List<Transform>());
            }
        }
        if (keys != null)
        {
            Umeng.JSONObject childs = jo["childs"] as Umeng.JSONObject;
            foreach (string key in keys)
            {
                Umeng.JSONArray cja = childs[key] as Umeng.JSONArray;
                int count = cja.Count;

                for (int j = 0; j < count; j++)
                {
                    Umeng.JSONObject cd = cja[j] as Umeng.JSONObject;
                    string tfName = cd["name"];
                    string grid_name = cd["grid_name"];
                    int grid_id = int.Parse(cd["grid_id"]);
                    int point_x = int.Parse(cd["point_x"]);
                    int point_y = int.Parse(cd["point_y"]);

                    float pos_x = float.Parse(cd["pos_x"]);
                    float pos_y = float.Parse(cd["pos_y"]);
                    float pos_z = float.Parse(cd["pos_z"]);

                    Transform oldGrid = null;
                    if (grid_name == "Grid_1" || grid_name == "Grid_2")
                    {
                        oldGrid = root.transform.Find("Grid_1");
                    }
                    else if (grid_name == "Grid_3" || grid_name == "Grid_4")
                    {
                        oldGrid = root.transform.Find("Grid_2");
                    }
                    else if (grid_name == "Grid_5" || grid_name == "Grid_6")
                    {
                        oldGrid = root.transform.Find("Grid_3");
                    }
                    else if (grid_name == "Grid_7" || grid_name == "Grid_8")
                    {
                        oldGrid = root.transform.Find("Grid_4");
                    }
                    else if (grid_name == "Grid_9" || grid_name == "Grid_10")
                    {
                        oldGrid = root.transform.Find("Grid_5");
                    }
                    else if (grid_name == "Grid_11")
                    {
                        oldGrid = root.transform.Find("Grid_6");
                    }
                    else if (grid_name == "Grid_12" || grid_name == "Grid_13")
                    {
                        oldGrid = root.transform.Find("Grid_7");
                    }
                    else if (grid_name == "Grid_14" || grid_name == "Grid_15" || grid_name == "Grid_16")
                    {
                        oldGrid = root.transform.Find("Grid_8");
                    }

                    if (oldGrid != null)
                    {
                        Transform parent = root.transform.Find(grid_name);
                        int len = oldGrid.childCount;
                        for (int i = 0; i < len; i++)
                        {
                            Transform tf = oldGrid.GetChild(i);
                            if (tf.name == tfName)
                            {
                                BaseElement be = tf.transform.GetComponent<BaseElement>();
                                if (be != null)
                                {
                                    be.m_gridId = grid_id;
                                    be.point.m_x = Mathf.FloorToInt(pos_x);
                                    be.point.m_y = Mathf.FloorToInt(pos_z);
                                }
                                tf.transform.SetParent(parent, false);
                                tf.transform.localPosition = new Vector3(pos_x, pos_y, pos_z);
                                break;
                            }
                        }
                    }
                }
            }
        }

        //for (int i = 0; i < length; i++)
        //{
        //    Umeng.JSONObject gd = grids[i] as Umeng.JSONObject;
        //    if (gd == null)
        //    {
        //        Debug.LogError("没找到grid ");
        //        continue;
        //    }
        //    string gnam = "Grid_" + (i + 1);

        //    GameObject ggo = GameObject.Find("GridGroup/" + gnam);
        //    User.TileMap.Grid grid = ggo.GetComponent<User.TileMap.Grid>();
        //    grid.m_id = int.Parse(gd["m_id"]);
        //    grid.m_x = int.Parse(gd["m_x"]);
        //    grid.m_y = int.Parse(gd["m_y"]);
        //    grid.m_samplingInterval = int.Parse(gd["m_samplingInterval"]);
        //    grid.m_samplingCenterY = int.Parse(gd["m_samplingCenterY"]);
        //    grid.m_isFrist = bool.Parse(gd["m_isFrist"]);
        //    ggo.transform.position = new Vector3(float.Parse(gd["pos_x"]), float.Parse(gd["pos_y"]), float.Parse(gd["pos_z"]));
        //}

    }

    public static void WriteNewGridGroud(int level)
    {
        string url = FileUtils.GetNewGridGroupPathAsset(level.ToString());
        TextAsset txt = AssetDatabase.LoadAssetAtPath<TextAsset>(url);
        if (txt == null)
        {
            Debug.LogError("找不到文件" + url);
            return;
        }
        Umeng.JSONObject jo = Umeng.JSONObject.Parse(txt.text) as Umeng.JSONObject;
        if (jo == null)
        {
            Debug.LogError("转JSON错误：" + url);
            return;
        }
        Umeng.JSONArray grids = jo["grids"] as Umeng.JSONArray;
        if (grids == null)
        {
            Debug.LogError("JSON数据错误 grids：" + url);
            return;
        }
        
        GameObject root = GameObject.Find("GridGroup");
        if(root == null)
        {
            return;
        }
        _GridChilds.Clear();
        int length = grids.Count;
        List<string> keys = new List<string>();
        for (int i = 0; i < length; i++)
        {
            Umeng.JSONObject gd = grids[i] as Umeng.JSONObject;
            if (gd == null)
            {
                Debug.LogError("没找到grid ");
                continue;
            }
            string gnam = "Grid_" + (i + 1);
            
            GameObject ggo = GameObject.Find("GridGroup/" + gnam);
            if (ggo == null)
            {
                ggo = new GameObject(gnam);
                ggo.AddComponent<User.TileMap.Grid>();
                ggo.transform.SetParent(root.transform, false);
            }
            
            //User.TileMap.Grid grid = ggo.GetComponent<User.TileMap.Grid>();
            //grid.m_id = int.Parse(gd["m_id"]);
            //grid.m_x = int.Parse(gd["m_x"]);
            //grid.m_y = int.Parse(gd["m_y"]);
            //grid.m_samplingInterval = int.Parse(gd["m_samplingInterval"]);
            //grid.m_samplingCenterY = int.Parse(gd["m_samplingCenterY"]);
            //grid.m_isFrist = bool.Parse(gd["m_isFrist"]);
            //ggo.transform.position = new Vector3(float.Parse(gd["pos_x"]), float.Parse(gd["pos_y"]), float.Parse(gd["pos_z"]));

            keys.Add(gnam);
            if (!_GridChilds.ContainsKey(gnam))
            {
                _GridChilds.Add(gnam, new List<Transform>());
            }
        }
        AssetDatabase.Refresh();
        
    }


    private static User.TileMap.Grid[] _GridList = null;

    private static Dictionary<string, List<Transform>> _GridChilds = new Dictionary<string, List<Transform>>();
    public static void ExportNewGridNodes(int level)
    {
        _GridList = null;
        _GridChilds.Clear();
        _InitGridGroupList(GameObject.Find("GridGroup"));
        _InitGridGroupJson(level.ToString());
    }
    private static void _InitGridGroupJson(string level)
    {
        if(_GridList != null && _GridChilds != null)
        {
            StreamWriter sw = FileUtils.GetNewGridGroupFile(level);
            Umeng.JSONObject rootJson = new Umeng.JSONObject();

            Umeng.JSONArray gridArr = new Umeng.JSONArray();
            rootJson.Add("grids", gridArr);
            foreach (User.TileMap.Grid item in _GridList)
            {
                Umeng.JSONObject gridObj = new Umeng.JSONObject();
                gridObj.Add("m_id", item.m_id);
                gridObj.Add("m_x", item.m_x);
                gridObj.Add("m_y", item.m_y);
                gridObj.Add("m_samplingInterval", item.m_samplingInterval);
                gridObj.Add("m_samplingCenterY", item.m_samplingCenterY);
                gridObj.Add("m_isFrist", item.m_isFrist);
                gridObj.Add("pos_x", item.transform.position.x);
                gridObj.Add("pos_y", item.transform.position.y);
                gridObj.Add("pos_z", item.transform.position.z);
                gridArr.Add(gridObj);
            }
            Umeng.JSONObject childs = new Umeng.JSONObject();
            rootJson.Add("childs", childs);
            foreach (KeyValuePair<string, List<Transform>> item in _GridChilds)
            {
                string key = item.Key;
                List<Transform> list = item.Value;
                Umeng.JSONArray gridChilds = new Umeng.JSONArray();
                childs.Add(key, gridChilds);

                foreach (Transform ctf in list)
                {
                    Umeng.JSONObject cdata = new Umeng.JSONObject();
                    gridChilds.Add(cdata);
                    BaseElement be = ctf.GetComponent<BaseElement>();
                    if(be == null)
                    {
                        Debug.LogError(ctf.name + "找不到脚本");
                        continue;
                    }
                    cdata.Add("name", ctf.name);
                    cdata.Add("grid_name", key);
                    cdata.Add("grid_id", be.m_gridId);
                    cdata.Add("point_x", be.point.m_x);
                    cdata.Add("point_y", be.point.m_y);
                    cdata.Add("pos_x", ctf.localPosition.x);
                    cdata.Add("pos_y", ctf.localPosition.y);
                    cdata.Add("pos_z", ctf.localPosition.z);
                }
            }

            sw.Write(rootJson.ToString());
            sw.Close();
            Application.OpenURL(FileUtils.GetNewGridGroupPath(level));
        }
    }
    private static void _InitGridGroupList(GameObject gridGroup)
    {
        if (gridGroup != null)
        {
            _GridList = gridGroup.GetComponentsInChildren<User.TileMap.Grid>();
            if (_GridList != null)
            {
                foreach (User.TileMap.Grid item in _GridList)
                {
                    Transform tf = item.transform;
                    string tfName = tf.name;
                    if (!_GridChilds.ContainsKey(tfName))
                    {
                        _GridChilds.Add(tfName, new List<Transform>());
                    }
                    List<Transform> list = _GridChilds[tfName];

                    int length = tf.childCount;
                    for (int i = 0; i < length; i++)
                    {
                        list.Add(tf.GetChild(i));
                    }
                }
            }
        }
    }

    #endregion

    public static void CheckColliderCenterZ()
    {
        //List<GameObject> allGo = SceneUtil.GetActiveSceneAllGO();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            WideTilePro be = go.GetComponent<WideTilePro>();
            if(be != null)
            {
                BoxCollider bc = go.GetComponent<BoxCollider>();
                if(bc != null)
                {
                    Vector3 center = bc.center;
                    if (center.z != 0)
                    {
                        Vector3 localPos = go.transform.localPosition;
                        localPos.z += center.z;
                        go.transform.localPosition = localPos;

                        be.point.m_x = Mathf.FloorToInt(localPos.x);
                        be.point.m_y = Mathf.FloorToInt(localPos.z);

                        center.z = 0;
                        bc.center = center;
                    }
                }
            }
        }
    }

    private static void DoDelAnimator(Transform node)
    {
        Animator anim = node.GetComponent<Animator>();
        if (anim != null)
        {
            GameObject.DestroyImmediate(anim);
        }
        for (int i = 0; i < node.childCount; i++)
        {
            Transform child = node.GetChild(i);
            DoDelAnimator(child);
        }
    }
    public static void Del_All_Animator()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            DoDelAnimator(tf);
        }
    }

    public static List<GameObject> models = new List<GameObject>();
    public static void UnDel_All_Animator()
    {
        Transform[] tfs = Selection.transforms;
        foreach (Transform t in tfs)
        {
            if(t.childCount != 1)
            {
                return;
            }
            Transform ctf = t.Find("model");
            if(ctf == null)
            {
                return;
            }
            Animator cator = ctf.GetComponent<Animator>();
            Animation caion = ctf.GetComponent<Animation>();
            if(cator == null && caion != null)
            {
                //cator = ctf.gameObject.AddComponent<Animator>();
                models.Add(ctf.gameObject);
                Debug.Log("====>" + t.name);
            }
        }
        Selection.objects = models.ToArray();
    }


}

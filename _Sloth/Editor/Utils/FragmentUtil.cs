using RS2;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public struct FragmentData
{
    public float StartPos;
    public float EndPos;
    public User.TileMap.Grid Grid;
    public List<GameObject> ChildList;

    public FragmentData(float spos, float epos, User.TileMap.Grid grid)
    {
        StartPos = spos;
        EndPos = epos;
        Grid = grid;
        ChildList = new List<GameObject>();
    }
}
/// <summary>
/// 分段隐藏玩法 ：
/// 1：查找场景中的脚本 Grid 按此分段。
/// 2：美术标记剩余的显示对象打上脚本 SlothFragmentMono。
/// 3：如果节点下有多个显示对象，并且分布横跨多个分段，需要为每个单独节点添加SlothFragmentMono，父节点不添加SlothFragmentMono，直到一个显示对象只在一个分段上。
/// 4：如果这个显示对象很大，横跨多个分段。单独为他打上SlothFragmentMono脚本。
/// </summary>
public class FragmentUtil {

    private static Dictionary<int, FragmentData> _fdDict = new Dictionary<int, FragmentData>();
    
    public static void ExportFragmentToJson()
    {
        _FindGridToDict();
        _FindAllFragmentScriptToChilds();
        _ToJSON();
    }

    public static void AutoBindFragmentScript()
    {
        _BindScriptToGridObjChilden();
    }

    public static void CalculationObjectFragmentIndexs()
    {
        _CalculationObjectFragmentIndexs();
    }

    public static void UnBindSlothFragmentMonoscript()
    {
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        SlothFragmentMono[] monos = null;
        int count = 0;
        foreach (GameObject item in list)
        {
            monos = item.GetComponents<SlothFragmentMono>();
            if (monos != null)
            {
                foreach (SlothFragmentMono stm in monos)
                {
                    GameObject.DestroyImmediate(stm);
                    count++;
                }
            }
        }
        Debug.Log("移除绑在对象身上的 SlothFragmentMono 脚本数量: " + count);
    }

    public static void ReductionSlothScript()
    {
        _ReductionSlothScript();
    }

    #region 导出分段隐藏JSON
    private static void _FindGridToDict()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in gos)
        {
            if (item.activeInHierarchy && item.GetComponent<User.TileMap.Grid>())
            {

                User.TileMap.Grid grid = item.GetComponent<User.TileMap.Grid>();
                if (grid)
                {
                    if (!_fdDict.ContainsKey(grid.m_id))
                    {
                        float sz = item.transform.position.z;
                        float ez = sz + grid.m_x;
                        _fdDict.Add(grid.m_id, new FragmentData(sz, ez, grid));
                    }
                }
            }
        }
    }

    private static void _FindAllFragmentScriptToChilds()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        SlothFragmentMono tag = null;
        foreach (GameObject item in gos)
        {
            if (item.activeInHierarchy)
            {
                tag = item.GetComponent<SlothFragmentMono>();
                if (tag != null)
                {
                    foreach (int idx in tag.FragmentIndexs)
                    {
                        if (_fdDict.ContainsKey(idx))
                        {
                            _fdDict[idx].ChildList.Add(item);
                        }
                    }
                }
            }
        }
    }

    private static void _ToJSON()
    {
        StreamWriter sw = FileUtil.GetFragmentFile();
        Umeng.JSONArray rootJson = new Umeng.JSONArray();
        int cnum = 0;
        int length = _fdDict.Count;
        for (int i = 0; i < length; i++)
        {
            if (_fdDict.ContainsKey(i))
            {
                FragmentData fd = _fdDict[i];
                Umeng.JSONObject cjo = new Umeng.JSONObject();
                cjo.Add("startPos", fd.StartPos);
                cjo.Add("endPos", fd.EndPos);

                List<GameObject> list = fd.ChildList;
                Umeng.JSONArray childList = new Umeng.JSONArray();
                foreach (GameObject go in list)
                {
                    childList.Add(FileUtil.GetGameObjectPath(go));
                }
                cjo.Add("childs", childList);
                cnum += childList.Count;
                rootJson.Add(cjo);
            }
        }
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtil.GetFragmentFilePath());
        Debug.Log("分段导出完毕 导出数量:" + cnum);
    }
    #endregion

    #region 为对象绑定脚本
    private static void _BindScriptToGridObjChilden()
    {
        int count = 0;
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in gos)
        {
            if (item.GetComponent<User.TileMap.Grid>() != null)
            {
                User.TileMap.Grid grid = item.GetComponent<User.TileMap.Grid>();
                int length = item.transform.childCount;
                Transform ctf = null;
                for (int i = 0; i < length; i++)
                {
                    ctf = item.transform.GetChild(i);
                    //排除Grid下，挂有 PathToMoveEffect 脚本的对象
                    if (ctf.GetComponent<SlothFragmentMono>() == null
                        && ctf.GetComponent<PathToMoveEffect>() == null//纸飞机路径
                        && ctf.GetComponent<NormalSkateboardVehicle>() == null)//滑板
                    {
                        SlothFragmentMono tag = ctf.gameObject.AddComponent<SlothFragmentMono>();
                        tag.FragmentIndexs = new int[1] { grid.m_id };
                        count++;
                    }
                }
            }
        }
        Debug.Log("绑脚本 SlothFragmentMono 数量： " + count);
    }
    #endregion

    #region 为绑定脚本的对象，按包围盒计算所在分段
    private static void _CalculationObjectFragmentIndexs()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        SlothFragmentMono tag = null;
        List<User.TileMap.Grid> gridList = new List<User.TileMap.Grid>();
        foreach (GameObject item in gos)
        {
            if (item.activeInHierarchy && item.GetComponent<User.TileMap.Grid>())
            {
                gridList.Add(item.GetComponent<User.TileMap.Grid>());
            }
        }

        foreach (GameObject item in gos)
        {
            tag = item.GetComponent<SlothFragmentMono>();
            if(tag != null)
            {
                List<int> newList = new List<int>();
                foreach (User.TileMap.Grid g in gridList)
                {
                    if (_IsOnGridForIgnoremSamplingInterval(item.transform, g, gridList.Count-1))
                    {
                        if (!newList.Contains(g.m_id))
                        {
                            newList.Add(g.m_id);
                            break;
                        }
                    }
                }
                tag.FragmentIndexs = newList.ToArray<int>();
                _IsOutGridForIgnoremSamplingInterval(item.transform, gridList);
            }
        }
        Debug.Log("计算完毕");
    }
    //位置定位
    private static bool _IsOnGridForIgnoremSamplingInterval(Transform tf, User.TileMap.Grid grid, int length)
    {
        Vector3 _vector = grid.transform.InverseTransformPoint(tf.position);
        if (_vector.z >= 0 && _vector.z <= grid.m_x)//正常体积，位置正常
        {
            return true;
        }
        else if (grid.m_isFrist && _vector.z < 0)//初始位置为负值
        {
            return true;
        }
        else if (grid.m_id == length && _vector.z > grid.m_x)//初始位置超过最大段
        {
            return true;
        }
        return false;
    }
    //对体积异常大的二次处理
    private static void _IsOutGridForIgnoremSamplingInterval(Transform tf, List<User.TileMap.Grid> gridList)
    {
        if (tf == null)
        {
            return;
        }
        SlothFragmentMono frag = tf.GetComponent<SlothFragmentMono>();
        if (frag == null)
        {
            return;
        }
        List<int> newList = frag.FragmentIndexs.ToList();
        if (newList.Count > 0)
        {
            float size = BoundUtil.GetBounds(tf.gameObject).size.z;
            int start = newList[0];
            User.TileMap.Grid grid = gridList[start];
            float gridSize = grid.m_x;
            Vector3 _vector = grid.transform.InverseTransformPoint(tf.position);
            if (tf.position.z < _vector.z)//针对显示对象离坐标很远的情况
            {
                //TODO
            }
            int length = gridList.Count;
            for (int i = start; i < length; i++)
            {
                if (size > gridSize)
                {
                    int nextIddx = Mathf.Min(i + 1, length - 1);
                    if (!newList.Contains(nextIddx))
                    {
                        newList.Add(nextIddx);
                    }
                    size += _vector.z;
                    gridSize = gridList[nextIddx].transform.position.z + gridList[nextIddx].m_x;
                }
                else
                {
                    break;
                }
            }
            frag.FragmentIndexs = newList.ToArray();
        }
    }
    #endregion

    #region 根据已有的JSON还原脚本到对象
    private static void _ReductionSlothScript()
    {
        TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>(FileUtil.GetFragmentFilePathAsset());
        if (ta == null)
        {
            Debug.Log("读取文件信息失败");
            return;
        }
        Umeng.JSONArray ja = Umeng.JSONArray.Parse(ta.text) as Umeng.JSONArray;
        if (ja == null)
        {
            Debug.Log("没有分段标记列表");
            return;
        }
        Dictionary<string, GameObject> allDict = SceneUtil.GetActiveSceneAllGODict();

        int length = ja.Count;
        Umeng.JSONObject jo = null;
        List<int> idxList = null;
        int cnum = 0;
        for (int i = 0; i < length; i++)
        {
            jo = ja[i] as Umeng.JSONObject;
            Umeng.JSONArray childs = jo["childs"].AsArray;
            if (childs != null)
            {
                int clength = childs.Count;
                string gname = "";
                for (int k = 0; k < clength; k++)
                {
                    gname = childs[k];
                    if (string.IsNullOrEmpty(gname))
                    {
                        continue;
                    }
                    if (allDict.ContainsKey(gname))
                    {
                        SlothFragmentMono tag = allDict[gname].GetComponent<SlothFragmentMono>();
                        if (tag == null)
                        {
                            if (!allDict[gname].GetComponent<User.TileMap.Grid>())
                            {
                                tag = allDict[gname].AddComponent<SlothFragmentMono>();
                            }
                        }
                        if (tag != null)
                        {
                            if (tag.FragmentIndexs == null || tag.FragmentIndexs.Length == 0)
                            {
                                tag.FragmentIndexs = new int[] { i };
                            }
                            else
                            {
                                idxList = tag.FragmentIndexs.ToList();
                                if (!idxList.Contains(i))
                                {
                                    idxList.Add(i);
                                }
                                tag.FragmentIndexs = idxList.ToArray();
                            }
                            cnum++;
                        }
                    }
                    else
                    {
                        Debug.LogError("找不到对象:" + gname);
                    }
                }
            }
        }
        Debug.Log("分段标记完毕 标记数量:" + cnum);
    }
    #endregion


    
}

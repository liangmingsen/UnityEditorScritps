using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public struct FragmentData
{
    public float StartPos;
    public float EndPos;
    public User.TileMap.Grid Grid;
    public List<GameObject> ChildList;
    public List<GameObject> PartChilds;
    public List<GameObject> AnimChilds;

    public FragmentData(float spos, float epos, User.TileMap.Grid grid)
    {
        StartPos = spos;
        EndPos = epos;
        Grid = grid;
        ChildList = new List<GameObject>();
        PartChilds = new List<GameObject>();
        AnimChilds = new List<GameObject>();
    }

}
public class FragmentUtil {

    private static Dictionary<int, FragmentData> _fdDict = new Dictionary<int, FragmentData>();
    public static void ExportFragmentData()
    {
        _FindAllGrid();
        _FindAllOnGridObject();
        foreach (KeyValuePair<int, FragmentData> d in _fdDict)
        {
            _FindParticle(d.Value);
            _FindAnimator(d.Value);
        }
        _ToJSON();
    }

    private static void _FindAllGrid()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        foreach (GameObject item in gos)
        {
            if(item.activeInHierarchy && item.GetComponent<User.TileMap.Grid>())
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
                    FragmentData fd = _fdDict[grid.m_id];
                    fd.ChildList.Add(fd.Grid.gameObject);
                }
            }
        }
    }

    private static void _FindAllOnGridObject()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        SlothTagMono tag = null;
        User.TileMap.Grid grid = null;
        foreach (GameObject item in gos)
        {
            if (item.activeInHierarchy)
            {
                tag = item.GetComponent<SlothTagMono>();
                if(tag != null)
                {
                    List<int> newList = new List<int>();
                    foreach (KeyValuePair<int, FragmentData> d in _fdDict)
                    {
                        grid = d.Value.Grid;
                        if (_IsOnGridForIgnoremSamplingInterval(item.transform, d.Value))
                        {
                            d.Value.ChildList.Add(item);
                            int[] fragments = tag.FragmentIndexs;
                            newList.Add(grid.m_id);
                        }
                    }
                    tag.FragmentIndexs = newList.ToArray<int>();
                }
            }
        }
    }
    private static bool _IsOnGridForIgnoremSamplingInterval(Transform tf, FragmentData fd)
    {
        Vector3 _vector = fd.Grid.transform.InverseTransformPoint(tf.position);
        float size = BoundUtil.GetBounds(tf.gameObject).size.z;

        float val = size + _vector.z;
        if(size >= fd.Grid.m_x)//超大型物体
        {
            if(size+_vector.z > 0)
            {
                return true;
            }
        }
        else if (_vector.z >= 0 && _vector.z <= fd.Grid.m_x)//正常体积，位置正常
        {
            return true;
        }
        else if(fd.Grid.m_isFrist && _vector.z < 0)//初始位置为负值
        {
            return true;
        }
        else if (fd.Grid.m_id == _fdDict.Count-1 && _vector.z > fd.Grid.m_x)//初始位置超过最大段
        {
            return true;
        }
        return false;
    }
    private static void _FindParticle(FragmentData fd)
    {
        List<GameObject> gos = fd.ChildList;
        foreach (GameObject item in gos)
        {
            ParticleSystem[] pss = item.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem ani in pss)
            {
                if (!fd.PartChilds.Contains(ani.gameObject))
                {
                    fd.PartChilds.Add(ani.gameObject);
                }
            }
        }
    }

    private static void _FindAnimator(FragmentData fd)
    {
        List<GameObject> gos = fd.ChildList;
        foreach (GameObject item in gos)
        {
            Animator[] pss = item.GetComponentsInChildren<Animator>();
            RuntimeAnimatorController ranim = null;
            foreach (Animator ani in pss)
            {
                ranim = ani.runtimeAnimatorController;
                if (ranim != null && ranim.animationClips != null && ranim.animationClips.Length > 0)
                {
                    if (!fd.AnimChilds.Contains(ani.gameObject))
                    {
                        fd.AnimChilds.Add(ani.gameObject);
                    }   
                }
            }
        }
    }
    private static void _ToJSON()
    {
        StreamWriter sw = FileUtil.GetFragmentFile();
        Umeng.JSONArray rootJson = new Umeng.JSONArray();

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

                list = fd.PartChilds;
                childList = new Umeng.JSONArray();
                foreach (GameObject go in list)
                {
                    childList.Add(FileUtil.GetGameObjectPath(go));
                }
                cjo.Add("partChilds", childList);

                list = fd.AnimChilds;
                childList = new Umeng.JSONArray();
                foreach (GameObject go in list)
                {
                    childList.Add(FileUtil.GetGameObjectPath(go));
                }
                cjo.Add("animChilds", childList);
                rootJson.Add(cjo);
            }
        }
        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtil.GetFragmentFilePath());
    }

}

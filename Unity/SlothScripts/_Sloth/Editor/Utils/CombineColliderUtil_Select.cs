using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineColliderUtil_Select : MonoBehaviour {

    #region 将多个选中的BoxCollider合成一个大的。删除旧的小对象。
    protected static string mNewObjName = "new_big_collider_go";

    public static void CombineCollider_Tile_XiaoZhen_Move_Water()
    {
        string[] obj_a = new string[] {
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_3",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_1",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_4",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_18",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_8",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_12",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_10",
            "GridGroup/Grid_1/Tile_XiaoZhen_Move_Water(Clone)",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_19",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_14",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_2",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_16",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_15",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_9",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_17",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_11",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_13",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_7",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_6",
            "GridGroup/Grid_1/@Tile_XiaoZhen_Move_Water(Clone)_5"
        };
        _SelectCombineColliderMoveAllDirTile(obj_a);

        string[] obj_b = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1203",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1205",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1201"
        };
        _SelectCombineColliderMoveAllDirTile(obj_b);

        string[] obj_c = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1252",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1256",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1254"
         };
        _SelectCombineColliderMoveAllDirTile(obj_c);

        string[] obj_d = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1259",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1261"
        };
        _SelectCombineColliderMoveAllDirTile(obj_d);

        string[] obj_e = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1273",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1263",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1268",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1266",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1271"
        };
        _SelectCombineColliderMoveAllDirTile(obj_e);

        string[] obj_f = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1282",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1280",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1278",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1276"
        };
        _SelectCombineColliderMoveAllDirTile(obj_f);

        string[] obj_g = new string[]
        {
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1284",
            "GridGroup/Grid_4/@Tile_XiaoZhen_Move_Water(Clone)_1286"
        };
        _SelectCombineColliderMoveAllDirTile(obj_g);

        string[] obj_h = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1372",
            "GridGroup/Grid_7/Tile_XiaoZhen_Move_Water(Clone)"
        };
        _SelectCombineColliderMoveAllDirTile(obj_h);

        string[] obj_i = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1374",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1376",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1378"
        };
        _SelectCombineColliderMoveAllDirTile(obj_i);

        string[] obj_j = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1380",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1382",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1384"
        };
        _SelectCombineColliderMoveAllDirTile(obj_j);

        string[] obj_k = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1386",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1388",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1390"
        };
        _SelectCombineColliderMoveAllDirTile(obj_k);

        string[] obj_o = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1392",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1394",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1396",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1398"
        };
        _SelectCombineColliderMoveAllDirTile(obj_o);

        string[] obj_p = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1400",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1402",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1404"
        };
        _SelectCombineColliderMoveAllDirTile(obj_p);

        string[] obj_q = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1406",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1408",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1410"
        };
        _SelectCombineColliderMoveAllDirTile(obj_q);

        string[] obj_r = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1412",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1414",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1416"
        };
        _SelectCombineColliderMoveAllDirTile(obj_r);

        string[] obj_1 = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1418",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1420"
        };
        _SelectCombineColliderMoveAllDirTile(obj_1);

        string[] obj_2 = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1422",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1424",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1426",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1428"
        };
        _SelectCombineColliderMoveAllDirTile(obj_2);

        string[] obj_3 = new string[]
        {
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1430",
            "GridGroup/Grid_7/@Tile_XiaoZhen_Move_Water(Clone)_1432"
        };
        _SelectCombineColliderMoveAllDirTile(obj_3);

        string[] obj_4 = new string[]
        {

        };
        _SelectCombineColliderMoveAllDirTile(obj_4);

        string[] obj_5 = new string[]
        {

        };
        _SelectCombineColliderMoveAllDirTile(obj_5);

    }


    private static void _SelectCombineColliderMoveAllDirTile(string[] names) 
    {
        List<Transform> selects = new List<Transform>();
        List<MoveAllDirTile> scripts = new List<MoveAllDirTile>();
        List<BoxCollider> colliders = new List<BoxCollider>();
        foreach (string item in names)
        {
            GameObject go = GameObject.Find(item);
            if(go != null)
            {
                selects.Add(go.transform);
                MoveAllDirTile sc = go.GetComponent<MoveAllDirTile>();
                if(sc != null)
                {
                    scripts.Add(sc);
                }
                BoxCollider[] bcs = go.GetComponentsInChildren<BoxCollider>();
                if(bcs.Length == 1)
                {
                    colliders.Add(bcs[0]);
                }
            }
        }

        if (colliders.Count != selects.Count || scripts.Count != selects.Count || selects.Count == 0)
        {
            Debug.LogError("Collider数量不对 || 脚本数量不对，请检查每个对象");
            return;
        }
        MoveAllDirTile.TileData data = scripts[0].data;
        foreach (MoveAllDirTile item in scripts)
        {
            if (data.MoveDirection != item.data.MoveDirection)
            {
                Debug.LogError("MoveAllDirTile.TileData 数据不同" + item.transform.name);
                return;
            }
            if (data.MoveDistance != item.data.MoveDistance)
            {
                Debug.LogError("MoveAllDirTile.TileData 数据不同" + item.transform.name);
                return;
            }
            if (data.BeginDistance != item.data.BeginDistance)
            {
                Debug.LogError("MoveAllDirTile.TileData 数据不同" + item.transform.name);
                return;
            }
            if (data.SpeedScaler != item.data.SpeedScaler)
            {
                Debug.LogError("MoveAllDirTile.TileData 数据不同" + item.transform.name);
                return;
            }
        }

        Vector3 minPos = selects[0].localPosition;
        Vector3 maxPos = selects[0].localPosition;
        Vector3 minCenter = colliders[0].center;
        Vector3 maxCenter = colliders[0].center;
        Vector3 minSize = colliders[0].size;
        Vector3 maxSize = colliders[0].size;

        int length = selects.Count;
        for (int i = 0; i < length; i++)
        {
            Transform t = selects[i];
            minPos.x = Mathf.Min(t.localPosition.x, minPos.x);
            minPos.y = Mathf.Min(t.localPosition.y, minPos.y);
            minPos.z = Mathf.Min(t.localPosition.z, minPos.z);

            maxPos.x = Mathf.Max(t.localPosition.x, maxPos.x);
            maxPos.y = Mathf.Max(t.localPosition.y, maxPos.y);
            maxPos.z = Mathf.Max(t.localPosition.z, maxPos.z);
        }

        foreach (BoxCollider bc in colliders)
        {
            minCenter.x = Mathf.Min(bc.center.x, minCenter.x);
            minCenter.y = Mathf.Min(bc.center.y, minCenter.y);
            minCenter.z = Mathf.Min(bc.center.z, minCenter.z);

            maxCenter.x = Mathf.Max(bc.center.x, maxCenter.x);
            maxCenter.y = Mathf.Max(bc.center.y, maxCenter.y);
            maxCenter.z = Mathf.Max(bc.center.z, maxCenter.z);

            minSize.x = Mathf.Min(bc.size.x, minSize.x);
            minSize.y = Mathf.Min(bc.size.y, minSize.y);
            minSize.z = Mathf.Min(bc.size.z, minSize.z);

            maxSize.x = Mathf.Min(bc.size.x, maxSize.x);
            maxSize.y = Mathf.Min(bc.size.y, maxSize.y);
            maxSize.z = Mathf.Min(bc.size.z, maxSize.z);

        }
        bool a = minPos.y != maxPos.y;
        bool b = minCenter.x + maxCenter.x != 0;
        bool c = minCenter.z + maxCenter.z != 0;
        bool d = minCenter.y != maxCenter.y;
        bool e = minSize.y != maxSize.y;
        if (a || b || c || d || e)
        {
            Debug.LogError("高低不一致，请检查每个对象");
            return;
        }
        float posx = (minPos.x + maxPos.x) / 2;
        float posy = minPos.y;
        float posz = (minPos.z + maxPos.z) / 2;

        GameObject newGo = new GameObject(mNewObjName);
        newGo.transform.SetParent(selects[0].parent);
        newGo.transform.localPosition = new Vector3(posx, posy, posz);
        BoxCollider newBC = newGo.AddComponent<BoxCollider>();

        float center_x = minCenter.x;
        float center_y = minCenter.y;
        float center_z = minCenter.z;

        float size_x = maxPos.x - minPos.x + 1;
        float size_y = minSize.y;
        float size_z = maxPos.z - minPos.z + 1;

        newBC.center = new Vector3(center_x, center_y, center_z);
        newBC.size = new Vector3(size_x, size_y, size_z);

        UnityEditorInternal.ComponentUtility.CopyComponent(scripts[0]);
        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(newGo.gameObject);

        newGo.name = scripts[0].gameObject.name;
        MoveAllDirTile madt = newGo.GetComponent<MoveAllDirTile>();
        madt.point.m_x = Mathf.FloorToInt(newGo.transform.localPosition.x);
        madt.point.m_y = Mathf.FloorToInt(newGo.transform.localPosition.z);

        selects.Add(newGo.transform);
        Selection.objects = selects.ToArray();
    }
    
    public static void ClearCombineOldColliderMoveAllDirTile()
    {
        Transform[] tfs = Selection.transforms;
        int length = tfs.Length;
        for (int i = length - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(tfs[i].gameObject);
            Debug.Log("合并节点： " + 3);
        }
    }
    #endregion

    #region 多个小 NormalTile 合成一个大 wideTile

    public static void CombineBigCollider<T>(string[] names) where T : BaseElement
    {
        List<Transform> selects = new List<Transform>();
        List<T> scripts = new List<T>();
        List<BoxCollider> colliders = new List<BoxCollider>();
        foreach (string item in names)
        {
            GameObject go = GameObject.Find(item);
            if (go != null)
            {
                selects.Add(go.transform);
                T sc = go.GetComponent<T>();
                if (sc != null)
                {
                    scripts.Add(sc);
                }
                BoxCollider[] bcs = go.GetComponentsInChildren<BoxCollider>();
                if (bcs.Length == 1)
                {
                    colliders.Add(bcs[0]);
                }
            }
        }

        if (colliders.Count != selects.Count || scripts.Count != selects.Count || selects.Count == 0)
        {
            Debug.LogError("Collider数量不对 || 脚本数量不对，请检查每个对象");
            return;
        }

        Vector3 minPos = selects[0].localPosition;
        Vector3 maxPos = selects[0].localPosition;
        Vector3 minCenter = colliders[0].center;
        Vector3 maxCenter = colliders[0].center;
        Vector3 minSize = colliders[0].size;
        Vector3 maxSize = colliders[0].size;

        int length = selects.Count;
        for (int i = 0; i < length; i++)
        {
            Transform t = selects[i];
            minPos.x = Mathf.Min(t.localPosition.x, minPos.x);
            minPos.y = Mathf.Min(t.localPosition.y, minPos.y);
            minPos.z = Mathf.Min(t.localPosition.z, minPos.z);

            maxPos.x = Mathf.Max(t.localPosition.x, maxPos.x);
            maxPos.y = Mathf.Max(t.localPosition.y, maxPos.y);
            maxPos.z = Mathf.Max(t.localPosition.z, maxPos.z);
        }

        int min_size_x = scripts[0].point.m_x;
        int max_size_x = scripts[0].point.m_x;
        int min_size_z = scripts[0].point.m_y;
        int max_size_z = scripts[0].point.m_y;
        foreach (T t in scripts)
        {
            min_size_x = Mathf.Min(t.point.m_x, min_size_x);
            max_size_x = Mathf.Max(t.point.m_x, min_size_x);

            min_size_z = Mathf.Min(t.point.m_y, min_size_z);
            max_size_z = Mathf.Max(t.point.m_y, min_size_z);
        }
        int size_x = max_size_x - min_size_x + 1;
        int size_z = max_size_z - min_size_z + 1;
        



    }


    #endregion


}

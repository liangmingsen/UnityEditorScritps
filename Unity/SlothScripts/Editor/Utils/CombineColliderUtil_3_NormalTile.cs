using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineColliderUtil_3_NormalTile : CombineColliderUtil
{
    private static int _index = 1000;
    private static List<BaseElement> _elements = new List<BaseElement>();
    private static List<BoxCollider> _colliders = new List<BoxCollider>();
    private static List<Transform> _selectTfs = new List<Transform>();
    private static Vector3 _minPos = Vector3.zero;
    private static Vector3 _maxPos = Vector3.zero;
    private static Vector3 _minCenter = Vector3.zero;
    private static Vector3 _maxCenter = Vector3.zero;
    private static Vector3 _minSize = Vector3.zero;
    private static Vector3 _maxSize = Vector3.zero;


    
    //
    public static void CombineCollider_NormalTile()
    {

    }
    //  EmissionTile   2   WideTilePro
    public static void CombineCollider_EmissionTile()
    {
        Transform[] tfs = Selection.transforms;
        if(tfs == null || tfs.Length == 0)
        {
            return;
        }
        _InitList(tfs);
        if (_CheckLength(tfs) && _CheckTransfrom(tfs))
        {   
            _InitNewObjectData(tfs);

            bool a = _minPos.y != _maxPos.y;
            bool b = _minCenter.y != _maxCenter.y;
            bool c = _minSize.y != _maxSize.y;

            if (a || b || c)
            {
                Debug.LogError("高低不一致，请检查每个对象" + a + b + c);
                return;
            }
            GameObject newGo = _CreateWaltz_Tile_Empty1x1(tfs[0].parent);
            _AddBoxCollider(newGo);
            _AddWideTilePro(newGo);
            _InitWideTileProMissList(newGo);
            _ChangeLocalRotationUnZero(newGo, tfs[0].localRotation.eulerAngles);
            _ChearSelectBoxColliderAndScript();
            _MoveOutGridGroupAndTagStatic();

            Debug.Log("CombineCollider_EmissionTile success");
        }
    }
    private static void _InitList(Transform[] tfs)
    {
        _elements = new List<BaseElement>();
        _colliders = new List<BoxCollider>();
        _selectTfs = new List<Transform>();
    }
    private static bool _CheckLength(Transform[] tfs)
    {
        int gid = tfs[0].GetComponent<BaseElement>().m_gridId;
        foreach (Transform t in tfs)
        {
            _selectTfs.Add(t);
            BaseElement be = t.GetComponent<BaseElement>();
            if (be != null)
            {
                _elements.Add(be);
            }
            BoxCollider[] bc = t.GetComponentsInChildren<BoxCollider>();
            if (bc != null)
            {
                _colliders.AddRange(bc);
            }
            if (gid != be.m_gridId)
            {
                Debug.LogError("不支持，不同Grid下的网格合并。");
                return false;
            }
        }
        if (_colliders.Count != tfs.Length || _elements.Count != tfs.Length || _elements.Count == 0)
        {
            Debug.LogError("Collider数量不对 || 脚本数量不对，请检查每个对象 _colliders: " + _colliders.Count + "  =_scripts= " + tfs.Length + " _selects : " + tfs.Length);
            return false;
        }
        return true;
    }
    private static bool _CheckTransfrom(Transform[] tfs)
    {
        Quaternion rot = tfs[0].localRotation;
        Vector3 scale = tfs[0].localScale;
        foreach (Transform t in tfs)
        {
            if(t.localRotation != rot || t.localScale != scale)
            {
                Debug.LogError("旋转 或 绽放不一致");
                return false;
            }
        }
        return true;
    }
    private static void _InitNewObjectData(Transform[] tfs)
    {
        _minPos = tfs[0].localPosition;
        _maxPos = tfs[0].localPosition;
        _minCenter = _colliders[0].center;
        _maxCenter = _colliders[0].center;
        _minSize = _colliders[0].size;
        _maxSize = _colliders[0].size;

        foreach (Transform t in tfs)
        {
            _minPos.x = Mathf.Min(t.localPosition.x, _minPos.x);
            _minPos.y = Mathf.Min(t.localPosition.y, _minPos.y);
            _minPos.z = Mathf.Min(t.localPosition.z, _minPos.z);

            _maxPos.x = Mathf.Max(t.localPosition.x, _maxPos.x);
            _maxPos.y = Mathf.Max(t.localPosition.y, _maxPos.y);
            _maxPos.z = Mathf.Max(t.localPosition.z, _maxPos.z);
        }

        foreach (BoxCollider bc in _colliders)
        {
            _minCenter.x = Mathf.Min(bc.center.x, _minCenter.x);
            _minCenter.y = Mathf.Min(bc.center.y, _minCenter.y);
            _minCenter.z = Mathf.Min(bc.center.z, _minCenter.z);

            _maxCenter.x = Mathf.Max(bc.center.x, _maxCenter.x);
            _maxCenter.y = Mathf.Max(bc.center.y, _maxCenter.y);
            _maxCenter.z = Mathf.Max(bc.center.z, _maxCenter.z);

            _minSize.x = Mathf.Min(bc.size.x, _minSize.x);
            _minSize.y = Mathf.Min(bc.size.y, _minSize.y);
            _minSize.z = Mathf.Min(bc.size.z, _minSize.z);

            _maxSize.x = Mathf.Min(bc.size.x, _maxSize.x);
            _maxSize.y = Mathf.Min(bc.size.y, _maxSize.y);
            _maxSize.z = Mathf.Min(bc.size.z, _maxSize.z);
        }
    }
    private static GameObject _CreateWaltz_Tile_Empty1x1(Transform parent)
    {
        GameObject newGo = new GameObject("Waltz_Tile_Empty1x1_ET" + _index);
        
        float posx = (_minPos.x + _maxPos.x) *0.5f;
        float posy = _minPos.y;
        float posz = (_minPos.z + _maxPos.z) *0.5f;

        newGo.transform.SetParent(parent);
        newGo.transform.localPosition = new Vector3(posx, posy, posz);
        _index++;

        return newGo;
    }
    private static void _AddBoxCollider(GameObject newGo)
    {
        float center_x = _minCenter.x;
        float center_y = _minCenter.y;
        float center_z = _minCenter.z;

        float size_x = _maxPos.x - _minPos.x + 1;
        float size_y = _minSize.y;
        float size_z = _maxPos.z - _minPos.z + 1;

        BoxCollider newBC = newGo.AddComponent<BoxCollider>();
        newBC.center = new Vector3(center_x, center_y, center_z);
        newBC.size = new Vector3(size_x, size_y, size_z);
        newBC.isTrigger = true;
    }
    private static void _AddWideTilePro(GameObject newGo)
    {
        float width = _maxPos.x - _minPos.x + 1;
        float height = _maxPos.z - _minPos.z + 1;

        WideTilePro wtp = newGo.AddComponent<WideTilePro>();
        wtp.m_id = 708;
        wtp.m_gridId = _elements[0].m_gridId;
        wtp.point.m_x = Mathf.FloorToInt(newGo.transform.localPosition.x);
        wtp.point.m_y = Mathf.FloorToInt(newGo.transform.localPosition.z);
        wtp.data.Width = width;
        wtp.data.Height = height;
        wtp.data.BeginDistance = -(height / 2);
        wtp.data.ResetDistance = (height / 2);
        wtp.data.IfCheckMissTile = true;
        wtp.data.MissTiles = null;
    }
    private static void _InitWideTileProMissList(GameObject newGo)
    {
        WideTilePro wtp = newGo.GetComponent<WideTilePro>();
        List<string> miss = _CheckInBigCollider(newGo.transform, _minPos, _maxPos);
        wtp.data.MissTiles = miss.ToArray();
    }
    private static List<string> _CheckInBigCollider(Transform wideTf, Vector3 minPoint, Vector3 maxPoint)
    {
        List<string> misskeys = new List<string>();
        if (wideTf != null)
        {
            BoxCollider bc = wideTf.GetComponent<BoxCollider>();
            WideTilePro wtp = wideTf.GetComponent<WideTilePro>();
            if (bc != null && wtp != null)
            {
                int min_x = Mathf.FloorToInt(minPoint.x);
                int min_z = Mathf.FloorToInt(minPoint.z);
                int max_x = Mathf.FloorToInt(maxPoint.x);
                int max_z = Mathf.FloorToInt(maxPoint.z);

                for (int i = min_x; i <= max_x; i++)
                {
                    for (int j = min_z; j <= max_z; j++)
                    {
                        bool is_miss = true;
                        string key = (i - min_x) + "," + (j - min_z);
                        foreach (BaseElement item in _elements)
                        {
                            if (item.point.m_x == i && item.point.m_y == j)
                            {
                                is_miss = false;
                                continue;
                            }
                        }
                        if (is_miss)
                        {
                            misskeys.Add(key);
                        }
                    }
                }
            }
        }
        return misskeys;
    }
    private static void _ChangeLocalRotationUnZero(GameObject newGo, Vector3 localRot)
    {
        Transform newTf = newGo.transform;
        BoxCollider bc = _colliders[0];
        if(localRot.x != 0)
        {
            localRot.x = 0;
            BoxCollider newBc = newGo.GetComponent<BoxCollider>();
            newBc.center = new Vector3(bc.center.x, bc.center.z, bc.center.y);
            newBc.size = new Vector3(newBc.size.x, bc.size.z, newBc.size.z);
            newTf.localRotation = Quaternion.Euler(localRot);
        }
    }

    private static void _ChearSelectBoxColliderAndScript()
    {
        int length = _selectTfs.Count;
        for (int i = 0; i < length; i++)
        {
            Transform t = _selectTfs[i];
            BoxCollider bc = t.GetComponentInChildren<BoxCollider>();
            if (bc != null)
            {
                GameObject.DestroyImmediate(bc);
            }
            BaseElement be = t.GetComponent<BaseElement>();
            if (be != null)
            {
                GameObject.DestroyImmediate(be);
            }
        }
    }
    private static void _MoveOutGridGroupAndTagStatic()
    {
        Transform parent = GameObject.Find("Midground").transform;
        if(parent != null)
        {
            int length = _selectTfs.Count;
            for (int i = 0; i < length; i++)
            {
                Transform t = _selectTfs[i];
                t.SetParent(parent, true);
                StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags(t.gameObject);
                flags |= StaticEditorFlags.BatchingStatic;
                GameObjectUtility.SetStaticEditorFlags(t.gameObject, flags);
            }
        }
    }
}

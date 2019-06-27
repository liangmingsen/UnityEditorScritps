using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using User.TileMap;

public class CombineColliderUtil : CombineBase
{

    #region AnimEnemy 改  MoveAllDirTileNew
    private static List<Transform> _parents = null;
    private static List<Transform> _childs = null;
    public static void AnimEnemy2MoveAllDirTileNew()
    {
        Transform[] tfs = Selection.transforms;
        _InitAnimEnemy();
        if (_CheckAnimEnemyLength(tfs) && _CheckAnimEnemyParentAndChilds(tfs))
        {
            _ChangeAnimEnemyScript();
        }
    }
    private static void _InitAnimEnemy()
    {
        _parents = new List<Transform>();
        _childs = new List<Transform>();
    }
    private static bool _CheckAnimEnemyLength(Transform[] tfs)
    {
        List<AnimEnemy> anims = new List<AnimEnemy>();
        foreach (Transform item in tfs)
        {
            AnimEnemy m = item.GetComponent<AnimEnemy>();
            if (m != null)
            {
                anims.Add(m);
            }
        }
        if (anims.Count != tfs.Length)
        {
            Debug.LogError("AnimEnemy 脚本数量不一致 " + anims.Count + " : " + tfs.Length);
            return false;
        }
        return true;
    }
    private static bool _CheckAnimEnemyParentAndChilds(Transform[] tfs)
    {
        foreach (Transform item in tfs)
        {
            int length = item.parent.childCount;
            for (int i = 0; i < length; i++)
            {
                Transform par = item.parent.GetChild(i);
                MoveAllDirTile madt = par.GetComponent<MoveAllDirTile>();
                AnimEnemy anim = item.GetComponent<AnimEnemy>();
                if (madt != null && anim != null)
                {
                    if (madt.point.m_x == anim.point.m_x && madt.point.m_y == anim.point.m_y)
                    {
                        _parents.Add(par);
                        _childs.Add(item);
                        break;
                    }
                }
            }
        }
        return true;
    }
    private static void _ChangeAnimEnemyScript()
    {
        int length = _childs.Count;
        for (int i = 0; i < length; i++)
        {
            Transform t = _childs[i];
            AnimEnemy ae = t.GetComponent<AnimEnemy>();
            MoveAllDirTile madt = _parents[i].GetComponent<MoveAllDirTile>();
            if (ae == null || madt == null)
            {
                Debug.LogError(string.Format("AnimEnemy / MoveAllDirTile 为空 -> {0}", t.name));
                return;
            }
            MoveAllDirTileNew new_madt = t.gameObject.AddComponent<MoveAllDirTileNew>();
            new_madt.m_id = 1401;
            new_madt.m_gridId = ae.m_gridId;
            new_madt.point = ae.point;
            new_madt.data.BeginDistance2 = ae.data.BeginDistance;
            new_madt.data.ResetDistance = ae.data.ResetDistance;
            new_madt.data.BaseBallSpeed = ae.data.BaseBallSpeed;
            new_madt.data.IfAutoPlay = ae.data.IfAutoPlay;
            new_madt.data.IfLoop = ae.data.IfLoop;
            new_madt.data.AudioPlayTime = ae.data.AudioPlayTime;
            new_madt.data.IfHideBegin = ae.data.IfHideBegin;
            new_madt.DebugPercent = ae.DebugPercent;

            new_madt.data.MoveDirection = madt.data.MoveDirection;
            new_madt.data.MoveDistance = madt.data.MoveDistance;
            new_madt.data.BeginDistance = madt.data.BeginDistance;
            new_madt.data.SpeedScaler = madt.data.SpeedScaler;

            GameObject.DestroyImmediate(ae);
        }
        Debug.Log("===>: " + _childs.Count);
    }
    #endregion


    #region 根据Grid 将指定类型的多个小collider 合成一个大的collider 指定新类型为 WideTilePro
    protected static Transform mBigTf = null;
    protected static GameObject mBigGo = null;
    protected static List<GameObject> mCheckBoxs = new List<GameObject>();
    protected static List<GameObject> mHasColliders = new List<GameObject>();
    protected static List<GameObject> mMissBoxs = new List<GameObject>();
    protected static List<GameObject> mUnMissBoxs = new List<GameObject>();
    protected static int mColliderWidth = 0;
    protected static int mColliderHeight = 0;

    public static void ClearCombineBigColliderChilders(string name)
    {
        if (GameObject.Find(name) != null)
        {
            RemoveCreateChilders(name);
            RemoveHasColliders();
        }
    }

    protected static void CreateBigBox(string boxName, Vector3 localPos, Transform parent, Vector3 center, Vector3 size)
    {
        GameObject go = new GameObject(boxName);
        go.AddComponent<WideTilePro>();
        BoxCollider bc = go.AddComponent<BoxCollider>();
        bc.center = center;
        bc.size = size;
        bc.isTrigger = true;
        go.transform.SetParent(parent);
        go.transform.localPosition = localPos;

        mBigGo = go;
        mBigTf = go.transform;
    }

    protected static void CreateCheckBox(int colWid, int colHei, Vector3 center, Vector3 size)
    {
        mColliderWidth = colWid;
        mColliderHeight = colHei;
        float posx = colWid / 2;
        float posz = colHei / 2;

        mCheckBoxs = new List<GameObject>();
        mHasColliders = new List<GameObject>();
        mMissBoxs = new List<GameObject>();
        mUnMissBoxs = new List<GameObject>();

        for (int x = 0; x < colWid; x++)
        {
            float vx = x - posx;
            for (int y = 0; y < colHei; y++)
            {
                GameObject box = new GameObject(string.Format("{0},{1}", x, y));
                mCheckBoxs.Add(box);
                BoxCollider bc = box.AddComponent<BoxCollider>();
                bc.center = center;
                bc.size = size;
                Transform tf = box.transform;
                tf.SetParent(mBigTf);

                float vy = y - posz + 0.5f;
                tf.localPosition = new Vector3(vx, 0.25f, vy);
            }
        }
    }
    protected static void GetChildColliderGos<T>() where T : BaseElement
    {
        List<T> lists = new List<T>();
        List<GameObject> listgos = new List<GameObject>();
        GameObject[] gos = Selection.gameObjects;
        if (gos != null)
        {
            foreach (GameObject item in gos)
            {
                T[] typeGos = item.GetComponentsInChildren<T>();
                int length = typeGos.Length;
                for (int i = 0; i < length; i++)
                {
                    T t = typeGos[i];
                    if (mBigGo == t.gameObject || t.gameObject.GetComponent<BoxCollider>() == null)
                    {
                        continue;
                    }
                    lists.Add(t);
                    listgos.Add(t.gameObject);
                }
            }
        }
        mHasColliders.AddRange(listgos);
        //Selection.objects = listgos.ToArray();
    }
    protected static void CheckTabBox(List<string> removeMissList = null)
    {
        if (mHasColliders != null && mCheckBoxs != null)
        {
            int count = mCheckBoxs.Count;
            for (int j = count - 1; j >= 0; j--)
            {
                GameObject checkBox = mCheckBoxs[j];
                bool isMissBox = true;
                bool isCheck = true;

                if (removeMissList != null)
                {
                    foreach (string item in removeMissList)
                    {
                        if (checkBox.name == item)
                        {
                            checkBox.SetActive(false);
                            isCheck = false;
                            isMissBox = false;
                            mUnMissBoxs.Add(checkBox);
                            checkBox.SetActive(false);
                        }
                    }
                }

                if (isCheck)
                {
                    int length = mHasColliders.Count;
                    for (int i = 0; i < length; i++)
                    {
                        GameObject go = mHasColliders[i];
                        Transform tf = go.transform;

                        if (IsOnCollider(tf, checkBox.transform))
                        {
                            isMissBox = false;
                            mUnMissBoxs.Add(checkBox);
                            checkBox.SetActive(false);
                            break;
                        }
                    }
                }

                if (isMissBox)
                {
                    mMissBoxs.Add(checkBox);
                }
            }

        }
    }

    protected static bool IsOnCollider(Transform colliderTf, Transform checkTf)
    {
        Vector3 colPos = colliderTf.position;
        BoxCollider col = colliderTf.GetComponent<BoxCollider>();

        Vector3 boxPos = checkTf.position;
        BoxCollider boxCol = checkTf.GetComponent<BoxCollider>();

        float minX = colPos.x - col.size.x / 2;
        float maxX = colPos.x + col.size.x / 2;

        float minZ = colPos.z - col.size.z / 2;
        float maxZ = colPos.z + col.size.z / 2;

        if (boxPos.x > minX && boxPos.x < maxX && boxPos.z > minZ && boxPos.z < maxZ)
        {
            return true;
        }
        return false;
    }

    protected static void SetMissTilesToWideTilePro(int gridId)
    {
        if (mMissBoxs != null)
        {
            List<string> missTiles = new List<string>();
            foreach (GameObject item in mMissBoxs)
            {
                string val = item.name;
                missTiles.Add(val);
            }

            WideTilePro t = mBigTf.GetComponent<WideTilePro>();
            t.m_id = 708;
            t.m_gridId = gridId;
            t.point.m_x = Mathf.FloorToInt(mBigTf.localPosition.x);
            t.point.m_y = Mathf.FloorToInt(mBigTf.localPosition.z);
            t.data.Width = mColliderWidth;
            t.data.Height = mColliderHeight;
            t.data.BeginDistance = -(mColliderHeight / 2);
            t.data.ResetDistance = (mColliderHeight / 2);
            t.data.MissTiles = missTiles.ToArray();
            t.data.IfCheckMissTile = true;
            Debug.Log(t.data.MissTiles.Length + "  / " + mUnMissBoxs.Count);
        }

        mMissBoxs = null;
    }

    protected static void SetUnMissTiles()
    {

    }
    protected static void RemoveCreateChilders(string name)
    {
        GameObject go = GameObject.Find(name);
        if (go != null)
        {
            int length = go.transform.childCount;
            for (int i = length - 1; i >= 0; i--)
            {
                Transform box = go.transform.GetChild(i);
                GameObject.DestroyImmediate(box.gameObject);
            }
        }

        mCheckBoxs = null;
    }

    protected static void RemoveHasColliders()
    {
        if (mHasColliders != null)
        {
            int length = mHasColliders.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                GameObject go = mHasColliders[i];
                if (go.GetComponent<MeshFilter>() == null && go.transform.childCount == 0)
                {
                    GameObject.DestroyImmediate(go);
                }
                else
                {
                    Debug.Log("对象不可删除，只清Collider和脚本:" + go.name);
                    BoxCollider bc = go.GetComponent<BoxCollider>();
                    GameObject.DestroyImmediate(bc);
                    BaseElement[] bes = go.GetComponents<BaseElement>();
                    int len = bes.Length;
                    for (int j = len - 1; j >= 0; j--)
                    {
                        GameObject.DestroyImmediate(bes[j]);
                    }
                }
            }
        }
        mHasColliders = null;
    }
    #endregion

    #region 根据指定对象路径数组 来生居一个大的collider 指定新类型为 WideTilePro

    private static List<Transform> _selects = new List<Transform>();
    private static List<BaseElement> _scripts = new List<BaseElement>();
    private static List<BoxCollider> _colliders = new List<BoxCollider>();

    private static bool _FineCombineObjects(string[] names)
    {
        _selects = new List<Transform>();
        _scripts = new List<BaseElement>();
        _colliders = new List<BoxCollider>();
        foreach (string item in names)
        {
            GameObject go = GameObject.Find(item);
            if (go != null)
            {
                _selects.Add(go.transform);
                BaseElement sc = go.GetComponent<BaseElement>();
                if (sc != null)
                {
                    _scripts.Add(sc);
                }
                BoxCollider[] bcs = go.GetComponentsInChildren<BoxCollider>();
                if (bcs.Length == 1)
                {
                    _colliders.Add(bcs[0]);
                }

            }
        }

        if (_colliders.Count != _selects.Count || _scripts.Count != _selects.Count || _selects.Count == 0)
        {
            Debug.LogError("Collider数量不对 || 脚本数量不对，请检查每个对象 _colliders: " + _colliders.Count + "  =_scripts= " + _scripts.Count + " _selects : " + _selects.Count);
            return false;
        }
        return true;
    }

    public static void ClearCombineColliderAddWideTilePro()
    {
        foreach (Transform item in _selects)
        {
            MeshFilter[] meshs = item.GetComponentsInChildren<MeshFilter>();
            if (meshs.Length > 0)
            {
                BoxCollider[] bcs = item.GetComponentsInChildren<BoxCollider>();
                if (bcs != null)
                {
                    int length = bcs.Length;
                    for (int i = length - 1; i >= 0; i--)
                    {
                        MeshFilter[] ms = bcs[i].transform.GetComponentsInChildren<MeshFilter>();
                        if (ms.Length > 0)
                        {
                            GameObject.DestroyImmediate(bcs[i]);
                        }
                        else
                        {
                            GameObject.DestroyImmediate(bcs[i].gameObject);
                        }
                    }
                }
            }
            else
            {
                GameObject.DestroyImmediate(item.gameObject);
            }
        }
    }

    public static void SelectCombineColliderAddWideTilePro()
    {
        Transform[] tfs = Selection.transforms;
        if (tfs != null)
        {
            List<string> names = new List<string>();
            foreach (Transform item in tfs)
            {
                names.Add(item.name);
            }
            SelectCombineColliderAddWideTilePro(names.ToArray());
        }

    }

    private static int _index = 1000;
    protected static void SelectCombineColliderAddWideTilePro(string[] names)
    {
        if (!_FineCombineObjects(names))
        {
            return;
        }

        Vector3 minPos = _selects[0].localPosition;
        Vector3 maxPos = _selects[0].localPosition;
        Vector3 minCenter = _colliders[0].center;
        Vector3 maxCenter = _colliders[0].center;
        Vector3 minSize = _colliders[0].size;
        Vector3 maxSize = _colliders[0].size;

        int length = _selects.Count;
        for (int i = 0; i < length; i++)
        {
            Transform t = _selects[i];
            minPos.x = Mathf.Min(t.localPosition.x, minPos.x);
            minPos.y = Mathf.Min(t.localPosition.y, minPos.y);
            minPos.z = Mathf.Min(t.localPosition.z, minPos.z);

            maxPos.x = Mathf.Max(t.localPosition.x, maxPos.x);
            maxPos.y = Mathf.Max(t.localPosition.y, maxPos.y);
            maxPos.z = Mathf.Max(t.localPosition.z, maxPos.z);
        }

        foreach (BoxCollider bc in _colliders)
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
        bool b = false;//minCenter.x + maxCenter.x != 0;
        bool c = false;//minCenter.z + maxCenter.z != 0;
        bool d = minCenter.y != maxCenter.y;
        bool e = minSize.y != maxSize.y;
        if (a || b || c || d || e)
        {
            Debug.LogError("高低不一致，请检查每个对象" + a + b + c + d + e);
            return;
        }
        float posx = (minPos.x + maxPos.x) * 0.5f;
        float posy = minPos.y;
        float posz = (minPos.z + maxPos.z) * 0.5f;

        _index++;
        if (_index > 10000)
        {
            _index = 1000;
        }
        GameObject newGo = new GameObject("Waltz_Tile_Empty1x1_new" + _index);
        newGo.transform.SetParent(_selects[0].parent);
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
        newBC.isTrigger = true;

        WideTilePro wtp = newGo.AddComponent<WideTilePro>();
        wtp.m_id = 708;
        wtp.m_gridId = _scripts[0].m_gridId;
        wtp.point.m_x = Mathf.FloorToInt(newGo.transform.localPosition.x);
        wtp.point.m_y = Mathf.FloorToInt(newGo.transform.localPosition.z);
        wtp.data.Width = size_x;
        wtp.data.Height = size_z;
        wtp.data.BeginDistance = -(size_z / 2);
        wtp.data.ResetDistance = (size_z / 2);
        wtp.data.IfCheckMissTile = true;
        List<string> miss = CheckInBigCollider(newGo.transform, minPos, maxPos, _scripts);
        wtp.data.MissTiles = miss.ToArray();

    }

    protected static List<string> CheckInBigCollider<T>(Transform wideTf, Vector3 minPoint, Vector3 maxPoint, List<T> tileList) where T : BaseElement
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

                //Debug.Log(" min_x " + min_x + " min_z " + min_z + " max_x " + max_x + " max_z " + max_z);

                for (int i = min_x; i <= max_x; i++)
                {
                    for (int j = min_z; j <= max_z; j++)
                    {
                        bool is_miss = true;
                        string key = (i - min_x) + "," + (j - min_z);
                        foreach (BaseElement item in tileList)
                        {
                            if (item.point.m_x == i && item.point.m_y == j)
                            {
                                //Debug.Log("key :" + key + " , " + i + " , "+ j + " , " + item.gameObject.name);
                                is_miss = false;
                                continue;
                            }
                        }
                        if (is_miss)
                        {
                            misskeys.Add(key);
                            //Debug.Log(misskeys.Count +  " is_miss: " + key);
                        }
                    }
                }

            }
        }
        return misskeys;
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

    #region moveAllDirTile 改 NormalTile

    public static void Move_MoveAllDirTile_Distance(bool forward, Transform[] tfs)
    {
        if (tfs != null)
        {
            List<MoveAllDirTile> madts = new List<MoveAllDirTile>();

            foreach (Transform item in tfs)
            {
                MoveAllDirTile m = item.GetComponent<MoveAllDirTile>();
                if (m != null)
                {
                    madts.Add(m);
                }
            }
            if (madts.Count == tfs.Length)
            {
                Move_0_1(madts, forward);
            }
            else
            {
                Debug.LogError(madts.Count + "有的没脚本 MoveAllDirTile" + tfs.Length);
            }
        }
    }

    public static void MoveAllDirTile_Change_NormalTile()
    {
        Transform[] tfs = Selection.transforms;
        if (tfs != null)
        {
            List<MoveAllDirTile> madts = new List<MoveAllDirTile>();

            foreach (Transform item in tfs)
            {
                MoveAllDirTile m = item.GetComponent<MoveAllDirTile>();
                if (m != null)
                {
                    madts.Add(m);
                }
            }
            if (madts.Count == tfs.Length)
            {
                int idx = 1000;
                bool is_new = false;
                foreach (Transform item in tfs)
                {
                    int grid = item.GetComponent<MoveAllDirTile>().m_gridId;

                    Transform target = null;

                    MeshFilter[] mfs = item.GetComponentsInChildren<MeshFilter>();
                    if (mfs.Length == 0)
                    {
                        target = item;
                        is_new = false;
                    }
                    else
                    {
                        GameObject new_go = new GameObject();
                        new_go.transform.SetParent(item.parent);
                        new_go.transform.localPosition = item.localPosition;
                        new_go.transform.localRotation = item.localRotation;
                        new_go.transform.localScale = item.localScale;

                        BoxCollider bc = item.GetComponent<BoxCollider>();
                        UnityEditorInternal.ComponentUtility.CopyComponent(bc);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(new_go);

                        Vector3 new_rotat = new_go.transform.localRotation.eulerAngles;
                        if (new_rotat.x != 0)
                        {
                            new_rotat.x = 0;
                            BoxCollider new_bc = new_go.GetComponent<BoxCollider>();
                            if (new_bc != null && bc != null)
                            {
                                new_bc.center = new Vector3(bc.center.x, bc.center.z, bc.center.y);
                                new_bc.size = new Vector3(bc.size.x, bc.size.z, bc.size.y);
                            }
                        }
                        new_go.transform.localRotation = Quaternion.Euler(new_rotat);

                        target = new_go.transform;
                        is_new = true;
                        GameObject.DestroyImmediate(bc);

                    }

                    if (target != null)
                    {
                        NormalTile nt = target.gameObject.AddComponent<NormalTile>();
                        nt.m_id = 34;
                        nt.m_gridId = grid;
                        nt.point.m_x = Mathf.FloorToInt(target.localPosition.x);
                        nt.point.m_y = Mathf.FloorToInt(target.localPosition.z);

                        target.name = "Tile_P0_Road01_Water_m2n_" + idx;
                        if (is_new)
                        {
                            target.name += "_lms";
                        }

                        MoveAllDirTile madt = target.GetComponent<MoveAllDirTile>();
                        if (madt != null)
                        {
                            GameObject.DestroyImmediate(madt);
                        }
                    }

                    idx++;
                }
            }
            else
            {
                Debug.LogError("有的没脚本 MoveAllDirTile");
            }
        }
    }

    private static void Move_0_1(List<MoveAllDirTile> madts, bool forward = true)
    {
        Transform tf = null;
        foreach (MoveAllDirTile item in madts)
        {
            tf = item.transform;
            if (item.data.MoveDistance == 0)
            {
                continue;
            }
            Vector3 lpos = tf.localPosition;
            int f = forward ? 1 : -1;
            switch (item.data.MoveDirection)
            {
                case TileDirection.Left:
                    lpos.x -= (item.data.MoveDistance * f);
                    break;
                case TileDirection.Right:
                    lpos.x += (item.data.MoveDistance * f);
                    break;
                case TileDirection.Down:
                    lpos.y -= (item.data.MoveDistance * f);
                    break;
                case TileDirection.Up:
                    lpos.y += (item.data.MoveDistance * f);
                    break;
                case TileDirection.Forward:
                    lpos.z += (item.data.MoveDistance * f);
                    break;
                case TileDirection.Backward:
                    lpos.z -= (item.data.MoveDistance * f);
                    break;
                default:
                    Debug.LogError("未实现的移动" + (item.data.MoveDirection.ToString()));
                    break;
            }
            tf.localPosition = lpos;
        }
    }

    #endregion

    protected static void CombineModelCollider<T>(Transform[] tfs) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                if (model != null && collider != null && d && d2 && e && f && f2)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }
                    bool g2 = CheckTargetComponentCount<MeshFilter>(model, 3);
                    if (g2)
                    {
                        CopyComponent<MeshFilter>(model, t);
                        CopyComponent<MeshRenderer>(model, t);
                        SetTransformRotation(model, t);
                        DestroyGameObject(model.gameObject);
                    }
                    else
                    {
                        if (CheckTargetComponentCount<Transform>(model, 1))
                        {
                            DestroyGameObject(model.gameObject);
                        }
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

}

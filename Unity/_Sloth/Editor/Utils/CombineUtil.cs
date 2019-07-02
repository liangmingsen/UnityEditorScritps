using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CombineUtil
{
    public static bool IsCheck = false;
    private static List<GameObject> _checkFailedList = new List<GameObject>();
    private static int _destroyCount = 0;


    #region check

    /// <summary>
    /// 包含1个子节点 Home_dizhuan_001 
    /// 1：复制节点 Home_dizhuan_001 上的 mesh 到父节点，并删除 Home_dizhuan_001
    /// 2：删除父节点上的Animator 和 Animation
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenK(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 1)
            {
                Transform ctf = root.transform.Find("Home_dizhuan_001");
                //effect0.GetComponents [Transform / ParticleSystem / ParticleSystemRenderer]
                if (ctf != null && ctf.GetComponents<Component>().Length == 3 && ctf.transform.childCount == 0)
                {
                    flg = true;
                }
                if (flg)
                {
                    flg = false;
                    if (root.GetComponent<AnimTile>() != null)
                    {
                        flg = true;
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 包含2个子节点 effect0 \ effect1
    /// 1：删除 effect0 节点
    /// 2：复制 effect1 节点的组件到父节点 替换父节点的旋转、缩放。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenJ(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 2)
            {
                Transform effect0 = root.transform.Find("effect0");
                Transform effect1 = root.transform.Find("effect1");
                //effect0.GetComponents [Transform / ParticleSystem / ParticleSystemRenderer]
                if (effect0 != null && effect0.GetComponents<Component>().Length == 3 && effect0.transform.childCount == 0)
                {
                    flg = true;
                }
                if (flg)
                {
                    flg = false;
                    if (effect1 != null && effect1.GetComponents<Component>().Length == 3 && effect1.transform.childCount == 0 && effect1.GetComponent<ParticleSystem>() != null)
                    {
                        flg = true;
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 包含3个子节点 model \ collider \ triggerPoint
    /// 1：删除 collider 节点 \ 删除 triggerPoint 节点
    /// 2：将 model 的子节点提上一级。删除父 distanceEffect。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenI(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 3)
            {
                if (root.GetComponent<Collider>() == null)
                {
                    Transform model = root.transform.Find("model");
                    Transform collider = root.transform.Find("collider");
                    Transform triggerPoint = root.transform.Find("triggerPoint");
                    if (collider != null && collider.GetComponents<Component>().Length == 1 && collider.transform.childCount == 0)
                    {
                        flg = true;
                    }
                    if (flg)
                    {
                        flg = false;
                        if (triggerPoint != null && triggerPoint.GetComponents<Component>().Length == 1 && triggerPoint.transform.childCount == 0)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (model != null && model.GetComponents<Component>().Length == 1 && model.transform.childCount == 1)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }
    /// <summary>
    /// 包含5个子节点 model \ distanceEffect \ triggerEffect \ triggerPoint \ collider
    /// 1：删除model节点 \ 删除triggerPoint节点
    /// 2：将 distanceEffect 的子节点提上一级，并改成原父名。删除父 distanceEffect。
    /// 3：将 triggerEffect 的子节点提上一级，并改成原父名。删除父 triggerEffect。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenH(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 5)
            {
                if (root.GetComponent<Collider>() == null)
                {
                    Transform model = root.transform.Find("model");
                    Transform distanceEffect = root.transform.Find("distanceEffect");
                    Transform triggerEffect = root.transform.Find("triggerEffect");
                    Transform triggerPoint = root.transform.Find("triggerPoint");
                    Transform collider = root.transform.Find("collider");
                    if (collider != null && collider.GetComponents<Component>().Length == 2 && collider.GetComponents<Collider>() != null && collider.transform.childCount == 0)
                    {
                        flg = true;
                    }
                    if (flg)
                    {
                        flg = false;
                        if (model != null && model.GetComponents<Component>().Length == 1 && model.transform.childCount == 0)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (triggerPoint != null && triggerPoint.GetComponents<Component>().Length == 1 && triggerPoint.transform.childCount == 0)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (triggerEffect != null && triggerEffect.GetComponents<Component>().Length == 1 && triggerEffect.transform.childCount == 1)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (distanceEffect != null && distanceEffect.GetComponents<Component>().Length == 1 && distanceEffect.transform.childCount == 1)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 包含碱个子节点 model \ effect0 \ effect1
    /// 1：删除model节点
    /// 2：将effect0的子节点提上一级，并改成原父名。删除父effect0。
    /// 3：将effect1的子节点提上一级，并改成原父名。删除父effect1。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenG(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 3)
            {
                if (root.GetComponent<Animation>() == null && root.GetComponent<Animator>() == null && root.GetComponent<Collider>() == null)
                {
                    Transform model = root.transform.Find("model");
                    Transform effect0 = root.transform.Find("effect0");
                    Transform effect1 = root.transform.Find("effect1");
                    if (effect1 != null && effect1.GetComponents<Component>().Length == 1 && effect1.transform.childCount == 1)
                    {
                        flg = true;
                    }
                    if (flg)
                    {
                        flg = false;
                        if (effect0 != null && effect0.GetComponents<Component>().Length == 1 && effect0.transform.childCount == 1)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (model != null && model.GetComponents<Component>().Length == 1 && model.transform.childCount == 1)
                        {
                            Transform pgy = model.transform.GetChild(0);
                            if (pgy != null && pgy.GetComponents<Component>().Length == 1)
                            {
                                flg = true;
                            }
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }
    /// <summary>
    /// 包含碱个子节点 model \ collider \ triggerPoint
    /// 1:将model绑定的动画组件，复制到父节点，将model下的子节点，提到父级。删除model节点
    /// 2：将collider绑定的碰撞组件，复制到父节点。删除collider节点。
    /// 3：删除triggerPoint节点
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenF(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 3)
            {
                if (root.GetComponent<Animation>() == null && root.GetComponent<Animator>() == null && root.GetComponent<Collider>() == null)
                {
                    Transform model = root.transform.Find("model");
                    Transform collider = root.transform.Find("collider");
                    Transform triggerPoint = root.transform.Find("triggerPoint");
                    if (triggerPoint != null && triggerPoint.GetComponents<Component>().Length == 1)
                    {
                        flg = true;
                    }
                    if (flg)
                    {
                        flg = false;
                        if (collider != null && collider.GetComponents<Component>().Length == 2 && collider.GetComponent<Collider>() != null)
                        {
                            flg = true;
                        }
                    }
                    if (flg)
                    {
                        flg = false;
                        if (model != null && model.GetComponents<Component>().Length == 3 && model.GetComponent<Animator>() != null && model.GetComponent<Animation>() != null)
                        {
                            if (model.transform.childCount == 1)
                            {
                                Transform Home_dizhuan_001 = model.transform.GetChild(0);
                                if (Home_dizhuan_001 != null)
                                {
                                    flg = true;
                                }
                            }

                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }
    /// <summary>
    /// 只有一个节点，有mesh,名字叫啥不重要，父节点没有mesh,collider,audio。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenE(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 1)
            {
                if (root.GetComponent<MeshFilter>() == null && root.GetComponent<Collider>() == null && root.GetComponent<AudioSource>() == null)
                {
                    Transform model = root.transform.GetChild(0);
                    if (model != null)
                    {
                        if (model.GetComponent<MeshFilter>() != null)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 有三个子节点，分别叫 model 和 collider 和 path。并且 model 上有 mesh 。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenD(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 3)
            {
                Transform model = root.transform.Find("model");
                if (model != null)
                {
                    if (model.GetComponent<MeshFilter>() != null)
                    {
                        flg = true;
                    }
                }
                if (flg)
                {
                    flg = false;
                    Transform collTf = root.transform.Find("collider");
                    if (collTf != null)
                    {
                        if (collTf.GetComponent<Collider>() != null)
                        {
                            flg = true;
                        }
                    }
                }
                if (flg)
                {
                    flg = false;
                    Transform pathTf = root.transform.Find("path");
                    if (pathTf != null)
                    {
                        flg = true;
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 有两个子节点，分别叫 model 和 collider 。并且 model 上有 audio。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenC(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 2)
            {
                Transform model = root.transform.Find("model");
                if (model != null)
                {
                    if (model.GetComponent<AudioSource>() != null)
                    {
                        flg = true;
                    }
                }
                if (flg)
                {
                    flg = false;
                    Transform collTf = root.transform.Find("collider");
                    if (collTf != null)
                    {
                        if (collTf.GetComponent<Collider>() != null)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 有两个子节点，分别叫 model 和 collider 。并且 model上有mesh。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenB(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 2)
            {
                Transform model = root.transform.Find("model");
                if (model != null)
                {
                    if (model.GetComponent<MeshFilter>() != null)
                    {
                        flg = true;
                    }
                }
                if (flg)
                {
                    flg = false;
                    Transform collTf = root.transform.Find("collider");
                    if (collTf != null)
                    {
                        if (collTf.GetComponent<Collider>() != null)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    /// <summary>
    /// 有两个子节点，分别叫 model 和 collider 。并且 model上没有mesh,没有audio。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool _CheckChildenA(GameObject root)
    {
        if (!IsCheck)
        {
            return true;
        }
        bool flg = false;
        if (root != null)
        {
            if (root.transform.childCount == 2)
            {
                Transform model = root.transform.Find("model");
                if (model != null)
                {
                    if (model.GetComponent<MeshFilter>() == null && model.GetComponent<AudioSource>() == null)
                    {
                        flg = true;
                    }
                }
                if (flg)
                {
                    flg = false;
                    Transform collTf = root.transform.Find("collider");
                    if (collTf != null)
                    {
                        if (collTf.GetComponent<Collider>() != null)
                        {
                            flg = true;
                        }
                    }
                }
            }
        }
        if (!flg)
        {
            _checkFailedList.Add(root);
        }
        return flg;
    }

    #endregion

    #region 合并节点 - 删除子节点model 和 collider 。将collider碰撞组件复制到父节点  

    public static void CombineDelModelCopyCollidder()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenA(go))
                {
                    _DestroyModel(go);
                    _DestroyColliderCopyCollider(go);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    private static void _DestroyModel(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("model");
            if (ctf != null)
            {
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }

    #endregion

    #region 合并节点 - 删除节点model 和collider 。将collider碰撞组件复制到父节点 和 mesh 复制到父节点。

    public static void CombineCopyCollidderCopyMesh()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenB(go))
                {
                    _DestroyModelCopyMesh(go);
                    _DestroyColliderCopyCollider(go);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    #endregion

    //#region 合并节点 - 删除节点model 和collider 。将collider碰撞组件复制到父节点 和 mesh 复制到父节点， path节点暂时未处理。
    //public static void CombineChildsCopyCollidderCopyMeshAndPath()
    //{
    //    _destroyCount = 0;
    //    _checkFailedList.Clear();
    //    GameObject[] gos = Selection.gameObjects;
    //    foreach (GameObject go in gos)
    //    {
    //        if (go != null)
    //        {
    //            if(_check)
    //            _DestroyModelCopyMesh(go);
    //            _DestroyColliderCopyCollider(go);
    //        }
    //    }
    //    _OutFailedObjectMessage();
    //    Debug.Log("删除节点: " + _destroyCount);
    //}
    //#endregion

    #region #region 合并节点 - 删除节点model 和collider 。将collider碰撞组件复制到父节点 和 audio 复制到父节点。

    public static void CombineCopyCollidderCopyAudio()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenC(go))
                {
                    _DestroyModelCopyAudio(go);
                    _DestroyColliderCopyCollider(go);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    private static void _DestroyModelCopyAudio(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("model");
            if (ctf != null)
            {
                if (root.GetComponent<AudioSource>() == null)
                {
                    AudioSource audio = ctf.GetComponent<AudioSource>();
                    if (audio != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(audio);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                }
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }
    #endregion

    #region 合并节点 删除节点model 和 collider 。将collider 和 mesh 复制到 父节点，删除path和子节点beginPoint和endPoint .

    public static void CombineCopyCollidderCopyMeshDelPath()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenD(go))
                {
                    _DestroyModelCopyMesh(go);
                    _DestroyColliderCopyCollider(go);
                    _DestroyPathChild(go);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    private static void _DestroyPathChild(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("path");
            if (ctf != null)
            {
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount += 3;
            }
        }
    }

    #endregion

    #region 子节点替换父节点
    public static void ChildReplaceParentObj()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenE(go))
                {
                    Undo.RecordObject(go, "ReplaceAndDestroy");
                    _ChildReplaceParentObjAndReName(go);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }
    #endregion

    #region 包含碱个子节点 model \ collider \ triggerPoint
    public static void ReplaceAndDestroy()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenF(go))
                {
                    Undo.RecordObject(go, "ReplaceAndDestroy");
                    _DestroyModelCopyAnimator(go);
                    _DestroyColliderCopyCollider(go);
                    _DestroyGameObject(go, "triggerPoint");
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    #endregion

    #region 包含碱个子节点 model \ effect0 \ effect1
    public static void ReplaceAndDestroyPuGongYingEffect()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenG(go))
                {
                    Undo.RecordObject(go, "ReplaceAndDestroy");
                    _ChildReplaceParentObjAndReName(go.transform.Find("effect0").gameObject);
                    _ChildReplaceParentObjAndReName(go.transform.Find("effect1").gameObject);
                    Transform tf = go.transform.Find("model");
                    if (tf != null)
                    {
                        GameObject.DestroyImmediate(tf.gameObject);
                        _destroyCount++;
                    }
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }

    #endregion

    #region Two Effect Trigger Pro
    public static void ReplaceAndDestroyTwoEffectTriggerPro()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenH(go))
                {
                    Undo.RecordObject(go, "ReplaceAndDestroy");
                    _DestroyColliderCopyCollider(go);
                    _ChildReplaceParentObjAndReName(go.transform.Find("distanceEffect").gameObject);
                    _ChildReplaceParentObjAndReName(go.transform.Find("triggerEffect").gameObject);
                    _DestroyGameObject(go, "model");
                    _DestroyGameObject(go, "triggerPoint");
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }
    #endregion

    #region Anim Enemy Pro
    public static void ReplaceAndDestroyAnimEnemyPro()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenI(go))
                {
                    Undo.RecordObject(go, "ReplaceAndDestroy");
                    _DestroyGameObject(go, "collider");
                    _DestroyGameObject(go, "triggerPoint");
                    _ChildReplaceParentObje(go.transform.Find("model"));
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }
    #endregion

    #region DandelionEnemy  Enemy_PuGongYing
    public static void ReplaceAndDestroyDandelionEnemyPuGongYing()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenJ(go))
                {
                    _DestroyGameObject(go, "effect0");
                    GameObject effect1 = go.transform.Find("effect1").gameObject;
                    _CopyComponent<ParticleSystem>(effect1, go);
                    _SetTransformRotation(effect1, go);
                    _SetTransformScale(effect1, go);
                    _DestroyGameObject(effect1);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }
    #endregion

    #region Home_Road03_Up
    public static void CopyAndDestroyHome_Road03_Up()
    {
        _destroyCount = 0;
        _checkFailedList.Clear();
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                if (_CheckChildenK(go))
                {
                    Transform meshTf = go.transform.GetChild(0);
                    _CopyComponent<MeshFilter>(meshTf.gameObject, go);
                    _CopyComponent<MeshRenderer>(meshTf.gameObject, go);
                    _DestroyComponent(go.GetComponent<Animation>());
                    _DestroyComponent(go.GetComponent<Animator>());
                    _DestroyGameObject(meshTf.gameObject);
                }
            }
        }
        _OutFailedObjectMessage();
        Debug.Log("删除节点: " + _destroyCount);
    }
    #endregion

    private static void _DestroyModelCopyMesh(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("model");
            if (ctf != null)
            {
                if (root.GetComponent<MeshFilter>() == null)
                {
                    MeshFilter cmf = ctf.GetComponent<MeshFilter>();
                    if (cmf != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(cmf);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                    MeshRenderer cmr = ctf.GetComponent<MeshRenderer>();
                    if (cmr != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(cmr);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                }
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }
    private static void _DestroyColliderCopyCollider(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("collider");
            if (ctf != null)
            {
                if (root.GetComponent<BoxCollider>() == null)
                {
                    Collider coll = ctf.GetComponent<Collider>();
                    if (coll != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(coll);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                }
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }
    private static void _OutFailedObjectMessage()
    {
        if (IsCheck)
        {
            foreach (GameObject item in _checkFailedList)
            {
                Debug.LogError("合并节点检查异常： " + item.name);
            }
            Selection.objects = _checkFailedList.ToArray();
        }
    }
    private static void _DestroyModelCopyAnimator(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("model");
            if (ctf != null)
            {
                if (root.GetComponent<Animation>() == null && root.GetComponent<Animator>() == null)
                {
                    Animation cmf = ctf.GetComponent<Animation>();
                    if (cmf != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(cmf);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                    Animator cmr = ctf.GetComponent<Animator>();
                    if (cmr != null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(cmr);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                    if (ctf.childCount == 1)
                    {
                        ctf.GetChild(0).SetParent(root.transform, true);
                    }
                }
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }

    private static void _ChildReplaceParentObjAndReName(GameObject root)
    {
        if (root != null && root.transform.childCount == 1)
        {
            Transform ctf = root.transform.GetChild(0);
            if (ctf != null)
            {
                ctf.name = root.name;
                ctf.parent = root.transform.parent;

                GameObject.DestroyImmediate(root);
                _destroyCount++;
            }
        }
    }

    private static void _ChildReplaceParentObje(Transform root)
    {
        if (root != null && root.childCount == 1)
        {
            Transform ctf = root.GetChild(0);
            if (ctf != null)
            {
                ctf.parent = root.parent;

                GameObject.DestroyImmediate(root.gameObject);
                _destroyCount++;
            }
        }
    }

    private static void _DestroyGameObject(GameObject root, string childName)
    {
        Transform tf = root.transform.Find(childName);
        if (tf != null)
        {
            GameObject.DestroyImmediate(tf.gameObject);
            _destroyCount++;
        }
    }

    private static void _DestroyGameObject(GameObject go)
    {
        if (go != null)
        {
            GameObject.DestroyImmediate(go);
            _destroyCount++;
        }
    }

    private static void _DestroyComponent(Component com)
    {
        if (com != null)
        {
            GameObject.DestroyImmediate(com);
        }
    }

    private static void _CopyComponent<T>(GameObject copyTarget, GameObject pasteTo) where T : Component
    {
        if (copyTarget != null && pasteTo != null)
        {
            T t = copyTarget.GetComponent<T>();
            if (t != null)
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(t);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(pasteTo);
            }
        }
    }

    private static void _SetTransformRotation(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            Vector3 sr = source.transform.rotation.eulerAngles;
            target.transform.rotation = Quaternion.Euler(sr);
        }
    }

    private static void _SetTransformScale(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            target.transform.localScale = source.transform.localScale;
        }
    }

    private static void _SetTransformPosition(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            target.transform.position = source.transform.position;
        }
    }
}

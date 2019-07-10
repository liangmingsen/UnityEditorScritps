using RS2;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CombineBase
{
    protected static int mDestroyCount = 0;
    protected static List<GameObject> mSelectGos = new List<GameObject>();

    #region component

    /// <summary>
    /// 检查条件 成立
    /// 1：effect 局部坐标 = 0;
    /// 2：targetTf 身上只有两个 固定组件 BaseElement  和 Transform
    /// 3：effect 有 ParticleSystem。
    /// 则把source下的子节点往上提，并删除 source 自身
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="targetTf"></param>
    /// <returns></returns>
    protected static bool Com_CopyParticleEffectAndDestroySelf(Transform effect, Transform targetTf)
    {
        if (effect != null && targetTf != null)
        {
            bool c1 = CheckLocalPositionIsZero(effect);
            bool c2 = CheckTargetComponentCount<BaseElement>(targetTf, 2);
            bool c3 = CheckTargetHasComponent<ParticleSystem>(effect);
            if (c1 && c2 && c3)
            {
                Quaternion effectRotation = effect.localRotation;
                Vector3 effectScale = effect.localScale;
                CopyComponent<ParticleSystem>(effect, targetTf);
                targetTf.localRotation = effectRotation;
                targetTf.localScale = effectScale;
                DestroyGameObject(effect.gameObject);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 检查条件 成立
    /// 1：source 只有 Transform 唯一组件。
    /// 2：localScale = one。
    /// 3：rotation = zero。
    /// 则把source下的子节点往上提，并删除 source 自身
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    protected static bool Com_SetChildParentAndDestroySelf(Transform source)
    {
        if (source != null)
        {
            bool c1 = CheckTargetComponentCount<Transform>(source, 1);
            bool c2 = source.localScale == Vector3.one;
            bool c3 = CheckLocalRotationIsZero(source);
            bool c4 = true;//CheckLocalPositionIsZero(source);
            if (c1 && c2 && c3 && c4)
            {
                while (source.childCount > 0)
                {
                    Transform ctf = source.GetChild(0);
                    SetParent(ctf, source.parent, true);
                }
                DestroyGameObject(source.gameObject);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 检查 条件 成立 
    /// 1：指定父节点无绑 AudioSource 。
    /// 2：自身只有 AudioSource 和 Transform 两组件。
    /// 则 复制 AudioSource 到指定对象，并删除自身。
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="targetTf"></param>
    /// <returns></returns>
    protected static bool Com_CopyAudioAndDestroySelf(Transform audio, Transform targetTf)
    {
        if (audio != null && targetTf != null)
        {
            bool c2 = !CheckTargetHasComponent<AudioSource>(targetTf);//父无 AudioSource
            bool c3 = CheckTargetComponentCount<AudioSource>(audio, 2);//已身上只有 AudioSource 和 Transform
            if (c2 && c3)
            {
                CopyComponent<AudioSource>(audio, targetTf);
                DestroyGameObject(audio.gameObject);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 检查 条件 成立 
    /// 1：指定父节点无绑 BoxCollider 。
    /// 2：自身只有 BoxCollider 和 Transform 两组件。
    /// 3：位置为0。
    /// 4：无子节点。
    /// 5：缩放为0。
    /// 则 复制 BoxCollider 到指定对象，并删除自身。
    /// </summary>
    /// <param name="collider"></param>
    /// <param name="targetTf"></param>
    /// <returns></returns>
    protected static bool Com_CopyBoxColliderAndDestroySelf(Transform collider, Transform targetTf, bool changeCenterXY, bool checkTargetCollider = true)
    {
        if (collider != null && targetTf != null)
        {
            bool c2 = checkTargetCollider ? !CheckTargetHasComponent<BoxCollider>(targetTf) : true;//父无 BoxCollider
            bool c3 = CheckTargetComponentCount<BoxCollider>(collider, 2);//已身上只有 BoxCollider 和 Transform
            bool c4 = changeCenterXY ? true : CheckLocalPositionIsZero(collider);//己局部坐标为0
            bool c5 = collider.childCount == 0;//已无子节点
            bool c6 = CheckLocalRotationIsZero(collider); //如果有旋转，就不加到父节点了
            if (c2 && c3 && c4 && c5 && c6)
            {
                SetBoxColliderNewSize(collider, changeCenterXY);
                CopyComponent<BoxCollider>(collider, targetTf);
                DestroyGameObject(collider.gameObject);
                return true;
            }
        }
        return false;
    }

    //复制rootTf的所有只有BoxCollider的子节点对象到自身
    protected static void Com_CopyAllChildBoxColliderAndDestroySelf(Transform rootTf, bool changeCenterXY, bool checkTargetCollider)
    {
        List<Transform> boxColliderChilds = new List<Transform>();
        List<Transform> needDelBoxCollider = new List<Transform>();
        for (int i = 0; i < rootTf.childCount; i++)
        {
            Transform child = rootTf.GetChild(i);
            if (CheckTargetHasComponent<BoxCollider>(child))
            {
                boxColliderChilds.Add(child);
            }
            else if (child.name == "collider")
            {
                needDelBoxCollider.Add(child);
            }
        }
        for (int k = 0; k < needDelBoxCollider.Count; k++)
        {
            DestroyGameObject(needDelBoxCollider[k].gameObject);
        }
        if (boxColliderChilds.Count > 1 || boxColliderChilds.Count == 0)
        {
            //多个collider不处理
            return;
        }
        if (!Com_CopyBoxColliderAndDestroySelf(boxColliderChilds[0], rootTf, changeCenterXY, checkTargetCollider))
        {
            Debug.LogWarning(rootTf.name + " collider 合并不通过: " + boxColliderChilds[0].name);
        }

    }


    /// <summary>
    /// 检查 条件 成立 
    /// 1：指定父节点无绑 SphereCollider 。
    /// 2：自身只有 SphereCollider 和 Transform 两组件。
    /// 3：位置为0。
    /// 4：无子节点。
    /// 5：缩放为0。
    /// 则 复制 SphereCollider 到指定对象，并删除自身。
    /// </summary>
    /// <param name="collider"></param>
    /// <param name="targetTf"></param>
    /// <returns></returns>
    protected static bool ComSphereColliderAndDestroySelf(Transform collider, Transform targetTf)
    {
        if (collider != null && targetTf != null)
        {
            bool c1 = !CheckTargetHasComponent<SphereCollider>(targetTf);
            bool c2 = CheckTargetComponentCount<SphereCollider>(collider, 2);
            bool c3 = CheckLocalPositionIsZero(collider);
            bool c4 = collider.childCount == 0;
            bool c5 = collider.localScale == Vector3.one;
            if (c1 && c2 && c3 && c4 && c5)
            {
                CopyComponent<SphereCollider>(collider, targetTf);
                DestroyGameObject(collider.gameObject);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 检查 条件 成立 1：只有唯一Transform组件。2：无子节点
    /// 则 删除自身。
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool Com_DestroySelf(Transform tf)
    {
        if (tf != null)
        {
            bool c2 = CheckTargetComponentCount<Transform>(tf, 1);
            bool c3 = tf.childCount == 0;
            if (c3 && c2)
            {
                DestroyGameObject(tf.gameObject);
                return true;
            }
        }
        return false;
    }

    #endregion

    #region public

    public static void Combine_Destroy_Audio_path_11<T>(Transform[] tfs) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio", "effect" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 11);
            if (a && b)
            {
                Transform audio = t.Find("audio");

                bool d6 = CheckTargetComponentCount<AudioSource>(audio, 2);
                bool e6 = CheckTargetComponentAndChildsCount<Transform>(audio, 1);

                if (d6 && e6)
                {
                    CopyComponent<AudioSource>(audio, t);

                    DestroyGameObject(audio.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    public static void Combine_CopyCollider_2<T>(Transform[] tfs, Vector3 collLocalPos) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 2);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckLocalPositionIsZero(collider, collLocalPos);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (d2 && e2 && f2 && g2)
                {
                    bc.center += collLocalPos;
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    public static void Combine_model_collider_3_zero<T>(Transform[] tfs)where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(model);
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (d && e && f && d2 && e2 && f2 && g2)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    CopyComponent<MeshFilter>(model, t);
                    CopyComponent<MeshRenderer>(model, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject);

                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    public static void Combine_destory_model<T>(Transform[] tfs) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform model = t.Find("model");
                bool c = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                bool d = CheckTargetComponentCount<Transform>(model, 1);

                if (c && d)
                {
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    public static void Combine_DestroyModel_CopyCollider_Count_3<T>(Transform[] tfs, Vector3 colLocalPos) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool c = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                bool d = CheckTargetComponentCount<Transform>(model, 1);

                bool d2 = CheckLocalPositionIsZero(collider, colLocalPos);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (c && d && d2 && e2 && f2 && g2)
                {
                    bc.center += colLocalPos;
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    public static void Combine_CopyCollider<T>(Transform[] tfs) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (d2 && e2 && f2 && g2)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    public static void Combine_model_101<T>(Transform[] tfs) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(model, new Vector3(0, -0.05f, 0));
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model, new Vector3(1.01f, 1, 1.01f));

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);
                bool h2 = CheckColliderSizeXYZ(bc);

                if (d && e && f && d2 && e2 && f2 && g2 && h2)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    CopyComponent<MeshFilter>(model, t);
                    CopyComponent<MeshRenderer>(model, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject);

                    t.GetComponent<BoxCollider>().size = new Vector3(0.99f, 1, 0.99f);
                    t.GetComponent<BoxCollider>().center = t.GetComponent<BoxCollider>().center - new Vector3(0, -0.05f, 0);
                    t.localPosition = t.localPosition + new Vector3(0, -0.05f, 0);
                    t.localScale = new Vector3(1.01f, 1, 1.01f);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    public static void Combine_public_collider_model<T>(Transform[] tfs)where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = (collider.localPosition.x == 0 && collider.localPosition.z == 0);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                bool b2 = CheckColliderCenterXZ(bc);

                if (d && e && f && d2 && bc)
                {
                    Vector3 cen = bc.center;
                    bc.center = cen + collider.localPosition;
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    /// <summary>
    /// 合 collider model
    /// </summary>
    public static void Combine_Collider_Model<T>(bool changeCenterXy) where T : BaseElement
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<T>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, changeCenterXy))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            if (!Com_DestroySelf(tf.Find("model")))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
        }
        DebugLog();
    }
    /// <summary>
    /// 合 collider
    /// </summary>
    public static void Combine_Collider<T>(bool changeCenterXy) where T : BaseElement
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<T>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, changeCenterXy))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    #endregion

    #region set
    protected static void SetParentAndName(Transform target, Transform parent, string newName, bool worldPos = true)
    {
        if (target != null && parent != null)
        {
            target.name = newName;
            target.SetParent(parent, worldPos);
        }
    }

    protected static void SetParent(Transform target, Transform parent, bool worldPos = true)
    {
        if (target != null && parent != null)
        {
            target.SetParent(parent, worldPos);
        }
    }

    protected static void DestroyChildObject(GameObject root, string childName)
    {
        Transform tf = root.transform.Find(childName);
        if (tf != null)
        {
            GameObject.DestroyImmediate(tf.gameObject);
            mDestroyCount++;
        }
    }

    protected static void DestroyGameObject(GameObject go, int count = 1)
    {
        if (go != null)
        {
            GameObject.DestroyImmediate(go);
            mDestroyCount += count;
        }
    }

    protected static void DestroyComponent(Component com)
    {
        if (com != null)
        {
            GameObject.DestroyImmediate(com);
            mDestroyCount++;
        }
    }

    protected static void CopyComponent<T>(GameObject copyTarget, GameObject pasteTo) where T : Component
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

    protected static void CopyComponent<T>(Transform copyTarget, Transform pasteTo) where T : Component
    {
        if (copyTarget != null && pasteTo != null)
        {
            T t = copyTarget.GetComponent<T>();
            if (t != null)
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(t);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(pasteTo.gameObject);
            }
        }
    }
    protected static void SetTransformRotation(Transform source, Transform target, bool isLocal = true)
    {
        if (source != null && target != null)
        {
            if (isLocal)
            {
                Vector3 sr = source.localRotation.eulerAngles;
                target.localRotation = Quaternion.Euler(sr);
            }
            else
            {
                Vector3 sr = source.rotation.eulerAngles;
                target.rotation = Quaternion.Euler(sr);
            }
        }
    }
    protected static void SetTransformRotation(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            Vector3 sr = source.transform.rotation.eulerAngles;
            target.transform.rotation = Quaternion.Euler(sr);
        }
    }

    protected static void SetTransformScale(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            target.transform.localScale = source.transform.localScale;
        }
    }
    protected static void SetTransformScale(Transform source, Transform target)
    {
        if (source != null && target != null)
        {
            target.localScale = source.localScale;
        }
    }

    protected static void SetBoxColliderNewSize(Transform source, bool changeCenter)
    {
        if (source != null)
        {
            BoxCollider bc = source.GetComponent<BoxCollider>();
            if (bc != null)
            {
                Vector3 scale = source.localScale;
                Vector3 center = bc.center;
                Vector3 size = bc.size;
                if (scale != Vector3.one)
                {
                    Vector3 newSize = new Vector3(scale.x * size.x, scale.y * size.y, scale.z * size.z);
                    center.x *= scale.x;
                    center.y *= scale.y;
                    center.z *= scale.z;
                    bc.center = center;
                    bc.size = newSize;
                }
                if (changeCenter)
                {
                    center.z += source.localPosition.z;
                    center.y += source.localPosition.y;
                    center.x += source.localPosition.x;
                    bc.center = center;
                }
            }
        }
    }

    protected static void SetTransformPosition(GameObject source, GameObject target)
    {
        if (source != null && target != null)
        {
            target.transform.position = source.transform.position;
        }
    }
    protected static void SetTransformAddPosition(Transform source, Transform target, bool isLocal = true)
    {
        if (source != null && target != null)
        {
            if (isLocal)
            {
                target.localPosition += source.localPosition;
            }
            else
            {
                target.position += source.position;
            }
        }
    }

    protected static void DebugLog()
    {
        Debug.Log("合并节点： " + mDestroyCount);
        mDestroyCount = 0;
    }

    protected static void SetTilePoint(BaseElement tile, Transform tf)
    {
        string sx = tf.localPosition.x.ToString("0.0000000000");
        sx = sx.Substring(0, sx.IndexOf('.'));
        string sz = tf.localPosition.z.ToString("0.0000000000");
        sz = sz.Substring(0, sz.IndexOf('.'));

        tile.point.m_x = int.Parse(sx);
        tile.point.m_y = int.Parse(sz);
    }
    #endregion

    #region check
    /// <summary>
    /// 位置是否是000
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalPositionIsZero(Transform tf)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localPosition;
            flg = v3 == Vector3.zero;
        }
        return flg;
    }
    /// <summary>
    /// 位置是否是000
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalPositionIsZero(Transform tf, Vector3 targetPos)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localPosition;
            flg = v3 == targetPos;
        }
        return flg;
    }

    /// <summary>
    /// 旋转是否是000
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalRotationIsZero(Transform tf)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localRotation.eulerAngles;
            flg = v3 == Vector3.zero;
        }
        return flg;
    }
    /// <summary>
    /// 旋转是否是000
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalRotationIsZero(Transform tf, Vector3 targetRot)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localRotation.eulerAngles;
            flg = v3 == targetRot;
        }
        return flg;
    }
    /// <summary>
    /// 缩放是否是111
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalScaleIsOne(Transform tf)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localScale;
            flg = v3 == Vector3.one;
        }
        return flg;
    }
    /// <summary>
    /// 缩放是否是111
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckLocalScaleIsOne(Transform tf, Vector3 targetRot)
    {
        bool flg = false;
        if (tf != null)
        {
            Vector3 v3 = tf.localScale;
            flg = v3 == targetRot;
        }
        return flg;
    }
    /// <summary>
    /// BoxCollider 的 X 和 Z 是否均为0。
    /// </summary>
    /// <param name="bc"></param>
    /// <returns></returns>
    protected static bool CheckColliderCenterXZ(BoxCollider bc)
    {
        bool flg = false;
        if (bc != null)
        {
            flg = bc.center.x + bc.center.z == 0;
        }
        return flg;
    }
    /// <summary>
    /// BoxCollider 的 X 和 Z 是否均为0。
    /// </summary>
    /// <param name="bc"></param>
    /// <returns></returns>
    protected static bool CheckColliderCenterXYZ(BoxCollider bc)
    {
        bool flg = false;
        if (bc != null)
        {
            flg = bc.center == Vector3.zero;
        }
        return flg;
    }
    /// <summary>
    /// BoxCollider 
    /// </summary>
    /// <param name="bc"></param>
    /// <returns></returns>
    protected static bool CheckColliderCenterXYZ(BoxCollider bc,Vector3 value)
    {
        bool flg = false;
        if (bc != null)
        {
            flg = bc.center == value;
        }
        return flg;
    }
    /// <summary>
    /// BoxCollider size
    /// </summary>
    /// <param name="bc"></param>
    /// <returns></returns>
    protected static bool CheckColliderSizeXYZ(BoxCollider bc)
    {
        bool flg = false;
        if (bc != null)
        {
            flg = bc.size == Vector3.one;
        }
        return flg;
    }
    /// <summary>
    /// BoxCollider size 
    /// </summary>
    /// <param name="bc"></param>
    /// <returns></returns>
    protected static bool CheckColliderSizeXYZ(BoxCollider bc, Vector3 value)
    {
        bool flg = false;
        if (bc != null)
        {
            flg = bc.size == value;
        }
        return flg;
    }
    /// <summary>
    /// 是否有网格
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    protected static bool CheckHasMesh(Transform tf)
    {
        if (tf)
        {
            MeshFilter mf = tf.GetComponent<MeshFilter>();
            if (mf && mf.sharedMesh != null)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 检查组件数量是否一至，并且保证包含指定的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    protected static bool CheckTargetComponentCount<T>(Transform target, int count) where T : Component
    {
        if (target != null)
        {
            int tleng = target.GetComponents<Component>().Length;
            if (count == tleng)
            {
                return CheckTargetHasComponent<T>(target);
            }
        }
        return false;
    }
    /// <summary>
    /// 检查组件数量是否一至，并且保证包含指定的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    protected static bool CheckTargetComponentAndChildsCount<T>(Transform target, int count) where T : Component
    {
        if (target != null)
        {
            int tleng = target.GetComponentsInChildren<Transform>().Length;
            if (count == tleng)
            {
                return CheckTargetHasComponent<T>(target);
            }
        }
        return false;
    }

    /// <summary>
    /// 是否包含指定组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target"></param>
    /// <returns></returns>
    protected static bool CheckTargetHasComponent<T>(Transform target) where T : Component
    {
        if (target != null)
        {
            if (target.GetComponent<T>() != null)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 子节点是否与指定的数组中的名字相同，并且数量相同。
    /// </summary>
    /// <param name="target"></param>
    /// <param name="cnames"></param>
    /// <returns></returns>
    protected static bool CheckChildFoNames(Transform target, string[] cnames)
    {
        if (target != null && cnames != null)
        {
            int leng = cnames.Length;
            int tleng = target.childCount;
            int num = 0;
            if (leng == tleng)
            {
                for (int k = 0; k < leng; k++)
                {
                    if (target.Find(cnames[k]) != null)
                    {
                        num++;
                    }
                }
            }
            return num == leng;
        }
        return false;
    }

    public static void CheckCombineChilds()
    {
        GameObject[] gos = Selection.gameObjects;
        List<Transform> list = new List<Transform>();
        Dictionary<Transform, int> dict = new Dictionary<Transform, int>();
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            dict.Add(tf, tf.childCount);
        }

        StreamWriter sw = FileUtils.GetTempFile();
        Umeng.JSONObject rootJson = new Umeng.JSONObject();

        foreach (KeyValuePair<Transform, int> item in dict)
        {
            Vector3 p3 = item.Key.localPosition;
            string str = p3.x + "_" + p3.y + "_" + p3.z;
            rootJson.Add(item.Key.name + str, item.Value);
        }

        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetTempFilePath());

    }

    #endregion

    #region 纠正

    public static void CorrectColliderSize()
    {
        GameObject[] gos = Selection.gameObjects;

        StreamWriter sw = FileUtils.GetCorrectFile();
        Umeng.JSONArray rootJson = new Umeng.JSONArray();

        foreach (GameObject go in gos)
        {
            Transform collider = go.transform.Find("collider");
            if (collider != null)
            {
                BoxCollider bc = collider.GetComponent<BoxCollider>();
                if (bc != null)
                {
                    Vector3 colliderScale = collider.localScale;
                    if (colliderScale != Vector3.one)
                    {
                        Vector3 size = bc.size;
                        Vector3 newSize = new Vector3(colliderScale.x * size.x, colliderScale.y * size.y, colliderScale.z * size.z);
                        Vector3 center = bc.center;
                        center.z = newSize.z * 0.5f;

                        Umeng.JSONObject colData = new Umeng.JSONObject();
                        colData.Add("name", go.name);
                        colData.Add("posX", go.transform.localPosition.x);
                        colData.Add("posY", go.transform.localPosition.y);
                        colData.Add("posZ", go.transform.localPosition.z);
                        colData.Add("centerZ", center.z);
                        colData.Add("sizeX", newSize.x);
                        colData.Add("sizeY", newSize.y);
                        colData.Add("sizeZ", newSize.z);

                        rootJson.Add(colData);
                    }
                }
            }
        }

        sw.Write(rootJson.ToString());
        sw.Close();
        Application.OpenURL(FileUtils.GetCorrectPath());
    }

    public static void WriteCorrectColliderSizeData()
    {
        TextAsset txt = AssetDatabase.LoadAssetAtPath<TextAsset>(FileUtils.GetCorrectPathAsset());
        if (txt == null)
        {
            Debug.LogError("找不到文件" + FileUtils.GetLightmapDataPathAsset());
            return;
        }
        Umeng.JSONArray jo = Umeng.JSONObject.Parse(txt.text) as Umeng.JSONArray;
        if (jo == null)
        {
            Debug.LogError("转JSON错误：" + FileUtils.GetLightmapDataPathAsset());
            return;
        }

        GameObject[] gos = Selection.gameObjects;

        int length = jo.Count;
        for (int i = 0; i < length; i++)
        {
            Umeng.JSONObject data = jo[i] as Umeng.JSONObject;
            float posX = float.Parse(data["posX"]);
            float posY = float.Parse(data["posY"]);
            float posZ = float.Parse(data["posZ"]);
            float centerZ = float.Parse(data["centerZ"]);
            float sizeX = float.Parse(data["sizeX"]);
            float sizeY = float.Parse(data["sizeY"]);
            float sizeZ = float.Parse(data["sizeZ"]);

            for (int j = 0; j < gos.Length; j++)
            {
                Transform tf = gos[j].transform;
                Vector3 tfPos = tf.localPosition;

                bool asx = Mathf.Approximately(tfPos.x, posX);
                bool asy = Mathf.Approximately(tfPos.y, posY);
                bool asz = Mathf.Approximately(tfPos.z, posZ);

                if (asx && asy && asz)
                {
                    BoxCollider bc = tf.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        Vector3 center = bc.center;
                        center.z = centerZ;
                        Vector3 newSize = new Vector3(sizeX, sizeY, sizeZ);
                        bc.center = center;
                        bc.size = newSize;
                    }
                }
            }

        }


    }

    #endregion

}

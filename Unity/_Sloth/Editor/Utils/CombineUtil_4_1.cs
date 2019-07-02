using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombineUtil_4_1 : CombineColliderUtil
{

    #region 节点优化
    //NormalTile
    public static void Combine_NormalTile(Transform[] tfs)
    {
        CombineModelCollider<NormalTile>(tfs);
    }
    //MoveAllDirTile
    public static void Combine_MoveAllDirTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<MoveAllDirTile>(t, 2);
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

                    int mcount = t.GetComponentsInChildren<Transform>().Length;
                    if (mcount == 3)
                    {
                        bool g2 = CheckTargetComponentCount<MeshFilter>(model, 3);
                        if (g2)
                        {
                            CopyComponent<MeshFilter>(model, t);
                            CopyComponent<MeshRenderer>(model, t);
                            SetTransformRotation(model, t);
                            DestroyGameObject(model.gameObject);
                        }
                    }
                    else if (mcount == 4)
                    {
                        Transform modelChild = model.Find("AiJi_ShaMo_Zhu01_1");
                        if (modelChild != null)
                        {
                            bool g3 = CheckTargetComponentCount<Transform>(model, 1);
                            bool e4 = CheckLocalRotationIsZero(model);
                            bool d3 = CheckLocalPositionIsZero(modelChild);
                            bool e3 = CheckLocalRotationIsZero(modelChild);
                            bool f3 = CheckLocalScaleIsOne(modelChild);
                            if (g3 && d3 && e3 && f3 && e4)
                            {
                                CopyComponent<MeshFilter>(modelChild, t);
                                CopyComponent<MeshRenderer>(modelChild, t);
                                SetTransformRotation(model, t);
                                DestroyGameObject(model.gameObject, 2);
                            }
                        }
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    public static void Combine_MoveAllDirTile2(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model" });
            if (a)
            {
                Transform model = t.Find("model");
                if(model != null)
                {
                    if(model.childCount == 0)
                    {
                        bool b = CheckTargetComponentCount<MeshFilter>(model, 3);
                        bool c = CheckLocalPositionIsZero(model);
                        bool d = CheckLocalScaleIsOne(model);
                        if (b && c && d)
                        {
                            CopyComponent<MeshFilter>(model, t);
                            CopyComponent<MeshRenderer>(model, t);
                            SetTransformRotation(model, t);
                            DestroyGameObject(model.gameObject);
                            continue;
                        }
                    }else if (model.childCount == 1)
                    {
                        Transform modelChild = model.GetChild(0);
                        if(modelChild != null)
                        {
                            bool b1 = CheckTargetComponentCount<MeshFilter>(modelChild, 3);
                            bool c1 = CheckLocalPositionIsZero(modelChild);
                            bool d1 = CheckLocalScaleIsOne(modelChild);
                            if (b1 && c1 && d1)
                            {
                                CopyComponent<MeshFilter>(modelChild, t);
                                CopyComponent<MeshRenderer>(modelChild, t);
                                SetTransformRotation(modelChild, t, false);
                                DestroyGameObject(model.gameObject, 2);
                                continue;
                            }
                        }
                    }
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //WideTilePro
    public static void Combine_WideTilePro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider" });
            bool b = CheckTargetComponentCount<WideTilePro>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 2;
            if (a && b && h)
            {
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (collider != null && d && e && f)
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
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //FreeCollideTile
    public static void Combine_FreeCollideTile(Transform[] tfs)
    {
        CombineModelCollider<FreeCollideTile>(tfs);
    }
    //GlassRootTile
    public static void Combine_GlassRootTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<GlassRootTile>(t, 3);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(model);
                bool e2 = CheckLocalRotationIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                if (model != null && collider != null && d && d2 && e && e2 && f && f2)
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
                    Transform centerPart = model.Find("centerPart");
                    if (centerPart != null)
                    {
                        bool g2 = CheckTargetComponentCount<MeshFilter>(centerPart, 3);
                        if (g2)
                        {
                            CopyComponent<MeshFilter>(centerPart, t);
                            CopyComponent<MeshRenderer>(centerPart, t);
                            SetTransformRotation(centerPart, t);
                            DestroyGameObject(model.gameObject, 6);
                        }
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //GlassChildTile
    public static void Combine_GlassChildTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<GlassChildTile>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(model);
                bool e2 = CheckLocalRotationIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                if (model != null && collider != null && d && d2 && e && e2 && f && f2)
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
                    Transform centerPart = model.Find("centerPart");
                    if (centerPart != null)
                    {
                        bool g2 = CheckTargetComponentCount<MeshFilter>(centerPart, 3);
                        if (g2)
                        {
                            CopyComponent<MeshFilter>(centerPart, t);
                            CopyComponent<MeshRenderer>(centerPart, t);
                            SetTransformRotation(centerPart, t);
                            DestroyGameObject(model.gameObject, 6);
                        }
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //NormalJumpTile
    public static void Combine_NormalJumpTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio" });
            bool b = CheckTargetComponentCount<NormalJumpTile>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 4;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform audio = t.Find("audio");

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
                        DestroyGameObject(model.gameObject, 6);
                    }

                    bool d3 = CheckTargetComponentCount<AudioSource>(audio, 2);
                    if (d3)
                    {
                        CopyComponent<AudioSource>(audio, t);
                        DestroyGameObject(audio.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //NormalEnemy AiJi_XiaPo_Zhu(Clone)
    public static void Combine_NormalEnemy_AiJi_XiaPo_Zhu(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<NormalEnemy>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, -2.99f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(model, new Vector3(0, 4, 0));
                bool e2 = CheckLocalRotationIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                if (model != null && collider != null && d && e && f && f2 && e2)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        if (bc.center == Vector3.zero)
                        {
                            bc.center = new Vector3(0, -2.99f - 4f, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }
                    bool g2 = CheckTargetComponentCount<MeshFilter>(model, 3);
                    if (g2)
                    {
                        CopyComponent<MeshFilter>(model, t);
                        CopyComponent<MeshRenderer>(model, t);
                        SetTransformAddPosition(model, t);
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //NormalEnemy Enemy_Enpty(Clone)
    public static void Combine_NormalEnemy_Enemy_Enpty(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<NormalEnemy>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                if (model != null && collider != null)
                {
                    if (CheckTargetComponentCount<Transform>(model, 1))
                    {
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //JumpDistanceQTETile
    public static void Combine_JumpDistanceQTETile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio" });
            bool b = CheckTargetComponentCount<JumpDistanceQTETile>(t, 2);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform audio = t.Find("audio");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool f2 = CheckLocalScaleIsOne(model);

                Vector3 modelLocalPos = new Vector3(0, -0.042f, 0);
                bool e2 = model.localPosition == modelLocalPos;

                if (audio != null && model != null && collider != null && d && e && f && f2 && e2)
                {
                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);

                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            Vector3 center = bc.center;
                            center.y -= modelLocalPos.y;
                            bc.center = center;
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
                        SetTransformAddPosition(model, t);
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            bool c = CheckChildFoNames(t, new string[] { "model", "collider" });
            if (c && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (model != null && collider != null && d && e && f)
                {
                    CopyComponent<AudioSource>(model, t);
                    DestroyGameObject(model.gameObject);

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
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //NormalDropEnemy
    public static void Combine_NormalDropEnemy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<NormalDropEnemy>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                if (model != null && collider != null && d2 && e && f && f2)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            bool d = collider.localPosition.y == 1;
                            bool d3 = bc.center.y == -1;
                            if (d && d3)
                            {
                                bc.center = Vector3.zero;
                                CopyComponent<BoxCollider>(collider, t);
                                DestroyGameObject(collider.gameObject);
                            }
                        }
                    }
                    if (CheckTargetComponentCount<Transform>(model, 1))
                    {
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //RoleAnimatiorTrigger
    public static void Combine_RoleAnimatiorTrigger(Transform[] tfs)
    {
        CombineModelCollider2<RoleAnimatiorTrigger>(tfs, 1.5f);
    }
    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        CombineModelCollider<CameraAnimTrigger>(tfs);
    }
    //ShakeCameraTrigger
    public static void Combine_ShakeCameraTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<ShakeCameraTrigger>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
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
                        CopyComponent<BoxCollider>(collider, t);
                        DestroyGameObject(collider.gameObject);
                    }
                    if (CheckTargetComponentCount<Transform>(model, 1))
                    {
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //CrownFragment
    public static void Combine_CrownFragment(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "effect", "audio" });
            bool b = CheckTargetComponentCount<CrownFragment>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform effect = t.Find("effect");
                Transform audio = t.Find("audio");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.372f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d3 = CheckLocalPositionIsZero(effect);
                bool e3 = CheckLocalRotationIsZero(effect);
                bool f3 = CheckLocalScaleIsOne(effect);
                Transform tx_chufa = effect.Find("tx_chufa");

                if (tx_chufa != null && effect != null && audio != null && model != null && collider != null && d && e && f && d3 && e3 && f3)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        if (bc.center == Vector3.zero)
                        {
                            bc.center = new Vector3(0, 0.372f, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }

                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);

                    SetParentAndName(tx_chufa, t, "effect");
                    DestroyGameObject(effect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //DiamondAward
    public static void Combine_DiamondAward(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "effect", "audio" });
            bool b = CheckTargetComponentCount<DiamondAward>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform effect = t.Find("effect");
                Transform audio = t.Find("audio");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.096f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d3 = CheckLocalPositionIsZero(effect);
                bool e3 = CheckLocalRotationIsZero(effect);
                bool f3 = CheckLocalScaleIsOne(effect);
                Transform tx_chufa = effect.Find("glow_031");

                if (tx_chufa != null && effect != null && audio != null && model != null && collider != null && d && e && f && d3 && e3 && f3)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        if (bc.center == Vector3.zero)
                        {
                            bc.center = new Vector3(0, 0.096f, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }

                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);

                    SetParentAndName(tx_chufa, t, "effect");
                    DestroyGameObject(effect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //TwoEffectTriggerPro
    public static void Combine_TwoEffectTriggerPro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint", "distanceEffect", "triggerEffect" });
            bool b = CheckTargetComponentCount<TwoEffectTriggerPro>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 9;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                Transform d_eff = distanceEffect.Find("effect");
                Transform t_eff = triggerEffect.Find("effect");

                if (triggerPoint != null && distanceEffect != null && triggerEffect != null && d_eff != null &&
                    t_eff != null && model != null && collider != null && d && e && f)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        CopyComponent<BoxCollider>(collider, t);
                        DestroyGameObject(collider.gameObject);
                    }

                    SetParentAndName(d_eff, t, "distanceEffect");
                    DestroyGameObject(distanceEffect.gameObject);

                    SetParentAndName(t_eff, t, "triggerEffect");
                    DestroyGameObject(triggerEffect.gameObject);

                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //FreeCollideAnimTile
    public static void Combine_FreeCollideAnimTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint" });
            bool b = CheckTargetComponentCount<FreeCollideAnimTile>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 9 || t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (triggerPoint != null && model != null && collider != null && d && e && f)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        CopyComponent<BoxCollider>(collider, t);
                        DestroyGameObject(collider.gameObject);
                    }

                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //CycleFBTile
    public static void Combine_CycleFBTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<CycleFBTile>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
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
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //WorldThemesTrigger
    public static void Combine_WorldThemesTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<RS2.WorldThemesTrigger>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                if (model != null && collider != null)
                {
                    bool g2 = CheckTargetComponentCount<Transform>(model, 1);
                    if (g2)
                    {
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //PathToMoveByUnpredictableDiamondAwardTrigger
    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio", "effect" });
            bool b = CheckTargetComponentCount<PathToMoveByUnpredictableDiamondAwardTrigger>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 11;
            if (a && b && h)
            {
                Transform collider = t.Find("collider");
                Transform audio = t.Find("audio");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckTargetComponentCount<AudioSource>(audio, 2);

                if (audio != null && collider != null && d && e && f && d2)
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

                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<BuyOutRebirthBoxTrigger>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 17;
            if (a && b && h)
            {
                Transform collider = t.Find("collider");
                Transform model = t.Find("model");
                Transform canmove2 = model.Find("canmove2");
                Transform canmove2_effect = canmove2.Find("effect");
                Transform wuti_shalou01 = canmove2_effect.Find("wuti_shalou01");

                Transform effect_fuhuodian02 = model.Find("Effect_fuhuodian02");
                Transform effect = effect_fuhuodian02.Find("effect");
                Transform glow_024 = effect.Find("glow_024");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckLocalPositionIsZero(effect_fuhuodian02);
                bool e2 = CheckLocalRotationIsZero(effect_fuhuodian02);
                bool f2 = CheckLocalScaleIsOne(effect_fuhuodian02);

                bool d3 = CheckLocalPositionIsZero(effect);
                bool e3 = CheckLocalRotationIsZero(effect);
                bool f3 = CheckLocalScaleIsOne(effect);

                if (model != null && collider != null && d && e && f && canmove2 != null && canmove2_effect != null && wuti_shalou01 != null
                    && d2 && e2 && f2 && d3 && e3 && f3 && effect_fuhuodian02 != null && effect != null && glow_024 != null)
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

                        SetParent(wuti_shalou01, canmove2);
                        DestroyGameObject(canmove2_effect.gameObject);

                        SetParentAndName(glow_024, model, "Effect_fuhuodian02");
                        DestroyGameObject(effect_fuhuodian02.gameObject, 2);
                    }

                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //AnimEnemyPro
    public static void Combine_AnimEnemyPro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "triggerPoint" });
            bool b = CheckTargetComponentCount<AnimEnemyPro>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 5 || t.GetComponentsInChildren<Transform>().Length == 4;
            if (a && b && h)
            {
                Transform triggerPoint = t.Find("triggerPoint");

                if (triggerPoint != null)
                {
                    bool g2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                    if (g2)
                    {
                        DestroyGameObject(triggerPoint.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //CurvedBendBoxTrigger
    public static void Combine_CurvedBendBoxTrigger(Transform[] tfs)
    {
        CombineModelCollider2<CurvedBendBoxTrigger>(tfs, 4);
    }
    //PathToMoveByRoleTrigger
    public static void Combine_PathToMoveByRoleTrigger(Transform[] tfs)
    {
        CombineModelCollider2<PathToMoveByRoleTrigger>(tfs, 1.5f);
    }
    //InputResetTrigger
    public static void Combine_InputResetTrigger(Transform[] tfs)
    {
        CombineModelCollider<InputResetTrigger>(tfs);
    }
    //DepartVehicleTrigger
    public static void Combine_DepartVehicleTrigger(Transform[] tfs)
    {
        CombineModelCollider<DepartVehicleTrigger>(tfs);
    }
    //RoleMoveLimitTrigger
    public static void Combine_RoleMoveLimitTrigger(Transform[] tfs)
    {
        CombineModelCollider<RS2.RoleMoveLimitTrigger>(tfs);
    }
    //ChangeCameraEffectTrigger
    public static void Combine_ChangeCameraEffectTrigger(Transform[] tfs)
    {
        CombineModelCollider<RS2.ChangeCameraEffectTrigger>(tfs);
    }
    //CrownFromFragment
    public static void Combine_CrownFromFragment(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio", "effect" });
            bool b = CheckTargetComponentCount<CrownFromFragment>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform collider = t.Find("collider");
                Transform audio = t.Find("audio");
                Transform effect = t.Find("effect");
                Transform tx_chufa = effect.Find("tx_chufa");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.11f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckTargetComponentCount<AudioSource>(audio, 2);

                if (tx_chufa != null && audio != null && collider != null && d && e && f && d2)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            bc.center = new Vector3(0, 0.11f, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }

                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);

                    SetParentAndName(tx_chufa, t, "effect");
                    DestroyGameObject(effect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //DisableInputTrigger
    public static void Combine_DisableInputTrigger(Transform[] tfs)
    {
        CombineModelCollider<DisableInputTrigger>(tfs);
    }
    //BackGroundTrigger
    public static void Combine_BackGroundTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<BackGroundTrigger>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");

                if (model != null)
                {
                    MeshCollider mc = model.GetComponent<MeshCollider>();
                    if (mc != null)
                    {
                        DestroyComponent(mc);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //ChangeRoleTrigger
    public static void Combine_ChangeRoleTrigger(Transform[] tfs)
    {
        CombineModelCollider<ChangeRoleTrigger>(tfs);
    }
    //EnableInputTrigger
    public static void Combine_EnableInputTrigger(Transform[] tfs)
    {
        CombineModelCollider<EnableInputTrigger>(tfs);
    }
    //RS2.OpenFollowTrigger
    public static void Combine_OpenFollowTrigger(Transform[] tfs)
    {
        CombineModelCollider2<RS2.OpenFollowTrigger>(tfs, 1.5f);
    }
    //RS2.DropDieStaticTrigger
    public static void Combine_DropDieStaticTrigger(Transform[] tfs)
    {
        CombineModelCollider<RS2.DropDieStaticTrigger>(tfs);
    }
    //RS2.HideBackTrigger
    public static void Combine_HideBackTrigger(Transform[] tfs)
    {
        CombineModelCollider<RS2.HideBackTrigger>(tfs);
    }
    //Award_Crown_lv4
    public static void Combine_Award_Crown_lv4(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "effect", "audio" });
            bool b = CheckTargetComponentCount<CrownAward>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 8;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform effect = t.Find("effect");
                Transform audio = t.Find("audio");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.11f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d3 = CheckLocalPositionIsZero(effect);
                bool e3 = CheckLocalRotationIsZero(effect);
                bool f3 = CheckLocalScaleIsOne(effect);
                Transform tx_chufa = effect.Find("tx_guangshu_1");

                if (tx_chufa != null && effect != null && audio != null && model != null && collider != null && d && e && f && d3 && e3 && f3)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        if (bc.center == Vector3.zero)
                        {
                            bc.center = new Vector3(0, 0.11f, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }

                    CopyComponent<AudioSource>(audio, t);
                    DestroyGameObject(audio.gameObject);

                    SetParentAndName(tx_chufa, t, "effect");
                    DestroyGameObject(effect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //WindOpenTrigger
    public static void Combine_WindOpenTrigger(Transform[] tfs)
    {
        CombineModelCollider2<WindOpenTrigger>(tfs, 1.5f);
    }
    //WindCloseTrigger
    public static void Combine_WindCloseTrigger(Transform[] tfs)
    {
        CombineModelCollider2<WindCloseTrigger>(tfs, 1.5f);
    }
    //RS2.CloseFollowTrigger
    public static void Combine_CloseFollowTrigger(Transform[] tfs)
    {
        CombineModelCollider2<RS2.CloseFollowTrigger>(tfs, 1.5f);
    }
    //WinBeforeFinishTrigger
    public static void Combine_WinBeforeFinishTrigger(Transform[] tfs)
    {
        CombineModelCollider<WinBeforeFinishTrigger>(tfs);
    }
    //HangingWinTile
    public static void Combine_HangingWinTile(Transform[] tfs)
    {
        CombineModelCollider<HangingWinTile>(tfs);
    }

    protected static void CombineModelCollider2<T>(Transform[] tfs, float centerY) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentCount<T>(t, 2);
            bool h = t.GetComponentsInChildren<Transform>().Length == 3;
            if (a && b && h)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, centerY, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (model != null && collider != null && d && e && f)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        if (bc.center == Vector3.zero)
                        {
                            bc.center = new Vector3(0, centerY, 0);
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                    }
                    if (CheckTargetComponentCount<Transform>(model, 1))
                    {
                        DestroyGameObject(model.gameObject);
                    }
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    
    #endregion

    #region 节点合并 

    /// <summary>
    /// 创建 WideTilePro
    /// 1：每个Transform 必须 绑有 BoxCollider 、 WideTilePro ; localPosition.y 必须一致，旋转、缩放一致。
    /// 2：每个WideTilePro的 grid 必须一至。
    /// 2：BoxCollider . center  / size 一致。
    /// </summary>
    /// <param name="tfs"></param>
    /// <param name="minPos"></param>
    /// <param name="maxPos"></param>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    protected static void Combine_new_wideTilePro(Transform[] tfs, Vector3 minPos, Vector3 maxPos, Vector3 minSize, Vector3 maxSize)
    {
        Transform child = tfs[0];
        BoxCollider cbc = child.GetComponent<BoxCollider>();
        WideTilePro cwtp = child.GetComponent<WideTilePro>();

        GameObject go = new GameObject(tfs[0].name + "_new");
        go.transform.SetParent(tfs[0].parent);
        float newGoPosX = minPos.x + (maxPos.x - minPos.x) * 0.5f;
        float newGoPosZ = minPos.z + (maxPos.z - minPos.z) * 0.5f;
        go.transform.localPosition = new Vector3(newGoPosX, child.localPosition.y, newGoPosZ);

        float sizeX = (maxSize.x - minSize.x);
        float sizeZ = cbc.size.z * tfs.Length;

        BoxCollider newBC = go.AddComponent<BoxCollider>();
        newBC.isTrigger = true;
        newBC.center = cbc.center;
        newBC.size = new Vector3(sizeX, cbc.size.y, sizeZ);

        WideTilePro newFC = go.AddComponent<WideTilePro>();
        newFC.m_id = 546;
        newFC.m_gridId = cwtp.m_gridId;
        newFC.data.Width = sizeX;
        newFC.data.Height = sizeZ;
        newFC.data.BeginDistance = -(sizeZ / 2);
        newFC.data.ResetDistance = (sizeZ / 2);
        newFC.data.IfCheckMissTile = true;
        SetTilePoint(newFC, go.transform);

        int length = tfs.Length;
        for (int i = 0; i < length; i++)
        {
            Transform t = tfs[i];
            t.SetParent(go.transform, true);
        }
        List<string> missList = new List<string>();
        for (int i = 0; i < length; i++)
        {
            Transform t = tfs[i];
            string sd = string.Empty;
            string lx = (t.localPosition.x * 10000).ToString("0.0000000000");
            string lz = (t.localPosition.z * 10000).ToString("0.0000000000");
            string sx = (t.GetComponent<BoxCollider>().size.x * 10000).ToString("0.0000000000");
            string sz = (t.GetComponent<BoxCollider>().size.z * 10000).ToString("0.0000000000");

            lx = lx.Substring(0, lx.IndexOf('.'));
            lz = lz.Substring(0, lz.IndexOf('.'));
            sx = sx.Substring(0, sx.IndexOf('.'));
            sz = sz.Substring(0, sz.IndexOf('.'));

            sd = string.Format("{0},{1},{2},{3}", lx, lz, sx, sz);
            missList.Add(sd);

            DestroyGameObject(t.gameObject);
        }
        newFC.data.MissTiles = missList.ToArray();
    }

    #region MoveAllDirTile
    /// <summary>
    /// 1：先执行 MoveAllDirTile_move_forward 。
    /// 2：分多次 选中与 NormalTile 相连，并且高度一致的 多个 MoveAllDirTile。
    /// 3：执行 Combine_block_MoveAllDirTile_change_NormalTile。
    /// 4：把 MoveAllDirTile 都转换成 NormalTile 后， NormalTile 转 wideTilepro。
    /// </summary>
    /// <param name="tfs"></param>
    public static void Combine_block_MoveAllDirTile_change_NormalTile(Transform[] tfs, bool normalTile = true)
    {
        List<MoveAllDirTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CheckComponents<MoveAllDirTile>(tfs, out tileList, out colList))
        {
            Transform child = tfs[0];
            BoxCollider cbc = child.GetComponent<BoxCollider>();
            MoveAllDirTile ctile = child.GetComponent<MoveAllDirTile>();

            foreach (Transform t in tfs)
            {
                //if (t.localPosition.y != child.localPosition.y)
                //{
                //    Debug.LogError(" 高度位置 参数不一致 ");
                //    return;
                //}
            }
            foreach (BoxCollider bc in colList)
            {
                if (bc.center != cbc.center || bc.size != cbc.size)
                {
                    Debug.LogError(" 碰撞体参数不一致 ");
                    return;
                }
            }
            foreach (MoveAllDirTile tile in tileList)
            {
                if (tile.m_gridId != ctile.m_gridId)
                {
                    Debug.LogError(" 脚本gid不一致 ");
                    return;
                }
            }

            if (normalTile)
            {
                Vector3 newCenter = new Vector3(0, -0.2f, 0);
                Vector3 newSize = new Vector3(1, 0.4f, 1);
                foreach (Transform t in tfs)
                {
                    GameObject newGo = new GameObject(GetNewName(t, "Tile_ShaMo_Road02_new"));
                    newGo.transform.SetParent(t.parent);
                    newGo.transform.localPosition = t.localPosition;
                    newGo.transform.localRotation = t.localRotation;
                    newGo.transform.localScale = t.localScale;

                    NormalTile nt = newGo.AddComponent<NormalTile>();
                    nt.m_id = 502;
                    nt.m_gridId = ctile.m_gridId;
                    nt.point.m_x = Mathf.FloorToInt(t.localPosition.x);
                    nt.point.m_y = Mathf.FloorToInt(t.localPosition.z);

                    BoxCollider bc = newGo.AddComponent<BoxCollider>();
                    bc.center = newCenter;
                    bc.size = newSize;
                    bc.isTrigger = true;
                }
            }

            foreach (BoxCollider bc in colList)
            {
                DestroyComponent(bc);
            }

            if (normalTile)
                Debug.Log("新增 NormalTile 对象: " + tfs.Length + "  删除 BoxCollider 组件: " + colList.Count);
            else
                Debug.Log("  删除 BoxCollider 组件: " + colList.Count);
        }
    }

    public static void Combine_block_NormalTile_Change_WideTipePro(Transform[] tfs, string staticParentName = "Midground_Static")
    {
        List<NormalTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CheckComponents<NormalTile>(tfs, out tileList, out colList))
        {
            Transform child = tfs[0];
            BoxCollider cbc = child.GetComponent<BoxCollider>();
            NormalTile ctile = child.GetComponent<NormalTile>();

            Vector3 minPos = child.localPosition;
            Vector3 maxPos = child.localPosition;

            foreach (Transform t in tfs)
            {
                if (t.localPosition.y != child.localPosition.y)
                {
                    Debug.LogError(" 高度位置 参数不一致 ");
                    return;
                }
                minPos.x = Mathf.Min(t.localPosition.x, minPos.x);
                minPos.y = Mathf.Min(t.localPosition.y, minPos.y);
                minPos.z = Mathf.Min(t.localPosition.z, minPos.z);

                maxPos.x = Mathf.Max(t.localPosition.x, maxPos.x);
                maxPos.y = Mathf.Max(t.localPosition.y, maxPos.y);
                maxPos.z = Mathf.Max(t.localPosition.z, maxPos.z);
            }
            foreach (BoxCollider bc in colList)
            {
                if (bc.center != cbc.center || bc.size != cbc.size)
                {
                    Debug.LogError(" 碰撞体参数不一致 ");
                    return;
                }
            }
            foreach (NormalTile tile in tileList)
            {
                if (tile.m_gridId != ctile.m_gridId)
                {
                    Debug.LogError(" 脚本gid不一致 ");
                    return;
                }
            }

            float newPosX = (minPos.x + maxPos.x) * 0.5f;
            float newPosY = minPos.y;
            float newPosZ = (minPos.z + maxPos.z) * 0.5f;

            GameObject newGo = new GameObject(GetNewName(child, "AiJi_WideTilePro(Clone)_new"));
            newGo.transform.SetParent(child.parent);
            newGo.transform.localPosition = new Vector3(newPosX, newPosY, newPosZ);

            float size_x = maxPos.x - minPos.x + 1;
            float size_y = cbc.size.y;
            float size_z = maxPos.z - minPos.z + 1;

            BoxCollider newBc = newGo.AddComponent<BoxCollider>();
            newBc.center = cbc.center;
            newBc.size = new Vector3(size_x, size_y, size_z);

            WideTilePro wtp = newGo.AddComponent<WideTilePro>();
            wtp.m_id = 546;
            wtp.m_gridId = ctile.m_gridId;
            wtp.point.m_x = Mathf.FloorToInt(newGo.transform.localPosition.x);
            wtp.point.m_y = Mathf.FloorToInt(newGo.transform.localPosition.z);
            wtp.data.Width = size_x;
            wtp.data.Height = size_z;
            wtp.data.BeginDistance = -(size_z / 2);
            wtp.data.ResetDistance = (size_z / 2);
            wtp.data.IfCheckMissTile = true;
            List<string> miss = CheckInBigCollider(newGo.transform, minPos, maxPos, tileList);
            wtp.data.MissTiles = miss.ToArray();

            int length = tfs.Length;
            for (int i = 0; i < length; i++)
            {
                Transform t = tfs[i];
                if (t.GetComponent<MeshFilter>() != null && !string.IsNullOrEmpty(staticParentName))
                {
                    BoxCollider bc = t.GetComponent<BoxCollider>();
                    DestroyComponent(bc);

                    NormalTile nt = t.GetComponent<NormalTile>();
                    DestroyComponent(nt);

                    
                    StaticEditorFlags flags = GameObjectUtility.GetStaticEditorFlags(t.gameObject);
                   //没有包含 光照的对象 ，可以移出Grid，并标记静态。
                    if (!GameObjectUtility.AreStaticEditorFlagsSet(t.gameObject, StaticEditorFlags.LightmapStatic))
                    {
                        flags |= StaticEditorFlags.BatchingStatic;
                        t.SetParent(GameObject.Find(staticParentName).transform, true);
                        GameObjectUtility.SetStaticEditorFlags(t.gameObject, flags);
                    }
                }
                else
                {
                    DestroyGameObject(t.gameObject);
                }
            }
        }
        DebugLog();
    }
    #endregion
    /// <summary>
    /// 生成 不规则 WideTilePro 数据
    /// </summary>
    /// <param name="tfs"></param>
    public static void Combine_block_WideTilePro_Anomaly(Transform[] tfs)
    {
        List<WideTilePro> tileList = new List<WideTilePro>();
        List<BoxCollider> colliderList = new List<BoxCollider>();
        foreach (Transform t in tfs)
        {
            WideTilePro tile = t.GetComponent<WideTilePro>();
            if (tile != null)
            {
                tileList.Add(tile);
            }
            BoxCollider bc = t.GetComponent<BoxCollider>();
            if (bc != null)
            {
                colliderList.Add(bc);
            }
        }
        if (tileList.Count != tfs.Length || colliderList.Count != tfs.Length)
        {
            Debug.LogError("脚本/碰撞器数量不对");
            return;
        }

        float px = tfs[0].transform.localPosition.x;
        float py = tfs[0].transform.localPosition.y;
        foreach (Transform t in tfs)
        {
            if (t.localPosition.y != py)
            {
                Debug.LogError("位置 参数不一致");
                return;
            }
            if (t.localRotation.eulerAngles != Vector3.zero)
            {
                Debug.LogError("旋转 参数不一致");
                return;
            }
            if (t.localScale != Vector3.one)
            {
                Debug.LogError("缩放 参数不一致");
                return;
            }
        }

        Vector3 center = colliderList[0].center;
        Vector3 size = colliderList[0].size;
        foreach (BoxCollider bc in colliderList)
        {
            if (bc.center != center || bc.size.z != size.z || bc.size.y != size.y)
            {
                Debug.LogError("center 参数不一致");
                return;
            }
        }
        foreach (WideTilePro tile in tileList)
        {
            if (tile.data.Height != 1 || tile.m_gridId != tileList[0].m_gridId)
            {
                Debug.LogError("脚本参数不一致");
                return;
            }
        }

        Vector3 minPos = tfs[0].localPosition;
        Vector3 maxPos = tfs[0].localPosition;
        Vector3 minSize = colliderList[0].size;
        Vector3 maxSize = colliderList[0].size;

        int length = tfs.Length;
        for (int i = 0; i < length; i++)
        {
            Transform t = tfs[i];
            BoxCollider bc = colliderList[i];
            if (i == 0)
            {
                minPos = t.localPosition;
                maxPos = t.localPosition;
                minPos.x = t.localPosition.x - bc.size.x * 0.5f;
                maxPos.x = t.localPosition.x + bc.size.x * 0.5f;

                minSize = bc.size;
                maxSize = bc.size;
                minSize.x = t.localPosition.x - bc.size.x * 0.5f;
                maxSize.x = t.localPosition.x + bc.size.x * 0.5f;
            }
            else
            {
                minPos.x = Mathf.Min(minPos.x, t.localPosition.x - bc.size.x * 0.5f);
                minPos.z = Mathf.Min(minPos.z, t.localPosition.z);
                maxPos.x = Mathf.Max(maxPos.x, t.localPosition.x + bc.size.x * 0.5f);
                maxPos.z = Mathf.Max(maxPos.z, t.localPosition.z);

                minSize.x = Mathf.Min(minSize.x, t.localPosition.x - bc.size.x * 0.5f);
                maxSize.x = Mathf.Max(maxSize.x, t.localPosition.x + bc.size.x * 0.5f);
            }
        }

        GameObject go = new GameObject(tfs[0].name + "_new");
        go.transform.SetParent(tfs[0].parent);
        float newGoPosX = minPos.x + (maxPos.x - minPos.x) * 0.5f;
        float newGoPosZ = minPos.z + (maxPos.z - minPos.z) * 0.5f;
        go.transform.localPosition = new Vector3(newGoPosX, py, newGoPosZ);

        float sizeX = (maxSize.x - minSize.x);
        float sizeZ = size.z * tfs.Length;

        BoxCollider newBC = go.AddComponent<BoxCollider>();
        newBC.isTrigger = true;
        newBC.center = center;
        newBC.size = new Vector3(sizeX, size.y, sizeZ);

        WideTilePro newFC = go.AddComponent<WideTilePro>();
        newFC.m_id = 546;
        newFC.m_gridId = tileList[0].m_gridId;
        newFC.data.Width = sizeX;
        newFC.data.Height = sizeZ;
        newFC.data.BeginDistance = -(sizeZ / 2);
        newFC.data.ResetDistance = (sizeZ / 2);
        newFC.data.IfCheckMissTile = true;
        SetTilePoint(newFC, go.transform);

        for (int i = 0; i < length; i++)
        {
            Transform t = tfs[i];
            t.SetParent(go.transform, true);
        }
        List<string> missList = new List<string>();
        for (int i = 0; i < length; i++)
        {
            Transform t = tfs[i];
            string sd = string.Empty;
            string lx = (t.localPosition.x * 10000).ToString("0.0000000000");
            string lz = (t.localPosition.z * 10000).ToString("0.0000000000");
            string sx = (t.GetComponent<BoxCollider>().size.x * 10000).ToString("0.0000000000");
            string sz = (t.GetComponent<BoxCollider>().size.z * 10000).ToString("0.0000000000");

            lx = lx.Substring(0, lx.IndexOf('.'));
            lz = lz.Substring(0, lz.IndexOf('.'));
            sx = sx.Substring(0, sx.IndexOf('.'));
            sz = sz.Substring(0, sz.IndexOf('.'));

            sd = string.Format("{0},{1},{2},{3}", lx, lz, sx, sz);
            missList.Add(sd);

            DestroyGameObject(t.gameObject);
        }
        newFC.data.MissTiles = missList.ToArray();
    }

    public static void Combine_block_FreeCollideTile(Transform[] tfs)
    {
        List<FreeCollideTile> tileList = new List<FreeCollideTile>();
        List<BoxCollider> colliderList = new List<BoxCollider>();
        foreach (Transform t in tfs)
        {
            FreeCollideTile tile = t.GetComponent<FreeCollideTile>();
            if (tile != null)
            {
                tileList.Add(tile);
            }
            BoxCollider bc = t.GetComponent<BoxCollider>();
            if (bc != null)
            {
                colliderList.Add(bc);
            }
        }
        if (tileList.Count != tfs.Length || colliderList.Count != tfs.Length)
        {
            Debug.LogError("脚本/碰撞器数量不对");
            return;
        }
        float px = tfs[0].transform.localPosition.x;
        float py = tfs[0].transform.localPosition.y;
        foreach (Transform t in tfs)
        {
            if (t.localPosition.x != px || t.localPosition.y != py)
            {
                Debug.LogError("位置不一致");
                return;
            }
            if (t.localRotation.eulerAngles != Vector3.zero)
            {
                Debug.LogError("旋转不一致");
                return;
            }
            if (t.localScale != Vector3.one)
            {
                Debug.LogError("缩放不一致");
                return;
            }
        }
        Vector3 center = colliderList[0].center;
        Vector3 size = colliderList[0].size;
        foreach (BoxCollider bc in colliderList)
        {
            if (bc.center != center || bc.size != size)
            {
                Debug.LogError("center 不一致");
                return;
            }
        }
        foreach (FreeCollideTile tile in tileList)
        {
            if (tile.data.TileWidth != 5 || tile.data.TileHeight != 1 || tile.m_gridId != tileList[0].m_gridId)
            {
                Debug.LogError("脚本参数不一致");
                return;
            }
        }

        Transform childTf = tfs[0];
        float sposz = childTf.localPosition.z;
        float eposz = childTf.localPosition.z;
        foreach (Transform t in tfs)
        {
            sposz = Mathf.Min(sposz, t.localPosition.z);
            eposz = Mathf.Max(eposz, t.localPosition.z);
        }
        float posz = sposz + (eposz - sposz) / 2;
        float height = tfs.Length;

        GameObject go = new GameObject(childTf.name + "_new");
        go.transform.SetParent(childTf.parent);
        go.transform.localPosition = new Vector3(px, py, posz);

        BoxCollider newBC = go.AddComponent<BoxCollider>();
        newBC.isTrigger = true;
        newBC.center = center;
        newBC.size = new Vector3(5, 0.4f, height);

        FreeCollideTile newFC = go.AddComponent<FreeCollideTile>();
        newFC.m_id = 524;
        newFC.m_gridId = tileList[0].m_gridId;
        newFC.data.TileWidth = tileList[0].data.TileWidth;
        newFC.data.TileHeight = height;

        string sx = px.ToString("0.0000000000");
        sx = sx.Substring(0, sx.IndexOf('.'));
        string sz = posz.ToString("0.0000000000");
        sz = sz.Substring(0, sz.IndexOf('.'));

        newFC.point.m_x = int.Parse(sx);
        newFC.point.m_y = int.Parse(sz);

        int length = tfs.Length;
        for (int i = 0; i < length; i++)
        {
            DestroyGameObject(tfs[i].gameObject);
        }
        DebugLog();
    }


    



    #endregion

    #region 通用

    public static bool CheckComponents<T>(Transform[] tfs, out List<T> tileList, out List<BoxCollider> colList)
    {
        tileList = new List<T>();
        colList = new List<BoxCollider>();
        foreach (Transform t in tfs)
        {
            T tile = t.GetComponent<T>();
            if (tile != null)
            {
                tileList.Add(tile);
            }
            BoxCollider bc = t.GetComponent<BoxCollider>();
            if (bc != null)
            {
                colList.Add(bc);
            }
        }
        if (tileList.Count != tfs.Length || colList.Count != tfs.Length)
        {
            Debug.LogError("脚本/碰撞器数量不对");
            return false;
        }
        return true;
    }

    public static string GetNewName(Transform sourceNameTf, string prefix)
    {
        return prefix + sourceNameTf.name.Substring(sourceNameTf.name.LastIndexOf('_'));
    }

    #endregion

}

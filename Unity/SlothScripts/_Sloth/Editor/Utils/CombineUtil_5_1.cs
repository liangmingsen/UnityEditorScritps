using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineUtil_5_1 : CombineColliderUtil
{
    #region 节点优化
    //MultiSegmentAnimationTile
    public static void Combine_MultiSegmentAnimationTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model" });
            bool b = CheckTargetComponentAndChildsCount<MultiSegmentAnimationTile>(t, 4);
            if (a && b)
            {
                Transform model = t.Find("model");
                bool d = CheckLocalPositionIsZero(model, new Vector3(0,-2,0));
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model);
                if (!d && (model.transform.localPosition.x == model.transform.localPosition.z) && model.transform.localPosition.z == 0)
                {
                    float valY = model.transform.localPosition.y;
                    t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y + valY, t.localPosition.z);
                    model.transform.localPosition = Vector3.zero;
                    d = true;
                }
                if (d && e && f)
                {
                    Transform collider = model.Find("collider");
                    Transform modelChild = model.Find("model");
                    if (collider != null && modelChild != null)
                    {
                        bool d1 = CheckLocalPositionIsZero(collider);
                        bool e1 = CheckLocalRotationIsZero(collider);
                        bool f1 = CheckLocalScaleIsOne(collider);
                        BoxCollider bc = collider.GetComponent<BoxCollider>();
                        bool d2 = CheckColliderCenterXZ(bc);
                        if (d1 && e1 && f1 && d2)
                        {
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);

                            SetParent(modelChild, t);
                            DestroyGameObject(model.gameObject);
                            continue;
                        }
                    }
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //NormalEnemy 第一版优化
    public static void Combine_NormalEnemy_easy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = t.GetComponent<NormalEnemy>() != null;
            if (b)
            {
                Transform model = t.Find("model");
                bool d = CheckLocalPositionIsZero(model);
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model);

                Transform triggerPoint = t.Find("triggerPoint");
                bool b1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                if (b1 && triggerPoint != null)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
                if (model != null && d && e && f && b1)
                {
                    CopyComponent<MeshFilter>(model, t);
                    CopyComponent<MeshRenderer>(model, t);
                    DestroyGameObject(model.gameObject);

                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    //AnimEnemy  WeirdDream_XiaoZhen_Star_UP
    public static void Combine_AnimEnemy_WeirdDream_XiaoZhen_Star_UP(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<AnimEnemy>(t, 3);
            if (b)
            {
                Transform collider = t.Find("collider");
                bool b1 = CheckTargetComponentAndChildsCount<Transform>(collider, 1);
                if (b1)
                {
                    DestroyGameObject(collider.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    //AnimEnemyPro 
    public static void Combine_AnimEnemyPro_easy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = t.GetComponent<AnimEnemyPro>() != null;
            if (b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool b1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                if (b1)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
                Transform collider = t.Find("collider");
                if(collider != null)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool b2 = CheckColliderCenterXZ(bc);
                        bool b3 = CheckColliderSizeXYZ(bc);
                        if (collider.transform.localPosition.x == 0 && collider.transform.localPosition.z == 0)
                        {
                            bc.center = collider.localPosition;
                            bc.size = collider.localScale;
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                            continue;
                        }
                    }
                    else
                    {
                        DestroyGameObject(collider.gameObject);
                        continue;
                    }
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    //TriggerEffectJumpTile 
    public static void Combine_TriggerEffectJumpTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = t.GetComponent<TriggerEffectJumpTile>() != null;
            if (b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool b1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                if (b1)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();
                if(bc != null)
                {
                    bool d = CheckLocalPositionIsZero(collider);
                    bool e = CheckLocalRotationIsZero(collider);
                    bool f = CheckLocalScaleIsOne(collider);
                    if(d && e && f)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                        }
                        else
                        {
                            Debug.LogError("BoxCollider条件不符:  " + t.name);
                        }
                    }
                }
                Transform model = t.Find("model");
                bool b2 = CheckTargetComponentAndChildsCount<AudioSource>(model, 4) || CheckTargetComponentAndChildsCount<AudioSource>(model, 3);
                bool d2 = CheckLocalPositionIsZero(model);
                bool e2 = CheckLocalRotationIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);
                if (b2 && d2 && e2 && f2)
                {
                    CopyComponent<AudioSource>(model, t);

                    Transform state2 = model.Find("state2");
                    SetParent(state2, t);

                    Transform state1 = model.Find("state1");
                    SetParent(state1, t);

                    DestroyGameObject(model.gameObject);
                }
                else
                {
                    Debug.LogError("model 条件不符:  " + t.name);
                }
            }
        }
        DebugLog();
    }
    //EmissionTile
    public static void Combine_EmissionTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<EmissionTile>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (model != null && collider != null && d && e && f)
                {
                    BoxCollider bc = collider.GetComponent<BoxCollider>();
                    if (bc != null)
                    {
                        bool g = CheckColliderCenterXZ(bc);
                        if (g)
                        {
                            CopyComponent<BoxCollider>(collider, t);
                            DestroyGameObject(collider.gameObject);
                            continue;
                        }
                    }
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //JumpDistanceTrigger
    public static void Combine_JumpDistanceTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<JumpDistanceTrigger>(t, 3);
            if (a && b)
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
    //DoorEnemy
    public static void Combine_DoorEnemy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model1", "collider", "model2", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<DoorEnemy>(t, 12);
            if(a && b)
            {
                Transform collider = t.Find("collider");
                bool c = CheckTargetComponentAndChildsCount<Transform>(collider, 1);

                Transform triggerPoint = t.Find("triggerPoint");
                bool c1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                if (c)
                {
                    DestroyGameObject(collider.gameObject);
                }
                if (c1)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }

                Transform model1 = t.Find("model1");
                bool c2 = CheckTargetComponentAndChildsCount<Transform>(model1, 2);
                bool d2 = CheckLocalPositionIsZero(model1);
                bool e2 = CheckLocalRotationIsZero(model1);
                bool f2 = CheckLocalScaleIsOne(model1);
                if(c2 && d2 && e2 && f2)
                {
                    Transform XiaoZhen_LuDeng01_Off = model1.Find("XiaoZhen_LuDeng01_Off");
                    if(XiaoZhen_LuDeng01_Off != null)
                    {
                        SetParent(XiaoZhen_LuDeng01_Off, t);
                        DestroyGameObject(model1.gameObject);
                    }
                    else
                    {
                        Debug.LogError(" model1 条件不符:  " + t.name);
                    }
                }
                Transform model2 = t.Find("model2");
                bool c3 = CheckTargetComponentAndChildsCount<Transform>(model2, 7);
                bool d3 = CheckLocalPositionIsZero(model2);
                bool e3 = CheckLocalRotationIsZero(model2);
                bool f3 = CheckLocalScaleIsOne(model2);
                if (c3 && d3 && e3 && f3)
                {
                    Transform Effect = model2.Find("Effect");
                    if (Effect != null)
                    {
                        SetParentAndName(Effect, t, "model2");
                        DestroyGameObject(model2.gameObject, 2);

                        continue;
                    }
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //AnimEffectTrigger
    public static void Combine_AnimEffectTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = t.GetComponent<AnimEffectTrigger>() != null;
            if (a)
            {
                Rigidbody rb = t.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    DestroyComponent(rb);
                }
            }
        }
        DebugLog();
    }
    //TrapRootTile
    public static void Combine_TrapRootTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<TrapRootTile>(t, 5);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if(d && e && f)
                {
                    BoxCollider[] bcs = collider.GetComponents<BoxCollider>();
                    foreach (BoxCollider bc in bcs)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(bc);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(t.gameObject);
                    }
                    DestroyGameObject(collider.gameObject);

                    while (model.childCount > 0)
                    {
                        SetParent(model.GetChild(0), t);
                    }
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //RS2.FreeMoveTile
    public static void Combine_FreeMoveTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "path" });
            bool b = CheckTargetComponentAndChildsCount<RS2.FreeMoveTile>(t, 9);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                Transform path = t.Find("path");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (path != null && collider != null && d && e && f)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

                    DestroyGameObject(path.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //InputResetTrigger
    public static void Combine_InputResetTrigger(Transform[] tfs)
    {
        CombineModelCollider<InputResetTrigger>(tfs);
    }
    //CrownFragment
    public static void Combine_CrownFragment(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "effect", "audio" });
            bool b = CheckTargetComponentAndChildsCount<CrownFragment>(t, 8);
            if (a && b)
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
    //JumpDistanceQTETile
    public static void Combine_JumpDistanceQTETile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool c = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<JumpDistanceQTETile>(t, 3);
            if (c && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckTargetComponentCount<AudioSource>(model, 2);

                if (d2 && collider != null && d && e && f)
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
    //DiamondAward
    public static void Combine_DiamondAward(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "effect", "audio" });
            bool b = CheckTargetComponentAndChildsCount<DiamondAward>(t, 8);
            if (a && b)
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
    //RS2.WorldThemesTrigger
    public static void Combine_WorldThemesTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<RS2.WorldThemesTrigger>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider, new Vector3(2.61f, 0, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                BoxCollider bc = collider.GetComponent<BoxCollider>();
                bool g = CheckColliderCenterXZ(bc);

                bool d2 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                if (model != null && collider != null && d && d2 && e && f && g)
                {
                    Vector3 tpos = t.localPosition;
                    t.localPosition = tpos + collider.localPosition;
                    RS2.WorldThemesTrigger be = t.GetComponent<RS2.WorldThemesTrigger>();
                    SetTilePoint(be, t);

                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

                    DestroyGameObject(model.gameObject);

                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //RS2.ChangeCameraEffectByNameTrigger
    public static void Combine_ChangeCameraEffectByNameTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] {"collider" });
            bool b = CheckTargetComponentAndChildsCount<RS2.ChangeCameraEffectByNameTrigger>(t, 2);
            if (a && b)
            {
                Transform collider = t.Find("collider");

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                BoxCollider bc = collider.GetComponent<BoxCollider>();
                bool g = CheckColliderCenterXZ(bc);

                if (collider != null && d && e && f && g)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //PathToMoveByPetTrigger 
    public static void Combine_PathToMoveByPetTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<PathToMoveByPetTrigger>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 1.5f,0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool d2 = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                bool b2 = CheckColliderCenterXYZ(bc);

                if (d && e && f && d2 && bc)
                {
                    bc.center = collider.localPosition;
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

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.224f, 0));
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
                            bc.center = new Vector3(0, 0.224f, 0);
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
    //PathToMoveByUnpredictableDiamondAwardTrigger
    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(tfs);
    }
    //RS2.ElevatorTrigger
    public static void Combine_ElevatorTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<RS2.ElevatorTrigger>(t, 3);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();
                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                if (collider != null && d && e && f && g)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        CombineModelCollider<CameraAnimTrigger>(tfs);
    }
    //DisableInputTrigger
    public static void Combine_DisableInputTrigger(Transform[] tfs)
    {
        CombineModelCollider<DisableInputTrigger>(tfs);
    }
    //RS2.OpenFollowTrigger
    public static void Combine_OpenFollowTrigger(Transform[] tfs)
    {
        Combine_public_collider_model<RS2.OpenFollowTrigger>(tfs);
    }
    //EnableInputTrigger
    public static void Combine_EnableInputTrigger(Transform[] tfs)
    {
        Combine_public_collider_model<EnableInputTrigger>(tfs);
    }
    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_BuyOutRebirthBoxTrigger(tfs);
    }
    //PathToMoveByRoleForLerpTrigger
    public static void Combine_PathToMoveByRoleForLerpTrigger(Transform[] tfs)
    {
        Combine_public_collider_model<PathToMoveByRoleForLerpTrigger>(tfs);
    }
    //WinBeforeFinishTrigger
    public static void Combine_WinBeforeFinishTrigger(Transform[] tfs)
    {
        Combine_public_collider_model<WinBeforeFinishTrigger>(tfs);
    }
    //NormalTile
    public static void Combine_NormalTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<NormalTile>(t, 3);
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
                    if (CheckTargetComponentCount<Transform>(model, 1))
                    {
                        DestroyGameObject(model.gameObject);
                        continue;
                    }
                    else
                    {
                        bool g2 = CheckTargetComponentCount<MeshFilter>(model, 3);
                        if (g2)
                        {
                            if(!GameObjectUtility.AreStaticEditorFlagsSet(model.gameObject, StaticEditorFlags.LightmapStatic))
                            {
                                SetParentAndName(model, GameObject.Find("Midground").transform, t.name);
                                continue;
                            }
                            else
                            {
                                Debug.LogError("有光照不能动==> :  " + t.name);
                            }
                        }
                    }
                    
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //MoveAllDirTile
    public static void Combine_MoveAllDirTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<MoveAllDirTile>(t, 3);
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
                            continue;
                        }
                    }
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //MoveAllDirTile
    public static void Combine_MoveAllDirTile_2(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model"});
            bool b = CheckTargetComponentAndChildsCount<MoveAllDirTile>(t, 2);
            if (a && b)
            {
                Transform model = t.Find("model");

                bool d = CheckLocalPositionIsZero(model);
                bool f = CheckLocalScaleIsOne(model);

                if (model != null && d && f)
                {
                    CopyComponent<MeshFilter>(model, t);
                    CopyComponent<MeshRenderer>(model, t);
                    SetTransformRotation(model, t);
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    #endregion

    #region 节点合并


    #region MoveAllDirTile
    /// <summary>
    /// 1：先执行 MoveAllDirTile_move_forward 。
    /// 2：分多次 选中与 NormalTile 相连，并且高度一致的 多个 MoveAllDirTile。
    /// 3：执行 Combine_block_MoveAllDirTile_change_NormalTile。
    /// 4：把 MoveAllDirTile 都转换成 NormalTile 后， NormalTile 转 wideTilepro。
    /// </summary>
    /// <param name="tfs"></param>
    public static void Combine_block_MoveAllDirTile_change_NormalTile(Transform[] tfs)
    {
        List<MoveAllDirTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CombineUtil_4_1.CheckComponentCounts<MoveAllDirTile>(tfs, out tileList, out colList))
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

            Vector3 newCenter = cbc.center;
            Vector3 newSize = cbc.size;
            foreach (Transform t in tfs)
            {
                MeshFilter[] mfs = t.GetComponentsInChildren<MeshFilter>();
                GameObject newGo = null;
                NormalTile nt = null;
                if (mfs != null && mfs.Length > 0)
                {
                    BoxCollider oldBc = t.GetComponent<BoxCollider>();
                    if (oldBc != null) DestroyComponent(oldBc);

                    newGo = new GameObject(CombineUtil_4_1.GetNewName(t, "Tile_P0_Road01_Water_new"));
                    newGo.transform.SetParent(t.parent);
                    newGo.transform.localPosition = t.localPosition;
                    newGo.transform.localRotation = t.localRotation;
                    newGo.transform.localScale = t.localScale;
                    nt = newGo.AddComponent<NormalTile>();

                    BoxCollider bc = newGo.AddComponent<BoxCollider>();
                    bc.center = newCenter;
                    bc.size = newSize;
                    bc.isTrigger = true;

                    Debug.Log("新建 一个 NormalTile，旧的 MoveAllDirTile 保留 但删除 BoxCollider" + t.name + " --- " + newGo.name);
                }
                else
                {
                    newGo = t.gameObject;
                    nt = newGo.AddComponent<NormalTile>();

                    MoveAllDirTile mdt = t.GetComponent<MoveAllDirTile>();
                    if (mdt != null) DestroyComponent(mdt);

                    Debug.Log("MoveAllDirTile 换 NormalTile"+ t.name);
                }

                nt.m_id = 34;
                nt.m_gridId = ctile.m_gridId;
                SetTilePoint(nt, newGo.transform);
            }
        }
    }

    public static void Combine_block_NormalTile_Change_WideTipePro(Transform[] tfs, string staticParentName = "Midground_Static")
    {
        List<NormalTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CombineUtil_4_1.CheckComponentCounts<NormalTile>(tfs, out tileList, out colList))
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

            GameObject newGo = new GameObject(CombineUtil_4_1.GetNewName(child, "AiJi_WideTilePro(Clone)_new"));
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
                if (t.GetComponent<MeshFilter>() != null)
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

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineUtil_Thief_2_H : CombineColliderUtil
{
    #region 优化节点

    //RS2.CarriageRider CoupleMirrorDancer 往后不处理


    //RS2.CoupleDetachTrigger
    public static void Combine_CoupleDetachTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.CoupleDetachTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //RS2.CoupleFollowTrigger
    public static void Combine_CoupleFollowTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "triggerPoint", "role" });
            bool b = CheckTargetComponentAndChildsCount<RS2.CoupleFollowTrigger>(t, 52);
            if (a && b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e2 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                if (d2 && e2 && d && e && f && g)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
    }

    //RS2.PathToMoveFixedByRoleAsFragementTrigger
    public static void Combine_PathToMoveFixedByRoleAsFragementTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.PathToMoveFixedByRoleAsFragementTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }

    //RS2.ForcePosTIle
    public static void Combine_ForcePosTIle(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "model" });
            bool b = CheckTargetComponentAndChildsCount<RS2.ForcePosTIle>(t, 9);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                bool d1 = CheckTargetComponentCount<Transform>(model, 1);
                bool e1 = model.GetComponentsInChildren<MeshFilter>().Length == 0;

                if (d && e && f && g && d1 && e1)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject, 7);
                }
            }
        }
    }

    //TwoEffectTriggerSpecial
    public static void Combine_TwoEffectTriggerSpecial(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "activeTrigger", "model", "beginTrigger", "triggerPoint", "distanceEffect", "triggerEffect" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerSpecial>(t, 11);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform beginTrigger = t.Find("beginTrigger");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");

                Transform distanceEffectEffect = t.Find("distanceEffect/effect");
                Transform triggerEffectEffect = t.Find("triggerEffect/effect");

                bool d1 = CheckTargetComponentCount<Transform>(model, 1);
                bool e1 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                bool d2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e2 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                bool d3 = CheckTargetComponentCount<Transform>(triggerEffect, 1);
                bool e3 = triggerEffect.childCount == 1;

                bool d4 = CheckTargetComponentCount<Transform>(distanceEffect, 1);
                bool e4 = distanceEffect.childCount == 1;

                if (d1 && e1 && d2 && e2 && d3 && e3 && d4 && e4)
                {
                    SetParentAndName(triggerEffectEffect, t, "triggerEffect");
                    SetParentAndName(distanceEffectEffect, t, "distanceEffect");

                    DestroyGameObject(model.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    DestroyGameObject(triggerEffect.gameObject);
                    DestroyGameObject(distanceEffect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //RS2.CraneTile  不处理

    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        CombineUtil_Pharaohs_1_E.Combine_BuyOutRebirthBoxTrigger(tfs);
    }

    //NormalDropEnemy
    public static void Combine_NormalDropEnemy(Transform[] tfs)
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalDropEnemy(tfs);
    }

    //RS2.WorldThemesTrigger
    public static void Combine_WorldThemesTrigger(Transform[] tfs)
    {
        Combine_destory_model<RS2.WorldThemesTrigger>(tfs);
    }

    //RS2.FreeMoveDiamondByCouple
    public static void Combine_FreeMoveDiamondByCouple(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "award", "trigger" });
            bool b = CheckTargetComponentAndChildsCount<RS2.FreeMoveDiamondByCouple>(t, 9);
            if (a && b)
            {
                Transform award = t.Find("award");
                Transform trigger = t.Find("trigger");

                Transform effect = award.Find("effect");
                Transform tx_chufa = award.Find("effect/tx_chufa");
                Transform collider = award.Find("collider");
                Transform audio = award.Find("audio");

                if (effect != null && audio != null && collider != null && tx_chufa)
                {
                    CopyComponent<AudioSource>(audio, collider);
                    SetParentAndName(tx_chufa, award, "effect");

                    DestroyGameObject(effect.gameObject);
                    DestroyGameObject(audio.gameObject);
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
            bool b = CheckTargetComponentAndChildsCount<DiamondAward>(t, 7);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                Transform effect = t.Find("effect");
                Transform audio = t.Find("audio");

                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider, new Vector3(0, 0.096f, 0));
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                bool d3 = CheckLocalPositionIsZero(effect);
                bool e3 = CheckLocalRotationIsZero(effect);
                bool f3 = CheckLocalScaleIsOne(effect);
                Transform tx_chufa = effect.Find("tx_chufa");

                if (d && e && f && g && d3 && e3 && f3)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

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

    //CrownFragment
    public static void Combine_CrownFragment(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_CrownFragment(tfs);
    }

    //RS2.AnimEnemyProByCouple
    public static void Combine_AnimEnemyProByCouple(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<RS2.AnimEnemyProByCouple>(t, 7) || CheckTargetComponentAndChildsCount<RS2.AnimEnemyProByCouple>(t, 15);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");

                bool d1 = CheckTargetComponentCount<Transform>(collider, 1);
                bool e1 = CheckTargetComponentAndChildsCount<Transform>(collider, 1);

                bool d2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e2 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                if (d1 && e1 && d2 && e2)
                {
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
                Debug.LogError("条件不符 :  " + t.name);
            }
        }
        DebugLog();
    }

    //CurvedBendBoxTrigger
    public static void Combine_CurvedBendBoxTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CurvedBendBoxTrigger>(tfs, new Vector3(0, 4, 0));
    }

    //InputResetTrigger
    public static void Combine_InputResetTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<InputResetTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //SwingingRopeTriggerBox  不处理

    //RS2.CraneJumpTile  不处理

    //RS2.DanceTogetherTrigger
    public static void Combine_DanceTogetherTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.DanceTogetherTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //DropDieTrigger
    public static void Combine_DropDieTrigger(Transform[] tfs)
    {
        Combine_destory_model<DropDieTrigger>(tfs);
    }

    //RS2.RoleChangeMoodByEvent
    public static void Combine_RoleChangeMoodByEvent(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.RoleChangeMoodByEvent>(tfs, new Vector3(0, 1.5f, 0));
    }

    //RoleAnimatiorTrigger
    public static void Combine_RoleAnimatiorTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RoleAnimatiorTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }

    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CameraAnimTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //CoupleAnimatorTrigger
    public static void Combine_CoupleAnimatorTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CoupleAnimatorTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //TwoEffectTriggerPro count == 10
    public static void Combine_TwoEffectTriggerPro_10(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint", "distanceEffect", "triggerEffect" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 10);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");

                bool d2 = distanceEffect.childCount == 1;
                bool e2 = triggerEffect.childCount == 1;

                Transform d_eff = distanceEffect.GetChild(0);
                Transform t_eff = triggerEffect.GetChild(0);

                bool d1 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                if (d2 && e2 && d_eff && t_eff)
                {
                    SetParentAndName(d_eff, t, "distanceEffect");
                    SetParentAndName(t_eff, t, "triggerEffect");

                    DestroyGameObject(distanceEffect.gameObject);
                    DestroyGameObject(triggerEffect.gameObject);
                }

                if (!model.gameObject.activeSelf)
                {
                    DestroyGameObject(model.gameObject);
                }
                else
                {
                    bool d3 = CheckTargetComponentCount<Transform>(model, 1);
                    bool e3 = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                    if (d3 && e3)
                    {
                        DestroyGameObject(model.gameObject);
                    }
                }

                DestroyGameObject(triggerPoint.gameObject);

                BoxCollider bc = collider.GetComponent<BoxCollider>();
                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);
                if (d && e && f && g)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                }
            }
        }
        DebugLog();
    }

    //TwoEffectTriggerPro count == 11
    public static void Combine_TwoEffectTriggerPro_11(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint", "distanceEffect", "triggerEffect" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 11);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");

                Transform d_eff = distanceEffect.GetChild(0);
                Transform t_eff = triggerEffect.GetChild(0);

                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                bool d1 = CheckTargetComponentCount<Transform>(model, 1);
                bool e1 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                bool d2 = d_eff.childCount == 1;
                bool e2 = t_eff.childCount == 1;

                if (d && e && f && g && d1 && e1 && d2 && e2 && d_eff != null && t_eff != null)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    SetParentAndName(d_eff, t, "distanceEffect");
                    SetParentAndName(t_eff, t, "triggerEffect");

                    DestroyGameObject(distanceEffect.gameObject);
                    DestroyGameObject(triggerEffect.gameObject);
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    DestroyGameObject(model.gameObject);
                    continue;
                }
                Debug.LogError("条件不符 11 :  " + t.name);
            }
        }
        DebugLog();
    }

    //JumpDistanceQTETile
    public static void Combine_JumpDistanceQTETile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<JumpDistanceQTETile>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d1 = CheckLocalPositionIsZero(collider);
                bool e1 = CheckLocalRotationIsZero(collider);
                bool f1 = CheckLocalScaleIsOne(collider);
                bool g1 = CheckColliderCenterXZ(bc);

                MeshFilter mf = model.GetComponent<MeshFilter>();
                bool d2 = model.GetComponent<AudioSource>() != null;
                bool f2 = mf.sharedMesh == null;

                if (d2 && f2)
                {
                    CopyComponent<AudioSource>(model, t);
                    DestroyGameObject(model.gameObject);
                    continue;
                }
                if (d1 && e1 && f1 && g1)
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

    //AnimEnemyPro 
    public static void Combine_AnimEnemyPro_All(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint", "effect" });
            if (a)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform effect = t.Find("effect");
                Transform triggerPoint = t.Find("triggerPoint");

                bool d4 = effect.childCount == 1;
                bool e4 = model.childCount == 1;

                Transform modelChild = model.GetChild(0);
                Transform effectChild = effect.GetChild(0);

                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool c = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                bool d = CheckTargetComponentCount<Transform>(triggerPoint, 1);

                bool d1 = CheckLocalPositionIsZero(model);
                bool e1 = CheckLocalRotationIsZero(model);
                bool f1 = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(effect);
                bool e2 = CheckLocalRotationIsZero(effect);
                bool f2 = CheckLocalScaleIsOne(effect);

                bool d3 = CheckLocalPositionIsZero(collider);
                bool e3 = CheckLocalRotationIsZero(collider);
                bool f3 = CheckLocalScaleIsOne(collider);
                bool g3 = CheckColliderCenterXZ(bc);

                if (d3 && e3 && f3 && g3)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                }
                if (d2 && e2 && f2 && d4 && effectChild != null)
                {
                    SetParentAndName(effectChild, t, "effect");
                    DestroyGameObject(effect.gameObject);
                }
                if (d1 && e1 && f1 && e4 && modelChild != null)
                {
                    SetParentAndName(modelChild, t, "model");
                    DestroyGameObject(model.gameObject);
                }
                if (c && d)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
                continue;
            }

            bool b = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint" });
            if (b)
            {
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");

                bool c = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                bool d = CheckTargetComponentCount<Transform>(triggerPoint, 1);

                bool c1 = CheckTargetComponentAndChildsCount<Transform>(collider, 1);
                bool d1 = CheckTargetComponentCount<Transform>(collider, 1);

                if (c && d && c1 && d1)
                {
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //NormalEnemy
    public static void Combine_NormalEnemy(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<NormalEnemy>(tfs, new Vector3(0, 0, 0));
    }

    //FreeCollideTile
    public static void Combine_FreeCollideTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = CheckTargetComponentAndChildsCount<FreeCollideTile>(t, 9) ||
                     CheckTargetComponentAndChildsCount<FreeCollideTile>(t, 7);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool c = CheckTargetComponentCount<Transform>(model, 1);
                bool d = CheckTargetComponentAndChildsCount<Transform>(model, 5) ||
                         CheckTargetComponentAndChildsCount<Transform>(model, 7);

                int modelCount = model.childCount + 1;

                bool e = model.GetComponentsInChildren<MeshFilter>().Length <= 0;

                bool c1 = CheckLocalPositionIsZero(collider, new Vector3(0, 0, 0));
                bool d1 = CheckLocalRotationIsZero(collider);
                bool e1 = CheckLocalScaleIsOne(collider);
                bool f1 = CheckColliderCenterXZ(bc);

                if (c && d && e && c1 && d1 && e1 && f1)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(model.gameObject, modelCount);
                    DestroyGameObject(collider.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //EmissionTile
    public static void Combine_EmissionTile(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<EmissionTile>(tfs, new Vector3(0, 0, 0));
    }
    #endregion

    #region 合并节点

    //合 EmissionTile
    public static void Combine_block_EmissionTile(Transform[] tfs)
    {
        List<EmissionTile> tileList = new List<EmissionTile>();
        List<BoxCollider> colliderList = new List<BoxCollider>();
        foreach (Transform t in tfs)
        {
            EmissionTile tile = t.GetComponent<EmissionTile>();
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
            if (bc.center != center || bc.size != size || size != Vector3.one)
            {
                Debug.LogError("center 不一致");
                return;
            }
        }
        EmissionTile fTile = tileList[0];
        foreach (EmissionTile tile in tileList)
        {
            if (tile.m_gridId != fTile.m_gridId)
            {
                Debug.LogError("脚本参数不一致");
                return;
            }
        }

        Transform childTf = tfs[0];
        float sposz = childTf.localPosition.z;
        float eposz = childTf.localPosition.z;

        float sposx = childTf.localPosition.x;
        float eposx = childTf.localPosition.x;

        foreach (Transform t in tfs)
        {
            sposz = Mathf.Min(sposz, t.localPosition.z);
            eposz = Mathf.Max(eposz, t.localPosition.z);

            sposx = Mathf.Min(sposx, t.localPosition.x);
            eposx = Mathf.Max(eposx, t.localPosition.x);
        }
        float posz = sposz + (eposz - sposz) / 2;
        float posx = sposx + (eposx - sposx) / 2;

        float height = tfs.Length;

        GameObject go = new GameObject(childTf.name + "_new");
        go.transform.SetParent(childTf.parent);
        go.transform.localPosition = new Vector3(posx, py, posz);

        BoxCollider newBC = go.AddComponent<BoxCollider>();
        newBC.isTrigger = true;
        newBC.center = center;
        newBC.size = new Vector3((eposx - sposx) + 1, size.y, (eposz - sposz) + 1);

        EmissionTile newFC = go.AddComponent<EmissionTile>();
        newFC.m_id = fTile.m_id;
        newFC.m_gridId = fTile.m_gridId;

        string sx = px.ToString("0.0000000000");
        sx = sx.Substring(0, sx.IndexOf('.'));
        string sz = posz.ToString("0.0000000000");
        sz = sz.Substring(0, sz.IndexOf('.'));

        newFC.point.m_x = int.Parse(sx);
        newFC.point.m_y = int.Parse(sz);

        int length = tfs.Length;
        for (int i = length-1; i >=0 ; i--)
        {
            Transform tf = tfs[i];
            if (tf.GetComponentsInChildren<MeshFilter>().Length == 0)
            {
                DestroyGameObject(tfs[i].gameObject);
            }
            else
            {
                BoxCollider bc = tf.GetComponentInChildren<BoxCollider>();
                if (bc != null)
                {
                    DestroyComponent(bc);
                }
            }
        }

        DebugLog();
    }

    //合 FreeCollideTile
    public static void Combine_block_FreeCollideTile(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_block_FreeCollideTile(tfs);
    }

   public static void Combine_block_FreeCollideTile2()
    {

    }


    #endregion

}

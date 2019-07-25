using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineUtil_Jazz_E : CombineColliderUtil
{
    #region 优化节点

    public static void ResetParentToCustom(Transform[] tfs)
    {
        GameObject custom = GameObject.Find(@"Midground/Custom");
        foreach (Transform tf in tfs)
        {
            tf.SetParent(custom.transform);
        }
    }

    //Jazz_Tile_xiaohao_normal(Clone)
    public static void ResetXiaoHaoNormalTile(Transform[] tfs)
    {
        GameObject temp = AssetDatabase.LoadAssetAtPath<GameObject>(@"Assets\_RS2Art\Art\Levels\Fantasia_Jazz_N\Model\FBX\Custom\Waltz_Tile_xiaohao_01_normal.prefab");
        foreach (Transform tf in tfs)
        {
            if (tf.childCount != 1)
            {
                Debug.LogError("childcount must be 2! name:" + tf.name);
                continue;
            }

            Transform child1 = tf.GetChild(0);
            // Transform child2 = tf.GetChild(1);
            if (child1 != null)
            {
                GameObject.DestroyImmediate(child1.gameObject);
            }
            // if (child2 != null)
            // {
            //     GameObject.DestroyImmediate(child2.gameObject);
            // }

            GameObject newChild = GameObject.Instantiate(temp);
            newChild.transform.SetParent(tf);
            newChild.transform.localPosition = Vector3.zero;
            newChild.transform.localScale = Vector3.one;
            newChild.transform.localEulerAngles = Vector3.zero;
        }
    }

    //Jazz_Tile_xiaohao_jump(Clone)
    public static void ResetXiaoHaoJumpTile(Transform[] tfs)
    {
        GameObject temp = AssetDatabase.LoadAssetAtPath<GameObject>(@"Assets\_RS2Art\Art\Levels\Fantasia_Jazz_N\Model\FBX\Custom\Waltz_Tile_xiaohao_01_jump.prefab");
        foreach (Transform tf in tfs)
        {
            if (tf.childCount != 1)
            {
                Debug.LogError("childcount must be 1! name:" + tf.name);
                continue;
            }

            Transform preChild = tf.GetChild(0);
            if (preChild != null)
            {
                GameObject.DestroyImmediate(preChild.gameObject);
            }

            GameObject newChild = GameObject.Instantiate(temp);
            newChild.transform.SetParent(tf);
            newChild.transform.localPosition = Vector3.zero;
            newChild.transform.localScale = Vector3.one;
            newChild.transform.localEulerAngles = Vector3.zero;
        }
    }

    public static void ResetYuePuTile(Transform[] tfs)
    {

        foreach (Transform tf in tfs)
        {
            Transform yuepuBao001 = tf.Find("model/model/Jazz_yuepu_bao010");
            if (yuepuBao001 != null)
            {
                // yuepuBao001.gameObject.SetActive(false);
                GameObject.DestroyImmediate(yuepuBao001.gameObject);
            }

            bool changeToSelect = true;
            Transform yuepuBao = tf.Find("model/model/Jazz_yuepu_bao");
            if (yuepuBao != null)
            {
                // yuepuBao.gameObject.SetActive(false);   
                // GameObject.DestroyImmediate(yuepuBao.gameObject);
                changeToSelect = false;
            }

            Transform yuepuHou = tf.Find("model/model/Jazz_yuepu_hou014");
            if (yuepuHou != null)
            {
                Vector3 lc = yuepuHou.localScale;
                lc.x = lc.y = lc.z = 1;
                yuepuHou.localScale = lc;
                Vector3 lp = yuepuHou.localPosition;
                lp.x = lp.y = lp.z = 0;
                yuepuHou.localPosition = lp;
                yuepuHou.gameObject.SetActive(true);
                if (changeToSelect)
                {
                    yuepuHou.name = "Jazz_yuepu_hou014_change";
                }
            }
        }
    }

    public static void ResetDanHuangGuan(Transform[] tfs)
    {
        foreach (Transform tf in tfs)
        {
            Transform model = tf.Find("model");
            Vector3 _lc = model.localScale;
            _lc.x = _lc.y = _lc.z = 1;
            model.localScale = _lc;
            Vector3 _lp = model.localPosition;
            _lp.x = _lp.y = _lp.z = 0;
            model.localPosition = _lp;
            model.gameObject.SetActive(true);
        }
    }

    //HangingWinTile
    public static void Combine_HangingWinTile(Transform[] tfs)
    {
        Combine_destory_model<HangingWinTile>(tfs);
    }
    //WinBeforeFinishTrigger
    public static void Combine_WinBeforeFinishTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<WinBeforeFinishTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //PathToMoveByRoleForLerpTrigger
    public static void Combine_PathToMoveByRoleForLerpTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<PathToMoveByRoleForLerpTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }
    //CrownFromFragment
    public static void Combine_CrownFromFragment(Transform[] tfs)
    {
        CombineUtil_Pharaohs_1_E.Combine_CrownFromFragment(tfs);
    }
    //PathToMoveByUnpredictableCrownAwardTrigger
    public static void Combine_PathToMoveByUnpredictableCrownAwardTrigger(Transform[] tfs)
    {
        Combine_Destroy_Audio_path_11<PathToMoveByUnpredictableCrownAwardTrigger>(tfs);
    }
    //EnableInputTrigger
    public static void Combine_EnableInputTrigger(Transform[] tfs)
    {
        Combine_destory_model<EnableInputTrigger>(tfs);
    }
    //RS2.OpenFollowTrigger
    public static void Combine_OpenFollowTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.OpenFollowTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }
    //DisableInputTrigger
    public static void Combine_DisableInputTrigger(Transform[] tfs)
    {
        Combine_destory_model<DisableInputTrigger>(tfs);
    }

    //DesertGateWay     NormalPathVehicle   RS2.NormalSkateboardVehicle   不处理

    //PathToMoveByRoleTrigger
    public static void Combine_PathToMoveByRoleTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<PathToMoveByRoleTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }
    //RoleAnimatiorTrigger
    public static void Combine_RoleAnimatiorTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RoleAnimatiorTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //PathGuideTrigger  不处理

    //RS2.RoleMoveLimitTrigger
    public static void Combine_RoleMoveLimitTrigger(Transform[] tfs)
    {
        CombineModelCollider<RS2.RoleMoveLimitTrigger>(tfs);
    }
    //RelativeDisplacementMotionTriggerBox 不处理
    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_BuyOutRebirthBoxTrigger(tfs);
    }
    //RS2.ChangeCameraEffectByNameTrigger
    public static void Combine_ChangeCameraEffectByNameTrigger(Transform[] tfs)
    {
        Combine_CopyCollider_2<RS2.ChangeCameraEffectByNameTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //PathToMoveByUnpredictableDiamondAwardTrigger
    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Transform[] tfs)
    {
        Combine_Destroy_Audio_path_11<PathToMoveByUnpredictableDiamondAwardTrigger>(tfs);
    }

    //DepartVehicleTrigger
    public static void Combine_DepartVehicleTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<DepartVehicleTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //CurvedBendBoxTrigger
    public static void Combine_CurvedBendBoxTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CurvedBendBoxTrigger>(tfs, new Vector3(0, 4.0f, 0));
    }

    //CrownFragment
    public static void Combine_CrownFragment(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_CrownFragment(tfs);
    }
    //InputResetTrigger
    public static void Combine_InputResetTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<InputResetTrigger>(tfs, Vector3.zero);
    }
    //RS2.WorldThemesTrigger
    public static void Combine_WorldThemesTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.WorldThemesTrigger>(tfs, Vector3.zero);
    }
    //WideTilePro
    public static void Combine_WideTilePro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = CheckTargetComponentAndChildsCount<WideTilePro>(t, 3) || CheckTargetComponentAndChildsCount<WideTilePro>(t, 2);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                if (model != null)
                {
                    bool c = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                    bool d = CheckTargetComponentCount<Transform>(model, 1);

                    if (c && d)
                    {
                        DestroyGameObject(model.gameObject);
                    }
                }

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

    //LeftRightRotateSendTrigger
    public static void Combine_LeftRightRotateSendTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<LeftRightRotateSendTrigger>(tfs, Vector3.zero);
    }
    //DiamondAward
    public static void Combine_DiamondAward(Transform[] tfs)
    {
        CombineUtil_4_1.Combine_DiamondAward(tfs);
    }

    //LeftRightRotateListenTrigger  龙脉所在，强动必崩

    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CameraAnimTrigger>(tfs, Vector3.zero);
    }
    //PathGuideListenTrigger    龙脉所在，强动必崩

    //PathGuideSendTrigger
    public static void Combine_PathGuideSendTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<PathGuideSendTrigger>(tfs, Vector3.zero);
    }

    //TwoEffectTriggerPro
    public static void Combine_TwoEffectTriggerPro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint", "distanceEffect", "triggerEffect" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 9);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");

                Transform d_eff = distanceEffect.Find("effect");
                Transform t_eff = triggerEffect.Find("effect");

                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool g = CheckColliderCenterXZ(bc);

                bool d1 = CheckTargetComponentCount<AudioSource>(model, 2);
                bool e1 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                if (d && e && f && g && d1 && e1)
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
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //SwitchSendTrigger
    public static void Combine_SwitchSendTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<SwitchSendTrigger>(tfs, Vector3.zero);
    }

    //NormalEnemy
    public static void Combine_NormalEnemy(Transform[] tfs)
    {
        Combine_destory_model<NormalEnemy>(tfs);
    }
    //EffectEnemy 龙脉所在，强动必崩

    //SwitchListenTrigger
    public static void Combine_SwitchListenTrigger(Transform[] tfs)
    {
        Combine_Destroy_TriggerPoint(tfs);
    }
    //DropDieTrigger
    public static void Combine_DropDieTrigger(Transform[] tfs)
    {
        Combine_destory_model<DropDieTrigger>(tfs);
    }
    //SynchronizedAnimationMidground   
    public static void Combine_SynchronizedAnimationMidground(Transform[] tfs)
    {
        Combine_Destroy_TriggerPoint(tfs);
    }
    //JumpDistanceTrigger   
    public static void Combine_JumpDistanceTrigger(Transform[] tfs)
    {
        Combine_ModelAudio_collider_3_zero<JumpDistanceTrigger>(tfs, Vector3.zero);
    }
    //JumpDistanceQTETile  Jazz_Tile_xiaohao_jump  count = 6
    public static void Combine_JumpDistanceQTETile_Jazz_Tile_xiaohao_jump(Transform[] tfs)
    {
        Combine_CopyCollider<JumpDistanceQTETile>(tfs, Vector3.zero);
    }
    //JumpDistanceQTETile  Jazz_Tile_Jump_Empty1x1  count = 3
    public static void Combine_JumpDistanceQTETile_Jazz_Tile_Jump_Empty1x1(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<JumpDistanceQTETile>(tfs, Vector3.zero);
    }
    //AnimEnemyPro  Jazz_Enemy_yuepu_05
    public static void Combine_AnimEnemyPro_Jazz_Enemy_yuepu_05(Transform[] tfs)
    {
        Combine_CopyCollider<AnimEnemyPro>(tfs, Vector3.zero);
    }
    //AnimEnemyPro  destroy triggerPoint 
    public static void Combine_AnimEnemyPro_Destroy_TriggerPoint(Transform[] tfs)
    {
        Combine_Destroy_TriggerPoint(tfs);
    }
    //MultiSegmentAnimationTile  destroy collider 
    public static void Combine_MultiSegmentAnimationTile_Destroy_Collider(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            Transform collider = collider = t.Find("collider");
            if (collider == null)
            {
                collider = t.Find("model/collider");
            }
            if (collider != null)
            {
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = collider.localPosition.x + collider.localPosition.z == 0;
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (d2 && e2 && f2 && g2)
                {
                    bc.center = new Vector3(bc.center.x, collider.localPosition.y + bc.center.y, bc.center.z);
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    continue;
                }
                Debug.LogError("条件不符:  " + t.name);
            }
        }
        DebugLog();
    }
    //MultiSegmentAnimationTile  Jazz_MultiSegmentAnimationTile_Piano_Fly count = 5
    public static void Combine_MultiSegmentAnimationTile_5(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model" });
            bool b = CheckTargetComponentAndChildsCount<MultiSegmentAnimationTile>(t, 5);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform collider = model.Find("collider");
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
                Debug.LogError("条件不符:  " + t.name);
            }
        }
        DebugLog();
    }
    //MultiSegmentAnimationTile  Jazz_MultiSegmentAnimationTile_danhuangguan count = 4
    public static void Combine_MultiSegmentAnimationTile_4(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model" });
            bool b = CheckTargetComponentAndChildsCount<MultiSegmentAnimationTile>(t, 4);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform childModel = model.Find("model");
                Transform collider = model.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d1 = CheckLocalPositionIsZero(model);
                bool e1 = CheckLocalRotationIsZero(model);
                bool f1 = CheckLocalScaleIsOne(model);
                bool g1 = CheckTargetComponentCount<Transform>(model, 1);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (d2 && e2 && f2 && g2 && d1 && e1 && f1 && g1)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    SetParent(childModel, t);

                    DestroyGameObject(model.gameObject, 2);
                    continue;
                }
                Debug.LogError("条件不符:  " + t.name);
            }
        }
        DebugLog();
    }

    #endregion

    #region 合并节点

    //MultiSegmentAnimationTile
    public static void Combine_MultiSegmentAnimationTile_To_NormalTile_Block(Transform[] tfs)
    {
        List<MultiSegmentAnimationTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CheckComponentCounts<MultiSegmentAnimationTile>(tfs, out tileList, out colList) && CheckTransform_posY_rot_scale(tfs)
            && CheckBoxcollider_Center_SizeZY_(colList) && CheckBaseElement_tileId(tileList))
        {
            Vector3 pos = Vector3.zero;
            Vector3 size = Vector3.zero;
            Vector3 minPos = Vector3.zero;
            Vector3 maxPos = Vector3.zero;

            CalculateMulti_1x1_WideTileProToBlockSize(tfs, colList, ref pos, ref size, ref minPos, ref maxPos);

            float cx = colList[0].size.x;
            float cz = colList[0].size.z;

            int cx2 = Mathf.FloorToInt(cx);
            int cz2 = Mathf.FloorToInt(cz);

            GameObject newGo = CreateNewGameobjectNormalTileAndCollider(tfs[0], "Fate_tile_Normal(Clone)", 451, pos, size, new Vector3(cx - cx2, 0, cz - cz2));

            int length = colList.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                DestroyComponent(colList[i]);
            }
        }
    }


    #endregion

}

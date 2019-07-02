using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineUtil_6_1 : CombineColliderUtil
{
    #region 合并节点
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
    //DisableInputTrigger
    public static void Combine_DisableInputTrigger(Transform[] tfs)
    {
        Combine_destory_model<DisableInputTrigger>(tfs);
    }
    //RS2.CloseFollowTrigger
    public static void Combine_CloseFollowTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.CloseFollowTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }
    //RS2.CameraClipTrigger
    public static void Combine_CameraClipTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.CameraClipTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //RS2.DropDieForwordTrigger
    public static void Combine_DropDieForwordTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.DropDieForwordTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //PathToMoveByUnpredictableCrownAwardTrigger
    public static void Combine_PathToMoveByUnpredictableCrownAwardTrigger(Transform[] tfs)
    {
        Combine_PathToMoveByUnpredictableDiamondAwardTrigger(tfs);
    }
    //RS2.DropDieStaticTrigger
    public static void Combine_DropDieStaticTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.DropDieStaticTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //RS2.OpenFollowTrigger
    public static void Combine_OpenFollowTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.OpenFollowTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }
    //JumpDirTrigger
    public static void Combine_JumpDirTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<JumpDirTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        Combine_CopyCollider<BuyOutRebirthBoxTrigger>(tfs);
    }
    //ShakeCameraTrigger
    public static void Combine_ShakeCameraTrigger(Transform[] tfs)
    {
        Combine_destory_model<ShakeCameraTrigger>(tfs);
    }
    //RS2.WorldThemesTrigger
    public static void Combine_WorldThemesTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.WorldThemesTrigger>(tfs, new Vector3(2.61f, 0, 0));
    }
    //RS2.RoleMoveLimitTrigger
    public static void Combine_RoleMoveLimitTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.RoleMoveLimitTrigger>(tfs, new Vector3(0, 0, 0));
    }
    //PathToMoveByUnpredictableDiamondAwardTrigger
    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio", "effect" });
            bool h = t.GetComponentsInChildren<Transform>().Length == 11;
            if (a && h)
            {
                Transform audio = t.Find("audio");
                bool d2 = CheckTargetComponentCount<AudioSource>(audio, 2);

                if (d2)
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
    //DiamondAward
    public static void Combine_DiamondAward(Transform[] tfs)
    {
        CombineUtil_5_1.Combine_DiamondAward(tfs);
    }
    //ChangeRailwaySpeedTrigger
    public static void Combine_ChangeRailwaySpeedTrigger(Transform[] tfs)
    {
        Combine_destory_model<ChangeRailwaySpeedTrigger>(tfs);
    }
    //CurvedBendBoxTrigger
    public static void Combine_CurvedBendBoxTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CurvedBendBoxTrigger>(tfs, new Vector3(0,4,0));
    }
    //DropDieTrigger
    public static void Combine_DropDieTrigger(Transform[] tfs)
    {
        Combine_destory_model<DropDieTrigger>(tfs);
    }
    //RoleAnimatiorTrigger
    public static void Combine_RoleAnimatiorTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RoleAnimatiorTrigger>(tfs, Vector3.zero);
    }
    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CameraAnimTrigger>(tfs, Vector3.zero);
    }
    //NormalTile 
    public static void Combine_NormalTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider" });
            bool b = CheckTargetComponentAndChildsCount<NormalTile>(t, 2);
            if (b)
            {
                Transform collider = t.Find("collider");
                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);

                if (d2 && e2 && f2)
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
    //EffectEnemy 
    public static void Combine_EffectEnemy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = false;
            bool b = false;
            if (CheckTargetComponentAndChildsCount<EffectEnemy>(t, 7))
            {
                a = true;
            }
            else if (CheckTargetComponentAndChildsCount<EffectEnemy>(t, 4))
            {
                a = true;
                b = true;
            }
            else if (CheckTargetComponentAndChildsCount<EffectEnemy>(t, 3))
            {
                a = true;
            }
            if (a)
            {
                Transform effect = t.Find("effect");
                for (int i = 0; i < effect.childCount; i++)
                {
                    SetParent(effect.GetChild(i), t);
                }
                DestroyGameObject(effect.gameObject);
            }
            if (b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool b1 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                bool b2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                if (b1 && b2)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
        DebugLog();
    }
    //RS2.RoleLineTrigger 
    public static void Combine_RoleLineTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RS2.RoleLineTrigger>(tfs, Vector3.zero);
    }
    //NormalEnemy 第一版优化
    public static void Combine_NormalEnemy_easy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<NormalEnemy>(t, 3);
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
    //MoveThreeEnemy all child 13
    public static void Combine_MoveThreeEnemy_13(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "path", "begin" });
            bool b = CheckTargetComponentAndChildsCount<MoveThreeEnemy>(t, 13);
            if (b)
            {
                Transform model = t.Find("model");
                Transform model2 = t.Find("model/model");
                Transform collider = t.Find("collider");
                Transform path = t.Find("path");
                Transform begin = t.Find("begin");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(model);
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);

                bool d3 = CheckLocalPositionIsZero(model2);
                bool e3 = CheckLocalRotationIsZero(model2);
                bool f3 = CheckLocalScaleIsOne(model2);

                if (d && e && f && d2 && e2 && f2 && d3 && e3 && f3)
                {
                    CopyComponent<MeshFilter>(model2, t);
                    CopyComponent<MeshRenderer>(model2, t);

                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject, 2);

                    DestroyGameObject(path.gameObject, 5);
                    DestroyGameObject(begin.gameObject, 4);

                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //JumpDistanceQTETile  
    public static void Combine_JumpDistanceQTETile(Transform[] tfs)
    {
        CombineUtil_5_1.Combine_JumpDistanceQTETile(tfs);
    }
    //MoveAllDirTile  Fate_Tile_white_move_R
    public static void Combine_MoveAllDirTile_Fate_Tile_white_move_R(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<MoveAllDirTile>(t, 4);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(model);
                bool e = CheckLocalRotationIsZero(model, new Vector3(0, 180, 0));
                bool f = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);

                Transform model2 = model.Find("model");

                if (d && e && f && d2 && e2 && f2 && model2 != null)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    SetParent(model2, t);

                    SetTransformRotation(model, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    //MoveAllDirTile  Fate_Tile_white_move_L
    public static void Combine_MoveAllDirTile_Fate_Tile_white_move_L(Transform[] tfs)
    {
        Combine_CopyCollider<MoveAllDirTile>(tfs);
    }

    //MoveAllDirTile  Fate_Tile_qipan_white_move
    public static void Combine_MoveAllDirTile_Fate_Tile_qipan_white_move(Transform[] tfs)
    {
        Combine_model_101<MoveAllDirTile>(tfs);
    }

    //WideTilePro
    public static void Combine_WideTilePro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider" });
            bool b = CheckTargetComponentAndChildsCount<WideTilePro>(t, 2);
            if (b)
            {
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                if (d && e && f)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //FreeCollideAnimTile all child 3
    public static void Combine_FreeCollideAnimTile_3(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<FreeCollideAnimTile>(t, 3);
            if (b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool b2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);

                if (b2)
                {
                    DestroyGameObject(triggerPoint.gameObject);

                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //FreeCollideAnimTile all child 4
    public static void Combine_FreeCollideAnimTile_4(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<FreeCollideAnimTile>(t, 4);
            if (b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);

                bool b2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);

                if(d && e && f && b2)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);

                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //MoveAllEnemy all child 14
    public static void Combine_MoveAllEnemy_14(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider (1)", "path", "begin" });
            bool b = CheckTargetComponentAndChildsCount<MoveAllEnemy>(t, 14);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider (1)");
                Transform path = t.Find("path");
                Transform begin = t.Find("begin");
                CapsuleCollider bc = collider.GetComponent<CapsuleCollider>();

                bool d = CheckLocalPositionIsZero(model);
                bool e = CheckLocalRotationIsZero(model);
                bool f = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider, new Vector3(0, 0.309f, 0));
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = bc.center == Vector3.zero;

                Transform model2 = model.Find("model/model");
            
                if (d && e && f && d2 && e2 && f2 && g2 && model2)
                {
                    SetParent(model2, t);

                    CopyComponent<CapsuleCollider>(collider, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject, 2);

                    DestroyGameObject(path.gameObject, 5);
                    DestroyGameObject(begin.gameObject, 4);

                    t.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.309f, 0);

                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //MoveAllEnemy all child 3
    public static void Combine_MoveAllEnemy_3(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<MoveAllEnemy>(t, 3);
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
                bool h2 = CheckColliderSizeXYZ(bc, new Vector3(0.65f, 4.6f, 0.65f));

                if (d && e && f && d2 && e2 && f2 && g2 && h2)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    CopyComponent<MeshFilter>(model, t);
                    CopyComponent<MeshRenderer>(model, t);

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(model.gameObject);

                    continue;
                }
                Debug.LogError("条件不满足: " + t.name);
            }
        }
        DebugLog();
    }
    //AnimEnemyPro - destroy - all - triggerPoint
    public static void Combine_AnimEnemyPro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            if(t.GetComponent<AnimEnemyPro>() != null)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool b = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool c = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);
                if(b && c)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
        DebugLog();
    }
    //EmissionTile
    public static void Combine_EmissionTile(Transform[] tfs)
    {
        Combine_model_101<EmissionTile>(tfs);
    }


    #region public combine

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
    public static void Combine_DestroyModel_CopyCollider_Count_3<T>(Transform[] tfs, Vector3 colPos) where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<T>(t, 3);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                bool c = CheckTargetComponentAndChildsCount<Transform>(model, 1);
                bool d = CheckTargetComponentCount<Transform>(model, 1);

                bool d2 = CheckLocalPositionIsZero(collider, colPos);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);

                if (c && d && d2 && e2 && f2)
                {
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

                if (d2 && e2 && f2)
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
    #endregion

    #endregion

    #region 合并网格
    //FreeCollideAnimTile   //带有动画控制 ，不要合
    
    //EmissionTile 2 NormalTile
    public static void Combine_Collider_EmissionTile_2_NormalTile(Transform[] tfs)
    {
        List<EmissionTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CombineUtil_4_1.CheckComponentCounts<EmissionTile>(tfs, out tileList, out colList))
        {
            foreach (Transform t in tfs)
            {
                GameObject newGo = CreateNewGameobjectNormalTileAndCollider(t,"Fate_tile_Normal(Clone)", 451);
                RemoveTileAndCollider(t);

                if(newGo != null)//修正
                {
                    newGo.transform.localScale = Vector3.one;
                    newGo.GetComponent<BoxCollider>().size = Vector3.one;
                }
            }
        }
    }
    //MoveAllDirTile 2 WideTilePro 
    public static void Combine_Collider_MoveAllDirTile_2_WideTilePro_5x1(Transform[] tfs)
    {
        List<MoveAllDirTile> tileList = null;
        List<BoxCollider> colList = null;
        if (CheckComponentCounts<MoveAllDirTile>(tfs, out tileList, out colList))
        {
            foreach (Transform t in tfs)
            {
                GameObject newGo = CreateGameobjectWideTileProAndCollider(t, "WideTilePro(Clone)", 449);
                RemoveCollider(t);
            }
        }
    }

    public static void ChangeWideTileProLocalScaleToOne(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = t.GetComponentsInChildren<MeshFilter>().Length == 0;
            bool b = t.localScale == new Vector3(0.5f,1,1);
            BoxCollider bc = t.GetComponent<BoxCollider>();
            if(a && b && bc != null)
            {
                t.localScale = Vector3.one;
                bc.size = new Vector3(bc.size.x * 0.5f, bc.size.y, bc.size.z);
            }
        }
    }

    /// <summary>
    /// 生成 不规则 WideTilePro 数据
    /// </summary>
    /// <param name="tfs"></param>
    public static void Combine_block_WideTilePro_Anomaly(Transform[] tfs)
    {
        List<BaseElement> tileList = null;
        List<BoxCollider> colList = null;

        bool a = CheckComponentCounts<BaseElement>(tfs, out tileList, out colList);
        bool b = CheckTransform_posY_rot_scale(tfs);
        bool c = CheckBoxcollider_Center_SizeZY_(colList);
        bool d = CheckBaseElement_tileId(tileList);

        if (a && b && c && d)
        {
            Vector3 newPos = Vector3.one;
            Vector3 newSize = Vector3.one;

            CalculateMulti_Xx1_WideTileProToBlockSize(tfs, colList, ref newPos, ref newSize);
            GameObject newGo = CombineMulti_Xx1_WideTileProToBlock(tfs[0], newPos, newSize, "WideTilePro(Clone)", 449);
            CombineMulti_Xx1_WideTileProToBlockSetDataTileList(tfs, newGo);

            BeginTagDestroyGameobject(tfs);
        }
        DebugLog();
    }

    #endregion

}

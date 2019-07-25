using RS2;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothCombineCheck : Editor
{
    #region 通用
    [MenuItem("Sloth/CombineCheck/Correct Collider Size")]
    static void CorrectColliderSizes()
    {
        CombineBase.CorrectColliderSize();
    }

    [MenuItem("Sloth/CombineCheck/Write Correct Collider Data")]
    static void WriteCorrectColliderSizeDatas()
    {
        CombineBase.WriteCorrectColliderSizeData();
    }

    [MenuItem("Sloth/CombineCheck/Check Combine Childs")]
    static void CheckCombineChilds()
    {
        CombineBase.CheckCombineChilds();
    }

    #endregion

    #region level 0
    [MenuItem("Sloth/CombineCheck/level0/PuGongYing")]
    static void CombinePuGongYing()
    {
        CombineUtil_0.Combine_PuGongYing();
    }
    [MenuItem("Sloth/CombineCheck/level0/Combine Collider Model")]
    static void CombineColliderModel()
    {
        CombineUtil_0.Combine_Collider_Model();
    }
    [MenuItem("Sloth/CombineCheck/level0/Combine Collider Audio")]
    static void CombineColliderAudio()
    {
        CombineUtil_0.Combine_Collider_Audio();
    }


    #endregion

    #region level 1
    [MenuItem("Sloth/CombineCheck/level1/copy collider")]
    static void CombineDelModelCopyCollidder()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.CombineDelModelCopyCollidder();
    }

    [MenuItem("Sloth/CombineCheck/level1/copy mesh copy collider")] // Home_Road01
    static void CombineCopyCollidderCopyMesh()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.CombineCopyCollidderCopyMesh();
    }

    [MenuItem("Sloth/CombineCheck/level1/copy Audio copy collider")] // Tile_P0_SuperJumpQTE(Clone)
    static void CombineCopyCollidderCopyAudio()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.CombineCopyCollidderCopyAudio();
    }

    [MenuItem("Sloth/CombineCheck/level1/copy mesh copy collider del path")] // FreeMoveTile_Home03
    static void CombineCopyCollidderCopyMeshDelPath()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.CombineCopyCollidderCopyMeshDelPath();
    }

    [MenuItem("Sloth/CombineCheck/level1/child node Replace Parent node")]
    static void ChildReplaceParentObj()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ChildReplaceParentObj();
    }

    //包含碱个子节点 model \ collider \ triggerPoint
    [MenuItem("Sloth/CombineCheck/level1/Replace Destroy node")]
    static void ReplaceAndDestroy()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ReplaceAndDestroy();
    }

    //包含三个子节点 包含碱个子节点 model \ effect0 \ effect1
    [MenuItem("Sloth/CombineCheck/level1/Replace Destroy PuGongYing effect")]
    static void ReplaceAndDestroyPuGongYingEffect()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ReplaceAndDestroyPuGongYingEffect();
    }

    //包含5个子节点 model \ distanceEffect \ triggerEffect \ triggerPoint \ collider
    [MenuItem("Sloth/CombineCheck/level1/Replace Destroy Two Effect Trigger Pro")]
    static void ReplaceAndDestroyTwoEffectTriggerPro()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ReplaceAndDestroyTwoEffectTriggerPro();
    }

    //包含3个子节点 model \ collider \ triggerPoint
    [MenuItem("Sloth/CombineCheck/level1/Replace Destroy Anim Enemy Pro")]
    static void ReplaceAndDestroyAnimEnemyPro()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ReplaceAndDestroyAnimEnemyPro();
    }

    //包含2个子节点 effect0 \ effect1
    [MenuItem("Sloth/CombineCheck/level1/Replace Destroy Dandelion Enemy Pu Gong Ying")]
    static void ReplaceAndDestroyDandelionEnemyPuGongYing()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.ReplaceAndDestroyDandelionEnemyPuGongYing();
    }

    //包含1个子节点 Home_dizhuan_001     
    [MenuItem("Sloth/CombineCheck/level1/Copy Destroy Home_Road03_Up")]  // Home_Road03_Up  Home_Road01_Up  Home_Road02_Up
    static void CopyAndDestroyHome_Road03_Up()
    {
        CombineUtil.IsCheck = true;
        CombineUtil.CopyAndDestroyHome_Road03_Up();
    }

    #endregion

    #region level 2   

    [MenuItem("Sloth/CombineCheck/level2/NormalTile")]  // NormalTile
    static void CombineNormalTile()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_NormalTile();
    }

    [MenuItem("Sloth/CombineCheck/level2/WideTilePro")]  // WideTilePro
    static void CombineWideTilePro()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_WideTilePro();
    }

    [MenuItem("Sloth/CombineCheck/level2/FreeCollideTile")]  // FreeCollideTile
    static void CombineFreeCollideTile()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_FreeCollideTile();
    }

    [MenuItem("Sloth/CombineCheck/level2/TwoEffectTriggerPro")]  // TwoEffectTriggerPro
    static void CombineTwoEffectTriggerPro()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_TwoEffectTriggerPro();
    }

    [MenuItem("Sloth/CombineCheck/level2/NormalEnemy")]  // NormalEnemy
    static void CombineNormalEnemy()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_NormalEnemy();
    }
    /// <summary>
    /// 有个别，位置有变化，改手动调整。
    /// </summary>
    [MenuItem("Sloth/CombineCheck/level2/DropDieTrigger")]  // DropDieTrigger
    static void CombineDropDieTrigger()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_Collider_Model<DropDieTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/ChangeCameraEffectByNameTrigger")]  // ChangeCameraEffectByNameTrigger
    static void CombineChangeCameraEffectByNameTrigger()
    {
        CombineUtil.IsCheck = true;
        CombineUtil_2.Combine_Collider<ChangeCameraEffectByNameTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/JumpDistanceQTETile")]  // JumpDistanceQTETile
    static void CombineJumpDistanceQTETile()
    {
        CombineUtil_2.Combine_JumpDistanceQTETile();
    }

    [MenuItem("Sloth/CombineCheck/level2/DisableInputTrigger")]  // DisableInputTrigger
    static void CombineDisableInputTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<DisableInputTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/RoleAnimatiorTrigger")]  // RoleAnimatiorTrigger
    static void CombineRoleAnimatiorTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<RoleAnimatiorTrigger>(true);
    }

    [MenuItem("Sloth/CombineCheck/level2/CameraAnimTrigger")]  // CameraAnimTrigger
    static void CombineCameraAnimTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<CameraAnimTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/ChangeRuntimeAnimatorControllerTrigger")]  // ChangeRuntimeAnimatorControllerTrigger
    static void CombineChangeRuntimeAnimatorControllerTrigger()
    {
        CombineUtil_2.Combine_Collider<ChangeRuntimeAnimatorControllerTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/AnimEnemyPro")]  // AnimEnemyPro
    static void CombineAnimEnemyPro()
    {
        CombineUtil_2.Combine_AnimEnemyPro();
    }

    [MenuItem("Sloth/CombineCheck/level2/WaltzStringLaser")]  // WaltzStringLaser
    static void CombineWaltzStringLaser()
    {
        CombineUtil_2.Combine_WaltzStringLaser();
    }

    [MenuItem("Sloth/CombineCheck/level2/WorldThemesTrigger")]  // WorldThemesTrigger
    static void CombineWorldThemesTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<WorldThemesTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/ChangeCameraEffectTrigger")]  // ChangeCameraEffectTrigger
    static void CombineChangeCameraEffectTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<ChangeCameraEffectTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/InputResetTrigger")]  // InputResetTrigger
    static void CombineInputResetTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<InputResetTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/EnableInputTrigger")]  // EnableInputTrigger
    static void CombineEnableInputTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<EnableInputTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/CurvedBendBoxTrigger")]  // CurvedBendBoxTrigger
    static void CombineCurvedBendBoxTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<CurvedBendBoxTrigger>(true);
    }

    [MenuItem("Sloth/CombineCheck/level2/WinBeforeFinishTrigger")]  // WinBeforeFinishTrigger
    static void CombineWinBeforeFinishTrigger()
    {
        CombineUtil_2.Combine_Collider_Model<WinBeforeFinishTrigger>(false);
    }

    [MenuItem("Sloth/CombineCheck/level2/PathToMoveByUnpredictableDiamondAwardTrigger")]  // PathToMoveByUnpredictableDiamondAwardTrigger
    static void CombinePathToMoveByUnpredictableDiamondAwardTrigger()
    {
        CombineUtil_2.Combine_PathToMoveByUnpredictableDiamondAwardTrigger();
    }

    [MenuItem("Sloth/CombineCheck/level2/EffectEnemy")]  // EffectEnemy
    static void CombineEffectEnemy()
    {
        CombineUtil_2.Combine_EffectEnemy();
    }

    [MenuItem("Sloth/CombineCheck/level2/Waltz_Tile_Piano_SuperJump_empty")]  // EffectEnemy
    static void CombineWaltz_Tile_Piano_SuperJump_empty()
    {
        CombineUtil_2.Combine_Waltz_Tile_Piano_SuperJump_empty();
    }

    #endregion

    #region level 3
    [MenuItem("Sloth/CombineCheck/level3/JumpDistanceQTETile")]  // JumpDistanceQTETile
    static void CombineLv3_JumpDistanceQTETile()
    {
        CombineUtil_3.Combine_JumpDistanceQTETile();
    }

    [MenuItem("Sloth/CombineCheck/level3/DoorEnemy")]
    static void CombineLv3_DoorEnemy()
    {
        CombineUtil_3.Combine_DoorEnemy();
    }

    [MenuItem("Sloth/CombineCheck/level3/DropDie")]
    static void CombineLv3_DropDie()
    {
        CombineUtil_3.Combine_DropDie();
    }

    [MenuItem("Sloth/CombineCheck/level3/Tile_Road")]
    static void CombineLv3_Tile_Road()
    {
        CombineUtil_3.Combine_Tile_Road();
    }

    [MenuItem("Sloth/CombineCheck/level3/Tile_DuBai_Star")]
    static void CombineLv3_Tile_DuBai_Star()
    {
        CombineUtil_3.Combine_Tile_DuBai_Star();
    }

    [MenuItem("Sloth/CombineCheck/level3/XiaoWangZi_Enemy_Road01")]
    static void CombineLv3_XiaoWangZi_Enemy_Road01()
    {
        CombineUtil_3.Combine_XiaoWangZi_Enemy_Road01();
    }

    [MenuItem("Sloth/CombineCheck/level3/model_and_collider")]
    static void Combine_model_and_collider()
    {
        CombineUtil_3.Combine_model_and_collider();
    }

    // [MenuItem("Sloth/CombineCheck/level3/checkMaterial")]
    // static void CombineLv3_checkMaterial()
    // {
    //     CombineUtil_3.Combine_CheckMaterial();
    // }

    [MenuItem("Sloth/CombineCheck/level3/JiaoTang_or_YanCong_or_fangzi_or_effectJump")]
    static void Combine_JiaoTang_or_YanCong_or_fangzi_or_effectJump()
    {
        CombineUtil_3.Combine_JiaoTang_or_YanCong_or_fangzi_or_effectJump();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Tile_XiaoZhen_Move")]
    static void Combine_Tile_XiaoZhen_Move()
    {
        CombineUtil_3_1.Combine_Tile_XiaoZhen_Move();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Tile_XiaoZhen_Move_Water")]
    static void Combine_Tile_XiaoZhen_Move_Water()
    {
        CombineUtil_3_1.Combine_Tile_XiaoZhen_Move_Water();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Tile_P0_TwoStepsJump_Start")]
    static void Combine_Tile_P0_TwoStepsJump_Start()
    {
        CombineUtil_3_1.Combine_Tile_P0_TwoStepsJump_Start();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Tile_Bug_or_StarDown")]
    static void Combine_Tile_Bug_or_StarDown()
    {
        CombineUtil_3.Combine_Tile_Bug_or_StarDown();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Just_Collider")]
    static void Combine_Just_Collider()
    {
        CombineUtil_3.Combine_Just_Collider();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_Award_Diamond")]
    static void Combine_Award_Diamond()
    {
        CombineUtil_3.Combine_Award_Diamond();
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine_FreeMoveTile_6")]
    static void Combine_FreeMoveTile_6()
    {
        CombineUtil_3_1.Combine_FreeMoveTile_6(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level3/Combine_FreeMoveTile_9")]
    static void Combine_FreeMoveTile_9()
    {
        CombineUtil_3_1.Combine_FreeMoveTile_9(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level3/Combine AnimEnemyPro triggerPoint")]
    static void Combine_AnimEnemyPro_triggerPoint()
    {
        CombineUtil_3_1.Combine_AnimEnemyPro_triggerPoint(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/level3/Combine MultiSegmentAnimationTile")]
    static void Combine_MultiSegmentAnimationTile()
    {
        CombineUtil_3_1.Combine_MultiSegmentAnimationTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level3/Combine HorizonMoveTile")]
    static void Combine_HorizonMoveTile()
    {
        CombineUtil_3_1.Combine_HorizonMoveTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level3/Combine JumpDistanceTrigger")]
    static void Combine_JumpDistanceTrigger_3()
    {
        CombineUtil_3_1.Combine_JumpDistanceTrigger(Selection.transforms);
    }
    #endregion

    #region level 4
    [MenuItem("Sloth/CombineCheck/level4/Combine NormalTile")]
    static void Combine_NormalTile()
    {
        CombineUtil_4_1.Combine_NormalTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine MoveAllDirTile")]
    static void Combine_MoveAllDirTile()
    {
        CombineUtil_4_1.Combine_MoveAllDirTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine MoveAllDirTile2")]
    static void Combine_MoveAllDirTile2()
    {
        CombineUtil_4_1.Combine_MoveAllDirTile2(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine WideTilePro")]
    static void Combine_WideTilePro()
    {
        CombineUtil_4_1.Combine_WideTilePro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine FreeCollideTile")]
    static void Combine_FreeCollideTile()
    {
        CombineUtil_4_1.Combine_FreeCollideTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine GlassRootTile")]
    static void Combine_GlassRootTile()
    {
        CombineUtil_4_1.Combine_GlassRootTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine GlassChildTile")]
    static void Combine_GlassChildTile()
    {
        CombineUtil_4_1.Combine_GlassChildTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine NormalJumpTile")]
    static void Combine_NormalJumpTile()
    {
        CombineUtil_4_1.Combine_NormalJumpTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine NormalEnemy AiJi_XiaPo_Zhu(Clone)")]
    static void Combine_NormalEnemy_AiJi_XiaPo_Zhu()
    {
        CombineUtil_4_1.Combine_NormalEnemy_AiJi_XiaPo_Zhu(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine NormalEnemy Enemy_Enpty(Clone)")]
    static void Combine_NormalEnemy_Enemy_Enpty()
    {
        CombineUtil_4_1.Combine_NormalEnemy_Enemy_Enpty(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine JumpDistanceQTETile")]
    static void Combine_JumpDistanceQTETile()
    {
        CombineUtil_4_1.Combine_JumpDistanceQTETile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine NormalDropEnemy")]
    static void Combine_NormalDropEnemy()
    {
        CombineUtil_4_1.Combine_NormalDropEnemy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine RoleAnimatiorTrigger")]
    static void Combine_RoleAnimatiorTrigger()
    {
        CombineUtil_4_1.Combine_RoleAnimatiorTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CameraAnimTrigger")]
    static void Combine_CameraAnimTrigger()
    {
        CombineUtil_4_1.Combine_CameraAnimTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine ShakeCameraTrigger")]
    static void Combine_ShakeCameraTrigger()
    {
        CombineUtil_4_1.Combine_ShakeCameraTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CrownFragment")]
    static void Combine_CrownFragment()
    {
        CombineUtil_4_1.Combine_CrownFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine DiamondAward")]
    static void Combine_DiamondAward()
    {
        CombineUtil_4_1.Combine_DiamondAward(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine TwoEffectTriggerPro")]
    static void Combine_TwoEffectTriggerPro()
    {
        CombineUtil_4_1.Combine_TwoEffectTriggerPro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine FreeCollideAnimTile")]
    static void Combine_FreeCollideAnimTile()
    {
        CombineUtil_4_1.Combine_FreeCollideAnimTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CycleFBTile")]
    static void Combine_CycleFBTile()
    {
        CombineUtil_4_1.Combine_CycleFBTile(Selection.transforms);
    }
    //[MenuItem("Sloth/CombineCheck/level4/Combine PathToMoveByUnpredictableDiamondAwardTrigger")] // collider不能删除，会影响运行。
    static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger()
    {
        CombineUtil_4_1.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger()
    {
        CombineUtil_4_1.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine AnimEnemyPro")]
    static void Combine_AnimEnemyPro()
    {
        CombineUtil_4_1.Combine_AnimEnemyPro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CurvedBendBoxTrigger")]
    static void Combine_CurvedBendBoxTrigger()
    {
        CombineUtil_4_1.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine PathToMoveByRoleTrigger")]
    static void Combine_PathToMoveByRoleTrigger()
    {
        CombineUtil_4_1.Combine_PathToMoveByRoleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine InputResetTrigger")]
    static void Combine_InputResetTrigger()
    {
        CombineUtil_4_1.Combine_InputResetTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine DepartVehicleTrigger")]
    static void Combine_DepartVehicleTrigger()
    {
        CombineUtil_4_1.Combine_DepartVehicleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine RoleMoveLimitTrigger")]
    static void Combine_RoleMoveLimitTrigger()
    {
        CombineUtil_4_1.Combine_RoleMoveLimitTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine ChangeCameraEffectTrigger")]
    static void Combine_ChangeCameraEffectTrigger()
    {
        CombineUtil_4_1.Combine_ChangeCameraEffectTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CrownFromFragment")]
    static void Combine_CrownFromFragment()
    {
        CombineUtil_4_1.Combine_CrownFromFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine DisableInputTrigger")]
    static void Combine_DisableInputTrigger()
    {
        CombineUtil_4_1.Combine_DisableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine BackGroundTrigger")]
    static void Combine_BackGroundTrigger()
    {
        CombineUtil_4_1.Combine_BackGroundTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine ChangeRoleTrigger")]
    static void Combine_ChangeRoleTrigger()
    {
        CombineUtil_4_1.Combine_ChangeRoleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine EnableInputTrigger")]
    static void Combine_EnableInputTrigger()
    {
        CombineUtil_4_1.Combine_EnableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine OpenFollowTrigger")]
    static void Combine_OpenFollowTrigger()
    {
        CombineUtil_4_1.Combine_OpenFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine DropDieStaticTrigger")]
    static void Combine_DropDieStaticTrigger()
    {
        CombineUtil_4_1.Combine_DropDieStaticTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine HideBackTrigger")]
    static void Combine_HideBackTrigger()
    {
        CombineUtil_4_1.Combine_HideBackTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine Award_Crown_lv4")]
    static void Combine_Award_Crown_lv4()
    {
        CombineUtil_4_1.Combine_Award_Crown_lv4(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine WindOpenTrigger")]
    static void Combine_WindOpenTrigger()
    {
        CombineUtil_4_1.Combine_WindOpenTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine WindCloseTrigger")]
    static void Combine_WindCloseTrigger()
    {
        CombineUtil_4_1.Combine_WindCloseTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine CloseFollowTrigger")]
    static void Combine_CloseFollowTrigger()
    {
        CombineUtil_4_1.Combine_CloseFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine WinBeforeFinishTrigger")]
    static void Combine_WinBeforeFinishTrigger()
    {
        CombineUtil_4_1.Combine_WinBeforeFinishTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level4/Combine HangingWinTile")]
    static void Combine_HangingWinTile()
    {
        CombineUtil_4_1.Combine_HangingWinTile(Selection.transforms);
    }
    #endregion

    #region level 5
    [MenuItem("Sloth/CombineCheck/level5/Combine MultiSegmentAnimationTile")]
    static void Combine_5_MultiSegmentAnimationTile()
    {
        CombineUtil_5_1.Combine_MultiSegmentAnimationTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine MoveAllDirTile")]
    static void Combine_5_MoveAllDirTile()
    {
        CombineUtil_5_1.Combine_MoveAllDirTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine NormalEnemy Easy")]
    static void Combine_NormalEnemy_easy()
    {
        CombineUtil_5_1.Combine_NormalEnemy_easy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine AnimEnemy WeirdDream_XiaoZhen_Star_UP")]
    static void Combine_AnimEnemy_WeirdDream_XiaoZhen_Star_UP()
    {
        CombineUtil_5_1.Combine_AnimEnemy_WeirdDream_XiaoZhen_Star_UP(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine AnimEnemyPro")]
    static void Combine_AnimEnemyPro_easy()
    {
        CombineUtil_5_1.Combine_AnimEnemyPro_easy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine TriggerEffectJumpTile")]
    static void Combine_TriggerEffectJumpTile()
    {
        CombineUtil_5_1.Combine_TriggerEffectJumpTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine EmissionTile")]
    static void Combine_EmissionTile()
    {
        CombineUtil_5_1.Combine_EmissionTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine JumpDistanceTrigger")]
    static void Combine_JumpDistanceTrigger()
    {
        CombineUtil_5_1.Combine_JumpDistanceTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine DoorEnemy")]
    static void Combine_DoorEnemy()
    {
        CombineUtil_5_1.Combine_DoorEnemy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine AnimEffectTrigger")]
    static void Combine_AnimEffectTrigger()
    {
        CombineUtil_5_1.Combine_AnimEffectTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine TrapRootTile")]
    static void Combine_TrapRootTile()
    {
        CombineUtil_5_1.Combine_TrapRootTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine FreeMoveTile")]
    static void Combine_FreeMoveTile()
    {
        CombineUtil_5_1.Combine_FreeMoveTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine InputResetTrigger")]
    static void Combine_5_InputResetTrigger()
    {
        CombineUtil_5_1.Combine_InputResetTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine CrownFragment")]
    static void Combine_5_CrownFragment()
    {
        CombineUtil_5_1.Combine_CrownFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine JumpDistanceQTETile")]
    static void Combine_5_JumpDistanceQTETile()
    {
        CombineUtil_5_1.Combine_JumpDistanceQTETile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine DiamondAward")]
    static void Combine_5_DiamondAward()
    {
        CombineUtil_5_1.Combine_DiamondAward(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine WorldThemesTrigger")]
    static void Combine_WorldThemesTrigger()
    {
        CombineUtil_5_1.Combine_WorldThemesTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine ChangeCameraEffectByNameTrigger")]
    static void Combine_ChangeCameraEffectByNameTrigger()
    {
        CombineUtil_5_1.Combine_ChangeCameraEffectByNameTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine PathToMoveByPetTrigger")]
    static void Combine_PathToMoveByPetTrigger()
    {
        CombineUtil_5_1.Combine_PathToMoveByPetTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine CrownFromFragment")]
    static void Combine_5_CrownFromFragment()
    {
        CombineUtil_5_1.Combine_CrownFromFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine PathToMoveByUnpredictableDiamondAwardTrigger")]
    static void Combine_5_PathToMoveByUnpredictableDiamondAwardTrigger()
    {
        CombineUtil_5_1.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine ElevatorTrigger")]
    static void Combine_5_ElevatorTrigger()
    {
        CombineUtil_5_1.Combine_ElevatorTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine CameraAnimTrigger")]
    static void Combine_5_CameraAnimTrigger()
    {
        CombineUtil_5_1.Combine_CameraAnimTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine DisableInputTrigger")]
    static void Combine_5_DisableInputTrigger()
    {
        CombineUtil_5_1.Combine_DisableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine OpenFollowTrigger")]
    static void Combine_5_OpenFollowTrigger()
    {
        CombineUtil_5_1.Combine_OpenFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine EnableInputTrigger")]
    static void Combine_5_EnableInputTrigger()
    {
        CombineUtil_5_1.Combine_EnableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_5_BuyOutRebirthBoxTrigger()
    {
        CombineUtil_4_1.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine PathToMoveByRoleForLerpTrigger")]
    static void Combine_5_PathToMoveByRoleForLerpTrigger()
    {
        CombineUtil_5_1.Combine_PathToMoveByRoleForLerpTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine WinBeforeFinishTrigger")]
    static void Combine_5_WinBeforeFinishTrigger()
    {
        CombineUtil_5_1.Combine_WinBeforeFinishTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level5/Combine NormalTile")]
    static void Combine_5_NormalTile()
    {
        CombineUtil_5_1.Combine_NormalTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/level5/Combine MoveAllDirTile 2")]
    static void Combine_MoveAllDirTile_2()
    {
        CombineUtil_5_1.Combine_MoveAllDirTile_2(Selection.transforms);
    }

    #endregion

    #region level 6
    [MenuItem("Sloth/CombineCheck/level6/Combine EmissionTile")]
    static void Combine_6_EmissionTile()
    {
        CombineUtil_6_1.Combine_EmissionTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/level6/Combine AnimEnemyPro")]
    static void Combine_6_AnimEnemyPro()
    {
        CombineUtil_6_1.Combine_AnimEnemyPro(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/level6/Combine MoveAllEnemy 3")]
    static void Combine_6_MoveAllEnemy_3()
    {
        CombineUtil_6_1.Combine_MoveAllEnemy_3(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine MoveAllEnemy 14")]
    static void Combine_6_MoveAllEnemy_14()
    {
        CombineUtil_6_1.Combine_MoveAllEnemy_14(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine FreeCollideAnimTile 3")]
    static void Combine_6_FreeCollideAnimTile_3()
    {
        CombineUtil_6_1.Combine_FreeCollideAnimTile_3(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine FreeCollideAnimTile 4")] //   ???
    static void Combine_6_FreeCollideAnimTile_4()
    {
        CombineUtil_6_1.Combine_FreeCollideAnimTile_4(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine WideTilePro")]
    static void Combine_6_WideTilePro()
    {
        CombineUtil_6_1.Combine_WideTilePro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine MoveAllDirTile Fate_Tile_qipan_white_move")]
    static void Combine_6_MoveAllDirTile_Fate_Tile_qipan_white_move()
    {
        CombineUtil_6_1.Combine_MoveAllDirTile_Fate_Tile_qipan_white_move(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine MoveAllDirTile Fate_Tile_white_move_L")]
    static void Combine_6_MoveAllDirTile_Fate_Tile_white_move_L()
    {
        CombineUtil_6_1.Combine_MoveAllDirTile_Fate_Tile_white_move_L(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine MoveAllDirTile Fate_Tile_white_move_R")]
    static void Combine_6_MoveAllDirTile_Fate_Tile_white_move_R()
    {
        CombineUtil_6_1.Combine_MoveAllDirTile_Fate_Tile_white_move_R(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine JumpDistanceQTETile")]
    static void Combine_6_JumpDistanceQTETile()
    {
        CombineUtil_6_1.Combine_JumpDistanceQTETile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine MoveThreeEnemy 13")]
    static void Combine_6_MoveThreeEnemy_13()
    {
        //"GridGroup#Grid_5#Fate_Enemy_QiPan_qizi_MoveThree(Clone)":15,  这个节点手动删，就不用脚本了。
        CombineUtil_6_1.Combine_MoveThreeEnemy_13(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine NormalEnemy Easy")]
    static void Combine_6_NormalEnemy_easy()
    {
        CombineUtil_6_1.Combine_NormalEnemy_easy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine RoleLineTrigger")]
    static void Combine_6_RoleLineTrigger()
    {
        CombineUtil_6_1.Combine_RoleLineTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine EffectEnemy")]
    static void Combine_6_EffectEnemy()
    {
        CombineUtil_6_1.Combine_EffectEnemy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine NormalTile")]
    static void Combine_6_NormalTile()
    {
        CombineUtil_6_1.Combine_NormalTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine CameraAnimTrigger")]
    static void Combine_6_CameraAnimTrigger()
    {
        CombineUtil_6_1.Combine_CameraAnimTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine CurvedBendBoxTrigger")]
    static void Combine_6_CurvedBendBoxTrigger()
    {
        CombineUtil_6_1.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine DiamondAward")]
    static void Combine_6_DiamondAward()
    {
        CombineUtil_6_1.Combine_DiamondAward(Selection.transforms);
    }
    //AnimParticleEnemy 无

    [MenuItem("Sloth/CombineCheck/level6/Combine PathToMoveByUnpredictableDiamondAwardTrigger")]
    static void Combine_6_PathToMoveByUnpredictableDiamondAwardTrigger()
    {
        CombineUtil_6_1.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine RoleMoveLimitTrigger")]
    static void Combine_6_RoleMoveLimitTrigger()
    {
        CombineUtil_6_1.Combine_RoleMoveLimitTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine WorldThemesTrigger")]
    static void Combine_6_WorldThemesTrigger()
    {
        CombineUtil_6_1.Combine_WorldThemesTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine ShakeCameraTrigger")]
    static void Combine_6_ShakeCameraTrigger()
    {
        CombineUtil_6_1.Combine_ShakeCameraTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine JumpDirTrigger")]
    static void Combine_6_JumpDirTrigger()
    {
        CombineUtil_6_1.Combine_JumpDirTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine OpenFollowTrigger")]
    static void Combine_6_OpenFollowTrigger()
    {
        CombineUtil_6_1.Combine_OpenFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine DropDieStaticTrigger")]
    static void Combine_6_DropDieStaticTrigger()
    {
        CombineUtil_6_1.Combine_DropDieStaticTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine PathToMoveByUnpredictableCrownAwardTrigger")]
    static void Combine_6_PathToMoveByUnpredictableCrownAwardTrigger()
    {
        CombineUtil_6_1.Combine_PathToMoveByUnpredictableCrownAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine DropDieForwordTrigger")]
    static void Combine_6_DropDieForwordTrigger()
    {
        CombineUtil_6_1.Combine_DropDieForwordTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine CameraClipTrigger")]
    static void Combine_6_CameraClipTrigger()
    {
        CombineUtil_6_1.Combine_CameraClipTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine CloseFollowTrigger")]
    static void Combine_6_CloseFollowTrigger()
    {
        CombineUtil_6_1.Combine_CloseFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine DisableInputTrigger")]
    static void Combine_6_DisableInputTrigger()
    {
        CombineUtil_6_1.Combine_DisableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine WinBeforeFinishTrigger")]
    static void Combine_6_WinBeforeFinishTrigger()
    {
        CombineUtil_6_1.Combine_WinBeforeFinishTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/level6/Combine HangingWinTile")]
    static void Combine_6_HangingWinTile()
    {
        CombineUtil_6_1.Combine_HangingWinTile(Selection.transforms);
    }
    #endregion

    #region Waltz_1_E
    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine NormalTile Check")]
    static void Combine_NormalTile_Check()
    {
        CombineUtil_Waltz_1_E.Combine_NormalTile_Check(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine NormalTile ChangeMesh")]
    static void Combine_NormalTile_ChangeMesh()
    {
        CombineUtil_Waltz_1_E.Combine_NormalTile_ChangeMesh(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine NormalTile")]
    static void Combine_NormalTile_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_NormalTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine AnimEnemyPro Del TriggerPoint")]
    static void Combine_AnimEnemyPro_Del_TriggerPoint()
    {
        CombineUtil_Waltz_1_E.Combine_AnimEnemyPro_Del_TriggerPoint(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine AnimEnemyPro Waltz_Enemy_Jiguang")]
    static void Combine_AnimEnemyPro_Waltz_Enemy_Jiguang()
    {
        CombineUtil_Waltz_1_E.Combine_AnimEnemyPro_Waltz_Enemy_Jiguang(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine WideTilePro")]
    static void Combine_WideTilePro_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_WideTilePro(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine FreeCollideTile")]
    static void Combine_FreeCollideTile_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_FreeCollideTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine JumpDistanceQTETile Waltz_Tile_Piano_SuperJump_empty")]
    static void Combine_JumpDistanceQTETile_Waltz_Tile_Piano_SuperJump_empty()
    {
        CombineUtil_Waltz_1_E.Combine_JumpDistanceQTETile_Waltz_Tile_Piano_SuperJump_empty(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine JumpDistanceQTETile Waltz_Tile_paper_jump ChangeMesh")]
    static void Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump_ChangeMesh()
    {
        CombineUtil_Waltz_1_E.Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump_ChangeMesh(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine JumpDistanceQTETile Waltz_Tile_paper_jump")]
    static void Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump()
    {
        CombineUtil_Waltz_1_E.Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine TwoEffectTriggerPro Waltz_Effect_Jump")]
    static void Combine_TwoEffectTriggerPro_Waltz_Effect_Jump()
    {
        CombineUtil_Waltz_1_E.Combine_TwoEffectTriggerPro_Waltz_Effect_Jump(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine TwoEffectTriggerPro Waltz_Effect_Crown")]
    static void Combine_TwoEffectTriggerPro_Waltz_Effect_Crown()
    {
        CombineUtil_Waltz_1_E.Combine_TwoEffectTriggerPro_Waltz_Effect_Crown(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine TwoEffectTriggerPro Waltz_Effect_Jump_Big")]
    static void Combine_TwoEffectTriggerPro_Waltz_Effect_Jump_Big()
    {
        CombineUtil_Waltz_1_E.Combine_TwoEffectTriggerPro_Waltz_Effect_Jump(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine WaltzStringLaser")]
    static void Combine_WaltzStringLaser()
    {
        CombineUtil_Waltz_1_E.Combine_WaltzStringLaser(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine ChangeRuntimeAnimatorControllerTrigger")]
    static void Combine_ChangeRuntimeAnimatorControllerTrigger()
    {
        CombineUtil_Waltz_1_E.Combine_ChangeRuntimeAnimatorControllerTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine NormalEnemy")]
    static void Combine_NormalEnemy_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_NormalEnemy(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine CurvedBendBoxTrigger")]
    static void Combine_CurvedBendBoxTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine DropDieTrigger")]
    static void Combine_DropDieTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_DropDieTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine CameraAnimTrigger")]
    static void Combine_CameraAnimTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_CameraAnimTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine ChangeCameraEffectByNameTrigger")]
    static void Combine_ChangeCameraEffectByNameTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_ChangeCameraEffectByNameTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine RoleAnimatiorTrigger")]
    static void Combine_RoleAnimatiorTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_RoleAnimatiorTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine WorldThemesTrigger")]
    static void Combine_WorldThemesTrigger_Waltz_1()
    {
        CombineUtil_Waltz_1_E.Combine_WorldThemesTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine ActiveDiamond")]
    static void Combine_ActiveDiamond()
    {
        CombineUtil_Waltz_1_E.Combine_ActiveDiamond(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine DisableInputTrigger")]
    static void Combine_DisableInputTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_DisableInputTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine PathToMoveByUnpredictableDiamondAwardTrigger")]
    static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine CameraLookAtSpeedTrigger")]
    static void Combine_CameraLookAtSpeedTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_CameraLookAtSpeedTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine CameraBlankTrigger")]
    static void Combine_CameraBlankTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_CameraBlankTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine EnableInputTrigger")]
    static void Combine_EnableInputTrigger_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_EnableInputTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine PathToMoveByUnpredictableCrownAwardTrigger")]
    static void Combine_PathToMoveByUnpredictableCrownAwardTrigger()
    {
        CombineUtil_Waltz_1_E.Combine_PathToMoveByUnpredictableCrownAwardTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Waltz_1_E/Combine DiamondAward")]
    static void Combine_DiamondAward_Waltz_1_E()
    {
        CombineUtil_Waltz_1_E.Combine_DiamondAward(Selection.transforms);
    }

    #endregion

    #region level Pharaohs_1_E
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine NormalTile")]
    static void Combine_NormalTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine MoveAllDirTile")]
    static void Combine_MoveAllDirTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_MoveAllDirTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine MoveAllDirTile2")]
    static void Combine_MoveAllDirTile2_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_MoveAllDirTile2(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine WideTilePro")]
    static void Combine_WideTilePro_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_WideTilePro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine FreeCollideTile")]
    static void Combine_FreeCollideTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_FreeCollideTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine GlassRootTile")]
    static void Combine_GlassRootTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_GlassRootTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine GlassChildTile")]
    static void Combine_GlassChildTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_GlassChildTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine NormalJumpTile")]
    static void Combine_NormalJumpTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalJumpTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine NormalEnemy AiJi_XiaPo_Zhu(Clone)")]
    static void Combine_NormalEnemy_AiJi_XiaPo_Zhu_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalEnemy_AiJi_XiaPo_Zhu(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine NormalEnemy Enemy_Enpty(Clone)")]
    static void Combine_NormalEnemy_Enemy_Enpty_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalEnemy_Enemy_Enpty(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine JumpDistanceQTETile")]
    static void Combine_JumpDistanceQTETile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_JumpDistanceQTETile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine NormalDropEnemy")]
    static void Combine_NormalDropEnemy_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_NormalDropEnemy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine RoleAnimatiorTrigger")]
    static void Combine_RoleAnimatiorTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_RoleAnimatiorTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CameraAnimTrigger")]
    static void Combine_CameraAnimTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CameraAnimTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine ShakeCameraTrigger")]
    static void Combine_ShakeCameraTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_ShakeCameraTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CrownFragment")]
    static void Combine_CrownFragment_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CrownFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine DiamondAward")]
    static void Combine_DiamondAward_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_DiamondAward(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine TwoEffectTriggerPro")]
    static void Combine_TwoEffectTriggerPro_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_TwoEffectTriggerPro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine FreeCollideAnimTile")]
    static void Combine_FreeCollideAnimTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_FreeCollideAnimTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CycleFBTile")]
    static void Combine_CycleFBTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CycleFBTile(Selection.transforms);
    }
    //[MenuItem("Sloth/CombineCheck/level4/Combine PathToMoveByUnpredictableDiamondAwardTrigger")] // collider不能删除，会影响运行。
    static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine AnimEnemyPro")]
    static void Combine_AnimEnemyPro_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_AnimEnemyPro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CurvedBendBoxTrigger")]
    static void Combine_CurvedBendBoxTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine PathToMoveByRoleTrigger")]
    static void Combine_PathToMoveByRoleTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_PathToMoveByRoleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine InputResetTrigger")]
    static void Combine_InputResetTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_InputResetTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine DepartVehicleTrigger")]
    static void Combine_DepartVehicleTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_DepartVehicleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine RoleMoveLimitTrigger")]
    static void Combine_RoleMoveLimitTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_RoleMoveLimitTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine ChangeCameraEffectTrigger")]
    static void Combine_ChangeCameraEffectTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_ChangeCameraEffectTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CrownFromFragment")]
    static void Combine_CrownFromFragment_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CrownFromFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine DisableInputTrigger")]
    static void Combine_DisableInputTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_DisableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine BackGroundTrigger")]
    static void Combine_BackGroundTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_BackGroundTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine ChangeRoleTrigger")]
    static void Combine_ChangeRoleTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_ChangeRoleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine EnableInputTrigger")]
    static void Combine_EnableInputTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_EnableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine OpenFollowTrigger")]
    static void Combine_OpenFollowTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_OpenFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine DropDieStaticTrigger")]
    static void Combine_DropDieStaticTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_DropDieStaticTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine HideBackTrigger")]
    static void Combine_HideBackTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_HideBackTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine Award_Crown_lv4")]
    static void Combine_Award_Crown_lv4_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_Award_Crown_lv4(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine WindOpenTrigger")]
    static void Combine_WindOpenTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_WindOpenTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine WindCloseTrigger")]
    static void Combine_WindCloseTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_WindCloseTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine CloseFollowTrigger")]
    static void Combine_CloseFollowTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_CloseFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine WinBeforeFinishTrigger")]
    static void Combine_WinBeforeFinishTrigger_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_WinBeforeFinishTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Pharaohs_1_E/Combine HangingWinTile")]
    static void Combine_HangingWinTile_Pharaohs_1_E()
    {
        CombineUtil_Pharaohs_1_E.Combine_HangingWinTile(Selection.transforms);
    }
    #endregion

    #region Jazz_E
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine MultiSegmentAnimationTile 4")]
    static void Combine_MultiSegmentAnimationTile_4()
    {
        CombineUtil_Jazz_E.Combine_MultiSegmentAnimationTile_4(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine MultiSegmentAnimationTile 5")]
    static void Combine_MultiSegmentAnimationTile_5()
    {
        CombineUtil_Jazz_E.Combine_MultiSegmentAnimationTile_5(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine MultiSegmentAnimationTile Destroy Collider")]
    static void Combine_MultiSegmentAnimationTile_Destroy_Collider()
    {
        CombineUtil_Jazz_E.Combine_MultiSegmentAnimationTile_Destroy_Collider(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine AnimEnemyPro Destroy TriggerPoint")]
    static void Combine_MultiSegmentAnimationTile_Destroy_TriggerPoint()
    {
        CombineUtil_Jazz_E.Combine_AnimEnemyPro_Destroy_TriggerPoint(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine AnimEnemyPro Jazz_Enemy_yuepu_05")]
    static void Combine_MultiSegmentAnimationTile_Jazz_Enemy_yuepu_05()
    {
        CombineUtil_Jazz_E.Combine_AnimEnemyPro_Jazz_Enemy_yuepu_05(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine JumpDistanceQTETile Jazz_Tile_Jump_Empty1x1")]
    static void Combine_JumpDistanceQTETile_Jazz_Tile_Jump_Empty1x1()
    {
        CombineUtil_Jazz_E.Combine_JumpDistanceQTETile_Jazz_Tile_Jump_Empty1x1(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine JumpDistanceQTETile Jazz_Tile_xiaohao_jump")]
    static void Combine_JumpDistanceQTETile_Jazz_Tile_xiaohao_jump()
    {
        CombineUtil_Jazz_E.Combine_JumpDistanceQTETile_Jazz_Tile_xiaohao_jump(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine JumpDistanceTrigger")]
    static void Combine_JumpDistanceTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_JumpDistanceTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine SynchronizedAnimationMidground")]
    static void Combine_SynchronizedAnimationMidground()
    {
        CombineUtil_Jazz_E.Combine_SynchronizedAnimationMidground(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine DropDieTrigger")]
    static void Combine_DropDieTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_DropDieTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine SwitchListenTrigger")]
    static void Combine_SwitchListenTrigger()
    {
        CombineUtil_Jazz_E.Combine_SwitchListenTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine NormalEnemy")]
    static void Combine_NormalEnemy_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_NormalEnemy(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine SwitchSendTrigger")]
    static void Combine_SwitchSendTrigger()
    {
        CombineUtil_Jazz_E.Combine_SwitchSendTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine TwoEffectTriggerPro")]
    static void Combine_TwoEffectTriggerPro_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_TwoEffectTriggerPro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine PathGuideSendTrigger")]
    static void Combine_PathGuideSendTrigger()
    {
        CombineUtil_Jazz_E.Combine_PathGuideSendTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine DiamondAward")]
    static void Combine_DiamondAward_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_DiamondAward(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine LeftRightRotateSendTrigger")]
    static void Combine_LeftRightRotateSendTrigger()
    {
        CombineUtil_Jazz_E.Combine_LeftRightRotateSendTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine WideTilePro")]
    static void Combine_WideTilePro_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_WideTilePro(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine WorldThemesTrigger")]
    static void Combine_WorldThemesTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_WorldThemesTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine InputResetTrigger")]
    static void Combine_InputResetTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_InputResetTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine CrownFragment")]
    static void Combine_CrownFragment_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_CrownFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine CurvedBendBoxTrigger")]
    static void Combine_Combine_CurvedBendBoxTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine DepartVehicleTrigger")]
    static void Combine_Combine_DepartVehicleTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_DepartVehicleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine PathToMoveByUnpredictableDiamondAwardTrigger")]
    static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine ChangeCameraEffectByNameTrigger")]
    static void Combine_ChangeCameraEffectByNameTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_ChangeCameraEffectByNameTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine RoleMoveLimitTrigger")]
    static void Combine_RoleMoveLimitTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_RoleMoveLimitTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine PathToMoveByRoleTrigger")]
    static void Combine_PathToMoveByRoleTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_PathToMoveByRoleTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine DisableInputTrigger")]
    static void Combine_DisableInputTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_DisableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine OpenFollowTrigger")]
    static void Combine_OpenFollowTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_OpenFollowTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine EnableInputTrigger")]
    static void Combine_EnableInputTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_EnableInputTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine PathToMoveByUnpredictableCrownAwardTrigger")]
    static void Combine_PathToMoveByUnpredictableCrownAwardTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_PathToMoveByUnpredictableCrownAwardTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine CrownFromFragment")]
    static void Combine_CrownFromFragment_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_CrownFromFragment(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine PathToMoveByRoleForLerpTrigger")]
    static void Combine_PathToMoveByRoleForLerpTrigger()
    {
        CombineUtil_Jazz_E.Combine_PathToMoveByRoleForLerpTrigger(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine WinBeforeFinishTrigger")]
    static void Combine_WinBeforeFinishTrigger_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_WinBeforeFinishTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/Combine HangingWinTile")]
    static void Combine_HangingWinTile_Jazz_E()
    {
        CombineUtil_Jazz_E.Combine_HangingWinTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/ResetYuePuTile")]
    static void ResetYuePuTile()
    {
        CombineUtil_Jazz_E.ResetYuePuTile(Selection.transforms);
    }
    [MenuItem("Sloth/CombineCheck/Jazz_E/ResetDanHuangGuan")]
    static void ResetDanHuangGuan()
    {
        CombineUtil_Jazz_E.ResetDanHuangGuan(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/ResetXiaoHaoNormalTile")]
    static void ResetXiaoHaoNormalTile()
    {
        CombineUtil_Jazz_E.ResetXiaoHaoNormalTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/ResetXiaoHaoJumpTile")]
    static void ResetXiaoHaoJumpTile()
    {
        CombineUtil_Jazz_E.ResetXiaoHaoJumpTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Jazz_E/ResetParentToCustom")]
    static void ResetParentToCustom()
    {
        CombineUtil_Jazz_E.ResetParentToCustom(Selection.transforms);
    }
    #endregion

    #region Thief_2_H 合盗 简单
    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine EmissionTile")]
    static void Combine_EmissionTile_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_EmissionTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine FreeCollideTile")]
    static void Combine_FreeCollideTile_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_FreeCollideTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine NormalEnemy")]
    static void Combine_NormalEnemy_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_NormalEnemy(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine AnimEnemyPro")]
    static void Combine_AnimEnemyPro_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_AnimEnemyPro_All(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine JumpDistanceQTETile")]
    static void Combine_JumpDistanceQTETile_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_JumpDistanceQTETile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine TwoEffectTriggerPro")]
    static void Combine_TwoEffectTriggerPro_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerPro_11(Selection.transforms);
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerPro_10(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine CoupleAnimatorTrigger")]
    static void Combine_CoupleAnimatorTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_CoupleAnimatorTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine CameraAnimTrigger")]
    static void Combine_CameraAnimTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_CameraAnimTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine RoleAnimatiorTrigger")]
    static void Combine_RoleAnimatiorTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_RoleAnimatiorTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine RoleChangeMoodByEvent")]
    static void Combine_RoleChangeMoodByEvent_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_RoleChangeMoodByEvent(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine DropDieTrigger")]
    static void Combine_DropDieTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_DropDieTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine DanceTogetherTrigger")]
    static void Combine_DanceTogetherTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_DanceTogetherTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine InputResetTrigger")]
    static void Combine_InputResetTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_InputResetTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine CurvedBendBoxTrigger")]
    static void Combine_CurvedBendBoxTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine AnimEnemyProByCouple")]
    static void Combine_AnimEnemyProByCouple_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_AnimEnemyProByCouple(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine CrownFragment")]
    static void Combine_CrownFragment_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_CrownFragment(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine DiamondAward")]
    static void Combine_DiamondAward_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_DiamondAward(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine FreeMoveDiamondByCouple")]
    static void Combine_FreeMoveDiamondByCouple_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_FreeMoveDiamondByCouple(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine WorldThemesTrigger")]
    static void Combine_WorldThemesTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_WorldThemesTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine NormalDropEnemy")]
    static void Combine_NormalDropEnemy_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_NormalDropEnemy(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine TwoEffectTriggerSpecial")]
    static void Combine_TwoEffectTriggerSpecial_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerSpecial(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine ForcePosTIle")]
    static void Combine_ForcePosTIle_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_ForcePosTIle(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine PathToMoveFixedByRoleAsFragementTrigger")]
    static void Combine_PathToMoveFixedByRoleAsFragementTrigger()
    {
        CombineUtil_Thief_2_H.Combine_PathToMoveFixedByRoleAsFragementTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief_2_H/Combine CoupleFollowTrigger")]
    static void Combine_CoupleFollowTrigger_Thief_2_H()
    {
        CombineUtil_Thief_2_H.Combine_CoupleFollowTrigger(Selection.transforms);
    }

    #endregion


    #region Thief 合盗 困难
    [MenuItem("Sloth/CombineCheck/Thief/Combine EmissionTile")]
    static void Combine_EmissionTile_Thief()
    {
        CombineUtil_Thief_2_H.Combine_EmissionTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine FreeCollideTile")]
    static void Combine_FreeCollideTile_Thief()
    {
        CombineUtil_Thief_2_H.Combine_FreeCollideTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine NormalEnemy")]
    static void Combine_NormalEnemy_Thief()
    {
        CombineUtil_Thief_2_H.Combine_NormalEnemy(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine AnimEnemyPro")]
    static void Combine_AnimEnemyPro_Thief()
    {
        CombineUtil_Thief_2_H.Combine_AnimEnemyPro_All(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine JumpDistanceQTETile")]
    static void Combine_JumpDistanceQTETile_Thief()
    {
        CombineUtil_Thief_2_H.Combine_JumpDistanceQTETile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine TwoEffectTriggerPro")]
    static void Combine_TwoEffectTriggerPro_Thief()
    {
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerPro_11(Selection.transforms);
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerPro_10(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CoupleAnimatorTrigger")]
    static void Combine_CoupleAnimatorTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CoupleAnimatorTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CameraAnimTrigger")]
    static void Combine_CameraAnimTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CameraAnimTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine RoleAnimatiorTrigger")]
    static void Combine_RoleAnimatiorTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_RoleAnimatiorTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine RoleChangeMoodByEvent")]
    static void Combine_RoleChangeMoodByEvent_Thief()
    {
        CombineUtil_Thief_2_H.Combine_RoleChangeMoodByEvent(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine DropDieTrigger")]
    static void Combine_DropDieTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_DropDieTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine DanceTogetherTrigger")]
    static void Combine_DanceTogetherTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_DanceTogetherTrigger(Selection.transforms);
    }

    //RS2.ThiefMovePathTrigger
    //RS2.CraneJumpTile
    //RS2.SwingingRopeTriggerBox


    [MenuItem("Sloth/CombineCheck/Thief/Combine InputResetTrigger")]
    static void Combine_InputResetTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_InputResetTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CurvedBendBoxTrigger")]
    static void Combine_CurvedBendBoxTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CurvedBendBoxTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine AnimEnemyProByCouple")]
    static void Combine_AnimEnemyProByCouple_Thief()
    {
        CombineUtil_Thief_2_H.Combine_AnimEnemyProByCouple(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine DiamondAward")]
    static void Combine_DiamondAward_Thief()
    {
        CombineUtil_Thief_2_H.Combine_DiamondAward(Selection.transforms);
    }

    //RS2.CraneTile

    [MenuItem("Sloth/CombineCheck/Thief/Combine CrownFragment")]
    static void Combine_CrownFragment_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CrownFragment(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine NormalDropEnemy")]
    static void Combine_NormalDropEnemy_Thief()
    {
        CombineUtil_Thief_2_H.Combine_NormalDropEnemy(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine WorldThemesTrigger")]
    static void Combine_WorldThemesTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_WorldThemesTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine FreeMoveDiamondByCouple")]
    static void Combine_FreeMoveDiamondByCouple_Thief()
    {
        CombineUtil_Thief_2_H.Combine_FreeMoveDiamondByCouple(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine BuyOutRebirthBoxTrigger")]
    static void Combine_BuyOutRebirthBoxTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_BuyOutRebirthBoxTrigger(Selection.transforms);
    }

    //FreeCollideAnimTile
    [MenuItem("Sloth/CombineCheck/Thief/Combine FreeCollideAnimTile")]
    static void Combine_FreeCollideAnimTile_Thief()
    {
        CombineUtil_Thief.Combine_FreeCollideAnimTile(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine TwoEffectTriggerSpecial")]
    static void Combine_TwoEffectTriggerSpecial_Thief()
    {
        CombineUtil_Thief_2_H.Combine_TwoEffectTriggerSpecial(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine ForcePosTIle")]
    static void Combine_ForcePosTIle_Thief()
    {
        CombineUtil_Thief_2_H.Combine_ForcePosTIle(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine PathToMoveFixedByRoleAsFragementTrigger")]
    static void Combine_PathToMoveFixedByRoleAsFragementTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_PathToMoveFixedByRoleAsFragementTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CoupleFollowTrigger")]
    static void Combine_CoupleFollowTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CoupleFollowTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CoupleDetachTrigger")]
    static void Combine_CoupleDetachTrigger_Thief()
    {
        CombineUtil_Thief_2_H.Combine_CoupleDetachTrigger(Selection.transforms);
    }

    [MenuItem("Sloth/CombineCheck/Thief/Combine CrownFromFragment")]
    static void Combine_CrownFromFragment_Thief()
    {
        CombineUtil_4_1.Combine_CrownFromFragment(Selection.transforms);
    }

    #endregion
}

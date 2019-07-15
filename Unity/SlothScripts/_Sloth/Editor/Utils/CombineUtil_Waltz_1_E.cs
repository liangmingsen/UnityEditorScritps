using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineUtil_Waltz_1_E : CombineColliderUtil
{
    #region 优化节点 

    //DiamondAward
    public static void Combine_DiamondAward(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider", "audio", "effect" });
            bool b = CheckTargetComponentAndChildsCount<DiamondAward>(t, 8);
            if (a && b)
            {
                Transform audio = t.Find("audio");
                Transform effect = t.Find("effect");
                Transform collider = t.Find("collider");
                Transform glow_031 = effect.Find("glow_031");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckLocalPositionIsZero(collider, new Vector3(0, 0.096f, 0));
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                bool d6 = CheckTargetComponentCount<AudioSource>(audio, 2);
                bool e6 = CheckTargetComponentAndChildsCount<Transform>(audio, 1);

                if (d2 && e2 && f2 && g2 && d6 && e6)
                {
                    bc.center += new Vector3(0, 0.096f, 0);
                    CopyComponent<BoxCollider>(collider, t);
                    CopyComponent<AudioSource>(audio, t);
                    SetParentAndName(glow_031, t, "effect");

                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(audio.gameObject);
                    DestroyGameObject(effect.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
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

    //RS2.CameraBlankTrigger
    public static void Combine_CameraBlankTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<RS2.CameraBlankTrigger>(t, 3);
            if (a && b)
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
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //CameraLookAtSpeedTrigger
    public static void Combine_CameraLookAtSpeedTrigger(Transform[] tfs)
    {
        Combine_CopyCollider_2<CameraLookAtSpeedTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //PathToMoveByUnpredictableDiamondAwardTrigger
    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger(Transform[] tfs)
    {
        Combine_Destroy_Audio_path_11<PathToMoveByUnpredictableDiamondAwardTrigger>(tfs);
    }

    //DisableInputTrigger
    public static void Combine_DisableInputTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<DisableInputTrigger>(t, 3);
            if (a && b)
            {
                Transform model = t.Find("model");
                
                bool d6 = CheckTargetComponentCount<Transform>(model, 1);
                bool e6 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                if (d6 && e6)
                {
                    DestroyGameObject(model.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //RelativeDisplacementMotionTriggerBox 不处理

    //BuyOutRebirthBoxTrigger
    public static void Combine_BuyOutRebirthBoxTrigger(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "collider" });
            bool b = CheckTargetComponentAndChildsCount<BuyOutRebirthBoxTrigger>(t, 17);
            if (a && b)
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
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //ActiveDiamond
    public static void Combine_ActiveDiamond(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "effect", "audio", "model", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<ActiveDiamond>(t, 11);
            if (a && b)
            {
                Transform effect = t.Find("effect");
                Transform audio = t.Find("audio");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform glow_031 = effect.Find("glow_031");

                if (glow_031 != null)
                {
                    CopyComponent<AudioSource>(audio, t);
                    SetParentAndName(glow_031, t, "effect");

                    DestroyGameObject(audio.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
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
        Combine_DestroyModel_CopyCollider_Count_3<RS2.WorldThemesTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //RoleAnimatiorTrigger
    public static void Combine_RoleAnimatiorTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<RoleAnimatiorTrigger>(tfs, new Vector3(0, 1.5f, 0));
    }

    //RS2.ChangeCameraEffectByNameTrigger
    public static void Combine_ChangeCameraEffectByNameTrigger(Transform[] tfs)
    {
        Combine_CopyCollider_2<RS2.ChangeCameraEffectByNameTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //CameraAnimTrigger
    public static void Combine_CameraAnimTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CameraAnimTrigger>(tfs, new Vector3(0, 0, 0));
    }

    //DropDieTrigger
    public static void Combine_DropDieTrigger(Transform[] tfs)
    {
        Combine_destory_model<DropDieTrigger>(tfs);
    }

    //CurvedBendBoxTrigger
    public static void Combine_CurvedBendBoxTrigger(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<CurvedBendBoxTrigger>(tfs, new Vector3(0, 4, 0));
    }

    //EffectEnemy  不处理

    //NormalEnemy
    public static void Combine_NormalEnemy(Transform[] tfs)
    {
        Combine_DestroyModel_CopyCollider_Count_3<NormalEnemy>(tfs, Vector3.zero);
    }

    //RS2.ChangeRuntimeAnimatorControllerTrigger
    public static void Combine_ChangeRuntimeAnimatorControllerTrigger(Transform[] tfs)
    {
        Combine_CopyCollider_2<RS2.ChangeRuntimeAnimatorControllerTrigger>(tfs, new Vector3(0,0,0));
    }

    //RS2.WaltzStringLaser
    public static void Combine_WaltzStringLaser(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "model", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<RS2.WaltzStringLaser>(t, 12);
            if (a && b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                if(triggerPoint != null)
                {
                    DestroyGameObject(triggerPoint.gameObject, 5);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //TwoEffectTriggerPro Waltz_Effect_Crown count = 9
    public static void Combine_TwoEffectTriggerPro_Waltz_Effect_Crown(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "model", "distanceEffect", "triggerEffect", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 9);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d1 = CheckLocalPositionIsZero(model);
                bool e1 = CheckLocalRotationIsZero(model);
                bool f1 = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                bool d3 = CheckTargetComponentCount<Transform>(distanceEffect, 1);
                bool d4 = CheckTargetComponentCount<Transform>(triggerEffect, 1);

                bool d5 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e5 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                bool d6 = CheckTargetComponentCount<AudioSource>(model, 2);
                bool e6 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                Transform disEffect = distanceEffect.Find("effect");
                Transform triEffect = triggerEffect.Find("effect");

                if (d1 && e1 && f1 && d2 && e2 && f2 && g2 && d3 && d4 && d5 && e5 && d6 && e6 && disEffect != null && triEffect != null)
                {
                    CopyComponent<AudioSource>(model, t);
                    CopyComponent<BoxCollider>(collider, t);

                    SetParentAndName(disEffect, t, "distanceEffect");
                    SetParentAndName(triEffect, t, "triggerEffect");

                    DestroyGameObject(model.gameObject);
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerEffect.gameObject);
                    DestroyGameObject(distanceEffect.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }
    //TwoEffectTriggerPro Waltz_Effect_Jump count = 12 / 14
    public static void Combine_TwoEffectTriggerPro_Waltz_Effect_Jump(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "model", "distanceEffect", "triggerEffect", "triggerPoint" });
            bool b = CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 12) || CheckTargetComponentAndChildsCount<TwoEffectTriggerPro>(t, 14);
            if (a && b)
            {
                Transform model = t.Find("model");
                Transform distanceEffect = t.Find("distanceEffect");
                Transform triggerEffect = t.Find("triggerEffect");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d1 = CheckLocalPositionIsZero(model);
                bool e1 = CheckLocalRotationIsZero(model);
                bool f1 = CheckLocalScaleIsOne(model);

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                bool d3 = CheckTargetComponentCount<Transform>(distanceEffect, 1);
                bool d4 = CheckTargetComponentCount<Transform>(triggerEffect, 1);

                bool d5 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e5 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                bool d6 = CheckTargetComponentCount<Transform>(model, 1);
                bool e6 = CheckTargetComponentAndChildsCount<Transform>(model, 1);

                Transform disEffect = distanceEffect.Find("effect");
                Transform triEffect = triggerEffect.Find("effect/xuelie_yinfu001_2x2");

                if (d1 && e1 && f1 && d2 && e2 && f2 && g2 && d3 && d4 && d5 && e5 && d6 && e6 && disEffect != null && triEffect != null)
                {
                    CopyComponent<BoxCollider>(collider, t);

                    SetParentAndName(disEffect, t, "distanceEffect");
                    SetParentAndName(triEffect, t, "triggerEffect");

                    DestroyGameObject(model.gameObject);
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerEffect.gameObject,2);
                    DestroyGameObject(distanceEffect.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                    continue;
                }
            }
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //CombinationPianoKeyJumpTile 不处理 

    //JumpDistanceQTETile Waltz_Tile_normal_jump count = 3
    public static void Combine_JumpDistanceQTETile_Waltz_Tile_normal_jump(Transform[] tfs)
    {
        Combine_CopyCollider<JumpDistanceQTETile>(tfs);
    }
    //JumpDistanceQTETile Waltz_Tile_paper_jump count = 5
    public static void Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump(Transform[] tfs)
    {
        Combine_NormalTile(tfs);
    }
    //JumpDistanceQTETile Waltz_Tile_paper_jump changeMesh count = 5
    public static void Combine_JumpDistanceQTETile_Waltz_Tile_paper_jump_ChangeMesh(Transform[] tfs)
    {
        Combine_ChangeMesh<JumpDistanceQTETile>(tfs);
    }
    //JumpDistanceQTETile Waltz_Tile_Piano_SuperJump_empty count = 2
    public static void Combine_JumpDistanceQTETile_Waltz_Tile_Piano_SuperJump_empty(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "Waltz_Tile_Piano_Zhou" });
            bool b = CheckTargetComponentAndChildsCount<JumpDistanceQTETile>(t, 2);
            if (a && b)
            {
                Transform collider = t.Find("Waltz_Tile_Piano_Zhou");
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
            Debug.LogError("条件不符:  " + t.name);
        }
        DebugLog();
    }

    //CombinationPianoKeyTile 不处理

    //FreeCollideTile
    public static void Combine_FreeCollideTile(Transform[] tfs)
    {
        Combine_model_collider_3_zero<FreeCollideTile>(tfs);
    }
    //WideTilePro
    public static void Combine_WideTilePro(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider"});
            bool b = CheckTargetComponentAndChildsCount<WideTilePro>(t, 2);
            if (a && b)
            {
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d = CheckLocalPositionIsZero(collider);
                bool e = CheckLocalRotationIsZero(collider);
                bool f = CheckLocalScaleIsOne(collider);
                bool d1 = CheckColliderCenterXZ(bc);

                if(d && e && f && d1)
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

    //AnimEnemyPro Waltz_Enemy_Jiguang count = 15
    public static void Combine_AnimEnemyPro_Waltz_Enemy_Jiguang(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "AnimEnemyPro", "model" });
            bool b = CheckTargetComponentAndChildsCount<AnimEnemyPro>(t, 15);
            if(a && b)
            {
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");
                Transform triggerPoint = t.Find("triggerPoint");
                Transform effect = model.Find("effect");

                bool a1 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool b1 = triggerPoint.childCount == 0;

                bool a2 = CheckLocalPositionIsZero(collider);
                bool b2 = CheckLocalRotationIsZero(collider);
                bool c2 = CheckLocalScaleIsOne(collider);

                bool a3 = CheckTargetComponentCount<Transform>(model, 1);
                bool b3 = model.childCount == 0;

                if(a1 && b1 && a2 && b2 && c2 && a3 && b3)
                {
                    CopyComponent<CapsuleCollider>(collider, t);



                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
        DebugLog();
    }
    //AnimEnemyPro Del TriggerPoint (Waltz_Midground_PianoBallani01_left \ Waltz_Midground_PianoBallani02_easy_left)
    public static void Combine_AnimEnemyPro_Del_TriggerPoint(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            if (t.GetComponent<AnimEnemyPro>() != null)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                bool a = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool b = triggerPoint.childCount == 0;
                if (a && b)
                {
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
        DebugLog();
    }
    /// <summary>
    /// 1:Combine_NormalTile_Check
    /// 2:Combine_NormalTile_ChangeMesh
    /// 3:Combine_NormalTile
    /// </summary>
    /// <param name="tfs"></param>
    public static void Combine_NormalTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            Transform model = t.Find("model");
            Transform collider = t.Find("collider");
            if(model != null)
            {
                CopyComponent<MeshFilter>(model, t);
                CopyComponent<MeshRenderer>(model, t);
                t.localPosition += model.localPosition;
                DestroyGameObject(model.gameObject, 3);
            }
            if(collider != null)
            {
                CopyComponent<BoxCollider>(collider, t);
                DestroyGameObject(collider.gameObject);
            }
        }
        DebugLog();
    }
    //NormalTile 1.检查mesh区分各类。2.美术合模型。3.执和地脚本。
    public static void Combine_NormalTile_ChangeMesh(Transform[] tfs)
    {
        Combine_ChangeMesh<NormalTile>(tfs);
    }
    //NormalTile 1.检查mesh区分各类。2.美术合模型。3.执和地脚本。
    public static void Combine_NormalTile_Check(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            Combine_NormalTile_Check_One<NormalTile>(t);
        }
        DebugLog();
    }
    public static void Combine_ChangeMesh<T>(Transform[] tfs)where T : BaseElement
    {
        foreach (Transform t in tfs)
        {
            Transform model = t.Find("model");
            MeshFilter mf = model.GetComponent<MeshFilter>();
            MeshRenderer mr = model.GetComponent<MeshRenderer>();

            int val = Combine_NormalTile_Check_One<T>(t);
            bool flg = true;

            if (model != null && mf != null && mr != null && val < 2)
            {
                string sourceMeshPath = AssetDatabase.GetAssetPath(mf.sharedMesh);
                string sourceMaterialPath = AssetDatabase.GetAssetPath(mr.sharedMaterial);

                string newMeshPath = "";

                List<Material> mats = new List<Material>();

                MeshRenderer[] mrends = t.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer meshRenderer in mrends)
                {
                    mats.AddRange(meshRenderer.sharedMaterials);
                }

                Mesh newMesh = null;
                switch (val)
                {
                    case 0://Waltz_Tile_paper_empty 有洞
                        newMeshPath = sourceMeshPath.Substring(0, sourceMeshPath.LastIndexOf('/')) + "/Waltz_Tile_paper_empty_1.FBX";
                        model.localPosition = new Vector3(model.localPosition.x, -0.023f, model.localPosition.z);
                        model.localRotation = Quaternion.Euler(Vector3.zero);
                        newMesh = AssetDatabase.LoadAssetAtPath<Mesh>(newMeshPath);
                        if (newMesh != null && mats.Count > 0)
                        {
                            mf.sharedMesh = newMesh;
                            mr.sharedMaterials = mats.ToArray();
                            flg = false;
                        }
                        break;
                    case 1://Waltz_Tile_paper_normal
                        newMeshPath = sourceMeshPath.Substring(0, sourceMeshPath.LastIndexOf('/')) + "/Waltz_Tile_paper_normal_1.FBX";

                        newMesh = AssetDatabase.LoadAssetAtPath<Mesh>(newMeshPath);
                        if (newMesh != null && mats.Count > 0)
                        {
                            mf.sharedMesh = newMesh;
                            mr.sharedMaterials = mats.ToArray();
                            flg = false;
                        }
                        break;
                }
            }
            if (flg)
            {
                Debug.LogError("条件不符:  " + t.name);
            }
        }
        DebugLog();
    }
    public static int Combine_NormalTile_Check_One<T>(Transform t) where T : BaseElement
    {
        bool a = CheckTargetComponentAndChildsCount<T>(t, 4);
        bool b = CheckTargetComponentAndChildsCount<T>(t, 5);
        if (a || b)
        {
            Transform model = t.Find("model");
            if (model != null)
            {
                MeshFilter mf = model.GetComponent<MeshFilter>();
                MeshRenderer mr = model.GetComponent<MeshRenderer>();

                if(mf != null && mr != null)
                {
                    string mfname = mf.sharedMesh.name;
                    int mrlength = mr.sharedMaterials.Length;
                    string mrname = mr.sharedMaterials[0].name;

                    if (mfname == "Waltz_Tile_paper_normal" && mrlength == 1 && mrname == "Waltz_Tile_paper")
                    {
                        return 1;
                    }else if (mfname == "Waltz_Tile_paper_empty" && mrlength == 1 && mrname == "Waltz_Tile_paper_empty")
                    {
                        return 0;
                    }
                }
            }
        }
        Debug.LogError("条件不符:  " + t.name);
        return 2;
    }

    #endregion



}

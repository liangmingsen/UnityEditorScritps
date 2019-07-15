using RS2;
using UnityEditor;
using UnityEngine;

public class CombineUtil_2 : CombineBase
{


    public static void Combine_EffectEnemy() // EffectEnemy
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<EffectEnemy>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyParticleEffectAndDestroySelf(tf.Find("effect"), tf))
            {
                Debug.LogWarning(go.name + " effect 合并不通过: ");
            }
        }
    }

    public static void Combine_PathToMoveByUnpredictableDiamondAwardTrigger()  // PathToMoveByUnpredictableDiamondAwardTrigger
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<PathToMoveByUnpredictableDiamondAwardTrigger>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            //if(!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false)){
            //    Debug.LogWarning(go.name + "  collider 合并不通过: ");
            //}
            if (!Com_CopyAudioAndDestroySelf(tf.Find("audio"), tf))
            {
                Debug.LogWarning(go.name + "  audio 合并不通过: ");
            }
        }
    }

    public static void Combine_WaltzStringLaser()  // WaltzStringLaser
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<WaltzStringLaser>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            Transform triggerPoints = tf.Find("triggerPoints");
            if (triggerPoints != null)
            {
                int length = triggerPoints.childCount;
                bool flg = true;
                for (int i = 0; i < length; i++)
                {
                    Transform ctf = triggerPoints.GetChild(i);
                    if (!CheckTargetComponentCount<Transform>(ctf, 1) || ctf.childCount > 0)
                    {
                        flg = false;
                    }
                }
                if (flg)
                {
                    GameObject.DestroyImmediate(triggerPoints.gameObject);
                    mDestroyCount += 5;
                }
                else
                {
                    Debug.LogWarning(go.name + " triggerPoints 合并不通过: ");
                }
            }
        }
        DebugLog();
    }

    public static void Combine_JumpDistanceQTETile()  // JumpDistanceQTETile
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<JumpDistanceQTETile>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_Waltz_Tile_Piano_SuperJump_empty()  // @Waltz_Tile_Piano_SuperJump_empty
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<JumpDistanceQTETile>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            Transform collider = tf.Find("Waltz_Tile_Piano_Zhou");
            if (collider != null)
            {
                MeshFilter mf = collider.GetComponent<MeshFilter>();
                if (mf != null && mf.sharedMesh != null)
                {
                    return;
                }
            }
            bool c2 = !CheckTargetHasComponent<BoxCollider>(tf);//父无 BoxColliders
            bool c4 = true;
            bool c5 = collider.childCount == 0;//已无子节点
            if (c2 && c4 && c5)
            {
                SetBoxColliderNewSize(collider, true);
                CopyComponent<BoxCollider>(collider, tf);
                DestroyGameObject(collider.gameObject);
            }
            else
            {
                Debug.LogWarning(go.name + " Waltz_Tile_Piano_Zhou 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_AnimEnemyPro()  // AnimEnemyPro 
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<AnimEnemyPro>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            Com_DestroySelf(tf.Find("triggerPoint"));
            if (!ComSphereColliderAndDestroySelf(tf.Find("collider"), tf))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            if (!Com_SetChildParentAndDestroySelf(tf.Find("model")))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
            if (!Com_SetChildParentAndDestroySelf(tf.Find("effect")))
            {
                Debug.LogWarning(go.name + " effect 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_NormalTile()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<NormalTile>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            //暂时操作  等美术合并  要改
            Transform model = tf.Find("model");
            if (model != null)
            {
                bool c1 = CheckLocalPositionIsZero(model);
                bool c2 = true;// CheckLocalRotationIsZero(model);
                if (c1 && c2)
                {
                    while (model.childCount > 0)
                    {
                        SetParent(model.GetChild(0), tf);
                    }
                    CopyComponent<MeshFilter>(model, tf);
                    CopyComponent<MeshRenderer>(model, tf);
                    DestroyGameObject(model.gameObject);
                }
                else
                {
                    Debug.LogWarning(go.name + " model 合并不通过: ");
                }
            }
        }
        DebugLog();
    }

    public static void Combine_WideTilePro()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<WideTilePro>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_NormalEnemy()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<NormalEnemy>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false))
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

    public static void Combine_TwoEffectTriggerPro()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<TwoEffectTriggerPro>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, false))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            if (!Com_DestroySelf(tf.Find("model")))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
            if (!Com_DestroySelf(tf.Find("triggerPoint")))
            {
                Debug.LogWarning(go.name + " triggerPoint 合并不通过: ");
            }

            Transform distanceEffect = tf.Find("distanceEffect");
            if (distanceEffect != null)
            {
                bool c2 = CheckTargetComponentCount<Transform>(distanceEffect, 1);
                Transform effect = distanceEffect.Find("effect");
                if (c2 && effect != null)
                {
                    SetParentAndName(effect, tf, distanceEffect.name);
                    DestroyGameObject(distanceEffect.gameObject);
                }
                else
                {
                    Debug.LogWarning(go.name + " distanceEffect 合并不通过: " + c2);
                }
            }
            Transform triggerEffect = tf.Find("triggerEffect");
            if (triggerEffect != null)
            {
                bool c2 = CheckTargetComponentCount<Transform>(triggerEffect, 1);
                Transform effect = triggerEffect.Find("effect");
                if (c2 && effect != null)
                {
                    Transform xuelie_yinfu001_2x2 = effect.Find("xuelie_yinfu001_2x2");
                    if (xuelie_yinfu001_2x2 != null)
                    {
                        SetParentAndName(xuelie_yinfu001_2x2, tf, triggerEffect.name);
                        DestroyGameObject(triggerEffect.gameObject);
                    }
                }
                else
                {
                    Debug.LogWarning(go.name + " triggerEffect 合并不通过: " + c2);
                }
            }
        }
        Debug.LogWarning("合节点: " + mDestroyCount);
    }

    public static void Combine_FreeCollideTile()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            bool c1 = CheckChildFoNames(tf, new string[] { "collider", "model" });
            if (c1)
            {
                Transform collider = tf.Find("collider");
                Transform model = tf.Find("model");
                bool c2 = !CheckTargetHasComponent<BoxCollider>(tf);
                bool c3 = CheckTargetHasComponent<FreeCollideTile>(tf);
                bool c4 = CheckTargetComponentCount<BoxCollider>(collider, 2);
                bool c8 = CheckLocalPositionIsZero(collider);
                if (c2 && c3 && c4 && c8)
                {
                    CopyComponent<BoxCollider>(collider, tf);
                    DestroyGameObject(collider.gameObject);
                }
                else
                {
                    Debug.LogWarning(go.name + " 合并不通过c2348: " + c2 + " | " + c3 + " | " + c4 + " | " + c8);
                }
                bool c5 = CheckChildFoNames(model, new string[] { "Waltz_Midground_qinbing_01_1", "Waltz_Midground_qinbing_01_1 (1)" });
                if (c5)
                {
                    Transform cm1 = model.Find("Waltz_Midground_qinbing_01_1");
                    Transform cm2 = model.Find("Waltz_Midground_qinbing_01_1 (1)");
                    if (cm1 && !cm1.gameObject.activeSelf)
                    {
                        DestroyGameObject(cm1.gameObject);
                    }
                    if (cm2 && !cm2.gameObject.activeSelf)
                    {
                        DestroyGameObject(cm2.gameObject);
                    }
                }
                else
                {
                    Debug.LogWarning(go.name + " 合并不通过c5: " + c5);
                }
                bool c6 = CheckTargetComponentCount<MeshFilter>(model, 3);
                bool c7 = CheckHasMesh(model);
                if (c6 && c7)
                {
                    CopyComponent<MeshFilter>(model, tf);
                    CopyComponent<MeshRenderer>(model, tf);
                    DestroyGameObject(model.gameObject);
                }
                else
                {
                    Debug.LogWarning(go.name + " 合并不通过c67: " + c6 + " | " + c7);
                }
            }
            else
            {
                Debug.LogWarning(go.name + " 合并不通过c1: " + c1);
            }
        }
        DebugLog();
    }



}

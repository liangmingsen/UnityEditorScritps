using RS2;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombineUtil_3 : CombineBase
{
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
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, true))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            if (!Com_CopyAudioAndDestroySelf(tf.Find("model"), tf))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
        }
        DebugLog();
    }


    public static void Combine_DoorEnemy()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<DoorEnemy>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_DestroySelf(tf.Find("collider")))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
            if (!Com_DestroySelf(tf.Find("triggerPoint")))
            {
                Debug.LogWarning(go.name + " triggerPoint 合并不通过: ");
            }
            //model1 和 model2 是否需要合并？
        }
        DebugLog();
    }

    public static void Combine_DropDie()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<DropDieTrigger>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_DestroySelf(tf.Find("model")))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_Tile_Road()  // Tile_Road
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            // if (!CheckTargetHasComponent<EmissionTile>(tf))
            // {
            //     Debug.LogWarning(go.name + " 合并不通过: ");
            //     continue;
            // }
            if (tf.childCount != 2)
            {
                Debug.LogWarning(go.name + " 合并不通过: childCount not 2");
                continue;
            }
            Transform model = tf.Find("model");
            if (model == null)
            {
                Debug.LogWarning(go.name + " 合并不通过: model is null");
                continue;
            }
            bool c6 = CheckTargetComponentCount<MeshFilter>(model, 3);
            bool c7 = CheckHasMesh(model);
            bool checkModelRight = false;
            if (c6 && c7)
            {
                if (model.localPosition == Vector3.zero && model.localScale == Vector3.one)
                {
                    Vector3 localEuler = model.localEulerAngles;
                    if (localEuler != Vector3.zero && localEuler.x == 270 && localEuler.y == 0 && localEuler.z == 0)
                    {
                        //model如果有旋转，则合到父节点上时父节点也要相应的做旋转。
                        //如果还有collider节点合并了父节点，则collider要相应的调整center和size，达到和旋转前一样的效果
                        checkModelRight = true;
                    }
                }
            }

            if (checkModelRight)
            {
                CopyComponent<MeshFilter>(model, tf);
                CopyComponent<MeshRenderer>(model, tf);
                DestroyGameObject(model.gameObject);
                //修改父对象的localRotation
                Vector3 rootLocalRot = tf.localEulerAngles;
                rootLocalRot.x += -90;
                tf.localEulerAngles = rootLocalRot;

                //合collider
                Transform collider = tf.Find("collider");
                bool c2 = !CheckTargetHasComponent<BoxCollider>(tf);//父无 BoxCollider
                bool c3 = CheckTargetComponentCount<BoxCollider>(collider, 2);//已身上只有 BoxCollider 和 Transform
                bool c41 = CheckLocalPositionIsZero(collider);//己局部坐标为0
                bool c42 = CheckLocalRotationIsZero(collider);
                bool c43 = CheckLocalScaleIsOne(collider);
                bool c5 = collider.childCount == 0;//已无子节点
                if (c2 && c3 && c41 && c42 && c43 && c5)
                {
                    BoxCollider boxCo = collider.GetComponent<BoxCollider>();

                    //修改center和size，让其y与z互换，达到和旋转前一样的效果
                    Vector3 boxCoCenter = boxCo.center;
                    float cy = boxCoCenter.y;
                    boxCoCenter.y = boxCoCenter.z;
                    boxCoCenter.z = cy;
                    boxCo.center = boxCoCenter;

                    Vector3 boxCoSize = boxCo.size;
                    float sy = boxCoSize.y;
                    boxCoSize.y = boxCoSize.z;
                    boxCoSize.z = sy;
                    boxCo.size = boxCoSize;

                    CopyComponent<BoxCollider>(collider, tf);
                    DestroyGameObject(collider.gameObject);
                }
                else
                {
                    string msg = string.Format("{0} 合并不通过, collider 没通过校验", go.name);
                    Debug.LogWarning(msg);
                }
            }
            else
            {
                string msg = string.Format("{0} 合并不通过, model 没通过校验, c6:{1} c7:{2} model.localPos:{3} model.localScale:{4} model.localEulerAngles:{5}",
                    go.name, c6, c7, model.localPosition, model.localScale, model.localEulerAngles);
                Debug.LogWarning(msg);
            }
        }
        DebugLog();
    }

    public static void Combine_Tile_DuBai_Star()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<AnimEnemy>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            if (!Com_DestroySelf(tf.Find("collider")))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_XiaoWangZi_Enemy_Road01()
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
            if (!Com_DestroySelf(tf.Find("triggerPoint")))
            {
                Debug.LogWarning(go.name + " triggerPoint 合并不通过: ");
            }
            if (!Com_CopyBoxColliderAndDestroySelf(tf.Find("collider"), tf, true))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_model_and_collider()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            // if (!CheckTargetHasComponent<NormalTile>(tf))
            // {
            //     Debug.LogWarning(go.name + " 合并不通过: ");
            //     return;
            // }
            if (!Com_DestroySelf(tf.Find("model")))
            {
                Debug.LogWarning(go.name + " model 合并不通过: ");
            }
            Com_CopyAllChildBoxColliderAndDestroySelf(tf, true, false);
        }
        DebugLog();
    }

    private static void doCheckMaterial(Transform tf)
    {
        MeshFilter mf = tf.GetComponent<MeshFilter>();
        if (mf && mf.sharedMesh != null)
        {
            MeshRenderer meshRender = tf.GetComponent<MeshRenderer>();
            if (meshRender)
            {
                Material[] sharedMaterials = meshRender.sharedMaterials;
                if (sharedMaterials.Length == 0)
                {
                    Debug.LogError("sharedMaterials cannot be null, go.name:" + tf.name);
                }
            }
        }
        for (int i = 0; i < tf.childCount; i++)
        {
            doCheckMaterial(tf.GetChild(i));
        }
    }
    public static void Combine_CheckMaterial()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            doCheckMaterial(go.transform);
        }
    }

    public static void Combine_JiaoTang_or_YanCong_or_fangzi_or_effectJump()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            // if (!CheckTargetHasComponent<NormalEnemy>(tf))
            // {
            //     Debug.LogWarning(go.name + " 合并不通过: ");
            //     return;
            // }
            if (!Com_DestroySelf(tf.Find("triggerPoint")))
            {
                Debug.LogWarning(go.name + " triggerPoint 合并不通过: ");
            }
            Com_CopyAllChildBoxColliderAndDestroySelf(tf, true, false);
        }
        DebugLog();
    }

    public static void Combine_Tile_Bug_or_StarDown()
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
            if (!Com_DestroySelf(tf.Find("triggerPoint")))
            {
                Debug.LogWarning(go.name + " triggerPoint 合并不通过: ");
            }
            if (!Com_DestroySelf(tf.Find("collider")))
            {
                Debug.LogWarning(go.name + " collider 合并不通过: ");
            }
        }
        DebugLog();
    }

    public static void Combine_Just_Collider()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            // if (!CheckTargetHasComponent<NormalJumpTile>(tf))
            // {
            //     Debug.LogWarning(go.name + " 合并不通过: ");
            //     return;
            // }
            Com_CopyAllChildBoxColliderAndDestroySelf(tf, true, false);
        }
        DebugLog();
    }

    public static void Combine_Award_Diamond()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<DiamondAward>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            Com_CopyAllChildBoxColliderAndDestroySelf(tf, true, false);
            if (!Com_CopyAudioAndDestroySelf(tf.Find("audio"), tf))
            {
                Debug.LogWarning(go.name + " audio 合并不通过: ");
            }
        }
        DebugLog();
    }

}
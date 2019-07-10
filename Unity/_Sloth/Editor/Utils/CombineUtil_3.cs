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

    private static void DoDelAnimation(Transform node)
    {
        Animation anim = node.GetComponent<Animation>();
        if (anim != null)
        {
            GameObject.DestroyImmediate(anim);
        }
        for (int i = 0; i < node.childCount; i++)
        {
            Transform child = node.GetChild(i);
            DoDelAnimation(child);
        }
    }

    private static void DoDelAnimator(Transform node)
    {
        Animator anim = node.GetComponent<Animator>();
        if (anim != null)
        {
            GameObject.DestroyImmediate(anim);
        }
        for (int i = 0; i < node.childCount; i++)
        {
            Transform child = node.GetChild(i);
            DoDelAnimator(child);
        }
    }
    public static void Del_All_Animator()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            DoDelAnimator(tf);
        }
    }

    private static void DoRewrite_GridId(Transform node, int gridIndex)
    {
        BaseElement ele = node.GetComponent<BaseElement>();
        if (ele != null)
        {
            ele.m_gridId = gridIndex;
        }
        for (int i = 0; i < node.childCount; i++)
        {
            Transform child = node.GetChild(i);
            DoRewrite_GridId(child, gridIndex);
        }
    }

    public static void Rewrite_GridId()
    {
        GameObject go = Selection.activeGameObject;
        if (go.name != "GridGroup")
        {
            Debug.LogError("请选中GridGroup，在点击本按钮");
            return;
        }
        Transform tf = go.transform;
        for (int i = 0; i < tf.childCount; i++)
        {
            DoRewrite_GridId(tf.GetChild(i), i);
        }
    }

    private static int index = 5;
    private static int id = 1000;
    public static void ChangeToWideTilePro()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            BaseElement ele = go.GetComponent<BaseElement>();
            if (ele)
            {
                int gridId = ele.m_gridId;
                int pointX = ele.point.m_x;
                int pointY = ele.point.m_y;
                GameObject.DestroyImmediate(ele);

                BoxCollider bc = go.GetComponent<BoxCollider>();

                WideTilePro wildTile = go.AddComponent<WideTilePro>();
                wildTile.m_id = 708;
                wildTile.m_gridId = gridId;
                wildTile.point.m_x = pointX;
                wildTile.point.m_y = pointY;
                wildTile.data.Width = bc.size.x;
                wildTile.data.Height = bc.size.z;
                wildTile.data.BeginDistance = -(Mathf.FloorToInt(bc.size.z / 2));
                wildTile.data.ResetDistance = (Mathf.FloorToInt(bc.size.z / 2));
                wildTile.data.IfCheckMissTile = true;
                wildTile.data.MissTiles = new string[0];
                go.name = "Waltz_Tile_Empty1x1_" + index + "_" + id;
                id++;
            }
        }
    }

    private static void DoCheckPosNotEqualPoint(GameObject go)
    {
        Transform tf = go.transform;
        BaseElement ele = go.GetComponent<BaseElement>();
        if (go.activeSelf && ele)
        {
            if (ele.point.m_x != Mathf.FloorToInt(tf.localPosition.x))
            {
                Debug.Log(go.name + " localPosition.x not equal BaseElement.point.x");
            }
            if (ele.point.m_y != Mathf.FloorToInt(tf.localPosition.z))
            {
                Debug.Log(go.name + " localPosition.z not equal BaseElement.point.y");
            }
        }

        for (int i = 0; i < tf.childCount; i++)
        {
            DoCheckPosNotEqualPoint(tf.GetChild(i).gameObject);
        }
    }

    public static void CheckPosZNotEqualPointY()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            DoCheckPosNotEqualPoint(go);
        }
    }

    public static void ChangeMoveAllDirTieNewStar()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            Transform modelTf = tf.Find("model");
            if (modelTf != null)
            {
                modelTf.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
                modelTf.localEulerAngles = new Vector3(-90, -45, 0);
            }
        }
    }

    public static void ChangeAnimEnemyToMoveAllDirTileNew()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            AnimEnemy c1 = tf.GetComponent<AnimEnemy>();
            if (c1 == null)
            {
                continue;
            }
            Transform modelTf = tf.Find("model");
            if (modelTf != null)
            {
                modelTf.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
                modelTf.localEulerAngles = new Vector3(-90, -45, 0);
            }

            MoveAllDirTileNew c2 = go.AddComponent<MoveAllDirTileNew>();
            c2.m_id = 1401;
            c2.m_gridId = c1.m_gridId;
            c2.point.m_x = c1.point.m_x;
            c2.point.m_y = c1.point.m_y;
            // c2.data.MoveDirection = TileDirection.Right;
            // c2.data.MoveDistance = 
            c2.data.SpeedScaler = 0.5f;
            c2.data.BeginDistance2 = 7;

            GameObject.DestroyImmediate(c1);
        }
    }
}
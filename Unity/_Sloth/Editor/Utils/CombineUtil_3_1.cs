using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineUtil_3_1 : CombineBase {

	
    public static void Combine_Tile_XiaoZhen_Move()  // 删除 268 注意 完全匹配名字
    {
        Transform[] tfs = Selection.transforms;
        foreach (Transform tf in tfs)
        {
            bool a = CheckTargetComponentCount<MoveAllDirTile>(tf, 2);
            Transform collider_tf = tf.Find("collider");
            Transform model_tf = tf.Find("model");
            if(a && collider_tf && model_tf)
            {
                bool b = CheckTargetComponentCount<BoxCollider>(collider_tf, 2);
                bool c = CheckTargetComponentCount<MeshFilter>(model_tf, 3);
                bool d = CheckLocalPositionIsZero(model_tf);
                bool e = CheckLocalScaleIsOne(model_tf);
                bool f = CheckLocalPositionIsZero(collider_tf);
                bool g = CheckLocalScaleIsOne(collider_tf);
                bool h = CheckLocalRotationIsZero(collider_tf);
                BoxCollider cbc = collider_tf.GetComponent<BoxCollider>();
                bool i = cbc.center == new Vector3(0,-0.2f,0);
                bool j = cbc.size == new Vector3(1, 0.4f, 1);
                if (b && c && d && e && f && g && h && i && j)
                {
                    CopyComponent<MeshFilter>(model_tf, tf);
                    CopyComponent<MeshRenderer>(model_tf, tf);
                    SetTransformRotation(model_tf.gameObject, tf.gameObject);

                    CopyComponent<BoxCollider>(collider_tf, tf);
                    BoxCollider bc = tf.GetComponent<BoxCollider>();
                    bc.center = new Vector3(0,0,-0.2f);
                    bc.size = new Vector3(1,1,0.4f);
                    bc.isTrigger = true;

                    DestroyGameObject(model_tf.gameObject);
                    DestroyGameObject(collider_tf.gameObject);
                }
                else
                {
                    Debug.LogError("条件不对" + tf.name);
                }
            }
        }
        DebugLog();

    }

    public static void Combine_Tile_XiaoZhen_Move_Water() // 删除 247 注意 完全匹配名字
    {
        Transform[] tfs = Selection.transforms;
        foreach (Transform tf in tfs)
        {
            bool a = CheckTargetComponentCount<MoveAllDirTile>(tf, 2);
            Transform collider_tf = tf.Find("collider");
            Transform model_tf = tf.Find("model");
            if (a && collider_tf && model_tf)
            {
                bool b = CheckTargetComponentCount<BoxCollider>(collider_tf, 2);
                bool c = CheckTargetComponentCount<Transform>(model_tf, 1);
                bool f = CheckLocalPositionIsZero(collider_tf);
                bool g = CheckLocalScaleIsOne(collider_tf);
                bool h = CheckLocalRotationIsZero(collider_tf);
                BoxCollider cbc = collider_tf.GetComponent<BoxCollider>();
                bool i = cbc.center == new Vector3(0, -0.2f, 0);
                bool j = cbc.size == new Vector3(1, 0.4f, 1);
                if (b && c && f && g && h && i && j)
                {
                    CopyComponent<BoxCollider>(collider_tf, tf);
                    BoxCollider bc = tf.GetComponent<BoxCollider>();
                    bc.isTrigger = true;

                    DestroyGameObject(model_tf.gameObject);
                    DestroyGameObject(collider_tf.gameObject);
                }
                else
                {
                    Debug.LogError("条件不对" + tf.name);
                }
            }
        }
        DebugLog();
    }

    public static void Combine_Tile_P0_TwoStepsJump_Start() // 删除  注意 完全匹配名字  Tile_P0_TwoStepsJump_Start
    {
        Transform[] tfs = Selection.transforms;
        foreach (Transform tf in tfs)
        {
            bool a = CheckTargetComponentCount<JumpDistanceQTETile>(tf, 2);
            Transform collider_tf = tf.Find("collider");
            Transform model_tf = tf.Find("model");
            if (a && collider_tf && model_tf)
            {
                bool b = CheckTargetComponentCount<BoxCollider>(collider_tf, 2);
                bool c = CheckTargetComponentCount<AudioSource>(model_tf, 2);
                bool d = CheckLocalPositionIsZero(model_tf);
                bool e = CheckLocalScaleIsOne(model_tf);
                bool f = CheckLocalPositionIsZero(collider_tf);
                bool g = CheckLocalScaleIsOne(collider_tf);
                bool h = CheckLocalRotationIsZero(collider_tf);
                bool k = model_tf.childCount == 2;
                BoxCollider cbc = collider_tf.GetComponent<BoxCollider>();
                bool i = cbc.center == new Vector3(0, -0.2f, 0);
                if (b && c && d && e && f && g && h && i && k)
                {
                    Transform state1 = model_tf.Find("state1");
                    if(state1 == null)
                    {
                        Debug.LogError(" state1 条件不对" + tf.name);
                        continue;
                    }

                    Transform state2 = model_tf.Find("state2");
                    if(state2 == null)
                    {
                        Debug.LogError(" state2 条件不对" + tf.name);
                        continue;
                    }

                    SetParent(state1, tf);
                    SetParent(state2, tf);

                    CopyComponent<AudioSource>(model_tf, tf);

                    CopyComponent<BoxCollider>(collider_tf, tf);

                    DestroyGameObject(model_tf.gameObject);
                    DestroyGameObject(collider_tf.gameObject);
                }
                else
                {
                    Debug.LogError("条件不对" + tf.name);
                }
            }
        }
        DebugLog();
    }
    //RS2.FreeMoveTile child count 6
    public static void Combine_FreeMoveTile_6(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = CheckTargetComponentAndChildsCount<RS2.FreeMoveTile>(t, 6);
            if (b)
            {
                Transform path = t.Find("path");
                Transform model = t.Find("model");
                Transform collider = t.Find("collider");

                bool d2 = CheckLocalPositionIsZero(collider);
                bool e2 = CheckLocalRotationIsZero(collider);
                bool f2 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(collider.GetComponent<BoxCollider>());

                if(d2 && e2 && f2 && g2)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);

                    DestroyGameObject(path.gameObject, 3);
                    DestroyGameObject(model.gameObject, 3);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    //RS2.FreeMoveTile child count 9
    public static void Combine_FreeMoveTile_9(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = true;// CheckTargetComponentAndChildsCount<RS2.FreeMoveTile>(t, 9);
            if (b)
            {
                Transform path = t.Find("path");

                if (path != null)
                {
                    DestroyGameObject(path.gameObject, 3);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    //AnimEnemyPro triggerPoint
    public static void Combine_AnimEnemyPro_triggerPoint(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            Transform triggerPoint = t.Find("triggerPoint");

            if (triggerPoint != null)
            {
                DestroyGameObject(triggerPoint.gameObject);
                continue;
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }

    //MultiSegmentAnimationTile
    public static void Combine_MultiSegmentAnimationTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool b = CheckTargetComponentAndChildsCount<MultiSegmentAnimationTile>(t, 4);
            if (b)
            {
                Transform model = t.Find("model");
                Transform collider = model.Find("collider");
                Transform cmodel = model.Find("model");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckLocalPositionIsZero(model);
                bool e2 = CheckLocalRotationIsZero(model);
                bool f2 = CheckLocalScaleIsOne(model);

                bool d3 = CheckLocalPositionIsZero(collider);
                bool e3 = CheckLocalRotationIsZero(collider);
                bool f3 = CheckLocalScaleIsOne(collider);
                bool g2 = CheckColliderCenterXZ(bc);

                if (model != null && collider != null && cmodel != null && d2 && e2 && f2 && d3 && e3 && f3 && g2)
                {
                    CopyComponent<BoxCollider>(collider, t);
                    SetParent(cmodel, t);

                    DestroyGameObject(model.gameObject,2);
                    continue;
                }
            }
            Debug.LogError("条件不满足: " + t.name);
        }
        DebugLog();
    }
    //HorizonMoveTile
    public static void Combine_HorizonMoveTile(Transform[] tfs)  // Tile_Road
    {
        foreach (Transform t in tfs)
        {
            if (!CheckTargetHasComponent<HorizonMoveTile>(t))
            {
                Debug.LogWarning(t.name + " 合并不通过: ");
                continue;
            }
            if (t.childCount != 2)
            {
                Debug.LogWarning(t.name + " 合并不通过: childCount not 2");
                continue;
            }
            Transform model = t.Find("model");
            if (model == null)
            {
                Debug.LogWarning(t.name + " 合并不通过: model is null");
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
                CopyComponent<MeshFilter>(model, t);
                CopyComponent<MeshRenderer>(model, t);
                DestroyGameObject(model.gameObject);
                //修改父对象的localRotation
                Vector3 rootLocalRot = t.localEulerAngles;
                rootLocalRot.x += -90;
                t.localEulerAngles = rootLocalRot;

                //合collider
                Transform collider = t.Find("collider");
                bool c2 = !CheckTargetHasComponent<BoxCollider>(t);//父无 BoxCollider
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

                    CopyComponent<BoxCollider>(collider, t);
                    DestroyGameObject(collider.gameObject);
                }
                else
                {
                    string msg = string.Format("{0} 合并不通过, collider 没通过校验", t.name);
                    Debug.LogWarning(msg);
                }
            }
            else
            {
                string msg = string.Format("{0} 合并不通过, model 没通过校验, c6:{1} c7:{2} model.localPos:{3} model.localScale:{4} model.localEulerAngles:{5}",
                    t.name, c6, c7, model.localPosition, model.localScale, model.localEulerAngles);
                Debug.LogWarning(msg);
            }
        }
        DebugLog();
    }

    //JumpDistanceTrigger
    public static void Combine_JumpDistanceTrigger(Transform[] tfs)
    {
        CombineUtil_5_1.Combine_JumpDistanceTrigger(tfs);
    }

    //DoorEnemy
    public static void Combine_DoorEnemy(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            
        }
    }
}

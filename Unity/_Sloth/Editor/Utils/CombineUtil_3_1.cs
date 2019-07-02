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

}

using RS2;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombineUtil_0 : CombineBase
{
    
    public static void Combine_Collider_Audio()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            Transform model = tf.Find("model");
            Transform collider = tf.Find("collider");
            if (model != null)
            {
                if (CheckTargetComponentCount<AudioSource>(model, 2) && model.childCount == 0)
                {
                    CopyComponent<AudioSource>(model, tf);
                    DestroyGameObject(model.gameObject);
                }
            }
            if (collider != null)
            {
                bool c2 = !CheckTargetHasComponent<BoxCollider>(tf);//父无 BoxCollider
                bool c3 = CheckTargetComponentCount<BoxCollider>(collider, 2);//已身上只有 BoxCollider 和 Transform
                bool c4 = CheckLocalPositionIsZero(collider);//己局部坐标为0
                bool c5 = CheckLocalRotationIsZero(collider);
                bool c6 = CheckLocalScaleIsOne(collider);
                bool c7 = collider.childCount == 0;//已无子节点
                if (c2 && c3 && c4 && c5 && c6 && c7)
                {
                    CopyComponent<BoxCollider>(collider, tf);
                    DestroyGameObject(collider.gameObject);
                }
            }
        }
        DebugLog();
    }

    public static void Combine_Collider_Model()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            Transform model = tf.Find("model");
            Transform collider = tf.Find("collider");
            if(model != null)
            {
                if (CheckTargetComponentCount<Transform>(model, 1) && model.childCount == 0)
                {
                    DestroyGameObject(model.gameObject);
                }
            }
            if (collider != null)
            {
                bool c2 = !CheckTargetHasComponent<BoxCollider>(tf);//父无 BoxCollider
                bool c3 = CheckTargetComponentCount<BoxCollider>(collider, 2);//已身上只有 BoxCollider 和 Transform
                bool c4 = CheckLocalPositionIsZero(collider);//己局部坐标为0
                bool c5 = CheckLocalRotationIsZero(collider);
                bool c6 = CheckLocalScaleIsOne(collider);
                bool c7 = collider.childCount == 0;//已无子节点
                Debug.Log(c2 + " " + c3 + " " + c4 + " " + c5 + " " + c6 + " " + c7);
                if (c2 && c3 && c4 && c5 && c6 && c7)
                {
                    CopyComponent<BoxCollider>(collider, tf);
                    DestroyGameObject(collider.gameObject);
                }
            }
        }
        DebugLog();
    }

    public static void Combine_PuGongYing()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            if (!CheckTargetHasComponent<DandelionEnemy>(tf))
            {
                Debug.LogWarning(go.name + " 合并不通过: ");
                return;
            }
            Transform model = tf.Find("model");
            if(model != null)
            {
                if (CheckTargetComponentCount<Transform>(model, 1) && model.childCount == 1)
                {
                    Transform puGongYing = model.Find("PuGongYing");
                    if(puGongYing != null)
                    {
                        if (CheckTargetComponentCount<Transform>(puGongYing, 1) && puGongYing.childCount == 0)
                        {
                            DestroyGameObject(model.gameObject, 2);
                        }
                    }
                }
            }
            Transform effect0 = tf.Find("effect0");
            if(effect0 != null)
            {
                DestroyGameObject(effect0.gameObject, 2);
            }
            Transform effect1 = tf.Find("effect1");
            if (effect1 != null)
            {
                SetParentAndName(effect1.GetChild(0), tf, "effect1");
                DestroyGameObject(effect1.gameObject);
            }
        }
        DebugLog();
    }

    #region Check


    public static void CheckPuGongYing()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            Transform tf = go.transform;
            Transform effect0 = tf.Find("effect0");
            Transform effect1 = tf.Find("effect1");
            bool c1 = CheckTargetHasComponent<DandelionEnemy>(tf);
            bool c2 = CheckChildFoNames(tf, new string[] { "effect0", "effect1" });
            bool c3 = CheckTargetComponentCount<Transform>(effect0, 1);
            bool c4 = CheckTargetComponentCount<Transform>(effect1, 1);
            if (c1 || c2 || c3 ||c4)
            {
                mSelectGos.Add(go);
                return;
            }

        }
    }

    #endregion



}

﻿using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public partial class Sloth : Editor
{
    [MenuItem("Sloth/Node/Rename all duplicate node")]
    static void RenameAllDuplicateNode()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
            NodeUtil.EnumGameObject(obj);
        EditorUtility.DisplayDialog("message", "rename complete!", "ok");
    }

    [MenuItem("Sloth/Node/Copy node path")]
    public static void GetNodePath()
    {
        GameObject[] objs = Selection.gameObjects;
        StreamWriter sr = FileUtil.GetTempFile();
        for (var i = 0; i < objs.Length; i++)
        {
            GameObject obj = objs[i];
            if (null == obj)
                continue;

            string strPath = obj.name;
            Transform parent = obj.transform.parent;
            while (parent != null)
            {
                strPath = parent.transform.name + "#" + strPath;
                parent = parent.transform.parent;
            }
            sr.WriteLine(strPath);
        }
        sr.Close();
        Application.OpenURL(FileUtil.GetTempFilePath());
    }

    /// <summary>
    /// 场景中的精灵数量
    /// </summary>
    [MenuItem("Sloth/Node/ActiveScene GameObject Count")]
    static void ActiveSceneGameObjectCount()
    {
        int count = SceneUtil.GetActiveSceneAllGameObjectCount();
        Debug.Log("当前游戏精灵总数量：" + count);
    }

    /// <summary>
    /// 场景中的网格碰撞器数量 
    /// </summary>
    [MenuItem("Sloth/Node/ActiveScene MeshCollider Count")]
    static void ActiveSceneMeshColliderCount()
    {
        int count = 0;
        List<GameObject> mcGo = new List<GameObject>();
        List <GameObject> list = SceneUtil.GetActiveSceneAllGO();
        if (list != null)
        {   
            foreach (GameObject item in list)
            {
                if (item.GetComponent<MeshCollider>())
                {
                    count++;
                    mcGo.Add(item);
                }
            }
            Selection.objects = mcGo.ToArray();
        }
        Debug.Log("当前游戏网络碰撞器总数量：" + count);
    }

    /// <summary>
    /// 场景中的刚体数量 
    /// </summary>
    [MenuItem("Sloth/Node/ActiveScene Rigidbody Count")]
    static void ActiveSceneRigidbodyCount()
    {
        int count = 0;
        List<GameObject> rbGo = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        if (list != null)
        {
            foreach (GameObject item in list)
            {
                if (item.GetComponent<Rigidbody>())
                {
                    count++;
                    rbGo.Add(item);
                }
            }
            Selection.objects = rbGo.ToArray();
        }
        Debug.Log("当前游戏刚体总数量：" + count);
    }

    /// <summary>
    /// 场景中的音频数量 
    /// </summary>
    [MenuItem("Sloth/Node/ActiveScene AudioSource Count")]
    static void ActiveSceneAudioSourceCount()
    {
        int count = 0;
        List<GameObject> asGo = new List<GameObject>();
        List<GameObject> list = SceneUtil.GetActiveSceneAllGO();
        if (list != null)
        {
            foreach (GameObject item in list)
            {
                if (item.GetComponent<AudioSource>())
                {
                    count++;
                    asGo.Add(item);
                }
            }
            Selection.objects = asGo.ToArray();
        }
        Debug.Log("当前游戏音频总数量：" + count);
    }

    /// <summary>
    /// 场景中未激活的对象数量
    /// </summary>
    [MenuItem("Sloth/Node/UnActive GameObject count")]
    static void UnActiveGameObjectCount()
    {
        NodeUtil.UnActiveGameObjectCount();
    }

    [MenuItem("Sloth/Node/Check node name repetition")]
    static void CheckObjectName()
    {
        NodeUtil.CheckObjectName();
    }

    [MenuItem("Sloth/Node/Repetition node name")]
    static void RepetitionObjectName()
    {
        if (EditorUtility.DisplayDialog("", "重命名场景中重复的对象名字", "确定", "取消"))
        {
            NodeUtil.RepetitionObjectName();
        }
    }
    [MenuItem("Sloth/Node/Statistical node Type")]
    static void StatisticalNodeType()
    {
        NodeUtil.StatisticalNodeType();
    }
}
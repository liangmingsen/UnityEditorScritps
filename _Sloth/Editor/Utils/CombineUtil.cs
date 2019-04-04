using UnityEngine;
using UnityEditor;

public class CombineUtil {

    #region 合并节点 - 删除子节点model 和 collider 。将collider碰撞组件复制到父节点
    private static int _destroyCount = 0;
    public static void CombineChilds()
    {
        _destroyCount = 0;
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
                _CopyChildCollider(go);
                _RemoveModelChild(go);
            }
        }
        Debug.Log("删除节点: " + _destroyCount);
    }

    private static void _RemoveModelChild(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("model");
            if (ctf != null)
            {
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }

    private static void _CopyChildCollider(GameObject root)
    {
        if (root != null)
        {
            Transform ctf = root.transform.Find("collider");
            if (ctf != null)
            {
                BoxCollider bcoll = ctf.GetComponent<BoxCollider>();
                if (bcoll != null)
                {
                    if(root.GetComponent<BoxCollider>() == null)
                    {
                        UnityEditorInternal.ComponentUtility.CopyComponent(bcoll);
                        UnityEditorInternal.ComponentUtility.PasteComponentAsNew(root);
                    }
                }
                GameObject.DestroyImmediate(ctf.gameObject);
                _destroyCount++;
            }
        }
    }

    #endregion




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundUtil {
    /// <summary>
    /// 获取中心点
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Vector3 GetCenter(GameObject target)
    {
        Renderer[] mrs = target.gameObject.GetComponentsInChildren<Renderer>();
        Vector3 center = target.transform.position;
        if (mrs.Length != 0)
        {
            Bounds bounds = new Bounds(center, Vector3.zero);
            foreach (Renderer mr in mrs)
            {
                bounds.Encapsulate(mr.bounds);
            }
            center = bounds.center;
        }
        return center;
    }
    /// <summary>
    /// 获取包围盒（通过Renderer）
    /// </summary>
    /// <param name="target"></param>
    /// <param name="includeChildren">包括子对象</param>
    /// <returns></returns>
    public static Bounds GetBounds(GameObject target, bool includeChildren = true)
    {
        Renderer[] mrs = target.GetComponentsInChildren<Renderer>();
        Vector3 center = target.transform.position;
        Bounds bounds = new Bounds(center, Vector3.zero);
        if (includeChildren)
        {
            if (mrs.Length != 0)
            {
                foreach (Renderer mr in mrs)
                {
                    bounds.Encapsulate(mr.bounds);
                }
            }
        }
        else
        {
            Renderer rend = target.GetComponentInChildren<Renderer>();
            if (rend)
            {
                bounds = rend.bounds;
            }
        }
        return bounds;
    }
    /// <summary>
    /// 获取包围盒（通过MeshFilter）
    /// </summary>
    /// <param name="target"></param>
    /// <param name="includeChildren">包括子对象</param>
    /// <returns></returns>
    public static Bounds GetLocalBounds(GameObject target, bool includeChildren = true)
    {
        MeshFilter[] mfs = target.GetComponentsInChildren<MeshFilter>();
        Vector3 center = target.transform.localPosition;
        Bounds bounds = new Bounds(center, Vector3.zero);
        if (includeChildren)
        {
            if (mfs.Length != 0)
            {
                foreach (MeshFilter mf in mfs)
                {
                    if (mf.sharedMesh)
                    {
                        bounds.Encapsulate(mf.sharedMesh.bounds);
                    }
                }
            }
        }
        else
        {
            MeshFilter mf = target.GetComponentInChildren<MeshFilter>();
            if (mf && mf.sharedMesh)
            {
                bounds = mf.sharedMesh.bounds;
            }
        }
        return bounds;
    }
}

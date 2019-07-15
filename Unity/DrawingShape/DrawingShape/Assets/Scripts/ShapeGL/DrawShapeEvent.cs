using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct DrawShapePoint : ICEventArgs
{
    public Vector3[] pointList;

    public DrawShapePoint(List<Vector3> pointList)
    {
        this.pointList = new Vector3[pointList.Count];
        pointList.CopyTo(this.pointList);
    }
}
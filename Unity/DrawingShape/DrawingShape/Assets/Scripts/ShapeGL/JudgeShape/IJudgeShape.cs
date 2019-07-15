using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 判断画的是什么形状
/// </summary>
public interface IJudgeShape
{
    bool JudgeShape(Vector3[] positions);

    ShapeType GetShapeType();

    int MinLength();


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 直线判断
/// </summary>
public class JShapeLine : IJudgeShape
{
    /// <summary>
    /// 点到直线的 垂直距离 误差容错值
    /// </summary>
    public float lineRange = 0.02f;//测试后的值。

    public bool JudgeShape(Vector3[] positions)
    {
        if (positions != null && positions.Length > MinLength())
        {
            int length = positions.Length-1;
            Vector3 startPoint = positions[0];
            Vector3 endPoint = positions[length];
            
            for (int i = 1; i < length; i ++)
            {
                if (!JudgeUtil.JudgePointInLine(startPoint, endPoint, positions[i], JShapeManager.Instance.Range))
                {
                    return false;
                }
            }
            Debug.Log("判断为 直线 ----------");
            return true;
        }
        return false;
    }

    public ShapeType GetShapeType()
    {
        return ShapeType.Line;
    }
    /// <summary>
    /// 至少由多少个点组成一条直线，同理可由此规定直线的长度。
    /// </summary>
    /// <returns></returns>
    public int MinLength()
    {
        return 6;
    }
}

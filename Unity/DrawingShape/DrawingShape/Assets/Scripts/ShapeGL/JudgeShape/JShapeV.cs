using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
public class JShapeV : IJudgeShape
{
    public float lineRange = 0.02f;
    /// <summary>
    /// 忽略转弯角的前后多个点，不进行计算。
    /// 此值不应该超过 MinLength 的 1/4;
    /// </summary>
    public int loseWheelRadius = 2;

    public ShapeType GetShapeType()
    {
        return ShapeType.V;
    }

    public bool JudgeShape(Vector3[] positions)
    {
        if (positions != null && positions.Length > MinLength())
        {
            int length = positions.Length - 1;
            Vector3 startPoint = positions[0];
            Vector3 endPoint = positions[length];
            Vector3 startPoint2 = positions[0];
            Vector3 endPoint2 = positions[length];
            Vector3 bottomPoint = startPoint;
            int bottomIndex = 0;
            for (int i = 1; i < length; i++)
            {
                //找出最低点。
                if (positions[i].y < bottomPoint.y)
                {
                    bottomIndex = i;
                }
            }
            //忽略最低点前后的N个点
            bottomIndex = bottomIndex - loseWheelRadius;
            if (bottomIndex > 0)
            {
                bottomPoint = positions[bottomIndex];
            }
            else
            {
                return false;
            }

            bool isUp = false;
            for (int i = 1; i < length; i++)
            {
                if (i == bottomIndex)
                {
                    isUp = true;
                    //忽略最低点前后的N个点
                    i += loseWheelRadius;
                    if (i < length)
                        bottomPoint = positions[i];
                    else
                        return false;
                }
                if (!isUp)
                {   
                    if(!JudgeUtil.JudgePointInLine(startPoint, bottomPoint, positions[i], lineRange))
                    {
                        Debug.Log("V 前半段判断失败 ----------");
                        return false;
                    }
                }
                else
                {
                    if (!JudgeUtil.JudgePointInLine(bottomPoint, endPoint, positions[i], lineRange*2))
                    {
                        Debug.Log("V 后半段判断失败 ----------");
                        return false;
                    }
                }
            }
            Debug.Log("判断为 V ----------");
            return true;
        }
        return false;
    }

    public int MinLength()
    {
        return 10;
    }
}
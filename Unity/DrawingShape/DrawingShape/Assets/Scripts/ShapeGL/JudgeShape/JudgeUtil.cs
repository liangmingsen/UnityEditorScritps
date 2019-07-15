using UnityEngine;
using UnityEditor;

public static class JudgeUtil
{
    /// <summary>
    /// 判断点是否在直线范围上。
    /// 实际上是判断点到直线的垂直距离。
    /// </summary>
    /// <param name="startPoint">直线起点</param>
    /// <param name="endPoint">直线结束点</param>
    /// <param name="checkPoint">判断是否在直线上的点</param>
    /// <param name="range">点到直线的 垂直距离 误差容错值</param>
    /// <returns></returns>
    public static bool JudgePointInLine(Vector3 startPoint, Vector3 endPoint, Vector3 checkPoint, float range = 0)
    {
        //判断点在线段首尾两端之外则 return false。
        float cross = (endPoint.x - startPoint.x) * (checkPoint.x - startPoint.x) + (endPoint.y - startPoint.y) * (checkPoint.y - startPoint.y);
        if (cross <= 0)
        {
            Debug.Log("cross 不在直线内 " + cross);
            return false;
        }

        float lineLength = (endPoint.x - startPoint.x) * (endPoint.x - startPoint.x) + (endPoint.y - startPoint.y) * (endPoint.y - startPoint.y);
        if (cross >= lineLength)
        {
            Debug.Log("cross 不在直线内 lineLength " + cross + " / " + lineLength);
            return false;
        }
            
        float r = cross / lineLength;
        float px = startPoint.x + (endPoint.x - startPoint.x) * r;
        float py = startPoint.y + (endPoint.y - startPoint.y) * r;
        return Mathf.Sqrt((checkPoint.x - px) * (checkPoint.x - px) + (py - checkPoint.y) * (py - checkPoint.y)) <= range;
    }


}
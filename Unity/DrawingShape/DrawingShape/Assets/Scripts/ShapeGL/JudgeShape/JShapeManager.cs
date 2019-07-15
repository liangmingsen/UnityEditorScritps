using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JShapeManager : MonoBehaviour
{
    public float Range;//测试代码

    private IJudgeShape _judgeLine;
    private IJudgeShape _judgeV;

    public static JShapeManager Instance;//测试代码

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _judgeLine = new JShapeLine();
        _judgeV = new JShapeV();
    }

    private void OnEnable()
    {
        CEventUtil.AddListener(CEventName.JUDGE_SHAPE, _HandlerJudgeShape);
    }

    private void OnDisable()
    {
        CEventUtil.RemoveListener(CEventName.JUDGE_SHAPE, _HandlerJudgeShape);
    }

    private void _HandlerJudgeShape(ICEventArgs args)
    {
        DrawShapePoint point = (DrawShapePoint)args;
        //List<Vector3> points = args;
        //_judgeLine.JudgeShape(points);
        //_judgeV.JudgeShape(points);
    }
       


}

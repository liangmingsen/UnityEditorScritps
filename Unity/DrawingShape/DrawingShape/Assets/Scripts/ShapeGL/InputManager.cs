using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// 画线条首尾最小间隔。
    /// </summary>
    public float interval = 0.5f;
    /// <summary>
    /// 记录移动时的点轨迹
    /// </summary>
    private List<Vector3> _drawPoints;

    private bool _isMouseDown;

    private Vector3 _lastMousePos;

    // Start is called before the first frame update
    void Start()
    {
        _drawPoints = new List<Vector3>();
        _isMouseDown = false;
        _lastMousePos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _CheckInput();
    }

    private void FixedUpdate()
    {
        
    }

    private void _CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
            _lastMousePos = Input.mousePosition;
            _drawPoints.Clear();
            _AddPointToList(_lastMousePos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CEventUtil.SendEvent(CEventName.JUDGE_SHAPE, new DrawShapePoint(_drawPoints));
            _isMouseDown = false;
        }
        if (_isMouseDown)
        {
            if (Vector3.Distance(_lastMousePos, Input.mousePosition) >= interval)
            {
                _AddPointToList(Input.mousePosition);
            }
            _lastMousePos = Input.mousePosition;
        }
    }
    /// <summary>
    /// 添加点
    /// </summary>
    /// <param name="mousePos"></param>
    private void _AddPointToList(Vector3 mousePos)
    {
        if(_lastMousePos != mousePos)
        {
            _drawPoints.Add(_GetPositionToOrtho(mousePos));
            CEventUtil.SendEvent(CEventName.DRAW_SHAPE, new DrawShapePoint(_drawPoints));
        }
    }
    /// <summary>
    /// 返回一个正交相机坐标。
    /// </summary>
    /// <param name="mousePos"></param>
    /// <returns></returns>
    private Vector3 _GetPositionToOrtho(Vector3 mousePos)
    {
        return new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
    }

}

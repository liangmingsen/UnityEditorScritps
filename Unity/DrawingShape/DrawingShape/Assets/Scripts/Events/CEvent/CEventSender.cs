using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// C# 事件派发器
/// </summary>
public class CEventSender
{
    private Dictionary<string, CEventListener> _eDic = new Dictionary<string, CEventListener>();
    /// <summary>
    /// 添加事件监听器
    /// </summary>
    /// <param name="eType">事件名称</param>
    /// <param name="handler">事件处理器</param>
    public void AddListener(string eType, CEventHandler<ICEventArgs> handler)
    {
        CEventListener invoker;
        if(!_eDic.TryGetValue(eType, out invoker))
        {
            invoker = new CEventListener();
            _eDic.Add(eType, invoker);
        }
        invoker.handler += handler;
    }
    /// <summary>
    /// 移除事件监听器
    /// </summary>
    /// <param name="eType">事件名称</param>
    /// <param name="handler">事件处理器</param>
    public void RemoveListener(string eType, CEventHandler<ICEventArgs> handler)
    {
        CEventListener invoker;
        if (_eDic.TryGetValue(eType, out invoker))
            invoker.handler -= handler;
    }
    /// <summary>
    /// 是否已拥有该类型的事件
    /// </summary>
    /// <param name="eType">事件类型</param>
    /// <returns></returns>
    public bool HasListener(string eType)
    {
        return _eDic.ContainsKey(eType);
    }
    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eType">事件类型</param>
    /// <param name="args">事件参数结构</param>
    public void SendEvent(string eType, ICEventArgs  arg)
    {
        CEventListener invoker;
        if (_eDic.TryGetValue(eType, out invoker))
        {
            invoker.Invoke(arg);
        }
    }
    /// <summary>
    /// 清理所有事件监听器
    /// </summary>
    public void Clear()
    {
        foreach (CEventListener val in _eDic.Values)
        {
            val.Clear();
        }
        _eDic.Clear();
    }
}

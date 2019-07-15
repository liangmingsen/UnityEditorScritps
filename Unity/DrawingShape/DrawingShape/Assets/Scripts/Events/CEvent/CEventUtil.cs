using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// C# 事件工具类
/// 使用实例：
/// 添加监听 —— CEventUtil.AddListener(eventType, eventHandler);
/// 
/// 事件派发 —— CEventUtil.SendEvent(eventType, ...args);
/// 
/// 事件定义 —— 
/// </summary>
public static class CEventUtil
{

    private static CEventSender _sender = new CEventSender();
    /// <summary>
    /// 添加事件监听器
    /// </summary>
    /// <param name="eType">事件名称</param>
    /// <param name="handler">事件处理器</param>
    public static void AddListener(string eType, CEventHandler<ICEventArgs> handler)
    {
        _sender.AddListener(eType, handler);
    }
    /// <summary>
    /// 移除事件监听器
    /// </summary>
    /// <param name="eType">事件名称</param>
    /// <param name="handler">事件处理器</param>
    public static void RemoveListener(string eType, CEventHandler<ICEventArgs> handler)
    {
        _sender.RemoveListener(eType, handler);
    }
    /// <summary>
    /// 是否已拥有该类型的事件
    /// </summary>
    /// <param name="eType">事件类型</param>
    /// <returns></returns>
    public static bool HasListener(string eType)
    {
        return _sender.HasListener(eType);
    }
    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eType">事件类型</param>
    /// <param name="args">事件参数结构</param>
    public static void SendEvent(string eType, ICEventArgs args)
    {
        _sender.SendEvent(eType, args);
    }
    /// <summary>
    /// 清理所有事件监听器
    /// </summary>
    public static void Clear()
    {
        _sender.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 事件处理器 - 委托
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="args"></param>
public delegate void CEventHandler<ICEventArgs>(ICEventArgs args);

/// <summary>
/// 事件监听器
/// </summary>
public class CEventListener
{
    /// <summary>
    /// 事件处理器集合
    /// </summary>
    public CEventHandler<ICEventArgs> handler;
    /// <summary>
    /// 调用所有添加的事件
    /// </summary>
    /// <param name="args"></param>
    public void Invoke(ICEventArgs args)
    {
        if (handler != null)
            handler.Invoke(args);
    }
    /// <summary>
    /// 清理所有事件 委托
    /// </summary>
    public void Clear()
    {
        handler = null;
    }
}

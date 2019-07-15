using UnityEngine;

public class TimeManager {
    /// <summary>
    /// 游戏中每秒更新事件-不受timeScale的影响
    /// </summary>
    public const string E_UN_SCALE_SECOND_PAST = "TimeEvent.UnScaleSecondPast";
    /// <summary>
    /// 游戏中每秒更新事件-受timeScale的影响
    /// </summary>
    public const string E_SCALE_SECOND_PAST = "TimeEvent.ScaleSecondPast";

    private static TimeManager _instance = null;
    public static TimeManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new TimeManager();
                _instance._isInit = true;
            }
            return Instance;
        }
    }

    private bool _isInit = false;
    //非缩放计时
    private float _unScaleEscapeTime = 0;
    private float _tryAddUnscaleEscapeTime = 0;
    private int _deltaUnscaleEscapeTime = 0;
    //缩放计时
    private float _scaleEscapeTime = 0;
    private float _tryAddScaleEscapeTime = 0;
    private int _deltaScaleEscapeTime = 0;

    public void Update(float timeSinceStartup)
    {
        if (!_isInit)
        {
            return;
        }
        _UpdateSecond();
    }

    private void _UpdateSecond()
    {
        //Time.unscaledDeltaTime ： 最后一帧到当前帧的独立时间间隔;不受timeScale的影响。
        _tryAddUnscaleEscapeTime = _unScaleEscapeTime + Time.unscaledDeltaTime;
        _deltaUnscaleEscapeTime = (int)_tryAddUnscaleEscapeTime - (int)_unScaleEscapeTime;
        if (_deltaUnscaleEscapeTime > 0)
        {
            for (int i = 0; i < _deltaUnscaleEscapeTime; i++)
            {
                CEventUtil.SendEvent(E_UN_SCALE_SECOND_PAST, null);
            }
        }
        _unScaleEscapeTime += Time.unscaledDeltaTime;

        //Time.deltaTime : 当前帧和上一帧之间的时间;受timeScale的影响。
        _tryAddScaleEscapeTime = _scaleEscapeTime + Time.deltaTime;
        _deltaScaleEscapeTime = (int)_tryAddScaleEscapeTime - (int)_scaleEscapeTime;
        if (_deltaScaleEscapeTime > 0)
        {
            for (int i = 0; i < _deltaScaleEscapeTime; i++)
            {
                CEventUtil.SendEvent(E_SCALE_SECOND_PAST, null);
            }
        }
        _scaleEscapeTime += Time.deltaTime;
    }


}

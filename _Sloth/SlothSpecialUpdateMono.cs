using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothSpecialUpdateMono : MonoBehaviour {

    /// <summary>
    /// 按Grid更新，默认当前Grid更新，无需添加此脚本，只对特殊跨多个或需一直，或提前更新的。标记，多段。
    /// </summary>
    [SerializeField]
    public bool IsSpecial = true;

}

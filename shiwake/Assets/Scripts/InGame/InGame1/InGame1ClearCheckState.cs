using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1ClearCheckState : StateBase {

    /// <summary>
    /// 初期化前処理.
    /// </summary>
    override public bool OnBeforeInit()
    {
		return true;
    }

    /// <summary>
    /// メイン前処理.
    /// </summary>
    override public bool OnBeforeMain()
    {
		return false;
    }

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

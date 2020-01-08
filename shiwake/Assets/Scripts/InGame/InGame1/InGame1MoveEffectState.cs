using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame1MoveEffectState : StateBase {

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
		return true;
    }

    /// <summary>
    /// メイン更新処理.
    /// </summary>
    /// <param name="delta">経過時間</param>
    override public void OnUpdateMain(float delta)
    {
    }

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

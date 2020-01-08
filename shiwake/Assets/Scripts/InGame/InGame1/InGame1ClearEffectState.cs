using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1ClearEffectState : StateBase {

    /// <summary>
    /// メイン前処理.
    /// </summary>
    override public bool OnBeforeMain()
    {
		return false;
    }

    /// <summary>
    /// メイン更新処理.
    /// </summary>
    /// <param name="delta">経過時間</param>
    override public void OnUpdateMain(float delta)
    {
        StateMachineManager.Instance.ChangeState(StateMachineName.InGame, (int)InGame1State.End);
    }

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

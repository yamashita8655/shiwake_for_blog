using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1StartEffectState : StateBase {

    /// <summary>
    /// 初期化前処理.
    /// </summary>
    override public bool OnBeforeInit()
    {
		StateMachineManager.Instance.ChangeState(StateMachineName.InGame, (int)InGame1State.UserWait);

		return false;
    }

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

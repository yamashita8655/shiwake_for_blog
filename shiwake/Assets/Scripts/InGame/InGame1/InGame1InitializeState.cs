using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1InitializeState : StateBase {

    /// <summary>
    /// 初期化前処理.
    /// </summary>
    override public bool OnBeforeInit()
    {
		InGame1Scene scene = InGame1DataCarrier.Instance.Scene as InGame1Scene;

		for (int i = 0; i < scene.PalletObjectControllers.Length; i++) {
			scene.PalletObjectControllers[i].Initialize((Enum.BaggageType)i);
		}

		InGame1DataCarrier.Instance.CurrentScore = 0;
		scene.UpdateScoreText();

		return true;
    }

    /// <summary>
    /// メイン更新処理.
    /// </summary>
    /// <param name="delta">経過時間</param>
    override public void OnUpdateMain(float delta)
    {
        StateMachineManager.Instance.ChangeState(StateMachineName.InGame, (int)InGame1State.StartEffect);
    }

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

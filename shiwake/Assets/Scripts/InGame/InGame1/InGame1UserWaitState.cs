﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1UserWaitState : StateBase {

	// ユーザー入力待機の為、入力処理があるまで待つだけのステート

    ///// <summary>
    ///// メイン前処理.
    ///// </summary>
    //override public void OnBeforeMain()
    //{
    //}

    ///// <summary>
    ///// メイン更新処理.
    ///// </summary>
    ///// <param name="delta">経過時間</param>
    //override public void OnUpdateMain(float delta)
    //{
    //}

    /// <summary>
    /// ステート解放時処理.
    /// </summary>
    override public void OnRelease()
    {
    }
}

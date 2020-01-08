using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineSampleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StateMachineManager.Instance.Init();
        StateMachineManager.Instance.CreateStateMachineMap(StateMachineName.Test);
        StateMachineManager.Instance.AddState(StateMachineName.Test, 0, new TestState1());
        StateMachineManager.Instance.AddState(StateMachineName.Test, 1, new TestState2());
        StateMachineManager.Instance.ChangeState(StateMachineName.Test, 0);

		// 初期化
		// 開始演出
		// ユーザー入力待機、タイムアップ（失敗）監視
		// 移動演出
		// クリアチェック
		// クリア演出
		// 失敗演出
		// 終了処理
	}
	
	// Update is called once per frame
	void Update () {
        StateMachineManager.Instance.Update(StateMachineName.Test, Time.deltaTime);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1DataCarrier : SimpleMonoBehaviourSingleton<InGame1DataCarrier> {

	// シーン制御用
	public SceneBase Scene { get; set; }
	
	// リザルトシーンへ渡すデータ
	public ResultData CuResultData { get; set; }
	
	// スコア
	public int CurrentScore { get; set; }
	
	public void Initialize() {
		CuResultData = new ResultData();
	}

	public void Release() {
		Scene = null;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SerializeFieldResourceManager : BestPracticeSingleton<SerializeFieldResourceManager> {
	[SerializeField]
	private GameObject[] CuEffectObjects = null;

	[SerializeField]
	private GameObject CuInGame1BaggageObject = null;
	public GameObject InGame1BaggageObject => CuInGame1BaggageObject;
	

    public enum EffectObject : int {
		Ready = 0,
		Go,
		CountDown
	};

	public void Initialize() {
		// ここのチェックは、開発中だけでいい
#if UNITY_EDITOR
		if ((CuEffectObjects == null) || (CuEffectObjects.Length == 0)) {
			Debug.Log("SerializeFieldResourceManager:CuEffectObjects error");
		}

		if (CuInGame1BaggageObject == null) {
			Debug.Log("SerializeFieldResourceManager:CuInGame1BaggageObject error");
		}
#endif
    }
	
	// 格納されている物は、Rawデータとして扱うので、コピーして返す
	public GameObject GetEffectObject(EffectObject type) {
		GameObject obj = GameObject.Instantiate(CuEffectObjects[(int)type]) as GameObject;
		return obj;
	}

    public GameObject GetInGame1BaggageObject()
    {
        GameObject obj = GameObject.Instantiate(CuInGame1BaggageObject) as GameObject;
        return obj;
    }

}

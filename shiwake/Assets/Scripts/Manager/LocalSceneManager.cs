using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSceneManager : SimpleMonoBehaviourSingleton<LocalSceneManager> {
	private List<string> SceneNameList = new List<string>() {
		"Splash",
		"Title",
		"Home",
		"InGame",
		"Result",
		"Fade",
	};

	public enum SceneName : int {
		Splash = 0,
		Title,
		Home,
		InGame,
		Result,
		Fade,
		None
	};

	private SceneName FirstSceneName = SceneName.Splash;

	private SceneName CurrentSceneName = SceneName.None;
	
	public SceneDataBase SceneData { get; private set;}

	public void Initialize() {
		SceneData = null;
		SceneManager.LoadScene(SceneNameList[(int)SceneName.Fade], LoadSceneMode.Additive);
	}

	public SceneName GetFirstSceneName() {
		return FirstSceneName;
	}
	
	public void LoadScene(SceneName name, SceneDataBase sceneData) {
		SceneData = sceneData;

		// 本来は、この辺りでフェードなどの切り替え処理が入るので、
		// LoadとUnloadは一辺に行うべきではない
		SceneManager.LoadScene(SceneNameList[(int)name], LoadSceneMode.Additive);
		if (CurrentSceneName != SceneName.None) {
			SceneManager.UnloadSceneAsync(SceneNameList[(int)CurrentSceneName]);
		}

		CurrentSceneName = name;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScene : SceneBase
{
	private readonly float DisplayTime = 3f;
	private float PassTime = 0f;
	private bool IsFadeStart = false;

	// Start is called before the first frame update
	void Start()
	{
		PassTime = 0f;
		IsFadeStart = false;
		Debug.Log("splash");
	}

	// Update is called once per frame
	void Update()
	{
		if (IsFadeStart == false) {
			PassTime += Time.deltaTime;
			if (PassTime >= DisplayTime) {
				IsFadeStart = true;
				GoTitle();
			}
		}
	}

	private void GoTitle() {
		FadeManager.Instance.FadeIn(FadeManager.Type.Simple, 1.0f, () => {
			LocalSceneManager.Instance.LoadScene(LocalSceneManager.SceneName.Title, null);
		});
	}
	
	
	public void OnClickSkipButton() {
		PassTime = DisplayTime;
	}
}

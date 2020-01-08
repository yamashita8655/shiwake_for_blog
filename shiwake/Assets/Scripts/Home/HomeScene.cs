using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HomeScene : SceneBase
{
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("home");
		//SoundManager.Instance.PlayBgm(Enum.Bgm.Home);
		FadeManager.Instance.FadeOut(FadeManager.Type.Mask, 0.5f, null);
	}

	//// Update is called once per frame
	//void Update()
	//{
	//	
	//}
	//
	
	public void OnClickInGameButton() {
		SoundManager.Instance.PlaySe(Enum.Se.ButtonOk);
		FadeManager.Instance.FadeIn(FadeManager.Type.Mask, 0.5f, () => {
			LocalSceneManager.Instance.LoadScene(LocalSceneManager.SceneName.InGame, null);
		});
	}
}

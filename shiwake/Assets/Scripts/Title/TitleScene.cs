using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase
{
	// Start is called before the first frame update
	void Start()
	{
		SoundManager.Instance.PlayBgm(Enum.Bgm.Title);
		FadeManager.Instance.FadeOut(
			FadeManager.Type.Simple,
			0.5f,
			() => {
			}
		);
	}

	//// Update is called once per frame
	//void Update()
	//{
	//	
	//}
	//
	
	public void OnClickStartButton() {
		FadeManager.Instance.FadeIn(FadeManager.Type.Mask, 0.5f, () => {
			LocalSceneManager.Instance.LoadScene(LocalSceneManager.SceneName.Home, null);
		});
	}
}

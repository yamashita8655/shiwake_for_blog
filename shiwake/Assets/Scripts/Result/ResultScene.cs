using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : SceneBase
{
	[SerializeField]
	private GameObject SuccessImageObject = null;
	
	[SerializeField]
	private GameObject FailerImageObject = null;

    // Start is called before the first frame update
    void Start()
    {
        ResultData data = (ResultData)LocalSceneManager.Instance.SceneData;
		if (data.IsClear == true) {
			SuccessImageObject.SetActive(true);
			FailerImageObject.SetActive(false);
		} else {
			SuccessImageObject.SetActive(false);
			FailerImageObject.SetActive(true);
		}
		
		FadeManager.Instance.FadeOut(FadeManager.Type.Mask, 0.5f, null);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}
	//
	
	public void OnClickHomeButton() {
        FadeManager.Instance.FadeIn(FadeManager.Type.Mask, 0.5f, () => {
			LocalSceneManager.Instance.LoadScene(LocalSceneManager.SceneName.Home, null);
        });
	}
}

using UnityEditor;
using UnityEngine;

public class CaptureScreenshotFromEditor : Editor
{
	[MenuItem("ShortCutCommand/CaptureScreenshot")]
	private static void CaptureScreenshot()
	{
		//現在読み込まれているシーンを取得
		string sceneName = "";
		for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount ; i++) {
			sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name; 
			// このプロジェクトの設計上、BootとFadeは常時存在するので
			// それ以外が、操作するUIシーン
			if (sceneName != "Boot" && sceneName != "Fade") {
				break;
			}
		}
		string fileName = sceneName + ".png";

		// ここからは独自処理
		// AsciiDoc用に、保存先を変える
		fileName = "Doc/img/" + fileName;

		// キャプチャを撮る
#if UNITY_2017_1_OR_NEWER
		ScreenCapture.CaptureScreenshot(fileName);
#else
		Application.CaptureScreenshot(fileName);
#endif
	}
	
	// ユニークなスクショを取る場合。
	// ファイル名はシーン名＋日付時間
	[MenuItem("ShortCutCommand/CaptureScreenshotNameTime")]
	private static void CaptureScreenshotNameTime()
	{
		//現在読み込まれているシーンを取得
		string sceneName = "";
		for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount ; i++) {
			sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name; 
			// このプロジェクトの設計上、BootとFadeは常時存在するので
			// それ以外が、操作するUIシーン
			if (sceneName != "Boot" && sceneName != "Fade") {
				break;
			}
		}

		string time = System.DateTime.Now.ToString("yyyyMMddHHmmss");
		string fileName = sceneName + time + ".png";

		// ここからは独自処理
		// AsciiDoc用に、保存先を変える
		fileName = "Doc/img/" + fileName;

		Debug.Log(fileName);
		// キャプチャを撮る
#if UNITY_2017_1_OR_NEWER
		ScreenCapture.CaptureScreenshot(fileName);
#else
		Application.CaptureScreenshot(fileName);
#endif
	}
}

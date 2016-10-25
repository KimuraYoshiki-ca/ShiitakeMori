using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	// メンバ変数
	// フェード処理フラグ
	public bool FadeFlag;
	// フェード遷移
	private int FadeMode;
	// アルファ値
	private float Alpha;
	// シーン名
	private string _sceneName;


	// Use this for initialization
	void Start()
	{
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( Screen.width, Screen.height );
		gameObject.GetComponent<Image>().color = Color.clear;
		Alpha = 0.0f;

	}

	// Update is called once per frame
	void Update()
	{
		switch(FadeMode)
		{
			// 通常状態
			case 0:
				if(FadeFlag)
				{
					FadeMode = 1;

				}

				break;


			// フェードイン
			case 1:
				if ((Alpha += 0.02f) <= 1.0f) gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, Alpha);
				else
				{
					FadeMode = 2;
					Alpha = 1.0f;
					gameObject.GetComponent<Image>().color = new Color( 0.0f, 0.0f, 0.0f, Alpha );
					SceneManager.LoadScene( _sceneName );

				}

				break;


			// フェードアウト
			case 2:
				if ((Alpha -= 0.02f) >= 0.0f) gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, Alpha);
				else
				{
					FadeMode = 0;
					Alpha = 0.0f;
					gameObject.GetComponent<Image>().color = new Color( 0.0f, 0.0f, 0.0f, Alpha );
					FadeFlag = false;

				}

				break;


			default:

				break;


		}

	}

	// フェード+シーンのセット
	public void SetFade(string SceneName)
	{
		FadeFlag = true;
		_sceneName = SceneName;

	}

}

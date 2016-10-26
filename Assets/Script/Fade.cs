using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	// メンバ変数
	// フェード処理フラグ
	public bool FadeFlag;
	// フェード遷移
	private int _fadeMode;
	// アルファ値
	private float _alpha;
	// シーン名
	private string _sceneName;


	// Use this for initialization
	void Start()
	{
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( Screen.width, Screen.height );
		gameObject.GetComponent<Image>().color = Color.clear;
		_alpha = 0.0f;

	}

	// Update is called once per frame
	void Update()
	{
		switch(_fadeMode)
		{
			// 通常状態
			case 0:
				if(FadeFlag)
				{
					_fadeMode = 1;

				}

				break;


			// フェードイン
			case 1:
				if ((_alpha += 0.02f) <= 1.0f) gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
				else
				{
					_fadeMode = 2;
					_alpha = 1.0f;
					gameObject.GetComponent<Image>().color = new Color( 0.0f, 0.0f, 0.0f, _alpha );
					SceneManager.LoadScene( _sceneName );

				}

				break;


			// フェードアウト
			case 2:
				if ((_alpha -= 0.02f) >= 0.0f) gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
				else
				{
					_fadeMode = 0;
					_alpha = 0.0f;
					gameObject.GetComponent<Image>().color = new Color( 0.0f, 0.0f, 0.0f, _alpha );
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

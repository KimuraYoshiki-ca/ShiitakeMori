using UnityEngine;
using UnityEngine.SceneManagement;

/* フェードマネージャクラス
 * フェードIn・Out処理を一括管理するクラス
 * シーン名を入れるだけで自動でフェードIn→シーンの切り替え→Out処理をしてくれます
*/
public class FaderManager : SingletonMonoBehaviour<FaderManager>
{
	// フェード遷移
	enum FadeMode
	{
		None = 0,
		In,
		Out,
		Max

	};

	// メンバ変数
	// フェード遷移
	private FadeMode _fadeMode;
	// アルファ値
	private float _alpha;
	// シーン名
	private string _sceneName;
	// 暗転用2Dテクスチャ
	private Texture2D _blackTexture2D;


	public void Awake()
	{
		// 自身が無い時は削除
		if( this != Instance )
		{
			Destroy( this );
			return;

		}

		// シーン切り替え時に自身が削除されないよう設定
		DontDestroyOnLoad( gameObject );

		// テクスチャ生成
		_blackTexture2D = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
		_blackTexture2D.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0, false );
		_blackTexture2D.SetPixel( 0, 0, Color.black );
		_blackTexture2D.Apply();

	}


	// Use this for initialization
	void Start()
	{
		_fadeMode = FadeMode.None;

	}

	// Update is called once per frame
	void Update()
	{
		switch( _fadeMode )
		{
			// 通常状態
			case FadeMode.None:

				break;


			// フェードイン
			case FadeMode.In:
				if( ( _alpha += 0.02f ) <= 1.0f )
				{
				}
				else
				{
					_fadeMode = FadeMode.Out;
					_alpha = 1.0f;
					SceneManager.LoadScene( _sceneName );

				}

				break;


			// フェードアウト
			case FadeMode.Out:
				if( ( _alpha -= 0.02f ) >= 0.0f )
				{
				}
				else
				{
					_fadeMode = FadeMode.None;
					_alpha = 0.0f;

				}

				break;


			case FadeMode.Max:

				break;

		}

	}

	// フェード+シーンのセット
	public void LoadLevel( string sceneName )
	{
		_fadeMode = FadeMode.In;
		_sceneName = sceneName;

	}

	// フェード中の処理
	void OnGUI()
	{
		//アルファ値のセット
		if( _fadeMode != FadeMode.None && _fadeMode != FadeMode.Max )
		{
			GUI.color = new Color( 0.0f, 0.0f, 0.0f, _alpha );
			GUI.DrawTexture( new Rect( 0.0f, 0.0f, Screen.width, Screen.height ), _blackTexture2D );

		}

	}

}

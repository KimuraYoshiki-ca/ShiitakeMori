using UnityEngine;
using UniRx;
using UnityEngine.UI;

/* TitleManagerクラス
	タイトルのあらゆることの制御をするクラス
*/
public class TitleManager : MonoBehaviour
{
	// メンバ変数
	// 押されるボタン
	[ SerializeField ] public Button IconButton;
	public string GameSceneName;

	// Use this for initialization
	void Start()
	{
		// ゲームシーンへ移動
		IconButton.OnClickAsObservable().Subscribe( _ => FaderManager.Instance.LoadLevel( GameSceneName ) );

	}
	
}

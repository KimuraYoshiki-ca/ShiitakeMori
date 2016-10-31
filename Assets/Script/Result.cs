using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

/* Resultクラス
	プレイ終了後に出るリザルト画面
	スコアを受け取り、リプレイかタイトルへ戻る処理に繋げる
*/
public class Result : MonoBehaviour
{
	//メンバ変数
	// リザルトのゲームオブジェクト
	public GameObject ResultGameObject;
	// 非アクティブにするオブジェクトの登録
	public GameObject[] UnActiveGameObjects;
	// リザルト用スコア表示テキスト
	public Text ResultScoreText;
	// プレイヤーが獲得したスコアのテキスト
	public Text PlayerScoreText;
	// このオブジェクトが表示されるまでの時間
	public int ActiveDelayTime;

	// タイトルへ戻るボタン
	[SerializeField]
	public Button ReturnButton;
	// タイトルシーン名
	public string TitleSceneName;
	// リプレイボタン
	[SerializeField]
	public Button ReplayButton;
	// リプレイシーン名
	public string ReplaySceneName;

	// Use this for initialization
	void Start()
	{
		// リザルト画面表示
		this.UpdateAsObservable().First( _ => gameObject.GetComponent<Timer>().IsTimeOut() )
			.Delay( TimeSpan.FromSeconds( ActiveDelayTime ) )
			.Subscribe( _ =>
					ResultProcess()
			);

		// タイトルへ
		ReturnButton.OnClickAsObservable()
			.Subscribe( _ =>
						 FaderManager.Instance.LoadLevel( TitleSceneName )
			);

		// リプレイ
		ReplayButton.OnClickAsObservable()
			.Subscribe( _ =>
						 FaderManager.Instance.LoadLevel( ReplaySceneName )
			);

	}

	// リザルト時の処理
	void ResultProcess()
	{
		// リザルト画面を起動
		ResultGameObject.SetActive( true );

		// スコア値をリザルト内のスコア表示テキストに渡す
		ResultScoreText.GetComponent<NumberText>().NumericValue = PlayerScoreText.GetComponent<NumberText>().NumericValue;

		// タイマーを0に設定
		PlayerScoreText.GetComponent<NumberText>().NumericValue = 0;

		// 非アクティブ対象のゲームオブジェクト処理
		for( int i = 0; i < UnActiveGameObjects.Length; i++ )
		{
			UnActiveGameObjects[ i ].SetActive( false );

		}

	}

}

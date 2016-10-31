using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour
{
	// メンバ変数
	// カウントダウン数
	public int CountDownTime;
	// 表示用テキスト
	public GameObject CountDownGameObject;
	// カウントダウン前の遅延時間
	public int DelayTime;
	// テキストのNumberTextクラス
	private NumberText _countDownNumberText;
	// カウントダウン終了処理フラグ
	private static bool _isCountDown;

	// Use this for initialization
	void Start()
	{
		// カウントダウンのセット
		_isCountDown = false;
		_countDownNumberText = CountDownGameObject.GetComponent<NumberText>();
		_countDownNumberText.NumericValue = CountDownTime;

		// カウントダウン処理
		this.UpdateAsObservable().Delay( TimeSpan.FromSeconds( DelayTime ) )
			.ThrottleFirst( TimeSpan.FromSeconds( 1 ) )
			.Where( _ => _countDownNumberText.NumericValue > 0 )
			.Subscribe( _ =>
						_countDownNumberText.SubNumberCnt()

			);

		// カウントダウンテキストの非アクティブ化
		this.UpdateAsObservable().Delay( TimeSpan.FromSeconds( DelayTime ) )
			.First( _ => _countDownNumberText.NumericValue <= 0 )
			.Subscribe( _ =>
						GmaneStart()

			);

		this.UpdateAsObservable().First( _ => _isCountDown )
			.Delay( TimeSpan.FromSeconds( 2 ) )
			.Subscribe( _ =>
						 CountDownGameObject.SetActive( false )
			);

	}

	// ゲーム開始時の処理
	void GmaneStart()
	{
		Text countDoenText = CountDownGameObject.GetComponent< Text >();
		_countDownNumberText.UseTypeString = "0 START! ";
		countDoenText.color = Color.red;
		_isCountDown = true;

	}

	// カウントダウン処理終了フラグ
	public static bool IsCountDownFinished()
	{
		return _isCountDown;

	}

}

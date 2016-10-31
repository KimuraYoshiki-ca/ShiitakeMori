using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/* Timerクラス
	タイマーを1秒ずつ減算カウントしていく処理
*/
public class Timer : MonoBehaviour
{
	// メンバ変数
	// タイマーテキストのGameObject
	public NumberText TimerText;
	// ゲーム開始時のタイマーが止まっているカウント
	public int FirstStopTime;

	// Use this for initialization
	void Start()
	{
		// UniRxでタイマーの処理(リアルタイム換算)
		this.UpdateAsObservable().ThrottleFirst( TimeSpan.FromSeconds( 1 ) )
			.Skip( FirstStopTime )
			.Where( _ => TimerText.NumericValue > 0 )
			.Where( _ => CountDownStart.IsCountDownFinished() )
			.Subscribe( _ =>
				TimerText.SubNumberCnt()
			);

	}

	// 時間切れフラグ
	// 時間切れでフラグがtrueを返します
	public bool IsTimeOut()
	{
		return TimerText.NumericValue <= 0;

	}

}

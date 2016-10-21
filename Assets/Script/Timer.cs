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
	public GameObject TimerText;
	// ゲーム開始時のタイマーが止まっているカウント
	public int FirstStopTime;

	// Use this for initialization
	void Start()
	{
		// UniRxでタイマーの処理(リアルタイム換算)
		this.UpdateAsObservable().ThrottleFirst( TimeSpan.FromSeconds( 1 ) )
			.Skip( FirstStopTime )
			.Where( _ => TimerText.GetComponent<Number>().NumericValue > 0 )
			.Subscribe( _ =>
			TimerText.GetComponent<Number>().SubNumberCnt()
			);

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

}

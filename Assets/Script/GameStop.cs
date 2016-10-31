using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

/* GameStopクラス
	終了ボタンUIが規定数回押されたらプレイを去勢終了させるクラス
	基本的にはリザルト画面へと飛ぶようにする
*/
public class GameStop : MonoBehaviour
{
	// メンバ変数
	// 自分自身のボタンクラス
	public Button MyselfButton;
	// タイマーオブジェクト
	public NumberText TimerObject;
	// 2回クリックする間の反応時間
	public int ClickSpeed;
	// 規定クリック数
	public int ClickCount;

	// Use this for initialization
	void Start()
	{
		MyselfButton.OnClickAsObservable()
			.Buffer(
				( this.UpdateAsObservable().Where( _ => Input.GetMouseButtonDown( 0 ) ) )
					.Throttle( TimeSpan.FromMilliseconds( ClickSpeed ) ) )
			.Where( x => x.Count >= ClickCount )
			.Subscribe( _ =>
					TimerObject.SubNumberCnt( TimerObject.NumericValue )
			);

	}

}

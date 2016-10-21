using System;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using UnityEngine.UI;

public class InputCamera : MonoBehaviour
{
	// メンバ変数
	// 回転処理範囲のUI
	public Button RotationHitRange;

	// Use this for initialization
	void Start()
	{
		// スクリーンの大きさを取得、ボタンの大きさを設定
		float w = Screen.width;
		float h = Screen.height;
		RotationHitRange.GetComponent<RectTransform>().anchoredPosition = new Vector3( 0.0f, -h * 0.5f + h / 6.0f, 0.0f );
		RotationHitRange.GetComponent<RectTransform>().sizeDelta = new Vector2( w, h / 3.0f );

		// 回転処理
		this.UpdateAsObservable().Where( _ => Input.GetMouseButtonDown( 0 ) )
			.Subscribe( x =>
			this.transform.Rotate( ( Input.GetAxis( "Mouse X" ) * -1.0f ), ( Input.GetAxis( "Mouse Y" ) * -1.0f ), 0 )
			);

	}
	
	// Update is called once per frame
	void Update()
	{
		this.transform.Rotate( ( Input.GetAxis( "Vertical" ) * -1.0f ), ( Input.GetAxis( "Horizontal" ) * -1.0f ), 0 );

	}

}

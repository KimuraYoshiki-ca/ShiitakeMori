using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class InputCamera : MonoBehaviour
{
	// メンバ変数
	// 回転処理範囲のUI
	[ SerializeField ] public Button RotationHitRange;
	// 回転処理フラグ
	private bool _rotationFlag;

	// Use this for initialization
	void Start()
	{
		// フラグ初期化
		_rotationFlag = false;

		// スクリーンの大きさを取得、ボタンの大きさを設定
		float w = Screen.width;
		float h = Screen.height;
		Vector3 vector3 = new Vector3( 0.0f, -h * 0.5f + h / 8.0f, 0.0f );
		RotationHitRange.GetComponent<RectTransform>().anchoredPosition = vector3;
		RotationHitRange.GetComponent<RectTransform>().sizeDelta = new Vector2( w, h / 4.0f );

		// 回転処理フラグを立てる
		this.UpdateAsObservable().Where( _ => Input.GetMouseButtonDown( 0 ) )
			.Where( _ => 0 < Input.mousePosition.x && w > Input.mousePosition.x )
			.Where( _ => 0 < Input.mousePosition.y && h / 4.0f > Input.mousePosition.y )
			.Subscribe( _ => 
				_rotationFlag = true
			);

		// 回転処理フラグを下げる
		this.UpdateAsObservable().Where( _ => !Input.GetMouseButton( 0 ) )
			.Subscribe( _ =>
						_rotationFlag = false
			);

		// 回転処理
		this.UpdateAsObservable().Where( _ => _rotationFlag )
			.Subscribe( x =>
				Move()
			);

	}
	
	// Update is called once per frame
	void Update()
	{
		
	}


	void Move()
	{
		transform.Rotate(Input.GetAxis( "Mouse Y" ) * 2.25f, ( Input.GetAxis( "Mouse X" ) * 2.25f ), 0.0f);

	}

}

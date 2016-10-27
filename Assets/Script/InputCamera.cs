using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class InputCamera : MonoBehaviour
{
	// メンバ変数
	// 回転処理範囲のUI
	[ SerializeField ] public Button RotationHitRange;
	
	// 回転量制御値
	public float MinRotAmountControlX;
	public float MaxRotAmountControlX;

	// 移動量制御
	public float MinPosAmountControlY;
	public float MaxPosAmountControlY;

	// 回転処理フラグ
	private bool _rotationFlag;

	// 回転スピード
	public float MoveSpeedY;
	public float RotSpeedX;
	public float RotSpeedY;
	private float _mouseMoveAmountY;

	// メインカメラのTransform
	public Transform MainCameraTransform;


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
#if UNITY_EDITOR
		// マウスの移動量取得
		_mouseMoveAmountY = -Input.GetAxis("Mouse Y");

		// 回転処理
		transform.Rotate(
			0.0f,
			Input.GetAxis( "Mouse X" ) * RotSpeedY,
			0.0f);

		// メインカメラの移動
		MainCameraTransform.position += new Vector3(
			0.0f,
			_mouseMoveAmountY * MoveSpeedY,
			0.0f );

		// メインカメラの移動制御
		MainCameraTransform.position = new Vector3(
			MainCameraTransform.position.x,
			Mathf.Clamp(MainCameraTransform.position.y,MinPosAmountControlY,MaxPosAmountControlY),
			MainCameraTransform.position.z );

		// メインカメラの回転
		MainCameraTransform.Rotate(
			_mouseMoveAmountY * RotSpeedX,
			0.0f,
			0.0f );

		// メインカメラの回転制御
		MainCameraTransform.eulerAngles = new Vector3(
			Mathf.Clamp(MainCameraTransform.eulerAngles.x, MinRotAmountControlX, MaxRotAmountControlX ),
			MainCameraTransform.eulerAngles.y,
			0.0f );


#elif UNITY_ANDROID
		// マウスの移動量取得
		_mouseMoveAmountY = -Input.touches.First().deltaPosition.y;

		// 回転処理
		transform.Rotate(
			0.0f,
			Input.touches.First().deltaPosition.x * RotSpeedY,
			0.0f);

		// メインカメラの移動
		MainCameraTransform.position += new Vector3(
			0.0f,
			_mouseMoveAmountY * MoveSpeedY,
			0.0f );

		// メインカメラの移動制御
		MainCameraTransform.position = new Vector3(
			MainCameraTransform.position.x,
			Mathf.Clamp(MainCameraTransform.position.y,MinPosAmountControlY,MaxPosAmountControlY),
			MainCameraTransform.position.z );

		// メインカメラの回転
		MainCameraTransform.Rotate(
			_mouseMoveAmountY * RotSpeedX,
			0.0f,
			0.0f );

		// メインカメラの回転制御
		MainCameraTransform.eulerAngles = new Vector3(
			Mathf.Clamp(MainCameraTransform.eulerAngles.x, MinRotAmountControlX, MaxRotAmountControlX ),
			MainCameraTransform.eulerAngles.y,
			0.0f );

#endif

	}

}

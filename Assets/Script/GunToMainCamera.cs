using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

/* GunToMainCameraクラス
	クリックで弾を発射
	スクリーン座標からワールド座標に変換して弾を飛ばします
*/
public class GunToMainCamera : MonoBehaviour
{
	// メンバ変数
	// しいたけのプレハブ
	public GameObject[] ShiitakeGunPrehab;
	// スコアテキストのGameObject
	public NumberText ScoreText;
	// しいたけを飛ばす力
	public float InitialVelocity = 8.0f;
	// しいたけを出現させる距離(奥行の位置)
	public float DistanceFromCaera = 10.0f;
	// しいたけの種類を変更するタイミング
	public int ChangePrehabTimming;
	// しいたけを撃った数をカウントし周期的に変える
	private long _shotLoopCnt;
	// しいたけを撃つ範囲のUI
	[ SerializeField ] public Button ShotHitRange;
	// タイマーのテキスト
	public Timer TimerScript;
	// しいたけを飛ばすタッチできる範囲の比率
	public float TouchRangeRatioForObject;

	// Use this for initialization
	void Start()
	{
		// 撃ったしいたけのループカウントを初期化
		_shotLoopCnt = 0;

		// スクリーンの大きさを取得、ボタンの大きさを設定
		float w = Screen.width;
		float h = Screen.height;
		//ShotHitRange.GetComponent< RectTransform >().anchoredPosition = new Vector3( 0.0f, h * 0.5f - h / 4.0f, 0.0f );
		//ShotHitRange.GetComponent< RectTransform >().sizeDelta = new Vector2( w, h / 4.0f * 2.0f );


		// しいたけをマウス左クリックで飛ばす処理(UniRx)
		this.UpdateAsObservable().Where( _ => Input.GetMouseButtonDown( 0 ) )
			.Where( _ => 0 < Input.mousePosition.x && w > Input.mousePosition.x )
			.Where( _ => h / TouchRangeRatioForObject < Input.mousePosition.y && h > Input.mousePosition.y )
			.TakeWhile( _ => !TimerScript.IsTimeOut() )
			.Subscribe(x =>
						OnMouseChick()
			);

	}

	// しいたけを飛ばす処理(マウス左クリック)
	void OnMouseChick()
	{
		// 撃ったしいたけのカウントを監視
		// 通常はカウント+1、しいたけが切り替わった時点で数値1に戻す
		_shotLoopCnt = _shotLoopCnt == ChangePrehabTimming ? 1 : _shotLoopCnt + 1;
		
		// しいたけを切り替える処理
		GameObject gameObject = Instantiate( ShiitakeGunPrehab[ _shotLoopCnt / ChangePrehabTimming ], transform.position, transform.rotation ) as GameObject;
		
		// マウス座標取得、カメラから少し離れた位置から出すためZ値を変更
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = DistanceFromCaera;
		
		// スクリーン座標からワールド座標への返還
		Vector3 worldPoint = GetComponent< Camera >().ScreenToWorldPoint( mousePos );
		Vector3 direction = ( worldPoint - transform.position ).normalized;
		Debug.Assert(gameObject != null, "gameObject != null");
		gameObject.GetComponent< Rigidbody >().velocity = direction * InitialVelocity;

		// フィールド上にあるしいたけの数をカウント
		ScoreText.AddNumberCnt();

	}

	// しいたけの種類番号を返却
	public long GetPrehabType()
	{
		return ( _shotLoopCnt % ChangePrehabTimming ) / ( ChangePrehabTimming - 1 );

	}

}
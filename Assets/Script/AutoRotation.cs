using UnityEngine;

/* AutoRotationクラス
	Titleシーンでモデル(しいたけ)を自動で回すだけの処理
	Unity上で値を入れると大きさや符号に応じて回転速度や向きが変わる
*/
public class AutoRotation : MonoBehaviour
{
	// メンバ変数
	// 各軸
	public float RotX;
	public float RotY;
	public float RotZ;
	private Transform _myselfTransform;


	// Use this for initialization
	void Start()
	{
		// データのキャッシュ
		_myselfTransform = transform;

	}

	// Update is called once per frame
	void Update()
	{
		_myselfTransform.Rotate( RotX, RotY, RotZ );

	}

}

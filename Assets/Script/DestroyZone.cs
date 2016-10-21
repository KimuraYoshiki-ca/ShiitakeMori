using UnityEngine;

/* DestroyZoneクラス
	物体が落ちたらそのGameObjectを削除する処理
*/
public class DestroyZone : MonoBehaviour
{
	// メンバ変数
	// スコアテキストのGameObject
	public GameObject ScoreText;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	// 衝突判定処理
	void OnCollisionEnter( Collision col )
	{
		// 衝突判定が起こったら衝突した側のGameObjectを削除、スコアを減算する
		Destroy( col.gameObject );
		Number score = ScoreText.GetComponent< Number >();
		score.SubNumberCnt();

	}


}

using UnityEngine;

/* GunBulletクラス
	しいたけの衝突判定
	普通のしいたけに実装する
	普通のしいたけが何かに衝突した時だけ処理
	普通のしいたけが赤いしいたけにくっつく
*/
public class BulletCollision : MonoBehaviour
{
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
		// このGameObjectのRigidBodyを取得
		Rigidbody rb = GetComponent< Rigidbody >();

		// 普通のしいたけが赤いしいたけにぶつかったら、くっつける処理
		if( col.gameObject.tag == "Red" && rb.gameObject.tag == "Normal" )
		{
			// FixedJointをGameObjectに追加
			FixedJoint fj = gameObject.AddComponent< FixedJoint >();
			fj.connectedBody = col.rigidbody;

		}

	}

}

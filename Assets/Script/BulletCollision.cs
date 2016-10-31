using UnityEngine;

/* GunBulletクラス
	しいたけの衝突判定
	普通のしいたけに実装する
	普通のしいたけが何かに衝突した時だけ処理
	普通のしいたけが赤いしいたけにくっつく
*/
public class BulletCollision : MonoBehaviour
{
	public static float BreakForce;
	public static float BreakTorque;

	// Use this for initialization
	void Start()
	{
		BreakForce = FixedJointBreakAjustment.StaticBreakForce;
		BreakTorque = FixedJointBreakAjustment.StaticBreakTorque;

	}

	// 衝突判定処理
	void OnCollisionEnter( Collision collision )
	{
		// 普通のしいたけが赤いしいたけにぶつかったら、くっつける処理
		if( collision.gameObject.tag == "Red" )
		{
			// FixedJointをGameObjectに追加
			FixedJoint fixedJoint = gameObject.AddComponent< FixedJoint >();
			fixedJoint.connectedBody = collision.rigidbody;
			fixedJoint.breakForce = BreakForce;
			fixedJoint.breakTorque = BreakTorque;

		}

	}

}

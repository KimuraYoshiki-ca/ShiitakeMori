using UnityEngine;

/* FixedJointBreakAjustmentクラス
	Jointのパラメータ調整用スクリプト
*/
public class FixedJointBreakAjustment : MonoBehaviour
{
	public static float StaticBreakForce;
	public static float StaticBreakTorque;
	public float BreakForce;
	public float BreakTorque;

	void Start()
	{
		StaticBreakForce = BreakForce;
		StaticBreakTorque = BreakTorque;

	}

	void Update()
	{
		StaticBreakForce = BreakForce;
		StaticBreakTorque = BreakTorque;

	}

}
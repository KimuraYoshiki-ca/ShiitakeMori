using UnityEngine;

public class FixedJointBreakAjustment : MonoBehaviour
{
	public static float BreakForce;
	public static float BreakTorque;
	public float BreakForce_;
	public float BreakTorque_;

	void Start()
	{
		BreakForce = BreakForce_;
		BreakTorque = BreakTorque_;

	}

	void Update()
	{
		BreakForce = BreakForce_;
		BreakTorque = BreakTorque_;

	}

}
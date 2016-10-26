using UnityEngine;
using System.Collections;

public class AutoRotation : MonoBehaviour
{
	public float RotX, RotY, RotZ;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Rotate( RotX, RotY, RotZ );

	}

}

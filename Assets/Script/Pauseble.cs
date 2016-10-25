using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class RigidbodyVelocity
{
	public Vector3 Velocity;
	public Vector3 AngularVelocity;

	public RigidbodyVelocity( Rigidbody rigitbody )
	{
		Velocity = rigitbody.velocity;
		AngularVelocity = rigitbody.angularVelocity;

	}

}

public class Pauseble : MonoBehaviour
{
	// メンバ変数
	// 
	public bool Pausing;
	// 
	public GameObject[] IgnoreGameObjects;
	// 
	private bool _prevPausing;
	// 
	private RigidbodyVelocity[] _rigidbodyVelocities;
	// 
	private Rigidbody[] _pausingRigidbodys;
	// 
	private MonoBehaviour[] _pausingMonoBehaviours;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// 
		if( _prevPausing )
		{
			if( Pausing ) Pause();
			else Resume();
			_prevPausing = Pausing;

		}

	}

	// 
	void Pause()
	{
		// 
		// 
		Predicate<Rigidbody> rigidbodyPredicate =
			obj => !obj.IsSleeping() &&
			Array.FindIndex( IgnoreGameObjects, gameObject => gameObject == obj.gameObject ) < 0;
		_pausingRigidbodys = Array.FindAll( transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate );
		_rigidbodyVelocities = new RigidbodyVelocity[ _pausingRigidbodys.Length ];
		for( int i = 0; i < _pausingRigidbodys.Length; i++ )
		{
			// 
			_rigidbodyVelocities[ i ] = new RigidbodyVelocity( _pausingRigidbodys[ i ] );
			_pausingRigidbodys[ i ].Sleep();

		}

		// 
		// 
		Predicate<MonoBehaviour> monoBehaviourPredicate =
			obj => obj.enabled && obj != this &&
				   Array.FindIndex( IgnoreGameObjects, gameObject => gameObject == obj.gameObject ) < 0;
		_pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
		foreach (var monoBehaviour in _pausingMonoBehaviours)
		{
			monoBehaviour.enabled = false;

		}

	}

	// 
	void Resume()
	{
		// 
		for (int i = 0; i < _pausingRigidbodys.Length; i++)
		{
			_pausingRigidbodys[i].WakeUp();
			_pausingRigidbodys[i].velocity = _rigidbodyVelocities[i].Velocity;
			_pausingRigidbodys[i].angularVelocity = _rigidbodyVelocities[i].AngularVelocity;

		}

		// 
		foreach( var monoBehaviour in _pausingMonoBehaviours )
		{
			monoBehaviour.enabled = true;

		}

	}

}

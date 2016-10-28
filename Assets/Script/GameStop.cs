using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class GameStop : MonoBehaviour
{
	public Button MyselfButton;
	public Number TimerObject;
	public int ClickSpeed;

	// Use this for initialization
	void Start()
	{
		MyselfButton.OnClickAsObservable()
			.Buffer(
				( this.UpdateAsObservable().Where( _ => Input.GetMouseButtonDown( 0 ) ) )
					.Throttle( TimeSpan.FromMilliseconds( ClickSpeed ) ) )
			.Where( x => x.Count >= 2 )
			.Subscribe( _ =>
					TimerObject.SubNumberCnt( TimerObject.NumericValue )
			);

	}

	// Update is called once per frame
	void Update()
	{

	}

}

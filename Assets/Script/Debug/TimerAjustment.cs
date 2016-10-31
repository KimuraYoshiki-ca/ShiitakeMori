using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class TimerAjustment : MonoBehaviour
{
	public Button MyselfButton;
	public NumberText TimerObject;
	public int AjustValue;

	// Use this for initialization
	void Start()
	{
		MyselfButton.OnClickAsObservable().Subscribe(_ =>
					TimerObject.AddNumberCnt( AjustValue )
		);

	}

}

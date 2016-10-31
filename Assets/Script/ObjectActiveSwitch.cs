using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ObjectActiveSwitch : MonoBehaviour
{
	public GameObject ActiveGameObject;
	public Button MyselfButton;
	public bool ActiveSwitch;

	// Use this for initialization
	void Start()
	{
		MyselfButton.OnClickAsObservable().Subscribe( _ =>
					ActiveGameObject.SetActive( ( ActiveSwitch = !ActiveSwitch ) )

		);

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

}

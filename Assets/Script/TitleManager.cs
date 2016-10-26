using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	// メンバ変数
	// 押されるボタン
	[ SerializeField ] public Button IconButton;
	public string GameSceneName;
	public Image FadeImage;

	// Use this for initialization
	void Start()
	{
		IconButton.OnClickAsObservable().Subscribe( _ => FadeImage.GetComponent<Fade>().SetFade( GameSceneName ) );

	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

}

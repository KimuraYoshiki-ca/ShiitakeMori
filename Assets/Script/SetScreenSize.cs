using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetScreenSize : MonoBehaviour
{
	// メンバ変数
	// スクリーン色
	public Color ScreenColor;

	// Use this for initialization
	void Start()
	{
		// 色と画像の大きさ(画面サイズで)をセット
		gameObject.GetComponent<Image>().color = ScreenColor;
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( Screen.width, Screen.height );

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

}

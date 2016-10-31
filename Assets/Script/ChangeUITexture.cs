using UnityEngine;
using UnityEngine.UI;

/* ChangeUITextureクラス
	UI用に表示するテクスチャを切り替える
*/
public class ChangeUITexture : MonoBehaviour
{
	public Sprite[] ChangeSprites;
	public GunToMainCamera Camera;
	
	// Update is called once per frame
	void Update()
	{
		// 次に投げるしいたけの種類でUIテキストを変更する
		gameObject.GetComponent< Image >().sprite = ChangeSprites[ Camera.GetPrehabType() ];

	}

}

using UnityEngine;
using UnityEngine.UI;

public class ChangeUITexture : MonoBehaviour
{
	public Sprite[] ChangeTextures;
	public GameObject Camera;
	public long test;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		// 次に投げるしいたけの種類でUIテキストを変更する
		gameObject.GetComponent< Image >().sprite = ChangeTextures[ Camera.GetComponent< GunToMainCamera >().GetPrehubType() ];
		test = Camera.GetComponent<GunToMainCamera>().GetPrehubType();

	}

}

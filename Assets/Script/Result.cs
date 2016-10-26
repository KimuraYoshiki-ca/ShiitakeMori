using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class Result : MonoBehaviour
{
	//メンバ変数
	// リザルトのゲームオブジェクト
	public GameObject ResultGameObject;
	public Text ResultScoreText;
	public Text PlayerScoreText;
	public int ActiveDelayTime;

	// Use this for initialization
	void Start()
	{
		this.UpdateAsObservable().Where( _ => gameObject.GetComponent< Timer >().TimeOutFlag() )
			.Delay( TimeSpan.FromSeconds( ActiveDelayTime ) )
			.Subscribe( _ =>
					ResultProcess()
			);

	}

	// Update is called once per frame
	void Update()
	{

	}

	// リザルト時の処理
	void ResultProcess()
	{
		// リザルト画面を起動
		ResultGameObject.SetActive(true);

		// スコア値をリザルト内のスコア表示テキストに渡す
		ResultScoreText.GetComponent<Number>().NumericValue = PlayerScoreText.GetComponent<Number>().NumericValue;

	}

}

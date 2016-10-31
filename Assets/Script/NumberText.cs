using UnityEngine;
using UnityEngine.UI;

/* Numberクラス
	数値のテキストを表示する処理
	スコアやタイマーなどに使用できる汎用スクリプト
*/
public class NumberText : MonoBehaviour
{
	// メンバ変数
	// セットされる最初の数値
	public int NumericValue;
	// テキストのオブジェクト
	public Text MyselfText;
	// 数値の前に表示したい文字(使用用途)
	public string UseTypeString;
	// 表示桁数
	public long Digit;
	// .ToStringの引数用に変換する桁数の情報文字列
	private string _numberDigitStr;

	// Use this for initialization
	void Start()
	{
		// 桁数の数値を文字列に変換
		_numberDigitStr = "D" + Digit.ToString();

		// 使用用途、数値を表示用テキストへ設定
		MyselfText.text = UseTypeString + NumericValue.ToString( _numberDigitStr );

	}
	
	// Update is called once per frame
	void Update()
	{
		// 使用用途、数値を表示用テキストへ設定
		MyselfText.text = UseTypeString + NumericValue.ToString( _numberDigitStr );

	}

	// 数値の加算処理(デフォルト引数1)
	public void AddNumberCnt( int add = 1 )
	{
		NumericValue += add;

	}

	// 数値の減算処理(デフォルト引数1)
	public void SubNumberCnt( int sub = 1 )
	{
		NumericValue -= sub;

	}

}

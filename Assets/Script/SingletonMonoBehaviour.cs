using UnityEngine;


/* シングルトン生成クラス
	T ・・・ クラス名
	自動でシングルトンを生成します
*/
public class SingletonMonoBehaviour< T > : MonoBehaviour where T : MonoBehaviour
{
	// 自身のインスタンス
	private static T _instance;

	// インスタンス生成
	public static T Instance
	{
		get
		{
			// nullであれば自身のインスタンスを代入する
			if( _instance == null )
			{
				_instance = ( T ) FindObjectOfType( typeof( T ) );

				// 入っていない時はエラーを出す
				if( _instance == null )
				{
					Debug.LogError( typeof( T ) + "is nothing" );

				}

			}

			return _instance;

		}

	}

}

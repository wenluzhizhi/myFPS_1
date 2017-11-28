using UnityEngine;
using System.Collections;

public class EnemyAIController : MonoBehaviour
{


	#region  单例

	private static EnemyAIController _instance;
	public static EnemyAIController Instance{
		get{ 
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType (typeof(EnemyAIController)) as EnemyAIController;
			}
			return _instance;
		}
	}

	#endregion
	public Vector3[] enemyAIPos=new Vector3[8];
	public EnemyAI enemyAIPrefab;
	public int enemyCount = 1;
	void Start(){
		init ();
	}


	private void init()
	{

		for (int i = 0; i < enemyAIPos.Length; i++) 
		{
			GameObject go = GameObject.Instantiate (enemyAIPrefab.gameObject, enemyAIPos [i], Quaternion.identity) as GameObject;
			enemyCount++;
		}
	}

	public Vector3 giveBackAI(EnemyAI ai){
		enemyCount--;
		int n = Random.Range (0,8);
		return enemyAIPos[n];

	}

}

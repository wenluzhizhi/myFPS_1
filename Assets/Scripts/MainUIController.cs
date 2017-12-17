using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class MainUIController : MonoBehaviour {



	#region 单例
	private static MainUIController _instance;
	public static MainUIController Instance{
		get{
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType (typeof(MainUIController)) as MainUIController;
			}
			return _instance;
		}
	}

	#endregion





	public MoveControllerPanel leftMovePanel;
	//public FirstPersonController fsp;
	public MainPlayer mainPlayer;
	public MainSetting mainSetting; //游戏中常规变量的设置，用于测试
	[SerializeField] private GameObject bullet_prefab;
	public int MoveSpeed=40;
	public float timeFPS = 0.0f;

	public BgUIScripts bgUIScripts;


	GUIStyle sy1=new GUIStyle();





	#region mono event
	void Start () 
	{
		sy1.fontSize = 64;
		if (leftMovePanel)
		{
			leftMovePanel.moveAc += leftPanelMove;
		}
	}
	

	void Update () {
		timeFPS = 1.0f / Time.deltaTime;
	}


	void OnGUI(){
		GUILayout.Label (timeFPS.ToString("0.0"),sy1);
	}

	#endregion


	#region external function

	public Vector2 testMove = Vector2.zero;
	public void leftPanelMove(Vector2 v){
		float x = 0;
		float y = 0;
		if (v.x > 10) {
			x = 1;
		} else if (v.x < -10) {
			x = -1;
		}


		if (v.y > 10) {
			y = 1;
		} 
		else if (v.y < -10) 
		{
			y = -1;
		}
		testMove = new Vector2 (x,y);
		mainPlayer.setMove (new Vector2 (x,y));
	}

	public void SetMainPlayerRotate(Vector2 v){
		mainPlayer.setRotate (v);
		
	}


	public void OnClickTurnBack()
	{
		mainPlayer.setRotate (new Vector2 (0,180));
	}
	public void OnClickSettingPanel(){
		Debug.Log ("open setting panel"+Time.time);
		mainSetting.gameObject.SetActive (true);
	}

	public void setBoolDot(Vector3 worldPos){
		
	}

	#endregion





	#region   资源池
	private List<GameObject> listBullet=new List<GameObject>();

	public GameObject getABullet(){
		GameObject go = null;
		if (listBullet.Count >= 1) {
			go = listBullet [0];
			listBullet.RemoveAt (0);
		} else {
			go = GameObject.Instantiate (bullet_prefab,Vector3.zero,Quaternion.identity) as GameObject;
		}
		go.SetActive (true);
		return go;
	}

	public void ReturnABullet(GameObject go){
		go.SetActive (false);
		listBullet.Add (go);
	}

	#endregion

}

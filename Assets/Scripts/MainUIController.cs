using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class MainUIController : MonoBehaviour {

	public MoveControllerPanel leftMovePanel;
	//public FirstPersonController fsp;
	public MainPlayer mainPlayer;

	public float timeFPS = 0.0f;
	#region mono event
	void Start () 
	{
		if (leftMovePanel)
		{
			leftMovePanel.moveAc += leftPanelMove;
		}
	}
	

	void Update () {
		timeFPS = 1.0f / Time.deltaTime;
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
			Vector3 v2=mainPlayer.transform.rotation.eulerAngles;
			//fsp.transform.rotation = Quaternion.Euler (v2.x,v2.y+180,v2.z);
			//y = 0;
		}
		testMove = new Vector2 (x,y);
		mainPlayer.setMove (new Vector2 (x,y));
	}



	public void OnClickTurnBack(){
		//fsp.setMove (new Vector2 (180,0));

	}

	#endregion


	void OnGUI(){
		GUILayout.Label (timeFPS.ToString("0.0"));
	}

}

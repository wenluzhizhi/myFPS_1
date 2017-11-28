using UnityEngine;
using System.Collections;


public enum EnemyAIState{
	idle,walk,hit,death,
}





public class EnemyAI : MonoBehaviour {

	public EnemyAIState state=EnemyAIState.idle;
	public Animator myAni;
	public float timer = 0.0f;
	public float maxTime=4.0f;
	public Vector3 lastPos=Vector3.zero;
	public Transform firstPlayer;
	public Transform gunPos;
	public AudioSource playShot;
	void Start () {
		lastPos = this.transform.position;
	}
	
	RaycastHit hit;
	void Update () {


		timer += Time.deltaTime;
		if (timer > maxTime)
		{
			timer = 0.0f;

			if (state == EnemyAIState.idle) 
			{
				
				state = EnemyAIState.walk;
				maxTime = Random.Range (4,20);
				myAni.SetTrigger ("run");
			} 
			else if (state == EnemyAIState.walk) 
			{
				
				state = EnemyAIState.idle;
				myAni.SetTrigger ("idle");
				maxTime = Random.Range (1,5);
			}

		    
		}



		#region  运动控制：
		if(state==EnemyAIState.idle){
			
		}
		else if(state==EnemyAIState.walk){

			if(Vector3.Distance(lastPos,transform.position)<0.02f)
			{

				float _angle = Vector3.Angle (transform.forward,firstPlayer.transform.position-transform.position);
				float _rot=Random.Range(20,200);
				transform.Rotate(0,_angle,0);

			}
			lastPos=transform.position;
			transform.Translate (transform.forward * Time.deltaTime*2,Space.World);



		}

		#endregion


		#region 射线检测

		if(state!=EnemyAIState.death){

			if(Physics.Raycast(gunPos.position,transform.forward,out hit,1000))
			{
				if(hit.transform.gameObject.name=="FPSController")
				{
					myAni.SetTrigger("shot");
					if(!playShot.isPlaying)
					{
						playShot.Play();
					}
				}
				else{
				}
			}
		}

		#endregion
	}

	string str1="";
	void OnGUI1(){
		GUILayout.Label (str1);
	}


	#region external function

	public Vector3 newPos=Vector3.zero;
	public void HitOne(){
		if (state != EnemyAIState.death) {
			myAni.SetTrigger ("death");
			state = EnemyAIState.death;
			newPos=EnemyAIController.Instance.giveBackAI (this);
			Invoke ("ResetAI",3.0f);
		}
	}


	public void ResetAI(){
		this.state = EnemyAIState.idle;
		this.transform.position = newPos;
		EnemyAIController.Instance.enemyCount++;
	}



	#endregion


  	#region  碰撞检测：

	void OnCollisionEnter1(Collision info)
	{
		
	}



	#endregion
}

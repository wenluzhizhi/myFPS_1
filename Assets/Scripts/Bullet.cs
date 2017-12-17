using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float timer=0.0f;

	public Vector3 forward;


	public void SetForWard(Vector3 v){
		this.forward = v;
	}
	void Start(){
		//forward = MainUIController.Instance.mainPlayer.gameObject.transform.forward;
	}


	void Update(){
		timer += Time.deltaTime;
		if (timer > 5.0f) 
		{
			death ();
		}
		else 
		{
			transform.Translate (forward*0.05f, Space.World);
		}
	}


	void OnCollisionEnter(Collision collider){
		if (collider.transform.gameObject.CompareTag("Player")) {
			MainUIController.Instance.bgUIScripts.SetBloodDotPos (this.transform.position);
		}
		death ();
	}




	private void death(){
		timer = 0.0f;
		MainUIController.Instance.ReturnABullet (this.gameObject);
	}



}

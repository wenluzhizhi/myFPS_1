using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainPlayer : MonoBehaviour {


	private Transform myT;
	private Rigidbody rig;
	public Transform Gun;
	void Start ()
	{
		myT = this.transform;
		rig = this.gameObject.GetComponent<Rigidbody> ();
	}
	

	void Update ()
	{
	   
	}

	public void setMove(Vector2 v)
	{
		//transform.Translate (transform.forward * v.y, Space.World);
		rig.AddForce(transform.forward * v.y*MainUIController.Instance.MoveSpeed,ForceMode.Force);
		rig.AddForce(transform.right *v.x*MainUIController.Instance.MoveSpeed,ForceMode.Force);
		//transform.Translate (transform.right * v.x, Space.World);
	}



	public float zRot=0;
	public float xRot = 0;
	public float yRot = 0;
	public void setRotate(Vector2 v)
	{
		myT.Rotate (v.x, v.y, 0);

		yRot = myT.eulerAngles.y;
		xRot = myT.eulerAngles.x;
		if (xRot >= 180 && xRot <= 360) {
			xRot-=360;
		}

		if (xRot >20) {
			xRot = 20;
		}
		if (xRot < -20) {
			xRot = -20;
		}

		myT.transform.eulerAngles = new Vector3 (xRot,yRot,0);
	}






}

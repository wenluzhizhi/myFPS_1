using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainPlayer : MonoBehaviour {


	private Transform myT;
	private Rigidbody rig;
	public Transform Gun;
	public Transform myCamera;
	public MeshRenderer firpersonRender;
	public GameObject thirdPerson;
	public bool isFirstPerson = true;
	public Animator ani;
	void Start ()
	{
		myT = this.transform;
		rig = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	void OnGUI(){
		if (GUILayout.Button ("Change Person")) {
			Debug.Log ("--------"+Time.time);
			isFirstPerson = !isFirstPerson;
			firpersonRender.enabled = isFirstPerson;
			thirdPerson.gameObject.SetActive (!isFirstPerson);
			if (isFirstPerson) {
				myCamera.localPosition = new Vector3 (0,0.42f,0);
				myCamera.localRotation = Quaternion.identity;
			} else {
				myCamera.localPosition = new Vector3 (-0.2f,2.2f,-4.1f);
				myCamera.localRotation = Quaternion.Euler (new Vector3(9,1.2f,0));
			}
		}
	}
	void Update ()
	{
		
	}

	public void setMove(Vector2 v)
	{

		if (!isFirstPerson)
		{
			AnimatorStateInfo s=ani.GetCurrentAnimatorStateInfo (0);

			if (!s.IsName("WalkFire"))
			{
				ani.SetTrigger ("WalkFire");
			}
		}
		rig.AddForce(transform.forward * v.y*MainUIController.Instance.MoveSpeed,ForceMode.Force);
		rig.AddForce(transform.right *v.x*MainUIController.Instance.MoveSpeed,ForceMode.Force);

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

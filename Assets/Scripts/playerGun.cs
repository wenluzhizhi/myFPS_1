using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGun : MonoBehaviour {


	public Transform myTransform;
	public RectTransform crossHairBg;
	public RectTransform hair;
	public AudioSource playShot;
	[SerializeField] private Transform bulletPos;
	void Start () {
		myTransform = this.gameObject.transform;
	}
	
	RaycastHit hit;
	public Vector3 hitV;
	public Vector2 ScreenPos;
	public Vector2 UIPos;
	void Update ()
	{
		if (Physics.Raycast (myTransform.position, myTransform.forward, out hit, 500)) 
		{
			hitV = hit.point;
			//Debug.DrawLine(myTransform.position,hitV,Color.red,0.2f);
			ScreenPos = RectTransformUtility.WorldToScreenPoint (Camera.main, hitV);
			RectTransformUtility.ScreenPointToLocalPointInRectangle (crossHairBg,ScreenPos,null,out UIPos);
			hair.anchoredPosition = UIPos;

			if (hit.transform.tag =="enemy") 
			{
				EnemyAI AI = hit.transform.gameObject.GetComponent<EnemyAI> ();
				if (!playShot.isPlaying&&AI.state!=EnemyAIState.death)
				{
					playShot.Play ();
					AI.HitOne ();
				}

			}
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
		  //fireBullet ();	
		}
	}


	private void fireBullet()
	{
		GameObject go = MainUIController.Instance.getABullet ();
		go.transform.position =bulletPos.position;

		go.transform.rotation = MainUIController.Instance.mainPlayer.transform.rotation;
	    //Rigidbody rig1=go.GetComponent<Rigidbody> ();
		//rig1.AddForce(myTransform.forward*1000);

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGun : MonoBehaviour {


	public Transform myTransform;
	public AudioSource playShot;
	[SerializeField] private Transform bulletPos;
	void Start () {
		myTransform = this.gameObject.transform;
	}
	
	RaycastHit hit;
	public Vector3 hitV;

	void Update ()
	{
		if (Physics.Raycast (myTransform.position, myTransform.forward, out hit, 500)) 
		{
			hitV = hit.point;
			MainUIController.Instance.bgUIScripts.setCrossHairPos (hitV);
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
	}
}

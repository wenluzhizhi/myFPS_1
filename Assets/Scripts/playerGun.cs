using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGun : MonoBehaviour {


	public Transform myTransform;
	public RectTransform crossHairBg;
	public RectTransform hair;
	public AudioSource playShot;
	void Start () {
		myTransform = this.gameObject.transform;
	}
	
	RaycastHit hit;
	public Vector3 hitV;
	public Vector3 ScreenPos;
	public Vector2 UIPos;
	void Update ()
	{
		if (Physics.Raycast (myTransform.position, myTransform.forward, out hit, 2000)) 
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
	}
}

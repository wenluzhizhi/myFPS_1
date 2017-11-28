using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {


	void Start ()
	{
	
	}
	

	void Update ()
	{
	
	}

	public void setMove(Vector2 v){
		transform.Translate (transform.forward * v.y, Space.World);
		transform.Rotate (Vector3.up, v.x);
	}

}

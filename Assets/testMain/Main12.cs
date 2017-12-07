using UnityEngine;
using System.Collections;

public class Main12 : MonoBehaviour {

	public Rigidbody rig;
	public Transform myt;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI(){
		if (GUILayout.Button ("test......")) {
			rig.AddForce (myt.forward*100);
		}
	}
}

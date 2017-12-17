using UnityEngine;
using System.Collections;

public class MainTestAnimator : MonoBehaviour {

	public Animator ani;
	void Start () {
		ani = this.gameObject.GetComponent<Animator> ();
	}
	

	void Update () {
	
	}

	void OnGUI(){
		if (GUILayout.Button ("Run")) {
			ani.SetTrigger ("Run");
		} else if (GUILayout.Button ("Idle")) {
			ani.SetTrigger ("Idle");
		}
		else if (GUILayout.Button ("CrouchFire")) {
			ani.SetTrigger ("CrouchFire");
		}
		else if (GUILayout.Button ("WalkFireRPG")) {
			ani.SetTrigger ("WalkFireRPG");
		}
		else if (GUILayout.Button ("WalkFire")) {
			ani.SetTrigger ("WalkFire");
		}
		else if (GUILayout.Button ("RelaxedWalk")) {
			ani.SetTrigger ("RelaxedWalk");
		}
		else if (GUILayout.Button ("CrouchWalk")) {
			ani.SetTrigger ("CrouchWalk");
		}
		else if (GUILayout.Button ("RunFire")) {
			ani.SetTrigger ("RunFire");
		}
		else if (GUILayout.Button ("StandingFire")) {
			ani.SetTrigger ("StandingFire");
		}
		else if (GUILayout.Button ("Crouch")) {
			ani.SetTrigger ("Crouch");
		}


		if (GUILayout.Button ("dfdddddf"))
		{
			AnimatorStateInfo a2 = ani.GetCurrentAnimatorStateInfo (0);
			if (a2.IsName ("WalkFire")) 
			{
				//ani.pl

				Debug.Log ("WalkFire......");
				Debug.Log (a2.normalizedTime);
			}
	
		}

	}



}

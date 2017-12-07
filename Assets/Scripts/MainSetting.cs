using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainSetting : MonoBehaviour
{

	[SerializeField] private InputField moveSpeedIpt;
	void Start () {
		this.gameObject.SetActive (false);
	}
	

	void Update () {
	
	}

	#region  onclick event

	public void OnClickClosePanel(){
		this.gameObject.SetActive (false);

		int moveSpeed = int.Parse (moveSpeedIpt.text.ToString());
		MainUIController.Instance.MoveSpeed = moveSpeed;
	}

	#endregion
}

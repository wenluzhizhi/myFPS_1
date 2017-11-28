using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BgUIScripts : UIBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{


	#region var

	public Transform gun;

	#endregion


	#region Interface

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
	}

	#endregion

	#region IDragHandler implementation

	public Vector2 DragV;
	public void OnDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		DragV=eventData.delta;
		Vector3 ve=gun.transform.localRotation.eulerAngles;

		float _x = ve.x;
		float _y = ve.y;
		if (_y > 180 && _y <= 360) {
			_y = _y - 360;
		}


		if (DragV.x > 4) {
			_y += 2f;
		} else if (DragV.x < -4) {
			_y -= 2f;
		}

		if (_y > 20) {
			_y = 20;
		} 
		else if (_y < -20)
		{
			_y = -20;
		}




		if (_x> 180 && _x <= 360) {
			_x = _x - 360;
		}


		if (DragV.y > 4) {
			_x -= 2f;
		} else if (DragV.y < -4) {
			_x += 2f;
		}

		if (_x > 20) {
			_x =20;
		} 
		else if (_x < -20)
		{
			_x = -20;
		}



		gun.transform.localRotation = Quaternion.Euler (_x,_y,ve.z);

	}

	#endregion

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
	}

	#endregion

	#endregion


	#region monoEvent

	void Start () {
	
	}
	

	void Update () {
	
	}

	#endregion
}

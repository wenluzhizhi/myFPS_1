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
		
		DragV=eventData.delta;
		MainUIController.Instance.SetMainPlayerRotate(new Vector2(DragV.y*-0.2f,DragV.x));

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

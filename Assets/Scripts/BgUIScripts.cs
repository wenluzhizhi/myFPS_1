using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BgUIScripts : UIBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{


	#region var

	public Transform gun;
	public RectTransform BgUI_RT;
	public RectTransform CrossHair_RT;
	public RectTransform BloodDot_RT;

	private Vector3 corssHairWorldPos;
	private Vector3 bloodDotWorldPos;
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


	#region external function

	private Vector2 ScreenPos;
	private Vector2 UIPos;
	public void setCrossHairPos(Vector3 worldPos){
		ScreenPos = RectTransformUtility.WorldToScreenPoint (Camera.main, worldPos);
		RectTransformUtility.ScreenPointToLocalPointInRectangle (BgUI_RT,ScreenPos,null,out UIPos);
		CrossHair_RT.anchoredPosition = UIPos;
	}

	public void SetBloodDotPos(Vector3 worldPos){
		ScreenPos = RectTransformUtility.WorldToScreenPoint (Camera.main, worldPos);
		RectTransformUtility.ScreenPointToLocalPointInRectangle (BgUI_RT,ScreenPos,null,out UIPos);
		BloodDot_RT.anchoredPosition = UIPos;
	}



	#endregion

	#region monoEvent

	void Start () {
		BgUI_RT = this.gameObject.GetComponent<RectTransform> ();

	}
	

	void Update () {
	
	}

	#endregion
}

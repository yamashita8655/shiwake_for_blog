using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaggageObject : DragController
{
	// ボタン画像
	[SerializeField]
	private Image BgImage = null;
	
	private Enum.BaggageType Type = Enum.BaggageType.One;
	
	private float MoveValue = 0f;

	private bool IsDrag = false;

	private GameObject AttachParentObject = null;
	
	private int BaggageValue = 0;

	public void Initialize(float moveValue, GameObject attachParentObject, int baggageValue)
	{
		MoveValue = moveValue;
		IsDrag = false;
		AttachParentObject = attachParentObject;
		BaggageValue = baggageValue;

		int type = UnityEngine.Random.Range(0, (int)Enum.BaggageType.Max);
		Type = (Enum.BaggageType)type;

		if (Type == Enum.BaggageType.One) {
			BgImage.color = Color.red;
		} else if (Type == Enum.BaggageType.Two) {
			BgImage.color = Color.green;
		} else if (Type == Enum.BaggageType.Three) {
			BgImage.color = Color.blue;
		} else if (Type == Enum.BaggageType.Four) {
			BgImage.color = Color.yellow;
		}
		
		//gameObject.transform.localPosition = new Vector3(-500f, 0f, 0f);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
	}
	

	void Update() {
		if (IsDrag == false) {
			Move(MoveValue);
		}
	}

	private void Move(float val) {
		Vector3 pos = gameObject.transform.localPosition;
		pos.x += val;
		gameObject.transform.localPosition = pos;
	}
	
	override public void OnPointerDown(PointerEventData data)
	{
		IsDrag = true;
		Debug.Log("BaggageObject:OnPointerDown");
		gameObject.transform.SetParent(AttachParentObject.transform);
		gameObject.transform.localScale = Vector3.one;
		//gameObject.transform.localPosition = data.position;
		gameObject.transform.position = data.position;
		Debug.Log(data.position);
		//DownPosition = data.pressPosition;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public Enum.BaggageType GetBaggageType() {
		return Type;
	}

	public int GetBaggageValue() {
		return BaggageValue;
	}
	
	public void SetBaggageValue(int val) {
		BaggageValue = val;
	}
	
	public void AddBaggageValue(int val) {
		BaggageValue += val;
	}

	override public void OnPointerUp(PointerEventData data)
	{
		Debug.Log("BaggageObject:OnPointerUp");
		var raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll ( data, raycastResults );

		bool dropSuccess = false;
		foreach ( var hit in raycastResults )
		{
			// もし DroppableField の上なら、その位置に固定する
			if (hit.gameObject.GetComponent<PalletObjectController>() != null)
			{
				dropSuccess = true;
				break;
			}
		}

		if (dropSuccess == false) {
			// ここで、マイナス点数
			Destroy(gameObject);
			Debug.Log("BaggageObject:dropFailer");
		}
	}
	
	override public void OnBeginDrag(PointerEventData data)
	{
		gameObject.transform.position = data.position;
		Debug.Log("BaggageObject:OnBeginDrag");
	}

	override public void OnDrag(PointerEventData data)
	{
		gameObject.transform.position = data.position;
		Debug.Log("BaggageObject:OnDrag");
	}

	override public void OnEndDrag(PointerEventData data)
	{
		Debug.Log("BaggageObject:OnEndDrag");
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PalletObjectController : DropController, IPointerClickHandler {
	[SerializeField]
	private Text MaxBaggageCapacityText = null;
	
	[SerializeField]
	private Text CurrentBaggageCapacityText = null;
	
	[SerializeField]
	private GameObject FilterImageObject = null;

	private Enum.BaggageType BaggageType;

	private int MaxBaggageCapacity = 10;
	private int CurrentBaggageCapacity = 0;

	private bool IsMove = false;
	
	private float MoveTime = 0f;
	private float MovePassTime = 0f;

	
	public void Initialize(Enum.BaggageType type) {
		BaggageType = type;

		MaxBaggageCapacityText.text = MaxBaggageCapacity.ToString();
		UpdateCurrentBaggageCapacityText(CurrentBaggageCapacity);
		IsMove = false;
		FilterImageObject.transform.localScale = new Vector3(1f, 0f, 1f);
	}

	private void UpdateCurrentBaggageCapacityText(int val) {
		CurrentBaggageCapacityText.text = val.ToString();
	}
	
	void Update() {
		if (IsMove == true) {
			MovePassTime += Time.deltaTime;
			if (MovePassTime >= MoveTime) {
				IsMove = false;
				InGame1DataCarrier.Instance.CurrentScore += CurrentBaggageCapacity;
				UpdateScore();
				CurrentBaggageCapacity = 0;
				UpdateCurrentBaggageCapacityText(CurrentBaggageCapacity);
				FilterImageObject.transform.localScale = new Vector3(1f, 0f, 1f);
			} else {
				float yScale = 1f - (1f * (MovePassTime/MoveTime));
				FilterImageObject.transform.localScale = new Vector3(1f, yScale, 1f);
			}
		}
	}

	private void UpdateScore() {
		InGame1Scene scene = InGame1DataCarrier.Instance.Scene as InGame1Scene;
		scene.UpdateScoreText();
	}

	public void OnPointerClick(PointerEventData data) {
		IsMove = true;
		MoveTime = CurrentBaggageCapacity;
		if (MoveTime <= 1f) {
			MoveTime = 1f;
		}
		MovePassTime = 0f;
		Debug.Log("Pallet:OnPointerClick");
	}

	override public void OnDrop(PointerEventData data)
	{
		if (IsMove == true) {
			// ミスなので、とりあえずカウントを増やさないようにしておく
		} else {
			BaggageObject obj = data.pointerDrag.GetComponent<BaggageObject>();
			if (obj.GetBaggageType() == BaggageType) {
				CurrentBaggageCapacity += obj.GetBaggageValue();
			} else {
				// ミスなので、とりあえずカウントを増やさないようにしておく
			}
			UpdateCurrentBaggageCapacityText(CurrentBaggageCapacity);
		}
		
		Destroy(data.pointerDrag);
		//Debug.Log(data.pointerDrag.name);
		Debug.Log("OnDrop");
	}
}

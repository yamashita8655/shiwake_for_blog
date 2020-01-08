using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public abstract void OnPointerDown(PointerEventData data);
					
	public abstract void OnPointerUp(PointerEventData data);
		   
	public abstract void OnBeginDrag(PointerEventData eventData);
					
	public abstract void OnDrag(PointerEventData data);
					
	public abstract void OnEndDrag(PointerEventData eventData);
}

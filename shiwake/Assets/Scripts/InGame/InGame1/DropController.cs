using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropController : MonoBehaviour, IDropHandler {
	public abstract void OnDrop(PointerEventData data);
}

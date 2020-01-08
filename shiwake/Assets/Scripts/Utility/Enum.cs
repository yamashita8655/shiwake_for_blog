using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour {
	
	public enum BaggageType : int {
		One = 0,
		Two,
		Three,
		Four,
		Max,
	}
	
	public enum Bgm {
		Title = 0,
		Home,
		Game,
		None
	};
	
	public enum Se {
		ButtonOk = 0,
		ButtonCancel,
		InGameButtonSelect,
		Correct,
		Failure,
	};
}

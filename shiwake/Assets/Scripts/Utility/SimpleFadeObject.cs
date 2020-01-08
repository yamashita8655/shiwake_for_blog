﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFadeObject : FadeObjectBase {

	private LinearCulc AlphaCulc = new LinearCulc();
	override public void Initialize()
	{
		AlphaCulc.SetEndCount(1f);
		AlphaCulc.SetStartValue(0f);
		AlphaCulc.SetEndValue(255f);
	}

	override public void UpdateFade(float range)
	{
		float alpha = AlphaCulc.GetValue(range);
		Debug.Log(alpha);
		Color color = FadeImage.color;
		color.a = alpha;
		FadeImage.color = color;
	}
}

//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using StuartHeathTools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///Logger full description
/// </summary>
public class Logger : GenericUnitySingleton<Logger>
{
	[SerializeField] private TextMeshProUGUI text;
	[SerializeField] private ScrollRect scrollRect;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Image background;

	public void SetCanvasLayer(int v) => canvas.sortingOrder = v;
	public void SetBackgroundColor(Color c) => background.color = c;

	public void LogWithColor(string message, Color color)
	{
		text.text +=DateTime.Now.ToString("HH:mm:ss.fff") + ": "+ message.WithColor(color) + "\r\n";
		StartCoroutine(PushToBottom());
	}

	public void Log(string message)
	{
		Debug.Log(message);
		LogWithColor(message, Color.white);
	}

	public void LogWarning(string message)
	{
		Debug.LogWarning(message);
		LogWithColor(message, Color.yellow);
	}

	public void LogError(string message)
	{
		Debug.LogError(message);
		LogWithColor(message, Color.red);
	}


	private IEnumerator PushToBottom()
	{
		yield return new WaitForEndOfFrame();
		scrollRect.verticalNormalizedPosition = 0;
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform) text.transform);
	}
}
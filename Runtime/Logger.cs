//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using System;
using System.ComponentModel;
using StuartHeathTools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///Logger full description
/// </summary>
public class Logger : MonoBehaviour
{
	private static Transform container;

	private void Awake() => container = GetComponentInChildren<VerticalLayoutGroup>().transform;


	public static void LogWithColor(string message, Color color)
	{
		var x = new GameObject().AddComponent<TextMeshProUGUI>();
		x.transform.SetParent(container);
		x.enableAutoSizing = true;
		x.text = message.WithColor(Color.white);
	}

	public static void Log(string message) => LogWithColor(message, Color.white);
	public static void LogWarning(string message) => LogWithColor(message, Color.yellow);
	public static void LogError(string message) => LogWithColor(message, Color.red);
}
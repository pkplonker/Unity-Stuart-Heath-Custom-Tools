//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
///FindMissingScripts full description
/// </summary>
public class FindMissingScript
{
	[MenuItem("Stuart/Missing Scripts/Find")]
	public static void FindMissingScripts()
	{
		foreach (var go in GameObject.FindObjectsOfType<GameObject>())
		{
			foreach (var component in go.GetComponentsInChildren<Component>())
			{
				if (component == null) Debug.Log($"{go.name} has missing script", go);
				break;
			}
		}
	}

	[MenuItem("Stuart/Missing Scripts/Delete")]
	public static void DestroyMissingScripts()
	{
		if (!EditorUtility.DisplayDialog("Destroy Components with Missing scripts?",
			    "Are you sure you want to destroy all components with missing scripts?", "Yes", "No")) return;
		var count = 0;
		foreach (var go in GameObject.FindObjectsOfType<GameObject>())
		{
			foreach (var component in go.GetComponentsInChildren<Component>())
			{
				if (component != null)continue;
				GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
				count++;
			}
		}

		Debug.Log(count > 0
			? $"Destroyed {count} components with missing scripts"
			: "No components with missing scripts found");
	}
}
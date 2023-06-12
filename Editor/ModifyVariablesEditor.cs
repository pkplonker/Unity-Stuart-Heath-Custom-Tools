//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using UnityEditor;

/// <summary>
///ModifyVariablesEditor full description
/// </summary>
public class ModifyVariablesEditor : EditorWindow
{
	private static MonoScript selectedScript;

	[MenuItem("Assets/Stuart/Modify Variables", false, 14)]
	public static void ShowWindow()
	{
		var selectedObject = Selection.activeObject;
		if (selectedObject != null && selectedObject is MonoScript monoScript)
		{
			selectedScript = monoScript;
			GetWindow<ModifyVariablesEditor>("Modify Variables Editor");
		}
		else
		{
			EditorUtility.DisplayDialog("Invalid Selection",
				"Please select a MonoBehaviour script in the project window", "OK");
		}
	}

	private void OnGUI()
	{
		selectedScript = EditorGUILayout.ObjectField("Select MonoScript", selectedScript, typeof(MonoScript), false) as MonoScript;

		if (selectedScript != null)
		{
			var serializedObject = new SerializedObject(selectedScript);
			var property = serializedObject.GetIterator();

			while (property.NextVisible(true))
			{
				EditorGUILayout.LabelField("", property.displayName);
			}
		}
		// Object selectedObject = Selection.activeObject;
		// if (selectedObject != null && selectedObject is MonoScript monoScript)
		// {
		// 	selectedScript = monoScript;
		// }
		//
		// Type scriptClassType = selectedScript.GetClass();
		//
		// if (scriptClassType == null) return;
		// // Get all fields (variables) in the class
		// var fields = scriptClassType.GetFields(BindingFlags.Public | BindingFlags.NonPublic);
		// string[] outputText = new string[fields.Length];
		//
		// for (var i = 0; i < fields.Length; i++)
		// {
		// 	Debug.Log(fields[i].Name);
		// 	outputText[i] = fields[i].Name;
		// 	outputText[i] = EditorGUILayout.TextField(outputText[i]);
		// }
	}
}
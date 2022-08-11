//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//
#if UNITY_EDITOR


using StuartHeathToolsEditor;
using UnityEditor;
using UnityEngine;

namespace StuartHeathToolsEditor
{
	/// <summary>
	///DemoWindow full description
	/// </summary>
	public class StuartToolsPanel : EditorWindow
	{
		[MenuItem("Stuart/Tools Panel", false, 0)]
		[MenuItem("Window/Panels/Stuart Tools Panel", false, 90)]
		[MenuItem("Window/Stuart Tools Panel", false, 0)]
		public static void ShowWindow()
		{
			UpdateToolsPackage.GetPackageVersionNumber();

			GetWindow<StuartToolsPanel>("Stuart Tools" + UpdateToolsPackage.currentVersionNumber);

		}

		private void OnGUI()
		{

			var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
			GUILayout.Label("New Scripts", style);
			EditorGUILayout.Space();
			ScriptGenerationButtons();
			UtilityEditor.LineBreak();




			GUILayout.FlexibleSpace();
			UpdateToolsPackage.GetPackageVersionNumber();
			GUILayout.Label(
				"Version " + (UpdateToolsPackage.currentVersionNumber == ""
					? "..."
					: UpdateToolsPackage.currentVersionNumber), style);
			if (GUILayout.Button("Update Tools Package"))
			{
				UpdateToolsPackage.UpdatePackageFromGit();
			}
		}

		private static void ScriptGenerationButtons()
		{
			using (new GUILayout.HorizontalScope())
			{
				if (GUILayout.Button("New MonoBehaviour", EditorStyles.miniButtonLeft))
					CreateScriptMenus.CreateMonoBehaviourScript();
				if (GUILayout.Button("New Editor", EditorStyles.miniButtonMid))
					CreateScriptMenus.CreateMonoBehaviourScript();
				if (GUILayout.Button("New Scriptable Object", EditorStyles.miniButtonRight))
					CreateScriptMenus.CreateSOScript();
			}
		}
	}
}

#endif	
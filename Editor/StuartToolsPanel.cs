//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using Editor.ScriptCreation;
using StuartHeathToolsEditor;
using UnityEditor;
using UnityEngine;

namespace Editor
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
			GetWindow<StuartToolsPanel>("Stuart Tools");
		}

		private void OnGUI()
		{
			var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
			GUILayout.Label("Create New Script", style);
			EditorGUILayout.Space();
			ScriptGenerationButtons();
			UtilityEditor.LineBreak();
		}

		private static void ScriptGenerationButtons()
		{
			using (new GUILayout.HorizontalScope())
			{
				if (GUILayout.Button("New MonoBehaviour", EditorStyles.miniButtonLeft))
					CreateScriptMenus.CreateMonoBehaviourScript();
				if (GUILayout.Button("New Editor", EditorStyles.miniButtonMid))
					CreateScriptMenus.CreateMonoBehaviourScript();
				if (GUILayout.Button("New MonoBehaviour", EditorStyles.miniButtonRight))
					CreateScriptMenus.CreateSOScript();
			}
		}
	}
}
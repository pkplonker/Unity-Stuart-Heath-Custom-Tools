//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//
#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace StuartHeathToolsEditor
{
	/// <summary>
	///CreateScriptMenus - Used to create the script menus with custom templates. Alternative templates can be used by setting the template path and stored in the same folder.
	/// </summary>

	public class CreateScriptMenus
	{
		private static readonly string monobehaviourTemplateTxt = "/MonoBehaviourTemplate.txt";
		private static readonly string editorTemplateTxt = "/EditorTemplate.txt";
		private static readonly string scriptableObjectTemplateTxt = "/ScriptableObjectTemplate.txt";


		[MenuItem("Assets/Stuart/Create Scripts/Create MonoBehaviour Script", false, 12)]
		[MenuItem("Stuart/Create Scripts/Create MonoBehaviour Script", false, 0)]
		public static void CreateMonoBehaviourScript()
		{
			var pathToNewFile = EditorUtility.SaveFilePanel("Create MonoBehaviour Script", GetCurrentPath(false),
				"NewMonoBehaviour.cs", "cs");
			var pathToTemplate = UtilityEditor.GetFolderPathFromFile(typeof(CreateScriptMenus)) +
			                     monobehaviourTemplateTxt;
			GenerateScriptFromTemplate(pathToNewFile, pathToTemplate);
		}

		[MenuItem("Assets/Stuart/Create Scripts/Create Scriptable Object Script", false, 14)]
		[MenuItem("Stuart/Create Scripts/Create Scriptable Object Script", false, 2)]
		public static void CreateSOScript()
		{
			var pathToNewFile = EditorUtility.SaveFilePanel("Create ScriptableObject Script", GetCurrentPath(false),
				"NewScriptableObject.cs", "cs");
			var pathToTemplate = UtilityEditor.GetFolderPathFromFile(typeof(CreateScriptMenus)) +
			                     scriptableObjectTemplateTxt;
			GenerateScriptFromTemplate(pathToNewFile, pathToTemplate);
		}


		[MenuItem("Assets/Stuart/Create Scripts/Create Editor Script", false, 13)]
		[MenuItem("Stuart/Create Scripts/Create Editor Script", false, 1)]
		public static void CreateEditorScript()
		{
			var pathToNewFile =
				EditorUtility.SaveFilePanel("Create Editor Script", GetCurrentPath(true), "NewEditor.cs", "cs");
			var pathToTemplate = UtilityEditor.GetFolderPathFromFile(typeof(CreateScriptMenus)) + editorTemplateTxt;
			GenerateScriptFromTemplate(pathToNewFile, pathToTemplate);
		}

		private static void GenerateScriptFromTemplate(string pathToNewFile, string pathToTemplate)
		{
			if (string.IsNullOrWhiteSpace(pathToNewFile)) return;
			var fileInfo = new FileInfo(pathToNewFile);
			var scriptName = Path.GetFileNameWithoutExtension(fileInfo.Name);
			var data = File.ReadAllText(pathToTemplate);
			data = ReplaceValues(data, scriptName);
			File.WriteAllText(pathToNewFile, data);
			AssetDatabase.Refresh();
		}

		public static string ReplaceValues(string data, string scriptName)
		{
			data = data.Replace("#SCRIPTNAME#", scriptName);
			data = data.Replace("#YEAR#", DateTime.Now.Year.ToString());
			data = data.Replace("#SCRIPTNAMEWITHOUTEDITOR#", scriptName.Replace("Editor", ""));
			return data;
		}

		private static string GetCurrentPath(bool isEditor)
		{
			if (Selection.assetGUIDs.Length == 0) return Application.dataPath + (isEditor ? "/Editor" : "/Scripts");
			var path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
			if (path.Contains("Packages/")) return Application.dataPath + (isEditor ? "/Editor" : "/Scripts");
			return !path.Contains(".") ? path : UtilityEditor.GetFolderPathFromFilePath(path);
		}
		
	}
}
#endif

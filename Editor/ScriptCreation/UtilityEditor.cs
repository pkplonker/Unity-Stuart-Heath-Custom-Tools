using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor.ScriptCreation
{
	/// <summary>
	/// Utility class for custom editor scripts.
	/// </summary>
	public class UtilityEditor
	{
		public static void LineBreak(int height = 1)
		{
			var rect = EditorGUILayout.GetControlRect(false, height);
			rect.height = height;
			EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
		}

		public static string GetFolderPathFromFilePath(string path)
		{
			if (string.IsNullOrWhiteSpace(path)) return "";
			var index = path.LastIndexOf("/");
			if (index == -1) return "";
			path = path.Substring(0, index);
			return path;
		}

		public static string GetMonoScriptPathFor(Type type)
		{
			var asset = "";
			var guids = AssetDatabase.FindAssets(string.Format("{0} t:script", type.Name));
			if (guids.Length > 1)
			{
				foreach (var guid in guids)
				{
					var assetPath = AssetDatabase.GUIDToAssetPath(guid);
					var filename = Path.GetFileNameWithoutExtension(assetPath);
					if (filename != type.Name) continue;
					asset = guid;
					break;
				}
			}
			else if (guids.Length == 1) asset = guids[0];
			else
			{
				Debug.LogErrorFormat("Unable to locate {0}", type.Name);
				return null;
			}

			return asset;
		}

		public static string GetFolderPathFromFile(Type t) =>
			GetFolderPathFromFilePath(AssetDatabase.GUIDToAssetPath(GetMonoScriptPathFor(t)));
	}
}
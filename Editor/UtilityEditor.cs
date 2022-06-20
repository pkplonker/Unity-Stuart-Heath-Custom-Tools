using UnityEditor;
using UnityEngine;

namespace StuartHeathToolsEditor
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

		public static string GetFolderPathFromFile(string path)
		{
			if (string.IsNullOrWhiteSpace(path)) return "";
			var index = path.LastIndexOf("/");
			path = path.Substring(0, index);
			return path;
		}
	}
}
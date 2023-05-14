//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StuartHeathToolsEditor
{
	/// <summary>
	///SceneView full description
	/// </summary>
	public class SceneViewBookmarksTool
	{
		private const string MENU_PATH = "Stuart/SceneCamera/";
		private static int bookmarkIndex = 0;
		[MenuItem(MENU_PATH + "Add")]
		public static void AddMenuItem()
		{
			var scene = EditorSceneManager.GetActiveScene();
			var directory = SceneViewBookmarkDirectory.Find(scene);
			if (directory == null)
				directory = SceneViewBookmarkDirectory.Create(scene);
			directory.AddBookMark(SceneViewBookmark.CreateSceneView(SceneView.lastActiveSceneView));
		}

		[MenuItem(MENU_PATH + "Switch _b")]
		public static void SwitchMenuItem()
		{
			var scene = EditorSceneManager.GetActiveScene();
			var directory = SceneViewBookmarkDirectory.Find(scene);
			if (directory != null)
			{
				SceneViewBookmark? bookmark = directory.GetBookmark(bookmarkIndex);
				if (bookmark.HasValue)
				{
					bookmark.Value.SetSceneViewOrientation(SceneView.lastActiveSceneView);
					bookmarkIndex++;
					if (bookmarkIndex >= directory.count) bookmarkIndex = 0;
				}
			}
		}

		[InitializeOnLoadMethod]
		private static void Initialize() => EditorSceneManager.sceneOpened += OnSceneOpened;
		private static void OnSceneOpened(Scene scene, OpenSceneMode mode) => bookmarkIndex = 0;
	}
}
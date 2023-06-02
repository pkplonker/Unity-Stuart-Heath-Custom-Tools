//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

/// <summary>
///SceneViewBookmarkDirectory full description
/// </summary>
public class SceneViewBookmarkDirectory : ScriptableObject
{
	[SerializeField] [HideInInspector] private string sceneGUID = null;

	[SerializeField] [Tooltip("Bookmarks")]
	private SceneViewBookmark[] bookmarks = null;

	public int count
	{
		get { return bookmarks == null ? 0 : bookmarks.Length; }
	}

	public static SceneViewBookmarkDirectory Create(Scene scene)
	{
		var directory = CreateInstance<SceneViewBookmarkDirectory>();
		var sceneGuid = AssetDatabase.AssetPathToGUID(scene.path);
		directory.sceneGUID = sceneGuid;
		var sceneName = Path.GetFileNameWithoutExtension(scene.path);
		var path = scene.path.Substring(0, scene.path.Length - Path.GetFileName(scene.path).Length);
		path = Path.Combine(path, sceneName + "Bookmarks.asset");
		AssetDatabase.CreateAsset(directory, path);
		return directory;
	}

	public static SceneViewBookmarkDirectory Find(Scene scene)
	{
		var sceneGuid = AssetDatabase.AssetPathToGUID(scene.path);
		foreach (var directoryGuid in AssetDatabase.FindAssets("t:SceneViewBookmarkDirectory"))
		{
			var pathToAsset = AssetDatabase.GUIDToAssetPath(directoryGuid);
			var directory =
				AssetDatabase.LoadAssetAtPath<SceneViewBookmarkDirectory>(pathToAsset);
			if (directory.sceneGUID.Equals(sceneGuid))
				return directory;
		}

		return null;
	}

	public SceneViewBookmark? GetBookmark(int index)
	{
		if (bookmarks == null || bookmarks.Length <= index) return null;
		return bookmarks[index];
	}

	public void AddBookMark(SceneViewBookmark bookmark)
	{
		if (bookmarks == null)
		{
			bookmarks = new SceneViewBookmark[1];
			bookmarks[0] = bookmark;
		}
		else
		{
			ArrayUtility.Add(ref bookmarks, bookmark);
		}

		EditorUtility.SetDirty(this);
		AssetDatabase.SaveAssetIfDirty(this);
	}
}
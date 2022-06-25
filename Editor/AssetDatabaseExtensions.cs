using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetDatabaseExtensions
{
	public static string GetPath(string filter)
	{
		var guids = AssetDatabase.FindAssets(filter);
		if (guids == null || guids.Length == 0) return null;
		return AssetDatabase.GUIDToAssetPath(guids[0]);
	}

	public static string GetPathToScript<T>() where T : class => GetPath($"t:Script{typeof(T).Name}");

	public static string GetDirectory<T>() where T : class
	{
		var relativePath = GetPathToScript<T>();
		return string.IsNullOrWhiteSpace(relativePath) ? null : Path.GetDirectoryName(relativePath);
	}
}
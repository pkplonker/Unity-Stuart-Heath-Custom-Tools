//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

/// <summary>
///VersionUpdater full description
/// </summary>
public class VersionUpdater
{
	[MenuItem("Stuart/Update Tools Version Number", false, 99900)]
	public static void UpdateToolsVersion()
	{
		if (!EditorUtility.DisplayDialog("Update Tools Version Number", "Do you want to update the tools version number?", "Yes", "No")) return;
		Debug.Log("User clicked Yes");

		var directoryPath = "Assets/Unity-Stuart-Heath-Custom-Tools";
		var fileName = "package.json";
		if(!File.Exists(directoryPath + "/" + fileName)||!Directory.Exists(directoryPath))
		{
			Debug.LogError("File not found: " + fileName);
			return;
		}
		var files = Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories);

		if (files.Length > 0)
		{
			Debug.Log("File found at path: " + files[0]);
			ReplaceVersionNumber(files[0]);
		}
		else
		{
			Debug.LogError("File not found: " + fileName);
		}
	}

	private static void ReplaceVersionNumber(string path)
	{
		var data = File.ReadAllText(path);
		var index = data.IndexOf("version", StringComparison.Ordinal);
		index += 11;
		var endIndex = data.IndexOf("\"", index, StringComparison.Ordinal);
		var res = data.Substring(index, endIndex - index);
		var resArray = res.Split('.');
		var version = int.Parse(resArray[2]);
		version++;
		data = data.Replace(res, resArray[0] + "." + resArray[1] + "." + version);
		var updatedJson = JsonUtility.ToJson(data, true);
		Debug.Log("Version number replaced. New JSON:\n" + updatedJson);
	}
}
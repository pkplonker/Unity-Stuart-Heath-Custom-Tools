using Editor.ScriptCreation;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class UtilityEditorTests
{
	[Test]
	public void GetFolderPathFromFilePath()
	{
		Assert.IsEmpty(UtilityEditor.GetFolderPathFromFilePath(""));
		Assert.AreEqual("Folder", UtilityEditor.GetFolderPathFromFilePath("Folder/file"));
		Assert.AreEqual("", UtilityEditor.GetFolderPathFromFilePath("Folderfile"));
		Assert.AreEqual("Folder", UtilityEditor.GetFolderPathFromFilePath("Folder/"));
		Assert.AreEqual("/A/B", UtilityEditor.GetFolderPathFromFilePath("/A/B/C"));
		Assert.AreEqual("/A/B/C", UtilityEditor.GetFolderPathFromFilePath("/A/B/C/"));
	}
	[Test]
	public void GetFolderPathFromFile() => Assert.AreEqual(
		"Packages/com.stuartheath.stuartheathtools/Tests/Editor",
		UtilityEditor.GetFolderPathFromFile(typeof(UtilityEditorTests)));
	[Test]
	public void GetMonoScriptPathFor() => Assert.AreEqual(
		"Packages/com.stuartheath.stuartheathtools/Tests/Editor/UtilityEditorTests.cs",
		AssetDatabase.GUIDToAssetPath(UtilityEditor.GetMonoScriptPathFor(typeof(UtilityEditorTests))));
}
using System;
using NUnit.Framework;
using StuartHeathToolsEditor;

public class CreateScriptMenusTests
{
	[Test]
	public void GetFolderPathFromFilePathEquals()
	{
		Assert.AreEqual("Test1", CreateScriptMenus.ReplaceValues("#SCRIPTNAME#", "Test1"));
		Assert.AreEqual(DateTime.Now.Year.ToString(), CreateScriptMenus.ReplaceValues("#YEAR#", "Test2"));
		Assert.AreEqual("Test3", CreateScriptMenus.ReplaceValues("#SCRIPTNAMEWITHOUTEDITOR#", "Test3Editor"));
		Assert.AreEqual("Test3", CreateScriptMenus.ReplaceValues("#SCRIPTNAMEWITHOUTEDITOR#", "Test3"));
	}

	[Test]
	public void GetFolderPathFromFilePathEmpty()
	{
		Assert.IsEmpty(CreateScriptMenus.ReplaceValues("#SCRIPTNAME#", ""));
		Assert.IsEmpty(CreateScriptMenus.ReplaceValues("", ""));
		Assert.IsEmpty(CreateScriptMenus.ReplaceValues("", "123"));
	}
}
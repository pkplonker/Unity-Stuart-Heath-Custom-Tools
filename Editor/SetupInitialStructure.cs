//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//
#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Editor
{
	/// <summary>
	///SetupInitialStructure full description
	/// </summary>
	///

	public class SetupInitialStructure
	{
		[MenuItem("Stuart/Setup InitialFolder Structure", false, 99999)]
		public static void SetupFolderStructure()
		{
			var folderList = new List<string> {"Prefabs", "Resources", "Scripts", "Editor", "Downloads", "Art"};

			//Check if folder exists with IsValidFolder if it doesn't create it
			foreach (var folder in folderList.Where(folder => !AssetDatabase.IsValidFolder($"Assets/{folder}")))
			{
				AssetDatabase.CreateFolder("Assets", folder);
			}

			folderList = new List<string> {"Animations", "Textures", "Materials"};
			foreach (var folder in folderList.Where(folder => !AssetDatabase.IsValidFolder($"Assets/{folder}")))
			{
				AssetDatabase.CreateFolder("Assets/Art", folder);
			}
		}
	}

}
#endif	
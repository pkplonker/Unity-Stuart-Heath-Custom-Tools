//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace StuartHeathToolsEditor
{
	/// <summary>
	///LoggerEditor full description
	/// </summary>
	[CustomEditor(typeof(LoggerOutput))]
	public class LoggerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			var t = target as LoggerOutput;
			if (t != null)
			{
				if (GUILayout.Button("Clear Log"))
				{
					t.ClearOutput();
				}
			}


			base.OnInspectorGUI();
		}
	}
}

#endif
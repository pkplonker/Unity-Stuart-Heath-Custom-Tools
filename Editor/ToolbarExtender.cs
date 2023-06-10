using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

//https://github.com/marijnz/unity-toolbar-extender
namespace StuartHeathToolsEditor
{
	[InitializeOnLoad]
	public static class ToolbarExtender
	{
		static int m_toolCount;
		static GUIStyle m_commandStyle = null;

		public static readonly List<Action> LeftToolbarGUI = new List<Action>();
		public static readonly List<Action> RightToolbarGUI = new List<Action>();
		private static GUIStyle buttonStyle;
		static ToolbarExtender()
		{
			Type toolbarType = typeof(Editor).Assembly.GetType("UnityEditor.Toolbar");
			string fieldName = "k_ToolCount";
			FieldInfo toolIcons = toolbarType.GetField(fieldName,
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
			m_toolCount = toolIcons != null ? ((int) toolIcons.GetValue(null)) : 8;
			ToolbarCallback.OnToolbarGUI = OnGUI;
			ToolbarCallback.OnToolbarGUILeft = GUILeft;
			ToolbarCallback.OnToolbarGUIRight = GUIRight;
			LeftToolbarGUI.Add(ToolBarLeft);
			RightToolbarGUI.Add(ToolBarRight);
			
		}

		
		public static void AddToolbarButton(ToolBarButtonInfo info)=>toolBarButtonInfos.Add(info);
		
		private static List<ToolBarButtonInfo> toolBarButtonInfos = new ();
		private static void ToolBarRight()
		{
			GUILayout.FlexibleSpace();

			
			foreach (var button in toolBarButtonInfos.Where(x=>!x.IsLeft))
			{
				buttonStyle = new GUIStyle(GUI.skin.button)
				{
					fixedWidth = button.Text.Length*2,
					fixedHeight = 25f,
				};
				if (button.Icon != null)
				{
					if (GUILayout.Button(new GUIContent(button.Text, button.Icon, button.Tooltip),buttonStyle))
					{
						button.OnClickCallback?.Invoke();
					}
				}
				else
				{
					if (GUILayout.Button(new GUIContent(button.Text, button.Tooltip),buttonStyle))
					{
						button.OnClickCallback?.Invoke();
					}
				}

			}
		}

		private static void ToolBarLeft()
		{
			GUILayout.FlexibleSpace();
			foreach (var button in toolBarButtonInfos.Where(x=>x.IsLeft))
			{
				buttonStyle = new GUIStyle(GUI.skin.button)
				{
					fixedWidth = 30+button.Text.Length*4,
					fixedHeight = 22f,
				};
				if (button.Icon != null)
				{
					if (GUILayout.Button(new GUIContent(button.Text, button.Icon, button.Tooltip),buttonStyle))
					{
						button.OnClickCallback?.Invoke();
					}
				}
				else
				{
					if (GUILayout.Button(new GUIContent(button.Text, button.Tooltip),buttonStyle))
					{
						button.OnClickCallback?.Invoke();
					}
				}

			}
		}

		private const float SPACE = 8;
		public const float LARGE_SPACE = 20;
		private const float BUTTON_WIDTH = 32;
		private const float DROPDOWN_WIDTH = 80;
		private const float PLAY_PAUSE_STOP_WIDTH = 140;

		static void OnGUI()
		{
			m_commandStyle ??= new GUIStyle("CommandLeft");

			var screenWidth = EditorGUIUtility.currentViewWidth;

			// Following calculations match code reflected from Toolbar.OldOnGUI()
			float playButtonsPosition = Mathf.RoundToInt((screenWidth - PLAY_PAUSE_STOP_WIDTH) / 2);

			Rect leftRect = new Rect(0, 0, screenWidth, Screen.height);
			leftRect.xMin += SPACE; // Spacing left
			leftRect.xMin += BUTTON_WIDTH * m_toolCount; // Tool buttons
			leftRect.xMin += SPACE; // Spacing between tools and pivot
			leftRect.xMin += 64 * 2; // Pivot buttons
			leftRect.xMax = playButtonsPosition;
			Rect rightRect = new Rect(0, 0, screenWidth, Screen.height);
			rightRect.xMin = playButtonsPosition;
			rightRect.xMin += m_commandStyle.fixedWidth * 3; // Play buttons
			rightRect.xMax = screenWidth;
			rightRect.xMax -= SPACE; // Spacing right
			rightRect.xMax -= DROPDOWN_WIDTH; // Layout
			rightRect.xMax -= SPACE; // Spacing between layout and layers
			rightRect.xMax -= DROPDOWN_WIDTH; // Layers
			rightRect.xMax -= SPACE; // Spacing between layers and account
			rightRect.xMax -= DROPDOWN_WIDTH; // Account
			rightRect.xMax -= SPACE; // Spacing between account and cloud
			rightRect.xMax -= BUTTON_WIDTH; // Cloud
			rightRect.xMax -= SPACE; // Spacing between cloud and collab
			rightRect.xMax -= 78; // Colab

			// Add spacing around existing controls
			leftRect.xMin += SPACE;
			leftRect.xMax -= SPACE;
			rightRect.xMin += SPACE;
			rightRect.xMax -= SPACE;

			// Add top and bottom margins
			leftRect.y = 4;
			leftRect.height = 22;
			rightRect.y = 4;
			rightRect.height = 22;

			if (leftRect.width > 0)
			{
				GUILayout.BeginArea(leftRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in LeftToolbarGUI)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}

			if (rightRect.width > 0)
			{
				GUILayout.BeginArea(rightRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in RightToolbarGUI)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}

		public static void GUILeft()
		{
			GUILayout.BeginHorizontal();
			foreach (var handler in LeftToolbarGUI)
			{
				handler();
			}

			GUILayout.EndHorizontal();
		}

		public static void GUIRight()
		{
			GUILayout.BeginHorizontal();
			foreach (var handler in RightToolbarGUI)
			{
				handler();
			}

			GUILayout.EndHorizontal();
		}
	}
	public class ToolBarButtonInfo
	{
		public string Text;
		public string Tooltip;
		public Texture Icon;
		public Action OnClickCallback;
		public bool IsLeft;

		public ToolBarButtonInfo(string text, [CanBeNull] string tooltip, [CanBeNull] Texture icon, Action onClickCallback,
			bool isLeft = true)

		{
			Text = text;
			Tooltip = tooltip ?? string.Empty;
			Icon = icon;
			OnClickCallback = onClickCallback ?? (()=>Debug.Log("Missing callback"));
			IsLeft = isLeft;
		}
		public ToolBarButtonInfo(string text, Action onClickCallback,
			bool isLeft = true)

		{
			Text = text;
			Tooltip = string.Empty;
			Icon = null;
			OnClickCallback = onClickCallback ?? (()=>Debug.Log("Missing callback"));
			IsLeft = isLeft;
		}
	}
}
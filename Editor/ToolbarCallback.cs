using System;
using UnityEngine;
using UnityEditor;
using System.Reflection;

using UnityEngine.UIElements;

namespace StuartHeathToolsEditor
{
	public static class ToolbarCallback
	{
		static Type m_toolbarType = typeof(Editor).Assembly.GetType("UnityEditor.Toolbar");
		static Type m_guiViewType = typeof(Editor).Assembly.GetType("UnityEditor.GUIView");
		static Type m_iWindowBackendType = typeof(Editor).Assembly.GetType("UnityEditor.IWindowBackend");

		static PropertyInfo m_windowBackend = m_guiViewType.GetProperty("windowBackend",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

		static PropertyInfo m_viewVisualTree = m_iWindowBackendType.GetProperty("visualTree",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

		static FieldInfo m_imguiContainerOnGui = typeof(IMGUIContainer).GetField("m_OnGUIHandler",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

		static ScriptableObject m_currentToolbar;

		/// <summary>
		/// Callback for toolbar OnGUI method.
		/// </summary>
		public static Action OnToolbarGUI;

		public static Action OnToolbarGUILeft;
		public static Action OnToolbarGUIRight;

		static ToolbarCallback()
		{
			EditorApplication.update -= OnUpdate;
			EditorApplication.update += OnUpdate;
		}

		static void OnUpdate()
		{
			// Relying on the fact that toolbar is ScriptableObject and gets deleted when layout changes
			if (m_currentToolbar != null) return;
			// Find toolbar
			var toolbars = Resources.FindObjectsOfTypeAll(m_toolbarType);
			m_currentToolbar = toolbars.Length > 0 ? (ScriptableObject) toolbars[0] : null;
			if (m_currentToolbar == null) return;
			var root = m_currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
			var rawRoot = root.GetValue(m_currentToolbar);
			var mRoot = rawRoot as VisualElement;
			RegisterCallback("ToolbarZoneLeftAlign", OnToolbarGUILeft);
			RegisterCallback("ToolbarZoneRightAlign", OnToolbarGUIRight);

			void RegisterCallback(string root, Action cb)
			{
				var toolbarZone = mRoot.Q(root);

				var parent = new VisualElement()
				{
					style =
					{
						flexGrow = 1,
						flexDirection = FlexDirection.Row,
					}
				};
				var container = new IMGUIContainer();
				container.style.flexGrow = 1;
				container.onGUIHandler += () => { cb?.Invoke(); };
				parent.Add(container);
				toolbarZone.Add(parent);
			}
		}
	}
}
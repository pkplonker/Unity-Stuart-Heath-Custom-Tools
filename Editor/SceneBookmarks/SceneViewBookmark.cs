//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using System;
using UnityEngine;
using UnityEditor;

/// <summary>
///SceneViewBookmark full description
/// </summary>
[Serializable]
public struct SceneViewBookmark
{
	public Vector3 pivot;
	public Quaternion rotation;
	public float size;
	public bool isOrtho;

	public static SceneViewBookmark CreateSceneView(SceneView sceneView)
	{
		SceneViewBookmark bookmark = new SceneViewBookmark()
		{
			pivot = sceneView.pivot,
			rotation = sceneView.rotation,
			size = sceneView.size,
			isOrtho = sceneView.orthographic
		};
		return bookmark;
	}

	public void SetSceneViewOrientation(SceneView sceneView)
	{
		SceneView.lastActiveSceneView.pivot = pivot;
		SceneView.lastActiveSceneView.rotation = rotation;
		SceneView.lastActiveSceneView.size = size;
		SceneView.lastActiveSceneView.orthographic = isOrtho;
	}
}
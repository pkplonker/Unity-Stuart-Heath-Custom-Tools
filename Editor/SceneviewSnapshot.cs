//
// Copyright (C) 2023 Stuart Heath. All rights reserved.
//

using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
///SceneviewSnapshot full description
/// </summary>
public class SceneviewSnapshot
{
	[MenuItem("Stuart/Capture Scene View")]
	public static void CaptureSceneViewMenuItem()
	{
		var sceneView = SceneView.lastActiveSceneView;
		var width = sceneView.camera.pixelWidth;
		var height = sceneView.camera.pixelHeight;
		var capture = new Texture2D(width, height);
		sceneView.camera.Render();
		RenderTexture.active = sceneView.camera.targetTexture;
		capture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		capture.Apply();
		var bytes = capture.EncodeToPNG();
		var fileName = "sceneViewCapture.png";
		File.WriteAllBytes(Application.dataPath + "/" + fileName, bytes);
		AssetDatabase.Refresh();
	}
}
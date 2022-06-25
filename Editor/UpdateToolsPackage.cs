using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class UpdateToolsPackage : UnityEditor.Editor
{
	static AddRequest Request;

	[MenuItem("Stuart/UpdateTools", false, 99995)]
	public static void UpdatePackageFromGit()
	{
		Request = Client.Add("https://github.com/pkplonker/Unity-Stuart-Heath-Custom-Tools.git");
		EditorApplication.update += Progress;
	}

	private static void Progress()
	{
		if (!Request.IsCompleted) return;
		if (Request.Status == StatusCode.Success)
			Debug.Log("Installed: " + Request.Result.packageId);
		else if (Request.Status >= StatusCode.Failure)
			Debug.Log(Request.Error.message);
		EditorApplication.update -= Progress;
	}
}
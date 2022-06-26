
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
#if UNITY_EDITOR

public class UpdateToolsPackage : UnityEditor.Editor
{
	static AddRequest Request;
	private static ListRequest listRequest;
	public static string currentVersionNumber { get; private set; } = "";

	[MenuItem("Stuart/UpdateTools", false, 99995)]
	public static void UpdatePackageFromGit()
	{
		Debug.Log("Updating Stuart Heath Tools....");
		Request = Client.Add("https://github.com/pkplonker/Unity-Stuart-Heath-Custom-Tools.git");
		EditorApplication.update += ProgressAdd;
	}

	private static void ProgressAdd()
	{
		if (!Request.IsCompleted) return;
		if (Request.Status == StatusCode.Success)
			Debug.Log("Installed: " + Request.Result.packageId);
		else if (Request.Status >= StatusCode.Failure)
		{
			Debug.LogWarning(Request.Error.message.Contains(" is already embedded and cannot be updated")
				? "Tools package already up to date"
				: Request.Error.message);
		}
		EditorApplication.update -= ProgressAdd;
	}

	public static void GetPackageVersionNumber()
	{
		listRequest = Client.List(false);
		EditorApplication.update += ProgressList;
	}

	private static void ProgressList()
	{
		if (!listRequest.IsCompleted) return;
		if (listRequest.Status == StatusCode.Success)
		{
		}
		else if (listRequest.Status >= StatusCode.Failure)
			Debug.Log(listRequest.Error.message);

		EditorApplication.update -= ProgressList;
		var info = listRequest.Result.FirstOrDefault(q => q.name == "com.stuartheath.stuartheathtools");
		if (info == null) return;
		currentVersionNumber = info.version;
	}
	#endif
}
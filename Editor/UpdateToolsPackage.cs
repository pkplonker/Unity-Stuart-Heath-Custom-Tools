using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class UpdateToolsPackage : UnityEditor.Editor
{
    static AddRequest Request;

    [MenuItem("Stuart/UpdateTools", false, 99999)]
    public static void UpdatePackageFromGit()
    {
        Client.Add("https://github.com/pkplonker/Unity-Stuart-Heath-Custom-Tools.git");
    }
    [MenuItem("Window/Add Package Example")]
    static void Add()
    {
        // Add a package to the project
        Request = Client.Add("https://github.com/pkplonker/Unity-Stuart-Heath-Custom-Tools.git");
        EditorApplication.update += Progress;
    }

    static void Progress()
    {
        if (Request.IsCompleted)
        {
            if (Request.Status == StatusCode.Success)
                Debug.Log("Installed: " + Request.Result.packageId);
            else if (Request.Status >= StatusCode.Failure)
                Debug.Log(Request.Error.message);

            EditorApplication.update -= Progress;
        }
    }
}

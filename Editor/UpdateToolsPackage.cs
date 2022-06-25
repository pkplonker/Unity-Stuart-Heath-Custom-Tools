using UnityEditor;
public class UpdateToolsPackage : UnityEditor.Editor
{
    [MenuItem("Stuart/UpdateTools", false, 99999)]
    public static void UpdatePackageFromGit()
    {
        UnityEditor.PackageManager.Client.Add("https://github.com/pkplonker/Unity-Stuart-Heath-Custom-Tools.git");
    }

}

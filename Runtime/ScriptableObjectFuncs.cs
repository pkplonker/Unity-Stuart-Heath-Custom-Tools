#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ScriptableObjectFuncs : MonoBehaviour
{
	public static T[] GetAllInstances<T>() where T : ScriptableObject
	{
		var guids = AssetDatabase.FindAssets("t:" +
		                                     typeof(T).Name); //FindAssets uses tags check documentation for more info
		var a = new T[guids.Length];
		for (var i = 0; i < guids.Length; i++) //probably could get optimized 
		{
			var path = AssetDatabase.GUIDToAssetPath(guids[i]);
			a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
		}

		return a;
	}
}
#endif
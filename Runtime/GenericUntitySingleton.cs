using UnityEngine;

namespace StuartHeathTools
{
	/// <summary>
	///GenericUnitySingleton - Persistent singleton class for Unity.
	/// </summary>
	public class GenericUnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance = null;

		public static T Instance
		{
			get
			{
				if (instance != null) return instance;
				instance = GameObject.FindObjectOfType<T>();
				if (instance != null) return instance;
				var singletonObj = new GameObject();
				singletonObj.name = typeof(T).ToString();
				instance = singletonObj.AddComponent<T>();
				return instance;
			}
		}
		protected void Awake()
		{
			if (instance != null)
			{
				Destroy(gameObject);
				return;
			}
			instance = GetComponent<T>();
			DontDestroyOnLoad(gameObject);
		}
	}
}
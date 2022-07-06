//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using System;
using System.Globalization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StuartHeathTools
{
	/// <summary>
	/// Utility general purpose class
	/// </summary>
	public static class Utility
	{
		public static void Test()
		{
			Debug.Log("Test");
		}

		public static string WithColor(this string text, Color color) =>
			"<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";

		public static string FormatMoneyToKMB(this decimal num)
		{
			if (num > 999999999 || num < -999999999) return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
			if (num > 999999 || num < -999999) return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
			if (num > 999 || num < -999) return num.ToString("0,.#K", CultureInfo.InvariantCulture);
			return num.ToString(CultureInfo.InvariantCulture);
			
		}


		public static bool IsNumericType(this object o)
		{
			switch (Type.GetTypeCode(o.GetType()))
			{
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				default:
					return false;
			}
		}

		public static void DestroyChildren(this Transform t)
		{
			foreach (Transform c in t)
			{
				Object.Destroy(c.gameObject);
			}
		}

		public static void ResetTransform(this Transform t)
		{
			t.position = Vector3.zero;
			t.rotation = Quaternion.identity;
			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.zero;
		}

		public static T GetOrAddComponent<T>(this GameObject go) where T : Component
		{
			return go.TryGetComponent(out T component) ? component : go.AddComponent<T>();
		}

		public static void QuitApplication()
		{
			Debug.Log("Quitting");
			Application.Quit();
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}
	}
}
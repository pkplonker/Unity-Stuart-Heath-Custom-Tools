//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using System;
using UnityEngine;

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

		
		public static string FormatMoneyToKMB<T>(T amount)
		{
			if (!amount.IsNumericType()) return amount.ToString();
			dynamic x = amount;
			if (x >= 1000000000000) return $"{x / 1000000000000}T";
			if (x >= 1000000000) return $"{x / 1000000000}B";
			if (x >= 1000000) return $"{x / 1000000}M";
			if (x >= 1000) return $"{x / 1000}K";

			if (x <= -1000000000000) return $"{x / 1000000000000}T";
			if (x <= -1000000000) return $"{x / 1000000000}B";
			if (x <= -1000000) return $"{x / 1000000}M";
			return x <= -1000 ? $"{x / 1000}K" : (string) x.ToString();
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
	}
}
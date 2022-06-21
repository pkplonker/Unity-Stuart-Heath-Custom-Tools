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

		#region FormatMoneyToKMB

		public static string FormatMoneyToKMB(ulong amount)
		{
			if (amount >= 1000000000) return $"{amount / 1000000000}B";
			if (amount >= 1000000) return $"{amount / 1000000}M";
			if (amount >= 1000) return $"{amount / 1000}K";
			return amount.ToString();
		}

		public static string FormatMoneyToKMB(long amount)
		{
			if (amount >= 1000000000) return $"{amount / 1000000000}B";
			if (amount >= 1000000) return $"{amount / 1000000}M";
			if (amount >= 1000) return $"{amount / 1000}K";
			return amount.ToString();
		}

		public static string FormatMoneyToKMB(float amount)
		{
			if (amount >= 1000000000) return $"{amount / 1000000000}B";
			if (amount >= 1000000) return $"{amount / 1000000}M";
			if (amount >= 1000) return $"{amount / 1000}K";
			return amount.ToString();
		}

		public static string FormatMoneyToKMB(double amount)
		{
			if (amount >= 1000000000) return $"{amount / 1000000000}B";
			if (amount >= 1000000) return $"{amount / 1000000}M";
			if (amount >= 1000) return $"{amount / 1000}K";
			return amount.ToString();
		}

		#endregion

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
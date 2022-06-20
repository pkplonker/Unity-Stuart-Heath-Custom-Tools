//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//
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
		
		public static string WithColor(this string text, Color color) => "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
		
		public static string FormatMoneyToKMB(ulong amount)
		{
			if (amount >= 1000000000) return $"{amount / 1000000000}B";
			if (amount >= 1000000) return $"{amount / 1000000}M";
			if (amount >= 100000) return $"{amount / 100000}K";
			return amount.ToString();
		}
		
	}
}
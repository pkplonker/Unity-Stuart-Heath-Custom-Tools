//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using UnityEngine;

namespace StuartHeathTools
{
	/// <summary>
	/// Utility class for math.
	/// </summary>
	public static class UtilityMath
	{
		public static readonly float TAU = 6.283185307179586f;
		public static float DegToRad(float deg) => deg * (TAU / 360.0f);
		public static float RadToDeg(float rad) => rad * (360.0f / TAU);
		public static float ClampAngle(float angle, float min, float max) => Mathf.Clamp(angle, min, max);
		public static float Clamp0360(float eulerAngles)
		{
			float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
			if (result < 0)
			{
				result += 360f;
			}
			return result;
		}
		public static float ClampAngle360(float angle) => ClampAngle(angle, 0.0f, 360.0f);
		public static float ClampAngle180(float angle) => ClampAngle(angle, -180.0f, 180.0f);
		public static float ClampAngle90(float angle) => ClampAngle(angle, -90.0f, 90.0f);
		public static float ClampAngle45(float angle) => ClampAngle(angle, -45.0f, 45.0f);

		public static float GetAngleFromVector(Vector3 direction)
		{
			direction = direction.normalized;
			var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			if (angle < 0) angle += 360;
			return angle + 90;
		}

		public static float LinearRemap(this float value,
			float valueRangeMin, float valueRangeMax,
			float newRangeMin, float newRangeMax)
		{
			return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) +
			       newRangeMin;
		}

		public static Color Clamp(this Color value, Color min, Color max)
		{
			var r =Mathf.Clamp(value.r, min.r, max.r);
			var g =Mathf.Clamp(value.g, min.g, max.g);
			var b =Mathf.Clamp(value.b, min.b, max.b);
			return new Color(r,g,b);
		}
		public static Color Clamp(this Color value, float min, float max)=>Clamp(value, new Color(min, min, min), new Color(max, max, max));
		public static Color ClampWithAlpha(this Color value, Color min, Color max)
		{
			var r =Mathf.Clamp(value.r, min.r, max.r);
			var g =Mathf.Clamp(value.g, min.g, max.g);
			var b =Mathf.Clamp(value.b, min.b, max.b);
			var a =Mathf.Clamp(value.a, min.a, max.a);
			return new Color(r,g,b,a);
		}
		public static Color ClampWithAlpha(this Color value, float min, float max)=>Clamp(value, new Color(min, min, min,min), new Color(max, max, max,max));
	}
}
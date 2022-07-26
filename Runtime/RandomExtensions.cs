using UnityEngine;
using Random = System.Random;

public static class RandomExtensions
{
	public static float NextSingle(this Random random, float min = 0f, float max = 1f) =>
		Mathf.Lerp(min, max, (float) random.NextDouble());

	public static Vector2 NextOnUnitCircle(this Random random)
	{
		var angle = random.NextSingle(0, 360f) * Mathf.Deg2Rad;
		var x = Mathf.Cos(angle);
		var y = Mathf.Sin(angle);
		return new Vector2(x, y);
	}

	public static Vector3 NextOnUnitSphere(this Random random)
	{
		var angle = random.NextSingle(0, 360f) * Mathf.Deg2Rad;
		var z = random.NextSingle(-1f, 1f);
		var mp = Mathf.Sqrt(1 - z * z);
		var x = mp * Mathf.Cos(angle);
		var y = mp * Mathf.Sin(angle);
		return new Vector3(x, y, z);
	}

	public static Vector3 NextInsideUnitSphere(this Random random) => random.NextOnUnitSphere() * random.NextSingle();
	public static Vector2 NextInsideUnitCircle(this Random random) => random.NextOnUnitCircle() * random.NextSingle();

	public static Quaternion NextRotation(this Random random)
	{
		var x = random.NextSingle(0f, 360f);
		var y = random.NextSingle(0f, 360f);
		var z = random.NextSingle(0f, 360f);
		return Quaternion.Euler(x, y, z);
	}

	public static Quaternion NextRotationUniform(this Random random)
	{
		float normal, w, x, y, z;
		do
		{
			w = random.NextSingle(-1f, 1f);
			x = random.NextSingle(-1f, 1f);
			y = random.NextSingle(-1f, 1f);
			z = random.NextSingle(-1f, 1f);
			normal = w * w + x * x + y * y + z * z;
		} while (normal > 1f || normal == 0f);

		normal = Mathf.Sqrt(normal);
		return new Quaternion(x / normal, y / normal, z / normal, w / normal);
	}

	public static Color NextColorHsv(this Random random) => random.NextColorHsv(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);


	public static Color NextColorHsv(this Random random, float minHue, float maxHue) =>
		random.NextColorHsv(minHue, maxHue, 0f, 1f, 0f, 1f, 1f, 1f);


	public static Color NextColorHsv(
		this Random random,
		float minHue,
		float maxHue,
		float minSaturation,
		float maxSaturation)
	{
		return random.NextColorHsv(minHue, maxHue, minSaturation, maxSaturation, 0f, 1f, 1f, 1f);
	}
 
	public static Color NextColorHsv(
		this Random random,
		float minHue,
		float maxHue,
		float minSaturation,
		float maxSaturation,
		float minValue,
		float maxValue)
	{
		return random.NextColorHsv(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue, 1f, 1f);
	}

	public static Color NextColorHsv(
		this Random random,
		float minHue,
		float maxHue,
		float minSaturation,
		float maxSaturation,
		float minValue,
		float maxValue,
		float minAlpha,
		float maxAlpha)
	{
		var h = Mathf.Lerp(minHue, maxHue, random.NextSingle());
		var s = Mathf.Lerp(minSaturation, maxSaturation, random.NextSingle());
		var v = Mathf.Lerp(minValue, maxValue, random.NextSingle());
		var color = Color.HSVToRGB(h, s, v, true);
		color.a = Mathf.Lerp(minAlpha, maxAlpha, random.NextSingle());
		return color;
	}
}
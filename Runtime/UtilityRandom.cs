//
// Copyright (C) 2022 Stuart Heath. All rights reserved.
//

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StuartHeathTools
{
	/// <summary>
	/// Utility class for working with random variables.
	/// </summary>
	public static class UtilityRandom
	{
		private static System.Random prng = new System.Random();  

		public static int RandomSign() => Random.value < 0.5f ? 1 : -1;
		public static bool RandomBool() => Random.value < 0.5f;
		public static float RandomFloat01() => Random.value;
		public static int RandomInt(int min, int max) => Random.Range(min, max);
		public static float RandomRangeFloat(float min, float max) => Random.Range(min, max);
		public static int RandomRangeInt(int min, int max) => Random.Range(min, max);

		public static Vector2 RandomVector2(float min, float max) =>
			new Vector2(Random.Range(min, max), Random.Range(min, max));

		public static Vector3 RandomVector3(float min, float max) => new Vector3(Random.Range(min, max),
			Random.Range(min, max), Random.Range(min, max));

		public static T GetRandomFromList<T>(this IList<T> list) => list[Random.Range(0, list.Count)];
        
		//https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        public static void Shuffle<T>(this IList<T> list)  
        {  
            var n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = prng.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }  
        }
        public static void ShuffleWithPRNG<T>(this IList<T> list, System.Random prng)  
        {  
	        var n = list.Count;  
	        while (n > 1) {  
		        n--;  
		        var k = prng.Next(n + 1);  
		        (list[k], list[n]) = (list[n], list[k]);
	        }  
        }
	}
}
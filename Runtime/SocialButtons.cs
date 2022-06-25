using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialButtons : MonoBehaviour
{
	public static void Twitter()
	{
		Application.OpenURL("https://twitter.com/Pkplonker");
	}

	public static void Discord()
	{
		Application.OpenURL("https://discord.com/users/125658582879305728");
	}

	public static void LinkedIn()
	{
		Application.OpenURL("https://www.linkedin.com/in/stuartheath1");
	}

	public static void GitHub()
	{
		Application.OpenURL("https://github.com/pkplonker");
	}
}
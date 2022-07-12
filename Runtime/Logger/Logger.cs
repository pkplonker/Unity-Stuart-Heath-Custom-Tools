using UnityEngine;

public static class Logger
{
	private static LoggerOutput loggerOutput;
	public static void Register(LoggerOutput lo) => loggerOutput = lo;
	public static void Deregister() => loggerOutput = null;

	public static void LogWithColor(string message, Color color)
	{
		if (loggerOutput == null)
		{
			Debug.Log("Logger output not identified");
			return;
		}

		loggerOutput.LogWithColor(message,color);
	}

	public static void Log(string message)
	{
		Debug.Log(message);
		LogWithColor(message, Color.white);
	}

	public static void LogWarning(string message)
	{
		Debug.LogWarning(message);
		LogWithColor(message, Color.yellow);
	}

	public static void LogError(string message)
	{
		Debug.LogError(message);
		LogWithColor(message, Color.red);
	}
}
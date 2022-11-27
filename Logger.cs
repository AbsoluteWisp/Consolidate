namespace Consolidate;

public static class Logger {
	/// <summary>
	/// Prints a log message to the console.
	/// It is prepended with its log level and has a newline appended to it.
	/// It is colored according to its log level.
	/// </summary>
	/// <param name="message">The message to log</param>
	/// <param name="level">The log level to use</param>
	public static void Log(string message, LogLevel level) {
		ColourPrinter.WriteLine($"{levelPrefixDict[level]} {message}", levelColorDict[level]);
	}

	static Dictionary<LogLevel, ConsoleColor> levelColorDict = new () {
		{ LogLevel.debug, ConsoleColor.Magenta },
		{ LogLevel.info, ConsoleColor.Cyan },
		{ LogLevel.warning, ConsoleColor.Yellow },
		{ LogLevel.error, ConsoleColor.Red },
	};

	static Dictionary<LogLevel, string> levelPrefixDict = new () {
		{ LogLevel.debug,   "DEBUG   |" },
		{ LogLevel.info,    "INFO    |" },
		{ LogLevel.warning, "WARNING |" },
		{ LogLevel.error,   "ERROR   |" },
	};

	public enum LogLevel {
		debug,
		info,
		warning,
		error,
	}
}
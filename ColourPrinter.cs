namespace Consolidate;

public static class ColourPrinter {
	/// <summary>
	/// Prints a string of text in the specified color and appends a newline character to it.
	/// </summary>
	/// <param name="message">The message to display</param>
	/// <param name="color">The color to use</param>
	public static void WriteLine(string message, ConsoleColor color) {
		Write($"{message}\n", color);
	}

	/// <summary>
	/// Prints a string of text in the specified color.
	/// </summary>
	/// <param name="message">The message to display</param>
	/// <param name="color">The color to use</param>
	public static void Write(string message, ConsoleColor color) {
		var previousColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
		Console.Write(message);
		Console.ForegroundColor = previousColor;
	}
}
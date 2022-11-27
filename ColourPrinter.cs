namespace Consolidate;

public static class ColourPrinter {
	public static void WriteLine(string message, ConsoleColor color) {
		Write($"{message}\n", color);
	}

	public static void Write(string message, ConsoleColor color) {
		var previousColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
		Console.Write(message);
		Console.ForegroundColor = previousColor;
	}
}
namespace Consolidate;

public static class Arguments {
	/// <summary>
	/// Parses an argument array to generate a Dictionary of keyword arguments
	/// </summary>
	/// <param name="args">The array of arguments to parse</param>
	/// <param name="keyPrefix">(Optional) The prefix that argument names start with</param>
	/// <returns>The Dictionary of keyword arguments</returns>
	public static Dictionary<string, string> GenerateKeywordArgs(string[] args, string keyPrefix = "--") {
		Dictionary<string, string> kwargs = new ();

		for (int i = 0; i < args.Length; i++) {
			var arg = args[i];

			// This is a key
			if (arg.StartsWith(keyPrefix)) {
				// This is the last argument. It must be a switch. 
				if (i == args.Length - 1) {
					RegisterArgument(arg[keyPrefix.Length..], "true", ref kwargs);
				}
				// Not the last argument; forward-look is safe.
				else {
					// The next argument is also a key, so this key has no value (it's a switch)
					if (args[i + 1].StartsWith(keyPrefix)) {
						RegisterArgument(arg[keyPrefix.Length..], "true", ref kwargs);
					}
					// The next argument is a value for this key
					else {
						RegisterArgument(arg[keyPrefix.Length..], args[i + 1], ref kwargs);
					}
				}
			}
		}

		return kwargs;
	}

	private static void RegisterArgument(string key, string value, ref Dictionary<string, string> kwargs) {
		if (!kwargs.ContainsKey(key)) {
			kwargs[key] = value;
		}
	}
}
using BachLib.Logging.Enums;

namespace BachLib.Logging
{
	public static class Logger
	{
		public static LogLevel Level { get; set; } = LogLevel.Info;

		public static bool ShowPrefix { get; set; } = true;

		/// <summary>
		///     Show the date and time in the log.
		/// </summary>
		/// <remarks>
		///     Ignored if <see cref="ShowPrefix" /> is false.
		/// </remarks>
		public static bool ShowDateTime { get; set; } = true;

		/// <summary>
		///    Show the log level in the log.
		/// </summary>
		/// <remarks>
		///    Ignored if <see cref="ShowPrefix" /> is false.
		/// </remarks>
		public static bool ShowLevel { get; set; } = true;

		private static readonly Dictionary<LogLevel, ConsoleColor> _colors = new()
		{
			{ LogLevel.Trace, ConsoleColor.Gray },
			{ LogLevel.Debug, ConsoleColor.DarkGray },
			{ LogLevel.Info, ConsoleColor.Blue },
			{ LogLevel.Warn, ConsoleColor.Yellow },
			{ LogLevel.Error, ConsoleColor.Red },
			{ LogLevel.Fatal, ConsoleColor.DarkRed }
		};

		public static void Log(string value, LogLevel level = LogLevel.Info)
		{
			if (level < Level)
				return;

			// Print newlines before the prefix
			if (value.StartsWith('\n'))
			{
				foreach (char c in value.TakeWhile(c => c == '\n'))
				{
					Console.WriteLine();
					value = value[1..];
				}
			}

			LogPrefix();
			Console.WriteLine(value);
		}

		private static void LogPrefix()
		{
			if (!ShowPrefix)
				return;

			Console.ForegroundColor = _colors[Level];

			if (ShowDateTime)
				Console.Write($"[{DateTime.Now:HH:mm:ss}] ");
			if (ShowLevel)
				Console.Write($"[{Level}] ");

			Console.ResetColor();
		}
	}
}
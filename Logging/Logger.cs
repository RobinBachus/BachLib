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

		public static TextWriter Out { get; set; } = Console.Out;

		private static readonly Dictionary<LogLevel, ConsoleColor> COLORS = new()
		{
			{ LogLevel.Trace, ConsoleColor.DarkGray },
			{ LogLevel.Debug, ConsoleColor.Magenta },
			{ LogLevel.Info, ConsoleColor.Blue },
			{ LogLevel.Warn, ConsoleColor.DarkYellow },
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
				foreach (char _ in value.TakeWhile(c => c == '\n'))
				{
					Out.WriteLine();
					value = value[1..];
				}
			}

			LogPrefix(level);
			Out.WriteLine(value);
		}

		private static void LogPrefix(LogLevel level)
		{
			if (!ShowPrefix)
				return;

			Console.ForegroundColor = COLORS[level];

			if (ShowDateTime)
				Out.Write($"[{DateTime.Now:HH:mm:ss}] ");
			if (ShowLevel)
				Out.Write($"[{level}] ");

			Console.ResetColor();
		}
	}
}
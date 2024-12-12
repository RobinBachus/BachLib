using BachLib.Logging.Enums;

namespace BachLib.Logging
{
	public static class Logger
	{
		/// <summary>
		///     Only log messages with a log level equal to or higher than this level.
		/// </summary>
		public static LogLevel Level { get; set; } = LogLevel.Info;

		/// <summary>
		///     Show the prefix in the log.
		/// </summary>
		public static bool ShowPrefix { get; set; } = true;

		/// <summary>
		///     Show the date and time in the log.
		/// </summary>
		/// <remarks>
		///     Ignored if <see cref="ShowPrefix" /> is false.
		/// </remarks>
		public static bool ShowDateTime { get; set; } = true;

		/// <summary>
		///     Show the log level in the log.
		/// </summary>
		/// <remarks>
		///     Ignored if <see cref="ShowPrefix" /> is false.
		/// </remarks>
		public static bool ShowLevel { get; set; } = true;

		/// <summary>
		///    Throw error logs as exceptions.
		/// </summary>
		public static bool ThrowErrorLogs { get; set; }

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

		/// <summary>
		///     Log a message with the specified log level.
		/// </summary>
		/// <param name="value">The message to log.</param>
		/// <param name="level">The log level of the message.</param>
		/// <param name="force">Force the message to be logged, even if the log level is lower than the specified level.</param>
		/// <remarks>
		///     If the log level is set to <see cref="LogLevel.None" />, the message will not be printed.
		///     To suppress the warning, use <paramref name="force" />.
		/// </remarks>
		public static void Log(string value, LogLevel level = LogLevel.Info, bool force = false)
		{
			switch (force)
			{
				case false when level == LogLevel.None:
				case false when level < Level:
					return;
			}

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
			if (ThrowErrorLogs && level == LogLevel.Error)
				throw new Exception(value);
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
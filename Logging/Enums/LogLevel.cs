namespace BachLib.Logging.Enums
{
	/// <summary>
	///     The log level of a log message. A higher log level means more important.
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		///     Most verbose log level.
		/// </summary>
		Trace,
		Debug,

		/// <summary>
		///     Default log level.
		/// </summary>
		Info,
		Warn,
		Error,
		Fatal,

		/// <summary>
		///     Do not log any messages.
		///     <para>
		///         Should not be used as a log level for a message.
		///     </para>
		/// </summary>
		None
	}
}
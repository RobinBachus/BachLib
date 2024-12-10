using System.Text;

namespace BachLib.Logging
{
	public class LoggerTextWriter(Encoding encoding) : TextWriter
	{
		public override Encoding Encoding { get; } = encoding;

		public LoggerTextWriter(): this(Console.OutputEncoding)
		{
		}

		public override void Write(char value)
		{
			Logger.Log(value.ToString());
		}

		public override void Write(string? value)
		{
			Logger.Log(value ?? string.Empty);
		}

		public override void Write(object? value)
		{
			Logger.Log($"{value}");
		}

		public override void WriteLine()
		{
			Logger.Log(string.Empty);
		}

		public override void WriteLine(char value)
		{
			Logger.Log(value.ToString());
		}

		public override void WriteLine(string? value)
		{
			Logger.Log(value ?? string.Empty);
		}

		public override void WriteLine(object? value)
		{
			Logger.Log($"{value}");
		}

		public override void WriteLine(char[]? buffer)
		{
			Logger.Log(new string(buffer));
		}

		public override void WriteLine(char[] buffer, int index, int count)
		{
			Logger.Log(new string(buffer, index, count));
		}
	}
}
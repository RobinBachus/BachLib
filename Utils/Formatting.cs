namespace BachLib.Utils
{
	public static class Formatting
	{
		public static string DataSizeToHumanReadable(long dataSize)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (dataSize >= 1024 && order < sizes.Length - 1)
			{
				order++;
				dataSize /= 1024;
			}
			return $"{dataSize:0.##} {sizes[order]}";
		}
	}
}

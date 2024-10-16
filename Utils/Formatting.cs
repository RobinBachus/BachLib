namespace BachLib.Utils
{
	public static class Formatting
	{
		public static string DataSizeToHumanReadable(long dataSize)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			long len = dataSize;
			int order = 0;
			while (len >= 1024 && order < sizes.Length - 1)
			{
				order++;
				len /= 1024;
			}
			return $"{len:0.##} {sizes[order]}";
		}
	}
}

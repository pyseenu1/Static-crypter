using System.IO;

namespace StaticCrypt4.Utilies
{
	public static class FileUtils
	{
		public static string StaticPath = Path.GetTempPath() + "StaticCrypt";

		public static bool CheckPath()
		{
			if (!Directory.Exists(StaticPath))
			{
				try
				{
					Directory.CreateDirectory(StaticPath);
					return true;
				}
				catch
				{
					return false;
				}
			}
			return true;
		}

		public static void ClearDir(string dir)
		{
			string[] files = Directory.GetFiles(dir);
			foreach (string path in files)
			{
				try
				{
					File.Delete(path);
				}
				catch
				{
				}
			}
		}

		public static long FileLenght(string filename)
		{
			return new FileInfo(filename).Length / 1000;
		}
	}
}

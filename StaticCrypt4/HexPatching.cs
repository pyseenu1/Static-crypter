using System;
using System.IO;
using System.Text;

namespace StaticCrypt4
{
	public static class HexPatching
	{
		public static bool AdressPatch(string PEpath, int adress, string Newbyte)
		{
			bool flag = false;
			try
			{
				string hex = ByteArrayToString(File.ReadAllBytes(PEpath)).Remove(adress * 2, Newbyte.Length).Insert(adress * 2, Newbyte);
				File.WriteAllBytes(PEpath, StringToByteArray(hex));
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool SequencePatch(string PEpath, string seq, string Newbyte)
		{
			string text = ByteArrayToString(File.ReadAllBytes(PEpath));
			if (seq.Length == Newbyte.Length)
			{
				bool flag = false;
				try
				{
					text = text.Replace(seq.ToLower(), Newbyte);
					File.WriteAllBytes(PEpath, StringToByteArray(text));
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}

		private static string ByteArrayToString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			byte b = 0;
			foreach (byte bb in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", bb);
			}
			return stringBuilder.ToString();
		}

		private static byte[] StringToByteArray(string hex)
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2 - 1 + 1];
			int num = length - 1;
			for (int i = 0; i <= num; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}
	}
}

using System.Text;

namespace StaticCrypt4
{
	public static class Helpers
	{
		public static int TabNumber = 0;

		public static bool EndOfTabs = false;

		public static string ExceptionCode = string.Empty;

		public static byte[] XorEnc(byte[] Data, string Key)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Key);
			for (int i = 0; i < Data.Length; i++)
			{
				Data[i] ^= bytes[i % Key.Length];
			}
			return Data;
		}

		public static byte[] Proper_RC4(byte[] Input, byte[] Key)
		{
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 0u;
			uint[] array = new uint[256];
			byte[] array2 = new byte[Input.Length];
			for (num = 0u; num <= 255; num++)
			{
				array[num] = num;
			}
			for (num = 0u; num <= 255; num++)
			{
				num2 = (num2 + Key[(long)num % (long)Key.Length] + array[num] & 0xFF);
				num3 = array[num];
				array[num] = array[num2];
				array[num2] = num3;
			}
			num = 0u;
			num2 = 0u;
			for (int i = 0; i <= array2.Length - 1; i++)
			{
				num = (num + 1 & 0xFF);
				num2 = (num2 + array[num] & 0xFF);
				num3 = array[num];
				array[num] = array[num2];
				array[num2] = num3;
				array2[i] = (byte)(Input[i] ^ array[array[num] + array[num2] & 0xFF]);
			}
			return array2;
		}
	}
}

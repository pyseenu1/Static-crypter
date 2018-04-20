using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Licence
{
	internal class Licence
	{
		private class ClsComputerInfo
		{
			internal string GetProcessorId()
			{
				string result = string.Empty;
				foreach (ManagementObject item in new ManagementObjectSearcher(new SelectQuery("Win32_processor")).Get())
				{
					result = ((ManagementBaseObject)item)["processorId"].ToString();
				}
				return result;
			}

			internal string GetMACAddress()
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
				string text = string.Empty;
				foreach (ManagementObject item in instances)
				{
					if (text.Equals(string.Empty))
					{
						if (Convert.ToBoolean(((ManagementBaseObject)item)["IPEnabled"]))
						{
							text = ((ManagementBaseObject)item)["MacAddress"].ToString();
						}
						item.Dispose();
					}
					text = text.Replace(":", string.Empty);
				}
				return text;
			}

			internal string GetVolumeSerial(string strDriveLetter = "C")
			{
				ManagementObject managementObject = new ManagementObject($"win32_logicaldisk.deviceid=\"{strDriveLetter}:\"");
				managementObject.Get();
				return ((ManagementBaseObject)managementObject)["VolumeSerialNumber"].ToString();
			}

			internal string GetMotherBoardID()
			{
				string result = string.Empty;
				foreach (ManagementObject item in new ManagementObjectSearcher(new SelectQuery("Win32_BaseBoard")).Get())
				{
					result = ((ManagementBaseObject)item)["product"].ToString();
				}
				return result;
			}

			internal string getMD5Hash(string strToHash)
			{
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] bytes = Encoding.ASCII.GetBytes(strToHash);
				bytes = mD5CryptoServiceProvider.ComputeHash(bytes);
				string text = "";
				byte[] array = bytes;
				for (int i = 0; i < array.Length; i++)
				{
					byte b = array[i];
					text += b.ToString("x2");
				}
				return text;
			}
		}

		[Flags]
		public enum ProcessAccessFlags : uint
		{
			All = 0x1F0FFF,
			Terminate = 0x1,
			CreateThread = 0x2,
			VirtualMemoryOperation = 0x8,
			VirtualMemoryRead = 0x10,
			VirtualMemoryWrite = 0x20,
			DuplicateHandle = 0x40,
			CreateProcess = 0x80,
			SetQuota = 0x100,
			SetInformation = 0x200,
			QueryInformation = 0x400,
			QueryLimitedInformation = 0x1000,
			Synchronize = 0x100000
		}

		public enum ProcessAccess
		{
			CreateThread = 2,
			SetSessionId = 4,
			VmOperation = 8,
			VmRead = 0x10,
			VmWrite = 0x20,
			DupHandle = 0x40,
			CreateProcess = 0x80,
			SetQuota = 0x100,
			SetInformation = 0x200,
			QueryInformation = 0x400,
			SuspendResume = 0x800,
			QueryLimitedInformation = 0x1000,
			Synchronize = 0x100000,
			Delete = 0x10000,
			ReadControl = 0x20000,
			WriteDac = 0x40000,
			WriteOwner = 0x80000,
			StandardRightsRequired = 983040,
			AllAccess = 0x1FFFFF
		}

		private WebClient _WebClient = new WebClient();

		private static MD5CryptoServiceProvider _MD5 = new MD5CryptoServiceProvider();

		private static string _Url = "http://staticsoftwares.pro/StaticCrypt4/KxoEoxee929";

		private static Thread thread1 = new Thread(processget1);

		public string Hwid
		{
			get;
			set;
		}

		private string _UserName
		{
			get;
			set;
		}

		private string _Password
		{
			get;
			set;
		}

		private static string _Key
		{
			get;
			set;
		}

		private static bool _Cracked
		{
			get;
			set;
		}

		public Licence()
		{
			ClsComputerInfo clsComputerInfo = new ClsComputerInfo();
			string volumeSerial = clsComputerInfo.GetVolumeSerial("C");
			string processorId = clsComputerInfo.GetProcessorId();
			string motherBoardID = clsComputerInfo.GetMotherBoardID();
			string mACAddress = clsComputerInfo.GetMACAddress();
			string s = processorId + volumeSerial + motherBoardID + mACAddress;
			string text2 = Hwid = BitConverter.ToString(_MD5.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "");
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					UseShellExecute = true,
					WorkingDirectory = Environment.CurrentDirectory,
					FileName = Application.ExecutablePath,
					Verb = "runas"
				};
				Application.ExitThread();
				try
				{
					Process.Start(startInfo);
				}
				catch
				{
					Process.GetCurrentProcess().Kill();
				}
				Process.GetCurrentProcess().Kill();
			}
			thread1.IsBackground = true;
			thread1.Start();
			_UserName = "";
			_Password = "";
			_Key = _UserName + _Password + Hwid;
		}

		public bool Cracked()
		{
			return _Cracked;
		}

		public string[] Login(string UserName, string Password)
		{
			_UserName = UserName;
			_Password = Password;
			_Key = UserName + Password + Hwid;
			return Decrypt(Encoding.UTF8.GetString(_WebClient.UploadValues(_Url + "/authenticate", new NameValueCollection
			{
				{
					"username",
					UserName
				},
				{
					"password",
					Password
				},
				{
					"hwid",
					Hwid
				}
			})).Replace("\ufeff", "")).Split(',');
		}

		public string Redeem(string Code)
		{
			_Key = _UserName + _Password + Code;
			return Decrypt(Encoding.UTF8.GetString(_WebClient.UploadValues(_Url + "/redeem", new NameValueCollection
			{
				{
					"username",
					_UserName
				},
				{
					"password",
					_Password
				},
				{
					"code",
					Code
				}
			})).Replace("\ufeff", ""));
		}

		public string Register(string UserName, string Password)
		{
			_Key = UserName + Password + Hwid;
			return Decrypt(Encoding.UTF8.GetString(_WebClient.UploadValues(_Url + "/register", new NameValueCollection
			{
				{
					"username",
					UserName
				},
				{
					"password",
					Password
				},
				{
					"hwid",
					Hwid
				}
			})).Replace("\ufeff", ""));
		}

		public string Variable(string Key)
		{
			_Key = _UserName + _Password + Key;
			return Decrypt(Encoding.UTF8.GetString(_WebClient.UploadValues(_Url + "/variable", new NameValueCollection
			{
				{
					"username",
					_UserName
				},
				{
					"password",
					_Password
				},
				{
					"variable",
					Key
				}
			})).Replace("\ufeff", "")).Split(',')[1];
		}

		public string Md5(string Texte)
		{
			return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(_Key + Texte))).ToLower().Replace("-", "");
		}

		private static string Decrypt(string stringv1)
		{
			try
			{
				byte[] array = Convert.FromBase64String(stringv1);
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(_Key));
				mD5CryptoServiceProvider.Clear();
				TripleDESCryptoServiceProvider obj = new TripleDESCryptoServiceProvider
				{
					Key = key,
					Mode = CipherMode.ECB,
					Padding = PaddingMode.PKCS7
				};
				byte[] bytes = obj.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
				obj.Clear();
				return Encoding.UTF8.GetString(bytes);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		private static void function1()
		{
			_Cracked = true;
			Process.GetCurrentProcess().Kill();
		}

		private static void processget1()
		{
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] int dwFlags, [Out] StringBuilder lpExeName, ref int lpdwSize);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr OpenProcess(ProcessAccess desiredAccess, bool inheritHandle, int processId);
	}
}

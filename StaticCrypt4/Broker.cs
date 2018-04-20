using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StaticCrypt4
{
	internal sealed class Broker
	{
		public delegate void LicenseSuspendedEventHandler(object sender, EventArgs e);

		public delegate void LicenseAuthorizedEventHandler(object sender, EventArgs e);

		public delegate void LicenseRefreshedEventHandler(object sender, EventArgs e);

		private delegate void CallbackDelegate();

		private delegate string GetPostBodyDelegate(int postId);

		private sealed class ThreadCulture
		{
			private CultureInfo _Culture;

			private CultureInfo _UICulture;

			public CultureInfo Culture => _Culture;

			public CultureInfo UICulture => _UICulture;

			public ThreadCulture(CultureInfo culture, CultureInfo uiCulture)
			{
				_Culture = culture;
				_UICulture = uiCulture;
			}
		}

		private sealed class StrongNameVerifierLite
		{
			[Guid("D332DB9E-B9B3-4125-8207-A14884F53216")]
			[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			private interface IMeta
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				object GetRuntime(string version, [MarshalAs(UnmanagedType.LPStruct)] Guid iid);
			}

			[Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
			[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			private interface IRuntime
			{
				void Reserved1();

				void Reserved2();

				void Reserved3();

				void Reserved4();

				void Reserved5();

				void Reserved6();

				[return: MarshalAs(UnmanagedType.Interface)]
				object GetInterface([MarshalAs(UnmanagedType.LPStruct)] Guid cid, [MarshalAs(UnmanagedType.LPStruct)] Guid iid);
			}

			[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			[Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")]
			private interface IStrongName
			{
				void Reserved1();

				void Reserved2();

				void Reserved3();

				void Reserved4();

				void Reserved5();

				void Reserved6();

				void Reserved7();

				int StrongNameFreeBuffer(IntPtr token);

				void Reserved8();

				void Reserved9();

				void Reserved10();

				void Reserved11();

				void Reserved12();

				void Reserved13();

				void Reserved14();

				void Reserved15();

				void Reserved16();

				void Reserved17();

				void Reserved18();

				void Reserved19();

				int StrongNameSignatureVerificationEx(string filePath, bool force, ref bool genuine);

				void Reserved20();

				int StrongNameTokenFromAssembly(string filePath, ref IntPtr token, ref int tokenLength);
			}

			private string _RuntimeVersion;

			private IStrongName _StrongName;

			private bool _UsingComInterfaces;

			public StrongNameVerifierLite()
			{
				_RuntimeVersion = RuntimeEnvironment.GetSystemVersion();
				if (int.Parse(_RuntimeVersion[1].ToString()) >= 4)
				{
					_UsingComInterfaces = true;
					InitializeComInterfaces();
				}
			}

			private void InitializeComInterfaces()
			{
				Guid cid = new Guid("9280188D-0E8E-4867-B30C-7FA83884E8DE");
				Guid cid2 = new Guid("B79B0ACD-F5CD-409B-B5A5-A16244610B92");
				IRuntime runtime = (IRuntime)((IMeta)CLRCreateInstance(cid, typeof(IMeta).GUID)).GetRuntime(_RuntimeVersion, typeof(IRuntime).GUID);
				_StrongName = (IStrongName)runtime.GetInterface(cid2, typeof(IStrongName).GUID);
			}

			public bool VerifyStrongName(string assemblyPath, byte[] publicToken)
			{
				return VerifyStrongName(assemblyPath, publicToken, false);
			}

			public bool VerifyStrongName(string assemblyPath, byte[] publicToken, bool ignoreToken)
			{
				IntPtr intPtr = default(IntPtr);
				int num = 0;
				bool flag = false;
				if (_UsingComInterfaces)
				{
					if (!(_StrongName.StrongNameSignatureVerificationEx(assemblyPath, true, ref flag) == 0 & flag))
					{
						return false;
					}
					if (!ignoreToken && _StrongName.StrongNameTokenFromAssembly(assemblyPath, ref intPtr, ref num) != 0)
					{
						return false;
					}
				}
				else
				{
					if (!(StrongNameSignatureVerificationEx(assemblyPath, true, ref flag) & flag))
					{
						return false;
					}
					if (!ignoreToken && !StrongNameTokenFromAssembly(assemblyPath, ref intPtr, ref num))
					{
						return false;
					}
				}
				if (!ignoreToken)
				{
					byte[] array = new byte[num];
					Marshal.Copy(intPtr, array, 0, num);
					if (_UsingComInterfaces)
					{
						_StrongName.StrongNameFreeBuffer(intPtr);
					}
					else
					{
						StrongNameFreeBuffer(intPtr);
					}
					if (array.Length != publicToken.Length)
					{
						return false;
					}
					for (int i = 0; i <= array.Length - 1; i++)
					{
						if (array[i] != publicToken[i])
						{
							return false;
						}
					}
				}
				return true;
			}

			[DllImport("mscoree.dll")]
			private static extern void StrongNameFreeBuffer(IntPtr token);

			[DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
			private static extern bool StrongNameSignatureVerificationEx(string fileName, bool force, ref bool genuine);

			[DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
			private static extern bool StrongNameTokenFromAssembly(string fileName, ref IntPtr token, ref int tokenLength);

			[DllImport("mscoree.dll", PreserveSig = false)]
			[return: MarshalAs(UnmanagedType.Interface)]
			private static extern object CLRCreateInstance([MarshalAs(UnmanagedType.LPStruct)] Guid cid, [MarshalAs(UnmanagedType.LPStruct)] Guid iid);
		}

		private sealed class ExceptionForm : Form
		{
			public ExceptionForm(string stackTrace)
			{
				base.SuspendLayout();
				PictureBox value = new PictureBox
				{
					Location = new Point(12, 9),
					Size = new Size(32, 32),
					TabStop = false,
					Image = SystemIcons.Error.ToBitmap()
				};
				Label value2 = new Label
				{
					Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
					AutoEllipsis = true,
					Font = new Font("Verdana", 8.25f),
					Location = new Point(50, 9),
					Size = new Size(367, 32),
					Text = "The application has encountered an unexpected exception and must terminate.",
					TextAlign = ContentAlignment.MiddleLeft
				};
				TextBox value3 = new TextBox
				{
					Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
					BackColor = SystemColors.Window,
					Font = new Font("Verdana", 8.25f),
					Location = new Point(12, 47),
					Multiline = true,
					ReadOnly = true,
					ScrollBars = ScrollBars.Vertical,
					Size = new Size(405, 183),
					Text = stackTrace
				};
				Button value4 = new Button
				{
					Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
					DialogResult = DialogResult.Cancel,
					Font = new Font("Verdana", 8.25f),
					Location = new Point(312, 236),
					Size = new Size(105, 26),
					TabIndex = 0,
					Text = "Close",
					UseVisualStyleBackColor = true
				};
				Text = "Application Error";
				base.ClientSize = new Size(430, 270);
				MinimumSize = new Size(360, 245);
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				base.ShowIcon = false;
				base.Controls.Add(value);
				base.Controls.Add(value2);
				base.Controls.Add(value3);
				base.Controls.Add(value4);
				base.ResumeLayout(false);
				base.PerformLayout();
			}
		}

		private Version _Version;

		private Type _LzmaLibType;

		private object _Authenticator;

		private Type _AuthenticatorType;

		private HttpClient _HttpClient;

		private DnsClient _DnsClient;

		private StrongNameVerifierLite _StrongNameVerifier;

		private string _PreferredMetadataEndPoint;

		private string _AlternateMetadataEndPoint;

		private ICryptoTransform _ComponentAesEncryptor;

		private ICryptoTransform _ComponentAesDecryptor;

		private byte[] _ComponentKey;

		private byte[] _AuthenticatorKey;

		private string _ServerEndPoint;

		private string _ComponentEndPoint;

		private string _LzmaLibHash;

		private string _AuthenticatorHash;

		private byte[] _LzmaLibData;

		private byte[] _AuthenticatorData;

		private string _ProductDirectory;

		public IPAddress IPAddress
		{
			get
			{
				EnsureInitialization();
				return (IPAddress)_AuthenticatorType.GetMethod("GetIPAddress").Invoke(_Authenticator, null);
			}
		}

		public string UserName
		{
			get
			{
				EnsureInitialization();
				return (string)_AuthenticatorType.GetMethod("GetUserName").Invoke(_Authenticator, null);
			}
		}

		public DateTime ExpirationDate
		{
			get
			{
				EnsureInitialization();
				return (DateTime)_AuthenticatorType.GetMethod("GetExpirationDate").Invoke(_Authenticator, null);
			}
		}

		public TimeSpan TimeRemaining
		{
			get
			{
				EnsureInitialization();
				return (TimeSpan)_AuthenticatorType.GetMethod("GetTimeRemaining").Invoke(_Authenticator, null);
			}
		}

		public LicenseType LicenseType
		{
			get
			{
				EnsureInitialization();
				return (LicenseType)_AuthenticatorType.GetMethod("GetLicenseType").Invoke(_Authenticator, null);
			}
		}

		public bool LicenseExpires
		{
			get
			{
				EnsureInitialization();
				return (bool)_AuthenticatorType.GetMethod("GetLicenseExpires").Invoke(_Authenticator, null);
			}
		}

		public string MachineId
		{
			get
			{
				EnsureInitialization();
				return (string)_AuthenticatorType.GetMethod("GetMachineId").Invoke(_Authenticator, null);
			}
		}

		public event LicenseSuspendedEventHandler LicenseSuspended;

		public event LicenseAuthorizedEventHandler LicenseAuthorized;

		public event LicenseRefreshedEventHandler LicenseRefreshed;

		public string GetPublicToken()
		{
			EnsureInitialization();
			return (string)_AuthenticatorType.GetMethod("GetPublicToken").Invoke(_Authenticator, null);
		}

		public byte[] GetPrivateKey()
		{
			EnsureInitialization();
			return (byte[])_AuthenticatorType.GetMethod("GetPrivateKey").Invoke(_Authenticator, null);
		}

		public int GetUsersOnline()
		{
			EnsureInitialization();
			return (int)_AuthenticatorType.GetMethod("GetUsersOnline").Invoke(_Authenticator, null);
		}

		public bool GetUpdatesAvailable()
		{
			EnsureInitialization();
			return (bool)_AuthenticatorType.GetMethod("GetUpdatesAvailable").Invoke(_Authenticator, null);
		}

		public BlogPost[] GetBlogPosts()
		{
			EnsureInitialization();
			List<BlogPost> list = new List<BlogPost>();
			object[] array = (object[])_AuthenticatorType.GetMethod("GetBlogPosts").Invoke(_Authenticator, null);
			for (int i = 0; i <= array.Length - 1; i += 4)
			{
				int id = (int)array[i];
				string title = (string)array[i + 1];
				int timesRead = (int)array[i + 2];
				DateTime datePosted = (DateTime)array[i + 3];
				BlogPost item = new BlogPost(id, title, timesRead, datePosted, new GetPostBodyDelegate(GetPostBody));
				list.Add(item);
			}
			return list.ToArray();
		}

		public string GetSetting(string name)
		{
			EnsureInitialization();
			return (string)_AuthenticatorType.GetMethod("GetSetting").Invoke(_Authenticator, new object[1]
			{
				name
			});
		}

		public void InstallUpdates()
		{
			EnsureInitialization();
			_AuthenticatorType.GetMethod("InstallUpdates").Invoke(_Authenticator, null);
		}

		public void SuspendUser(string reason)
		{
			EnsureInitialization();
			_AuthenticatorType.GetMethod("SuspendUser").Invoke(_Authenticator, new object[1]
			{
				reason
			});
		}

		private void HttpClient_WebRequestResolveHost(object sender, HttpClient.WebRequestResolveHostEventArgs e)
		{
			try
			{
				IPAddress[] array = null;
				lock (_DnsClient)
				{
					array = _DnsClient.Resolve(e.HostName);
				}
				if (array.Length != 0)
				{
					e.Address = array[0];
				}
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		public Broker()
		{
			_Version = new Version(2, 1, 1, 1);
			_PreferredMetadataEndPoint = "http://seal.nimoru.com/Base/checksumSE.php";
			_AlternateMetadataEndPoint = "https://s3-us-west-2.amazonaws.com/netseal/checksumSE.txt";
			_ComponentKey = new byte[16]
			{
				65,
				118,
				65,
				114,
				101,
				79,
				118,
				101,
				114,
				122,
				101,
				97,
				108,
				111,
				117,
				115
			};
			_AuthenticatorKey = new byte[444]
			{
				6,
				2,
				0,
				0,
				0,
				34,
				0,
				0,
				68,
				83,
				83,
				49,
				0,
				4,
				0,
				0,
				165,
				101,
				186,
				183,
				89,
				49,
				161,
				242,
				152,
				217,
				52,
				227,
				36,
				114,
				221,
				81,
				163,
				208,
				24,
				95,
				234,
				1,
				136,
				6,
				193,
				171,
				215,
				57,
				56,
				216,
				186,
				221,
				159,
				6,
				11,
				126,
				249,
				251,
				48,
				16,
				34,
				98,
				128,
				135,
				217,
				192,
				244,
				236,
				207,
				199,
				184,
				206,
				141,
				91,
				85,
				170,
				37,
				5,
				69,
				218,
				137,
				176,
				31,
				148,
				182,
				215,
				92,
				31,
				188,
				16,
				174,
				181,
				79,
				118,
				71,
				21,
				229,
				118,
				103,
				239,
				119,
				78,
				165,
				241,
				228,
				42,
				154,
				154,
				115,
				181,
				130,
				43,
				93,
				220,
				102,
				91,
				64,
				81,
				150,
				139,
				1,
				40,
				243,
				57,
				154,
				206,
				152,
				93,
				153,
				232,
				48,
				171,
				30,
				2,
				138,
				153,
				232,
				8,
				243,
				107,
				197,
				61,
				64,
				34,
				76,
				145,
				33,
				210,
				71,
				227,
				182,
				220,
				74,
				6,
				143,
				213,
				126,
				239,
				28,
				36,
				10,
				134,
				7,
				146,
				81,
				109,
				44,
				156,
				196,
				68,
				30,
				178,
				252,
				53,
				181,
				4,
				32,
				135,
				132,
				182,
				229,
				206,
				145,
				115,
				250,
				104,
				109,
				212,
				32,
				250,
				196,
				8,
				182,
				64,
				19,
				88,
				238,
				246,
				92,
				89,
				214,
				234,
				163,
				230,
				75,
				79,
				140,
				187,
				179,
				15,
				35,
				83,
				173,
				101,
				137,
				128,
				110,
				100,
				176,
				63,
				183,
				238,
				138,
				30,
				26,
				8,
				193,
				159,
				141,
				32,
				74,
				236,
				8,
				117,
				185,
				68,
				63,
				101,
				159,
				149,
				105,
				48,
				46,
				186,
				192,
				16,
				156,
				99,
				159,
				120,
				101,
				50,
				12,
				106,
				114,
				46,
				190,
				106,
				112,
				225,
				228,
				26,
				81,
				118,
				79,
				160,
				202,
				32,
				127,
				111,
				96,
				38,
				2,
				82,
				162,
				86,
				131,
				131,
				152,
				143,
				213,
				112,
				234,
				204,
				228,
				207,
				187,
				212,
				93,
				176,
				119,
				183,
				71,
				86,
				90,
				54,
				9,
				107,
				47,
				78,
				115,
				161,
				51,
				61,
				225,
				153,
				37,
				228,
				164,
				254,
				108,
				240,
				20,
				11,
				223,
				100,
				26,
				177,
				3,
				152,
				216,
				169,
				123,
				171,
				99,
				240,
				92,
				40,
				57,
				51,
				77,
				105,
				54,
				142,
				189,
				102,
				101,
				93,
				59,
				64,
				125,
				172,
				106,
				25,
				94,
				59,
				159,
				18,
				159,
				105,
				184,
				49,
				18,
				93,
				60,
				159,
				71,
				55,
				60,
				18,
				68,
				141,
				70,
				115,
				39,
				135,
				33,
				193,
				13,
				132,
				199,
				96,
				57,
				185,
				128,
				96,
				70,
				233,
				28,
				152,
				169,
				145,
				153,
				220,
				8,
				166,
				17,
				234,
				208,
				140,
				29,
				163,
				20,
				181,
				251,
				161,
				210,
				193,
				124,
				96,
				213,
				221,
				196,
				16,
				10,
				49,
				39,
				190,
				81,
				213,
				228,
				151,
				23,
				231,
				23,
				57,
				224,
				187,
				119,
				245,
				54,
				81,
				141,
				45,
				171,
				0,
				0,
				0,
				203,
				211,
				139,
				62,
				110,
				51,
				58,
				65,
				64,
				134,
				29,
				53,
				198,
				216,
				158,
				178,
				112,
				28,
				230,
				228
			};
		}

		public void Initialize(string productId)
		{
			Initialize(productId, new BrokerSettings());
		}

		public void Initialize(string productId, BrokerSettings settings)
		{
			try
			{
				if (_Authenticator != null)
				{
					throw new Exception("Loader has already been initialized.");
				}
				if (settings == null)
				{
					throw new ArgumentNullException("settings");
				}
				ThreadCulture threadCulture = NormalizeCulture();
				if (settings.VerifyRuntimeIntegrity)
				{
					_StrongNameVerifier = new StrongNameVerifierLite();
					CheckFrameworkStrongNames();
				}
				InitializeWebHandling();
				InitializeComponentTransform();
				_ProductDirectory = GetProductDirectory();
				string[] metadata = GetMetadata();
				ParseMetadata(metadata);
				if (!Directory.Exists(_ProductDirectory))
				{
					Directory.CreateDirectory(_ProductDirectory);
				}
				InitializeLzmaLib();
				InitializeAuthenticator();
				VerifyAuthenticator();
				_AuthenticatorType = Assembly.Load(_AuthenticatorData).GetType("Controller");
				_Authenticator = Activator.CreateInstance(_AuthenticatorType);
				MethodInfo method = _AuthenticatorType.GetMethod("UpdateValue");
				method.Invoke(_Authenticator, new object[2]
				{
					"ProductId",
					productId
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"CatchUnhandledExceptions",
					settings.CatchUnhandledExceptions
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"DeferAutomaticUpdates",
					settings.DeferAutomaticUpdates
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"SilentAuthentication",
					settings.SilentAuthentication
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"DialogTheme",
					Convert.ToInt32(settings.DialogTheme)
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"LoaderVersion",
					_Version
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"ProductVersion",
					new Version(Application.ProductVersion)
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"Metadata",
					metadata
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"AuthorizedCallback",
					new CallbackDelegate(AuthorizedCallback)
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"RefreshedCallback",
					new CallbackDelegate(RefreshedCallback)
				});
				method.Invoke(_Authenticator, new object[2]
				{
					"SuspendedCallback",
					new CallbackDelegate(SuspendedCallback)
				});
				_AuthenticatorType.GetMethod("Initialize").Invoke(_Authenticator, null);
				DisposeMembers();
				RestoreCulture(threadCulture);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void InitializeWebHandling()
		{
			_DnsClient = new DnsClient();
			_HttpClient = new HttpClient();
			_HttpClient.RequestThrottleTime = 100;
			_HttpClient.MaxConcurrentRequests = 1;
			_HttpClient.WebRequestResolveHost += HttpClient_WebRequestResolveHost;
		}

		private void InitializeComponentTransform()
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.KeySize = 128;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Key = _ComponentKey;
			rijndaelManaged.IV = rijndaelManaged.Key;
			_ComponentAesEncryptor = rijndaelManaged.CreateEncryptor();
			_ComponentAesDecryptor = rijndaelManaged.CreateDecryptor();
		}

		private void AuthorizedCallback()
		{
			if (this.LicenseAuthorized != null)
			{
				this.LicenseAuthorized(this, EventArgs.Empty);
			}
		}

		private void RefreshedCallback()
		{
			if (this.LicenseRefreshed != null)
			{
				this.LicenseRefreshed(this, EventArgs.Empty);
			}
		}

		private void SuspendedCallback()
		{
			if (this.LicenseSuspended != null)
			{
				this.LicenseSuspended(this, EventArgs.Empty);
			}
		}

		private string GetPostBody(int postId)
		{
			return (string)_AuthenticatorType.GetMethod("GetPostBody").Invoke(_Authenticator, new object[1]
			{
				postId
			});
		}

		private void HandleException(Exception ex)
		{
			string value = ExceptionToString(ex);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("[Loader: {0}]", _Version);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.Append(value);
			new ExceptionForm(stringBuilder.ToString()).ShowDialog();
			Environment.Exit(0);
		}

		private string ExceptionToString(Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(ex.Message);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(ex.GetType().FullName);
			stringBuilder.AppendLine(ex.StackTrace);
			if (ex.InnerException != null)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(ExceptionToString(ex.InnerException));
			}
			return stringBuilder.ToString();
		}

		private void EnsureInitialization()
		{
			if (_Authenticator != null)
			{
				return;
			}
			throw new Exception("Loader has not been initialized.");
		}

		private void CheckFrameworkStrongNames()
		{
			string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
			byte[] token = new byte[8]
			{
				183,
				122,
				92,
				86,
				25,
				52,
				224,
				137
			};
			byte[] token2 = new byte[8]
			{
				176,
				63,
				95,
				127,
				17,
				213,
				10,
				58
			};
			CheckStrongName(Path.Combine(runtimeDirectory, "mscorlib.dll"), token);
			CheckStrongName(Path.Combine(runtimeDirectory, "System.dll"), token);
			CheckStrongName(Path.Combine(runtimeDirectory, "System.Security.dll"), token2);
		}

		private void CheckStrongName(string fileName, byte[] token)
		{
			string fileName2 = Path.GetFileName(fileName);
			if (_StrongNameVerifier.VerifyStrongName(fileName, token))
			{
				return;
			}
			throw new Exception($"Could not verify strong name of file or assembly '{fileName2}'.");
		}

		private void VerifyAuthenticator()
		{
			byte[] array = new byte[40];
			byte[] array2 = new byte[_AuthenticatorData.Length - 42];
			Buffer.BlockCopy(_AuthenticatorData, 2, array, 0, array.Length);
			Buffer.BlockCopy(_AuthenticatorData, 42, array2, 0, array2.Length);
			DSACryptoServiceProvider dSACryptoServiceProvider = new DSACryptoServiceProvider();
			dSACryptoServiceProvider.ImportCspBlob(_AuthenticatorKey);
			if (dSACryptoServiceProvider.VerifyData(array2, array))
			{
				return;
			}
			throw new Exception("Could not verify signature of authenticator.");
		}

		private string[] GetMetadata()
		{
			try
			{
				byte[] bytes = DownloadData(_PreferredMetadataEndPoint);
				return Encoding.UTF8.GetString(bytes).Split(default(char));
			}
			catch
			{
				return GetMetadataFallback();
			}
		}

		private string[] GetMetadataFallback()
		{
			try
			{
				byte[] bytes = DownloadData(_AlternateMetadataEndPoint);
				return Encoding.UTF8.GetString(bytes).Split('|');
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
			return null;
		}

		private void ParseMetadata(string[] metadata)
		{
			_ComponentEndPoint = metadata[0];
			_LzmaLibHash = metadata[1];
			_AuthenticatorHash = metadata[3];
			_ServerEndPoint = metadata[5];
		}

		private string Md5HashData(byte[] data)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return ByteArrayToString(mD5CryptoServiceProvider.ComputeHash(data));
		}

		private string ByteArrayToString(byte[] data)
		{
			return BitConverter.ToString(data).ToLower().Replace("-", string.Empty);
		}

		private void InitializeLzmaLib()
		{
			string lzmaLibFileName = GetLzmaLibFileName();
			if (File.Exists(lzmaLibFileName))
			{
				_LzmaLibData = LoadComponentData(lzmaLibFileName);
				if (!_LzmaLibHash.Equals(Md5HashData(_LzmaLibData)))
				{
					_LzmaLibData = InstallLzmaLib(lzmaLibFileName);
				}
			}
			else
			{
				_LzmaLibData = InstallLzmaLib(lzmaLibFileName);
			}
		}

		private byte[] InstallLzmaLib(string fileName)
		{
			string componentEndPoint = GetComponentEndPoint(_LzmaLibHash);
			byte[] array = DeflateDecompress(DownloadData(componentEndPoint));
			SaveComponentData(fileName, array);
			return array;
		}

		private string GetLzmaLibFileName()
		{
			return Path.Combine(_ProductDirectory, "LzmaLib.bin");
		}

		private void InitializeAuthenticator()
		{
			string authenticatorFileName = GetAuthenticatorFileName();
			if (File.Exists(authenticatorFileName))
			{
				_AuthenticatorData = LoadComponentData(authenticatorFileName);
				if (!_AuthenticatorHash.Equals(Md5HashData(_AuthenticatorData)))
				{
					_AuthenticatorData = InstallAuthenticator(authenticatorFileName);
				}
			}
			else
			{
				_AuthenticatorData = InstallAuthenticator(authenticatorFileName);
			}
		}

		private byte[] InstallAuthenticator(string fileName)
		{
			string componentEndPoint = GetComponentEndPoint(_AuthenticatorHash);
			byte[] array = LzmaDecompress(DownloadData(componentEndPoint));
			SaveComponentData(fileName, array);
			return array;
		}

		private string GetAuthenticatorFileName()
		{
			return Path.Combine(_ProductDirectory, "License.bin");
		}

		private string GetComponentEndPoint(string hash)
		{
			return Path.Combine(_ComponentEndPoint, hash) + ".co";
		}

		private byte[] LoadComponentData(string fileName)
		{
			byte[] array = File.ReadAllBytes(fileName);
			return _ComponentAesDecryptor.TransformFinalBlock(array, 0, array.Length);
		}

		private void SaveComponentData(string fileName, byte[] data)
		{
			byte[] bytes = _ComponentAesEncryptor.TransformFinalBlock(data, 0, data.Length);
			File.WriteAllBytes(fileName, bytes);
		}

		private byte[] DeflateDecompress(byte[] data)
		{
			byte[] array = new byte[BitConverter.ToInt32(data, 0)];
			MemoryStream memoryStream = new MemoryStream(data, 4, data.Length - 4);
			DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, false);
			deflateStream.Read(array, 0, array.Length);
			deflateStream.Close();
			memoryStream.Close();
			return array;
		}

		private byte[] LzmaDecompress(byte[] data)
		{
			if (_LzmaLibType == (Type)null)
			{
				_LzmaLibType = Assembly.Load(_LzmaLibData).GetType("H");
			}
			return (byte[])_LzmaLibType.GetMethod("Decompress").Invoke(null, new object[1]
			{
				data
			});
		}

		private byte[] DownloadData(string url)
		{
			HttpClient.RequestOptions requestOptions = new HttpClient.RequestOptions();
			requestOptions.Timeout = 60000;
			requestOptions.RetryCount = 3;
			requestOptions.Proxy = null;
			requestOptions.Method = "GET";
			return _HttpClient.UploadValues(url, null, requestOptions);
		}

		private string GetProductDirectory()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Net Seal");
		}

		private ThreadCulture NormalizeCulture()
		{
			Thread currentThread = Thread.CurrentThread;
			ThreadCulture result = new ThreadCulture(currentThread.CurrentCulture, currentThread.CurrentUICulture);
			currentThread.CurrentCulture = CultureInfo.InvariantCulture;
			currentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			return result;
		}

		private void RestoreCulture(ThreadCulture threadCulture)
		{
			Thread currentThread = Thread.CurrentThread;
			currentThread.CurrentCulture = threadCulture.Culture;
			currentThread.CurrentUICulture = threadCulture.UICulture;
		}

		private void DisposeMembers()
		{
			_LzmaLibData = null;
			_AuthenticatorData = null;
			_ComponentKey = null;
			_AuthenticatorKey = null;
			_ComponentEndPoint = null;
			_ServerEndPoint = null;
			_AuthenticatorHash = null;
			_LzmaLibHash = null;
			_PreferredMetadataEndPoint = null;
			_AlternateMetadataEndPoint = null;
			_LzmaLibType = null;
			_HttpClient = null;
			_DnsClient = null;
			_StrongNameVerifier = null;
			_ComponentAesDecryptor = null;
			_ComponentAesEncryptor = null;
		}
	}
}

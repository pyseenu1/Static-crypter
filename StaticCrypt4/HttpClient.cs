using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace StaticCrypt4
{
	internal sealed class HttpClient
	{
		public delegate void WebRequestDownloadProgressEventHandler(object sender, WebRequestProgressEventArgs e);

		public delegate void WebRequestUploadProgressEventHandler(object sender, WebRequestProgressEventArgs e);

		public delegate void WebRequestCompletedEventHandler(object sender, WebRequestCompletedEventArgs e);

		public delegate void WebRequestResolveHostEventHandler(object sender, WebRequestResolveHostEventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed class WebRequestResolveHostEventArgs
		{
			private string _HostName;

			private IPAddress _Address;

			public string HostName => _HostName;

			public IPAddress Address
			{
				get
				{
					return _Address;
				}
				set
				{
					_Address = value;
				}
			}

			public WebRequestResolveHostEventArgs(string hostName, IPAddress address)
			{
				_HostName = hostName;
				_Address = address;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed class WebRequestCompletedEventArgs
		{
			private Exception _Error;

			private byte[] _Result;

			private WebHeaderCollection _Headers;

			private object _UserState;

			public Exception Error => _Error;

			public byte[] Result => _Result;

			public WebHeaderCollection Headers => _Headers;

			public object UserState => _UserState;

			public WebRequestCompletedEventArgs(Exception error, byte[] result, WebHeaderCollection headers, object userState)
			{
				_Error = error;
				_Result = result;
				_Headers = headers;
				_UserState = userState;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed class WebRequestProgressEventArgs
		{
			private double _ProgressPercentage;

			private int _BytesTransferred;

			private int _TotalBytesToTransfer;

			private object _UserState;

			public double ProgressPercentage => _ProgressPercentage;

			public int BytesTransferred => _BytesTransferred;

			public int TotalBytesToTransfer => _TotalBytesToTransfer;

			public object UserState => _UserState;

			public WebRequestProgressEventArgs(int bytesTransferred, int totalBytesToTransfer, object userState)
			{
				_BytesTransferred = bytesTransferred;
				_TotalBytesToTransfer = totalBytesToTransfer;
				if (totalBytesToTransfer != 0)
				{
					_ProgressPercentage = (double)(_BytesTransferred / _TotalBytesToTransfer * 100);
				}
				_UserState = userState;
			}
		}

		public sealed class RequestOptions
		{
			private IWebProxy _Proxy;

			private string _UserAgent;

			private string _Referer;

			private CookieContainer _Cookies;

			private WebHeaderCollection _Headers;

			private int _Timeout;

			private int _RetryCount;

			private string _Method;

			public IWebProxy Proxy
			{
				get
				{
					return _Proxy;
				}
				set
				{
					_Proxy = value;
				}
			}

			public string UserAgent
			{
				get
				{
					return _UserAgent;
				}
				set
				{
					_UserAgent = value;
				}
			}

			public string Referer
			{
				get
				{
					return _Referer;
				}
				set
				{
					_Referer = value;
				}
			}

			public CookieContainer Cookies
			{
				get
				{
					return _Cookies;
				}
				set
				{
					_Cookies = value;
				}
			}

			public WebHeaderCollection Headers
			{
				get
				{
					return _Headers;
				}
				set
				{
					_Headers = value;
				}
			}

			public int Timeout
			{
				get
				{
					return _Timeout;
				}
				set
				{
					_Timeout = value;
				}
			}

			public int RetryCount
			{
				get
				{
					return _RetryCount;
				}
				set
				{
					_RetryCount = Math.Max(value, 0);
				}
			}

			public string Method
			{
				get
				{
					return _Method;
				}
				set
				{
					if (string.IsNullOrEmpty(value))
					{
						_Method = "POST";
					}
					else
					{
						_Method = value.Trim().ToUpper();
					}
				}
			}

			public RequestOptions()
			{
				_Method = "POST";
				_Timeout = 60000;
				_Proxy = WebRequest.DefaultWebProxy;
				_Cookies = new CookieContainer();
				_Headers = new WebHeaderCollection();
			}
		}

		private sealed class RequestState
		{
			private RequestOptions _Options;

			private object _UserState;

			private bool _RaiseEvents;

			public RequestOptions Options => _Options;

			public object UserState => _UserState;

			public bool RaiseEvents => _RaiseEvents;

			public RequestState(RequestOptions options, object userState, bool raiseEvents)
			{
				_Options = options;
				_UserState = userState;
				_RaiseEvents = raiseEvents;
			}
		}

		private int _RetryDelayTime;

		private int _ConcurrentRequests;

		private int _RequestThrottleTime;

		private int _MaxConcurrentRequests;

		private bool _BypassPageCaching;

		private DateTime _RequestTime;

		private object _ThrottleLock;

		public bool BypassPageCaching
		{
			get
			{
				return _BypassPageCaching;
			}
			set
			{
				_BypassPageCaching = value;
			}
		}

		public int RequestThrottleTime
		{
			get
			{
				return _RequestThrottleTime;
			}
			set
			{
				_RequestThrottleTime = Math.Max(value, 0);
			}
		}

		public int MaxConcurrentRequests
		{
			get
			{
				return _MaxConcurrentRequests;
			}
			set
			{
				_MaxConcurrentRequests = Math.Max(value, 0);
			}
		}

		public int RetryDelayTime
		{
			get
			{
				return _RetryDelayTime;
			}
			set
			{
				_RetryDelayTime = Math.Max(value, 0);
			}
		}

		public event WebRequestDownloadProgressEventHandler WebRequestDownloadProgress;

		public event WebRequestUploadProgressEventHandler WebRequestUploadProgress;

		public event WebRequestCompletedEventHandler WebRequestCompleted;

		public event WebRequestResolveHostEventHandler WebRequestResolveHost;

		public HttpClient()
		{
			_BypassPageCaching = true;
			_RetryDelayTime = 1000;
			_ThrottleLock = new object();
			ServicePointManager.CheckCertificateRevocationList = false;
			ServicePointManager.DnsRefreshTimeout = -1;
			ServicePointManager.EnableDnsRoundRobin = false;
		}

		public byte[] DownloadData(string host)
		{
			RequestOptions requestOptions = new RequestOptions();
			requestOptions.Method = "GET";
			return UploadValues(host, null, requestOptions);
		}

		public byte[] UploadValues(string host, Dictionary<string, object> values)
		{
			return UploadValues(host, values, null);
		}

		public byte[] UploadValues(string host, Dictionary<string, object> values, RequestOptions options)
		{
			if (options == null)
			{
				options = new RequestOptions();
			}
			return ExecuteRequest(host, values, new RequestState(options, null, false));
		}

		public void DownloadDataAsync(string host)
		{
			RequestOptions requestOptions = new RequestOptions();
			requestOptions.Method = "GET";
			UploadValuesAsync(host, null, requestOptions, null);
		}

		public void DownloadDataAsync(string host, object userState)
		{
			RequestOptions requestOptions = new RequestOptions();
			requestOptions.Method = "GET";
			UploadValuesAsync(host, null, requestOptions, userState);
		}

		public void UploadValuesAsync(string host, Dictionary<string, object> values)
		{
			UploadValuesAsync(host, values, null, null);
		}

		public void UploadValuesAsync(string host, Dictionary<string, object> values, object userState)
		{
			UploadValuesAsync(host, values, null, userState);
		}

		public void UploadValuesAsync(string host, Dictionary<string, object> values, RequestOptions options)
		{
			UploadValuesAsync(host, values, options, null);
		}

		public void UploadValuesAsync(string host, Dictionary<string, object> values, RequestOptions options, object userState)
		{
			if (options == null)
			{
				options = new RequestOptions();
			}
			ThreadPool.QueueUserWorkItem(delegate
			{
				ExecuteRequest(host, values, new RequestState(options, userState, true));
			});
		}

		private void ThrottleRequest()
		{
			while (true)
			{
				TimeSpan timeSpan = default(TimeSpan);
				int num = _ConcurrentRequests;
				if (_RequestThrottleTime == 0)
				{
					timeSpan = TimeSpan.MaxValue;
				}
				else
				{
					lock (_ThrottleLock)
					{
						timeSpan = DateTime.Now - _RequestTime;
					}
				}
				if (_MaxConcurrentRequests == 0)
				{
					num = -1;
				}
				if (timeSpan.TotalMilliseconds > (double)_RequestThrottleTime && num < _MaxConcurrentRequests)
				{
					break;
				}
				Thread.Sleep(15);
			}
		}

		private byte[] ExecuteRequest(string host, Dictionary<string, object> values, RequestState state)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			int i = 0;
			WebRequest webRequest = null;
			Exception ex = null;
			byte[] result = null;
			WebHeaderCollection headers = null;
			for (; state.Options.RetryCount >= i; i++, Interlocked.Decrement(ref _ConcurrentRequests), Thread.Sleep(RetryDelayTime))
			{
				if (_RequestThrottleTime > 0 || _MaxConcurrentRequests > 0)
				{
					ThrottleRequest();
				}
				lock (_ThrottleLock)
				{
					if (DateTime.Now > _RequestTime)
					{
						_RequestTime = DateTime.Now;
					}
				}
				Interlocked.Increment(ref _ConcurrentRequests);
				try
				{
					webRequest = null;
					ex = null;
					result = null;
					Uri address = PrepareUri(host, values, state.Options);
					webRequest = PrepareWebRequest(address, state.Options);
					if (values != null && state.Options.Method == "POST")
					{
						WriteRequest(webRequest, values, state);
					}
					WebResponse response = webRequest.GetResponse();
					result = ReadResponse(response, state);
					headers = response.Headers;
					Interlocked.Decrement(ref _ConcurrentRequests);
				}
				catch (Exception ex2)
				{
					ex = ex2;
					continue;
				}
				break;
			}
			if (state.RaiseEvents)
			{
				WebRequestCompletedEventArgs e = new WebRequestCompletedEventArgs(ex, result, headers, state.UserState);
				if (this.WebRequestCompleted != null)
				{
					this.WebRequestCompleted(this, e);
				}
			}
			else if (ex != null)
			{
				throw ex;
			}
			return result;
		}

		private Uri PrepareUri(string host, Dictionary<string, object> values, RequestOptions options)
		{
			UriBuilder uriBuilder = new UriBuilder(host);
			StringBuilder stringBuilder = new StringBuilder();
			if (uriBuilder.Query.Length > 0)
			{
				stringBuilder.AppendFormat("{0}&", uriBuilder.Query.Substring(1));
			}
			if (values != null && options.Method == "GET")
			{
				foreach (KeyValuePair<string, object> value in values)
				{
					stringBuilder.AppendFormat("{0}={1}&", Uri.EscapeDataString(value.Key), Uri.EscapeDataString(value.Value.ToString()));
				}
				stringBuilder.Length--;
			}
			if (_BypassPageCaching)
			{
				stringBuilder.Append(Guid.NewGuid().ToString().Remove(8));
			}
			uriBuilder.Query = stringBuilder.ToString();
			return uriBuilder.Uri;
		}

		private HttpWebRequest PrepareWebRequest(Uri address, RequestOptions options)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(address);
			httpWebRequest.Accept = null;
			httpWebRequest.AllowAutoRedirect = true;
			httpWebRequest.AllowWriteStreamBuffering = false;
			httpWebRequest.AuthenticationLevel = AuthenticationLevel.None;
			httpWebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
			httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
			httpWebRequest.ClientCertificates = new X509CertificateCollection();
			httpWebRequest.ConnectionGroupName = null;
			httpWebRequest.ContentLength = 0L;
			httpWebRequest.ContinueDelegate = null;
			httpWebRequest.Credentials = null;
			httpWebRequest.CookieContainer = options.Cookies;
			httpWebRequest.Expect = null;
			httpWebRequest.ImpersonationLevel = TokenImpersonationLevel.None;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.MaximumAutomaticRedirections = 10;
			httpWebRequest.MaximumResponseHeadersLength = -1;
			httpWebRequest.MediaType = null;
			httpWebRequest.Method = options.Method;
			httpWebRequest.Pipelined = true;
			httpWebRequest.PreAuthenticate = false;
			httpWebRequest.ProtocolVersion = HttpVersion.Version11;
			httpWebRequest.Proxy = options.Proxy;
			httpWebRequest.ReadWriteTimeout = options.Timeout;
			httpWebRequest.Referer = options.Referer;
			httpWebRequest.SendChunked = false;
			httpWebRequest.Timeout = options.Timeout;
			httpWebRequest.TransferEncoding = null;
			httpWebRequest.UnsafeAuthenticatedConnectionSharing = true;
			httpWebRequest.UseDefaultCredentials = false;
			httpWebRequest.UserAgent = options.UserAgent;
			httpWebRequest.ServicePoint.BindIPEndPointDelegate = BindIPEndPoint;
			httpWebRequest.ServicePoint.ConnectionLeaseTimeout = 60000;
			httpWebRequest.ServicePoint.ConnectionLimit = 100;
			httpWebRequest.ServicePoint.Expect100Continue = false;
			httpWebRequest.ServicePoint.MaxIdleTime = 10000;
			httpWebRequest.ServicePoint.ReceiveBufferSize = 65535;
			httpWebRequest.ServicePoint.UseNagleAlgorithm = true;
			if (_BypassPageCaching)
			{
				((NameValueCollection)httpWebRequest.Headers)["Cache-Control"] = "no-cache, no-store, no-transform";
				((NameValueCollection)httpWebRequest.Headers)["Pragma"] = "no-cache";
			}
			if (options.Headers != null)
			{
				httpWebRequest.Headers.Add(options.Headers);
			}
			return httpWebRequest;
		}

		private byte[] PrepareRequestStream(Dictionary<string, object> values, string boundary)
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			foreach (KeyValuePair<string, object> value in values)
			{
				bool num = value.Value is byte[];
				streamWriter.WriteLine($"--{boundary}");
				streamWriter.WriteLine($"Content-Disposition: form-data; name=\"{value.Key}\"");
				if (num)
				{
					streamWriter.WriteLine("Content-Type: application/octet-stream");
				}
				streamWriter.WriteLine();
				if (num)
				{
					byte[] array = (byte[])value.Value;
					streamWriter.Flush();
					memoryStream.Write(array, 0, array.Length);
					streamWriter.WriteLine();
				}
				else
				{
					streamWriter.WriteLine(value.Value);
				}
			}
			streamWriter.WriteLine($"--{boundary}--");
			streamWriter.Close();
			return memoryStream.ToArray();
		}

		private void WriteRequest(WebRequest request, Dictionary<string, object> values, RequestState state)
		{
			if (values.Count != 0)
			{
				string text = DateTime.UtcNow.Ticks.ToString();
				byte[] array = PrepareRequestStream(values, text);
				request.ContentType = $"multipart/form-data; boundary={text}";
				request.ContentLength = array.Length;
				int num = 0;
				int num2 = 0;
				Stream requestStream = request.GetRequestStream();
				while (true)
				{
					if (state.RaiseEvents && this.WebRequestUploadProgress != null)
					{
						this.WebRequestUploadProgress(this, new WebRequestProgressEventArgs(num2, array.Length, state.UserState));
					}
					num = Math.Min(65535, array.Length - num2);
					if (num == 0)
					{
						break;
					}
					requestStream.Write(array, num2, num);
					num2 += num;
				}
			}
		}

		private byte[] ReadResponse(WebResponse response, RequestState state)
		{
			MemoryStream memoryStream = new MemoryStream();
			int num = Convert.ToInt32(response.ContentLength);
			int num2 = 0;
			int num3 = 0;
			byte[] array = new byte[65535];
			Stream responseStream = response.GetResponseStream();
			while (true)
			{
				if (state.RaiseEvents)
				{
					if (num == -1)
					{
						if (this.WebRequestDownloadProgress != null)
						{
							this.WebRequestDownloadProgress(this, new WebRequestProgressEventArgs(num3, num3, state.UserState));
						}
					}
					else if (this.WebRequestDownloadProgress != null)
					{
						this.WebRequestDownloadProgress(this, new WebRequestProgressEventArgs(num3, num, state.UserState));
					}
				}
				num2 = responseStream.Read(array, 0, array.Length);
				if (num2 == 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num2);
				num3 += num2;
			}
			response.Close();
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		private IPEndPoint BindIPEndPoint(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
		{
			WebRequestResolveHostEventArgs webRequestResolveHostEventArgs = new WebRequestResolveHostEventArgs(servicePoint.Address.DnsSafeHost.ToLower(), remoteEndPoint.Address);
			if (this.WebRequestResolveHost != null)
			{
				this.WebRequestResolveHost(this, webRequestResolveHostEventArgs);
			}
			remoteEndPoint.Address = webRequestResolveHostEventArgs.Address;
			return null;
		}

		public static int EstimateMaxTimeout(int numberOfBytes)
		{
			int num = 1000;
			int num2 = 32000;
			int num3 = Convert.ToInt32(Math.Ceiling((double)(numberOfBytes / num2)));
			return 5000 + num3 * num;
		}
	}
}

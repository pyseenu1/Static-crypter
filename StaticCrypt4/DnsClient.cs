using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace StaticCrypt4
{
	internal sealed class DnsClient
	{
		private class DnsResult
		{
			public readonly DateTime ResolutionTime;

			public readonly IPAddress[] AddressList;

			public DnsResult(IPAddress[] addressesList)
			{
				ResolutionTime = DateTime.Now;
				AddressList = addressesList;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct DnsRecordA
		{
			public IntPtr NextRecord;

			public string Name;

			public short Type;

			public short DataLength;

			public int Flags;

			public int Ttl;

			public int Reserved;

			public uint Data;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct IPv4Array
		{
			public int Count;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
			public uint[] Addresses;
		}

		private IPAddress _PreferredDnsServer;

		private IPAddress _AlternateDnsServer;

		private bool _IgnoreHostsFile;

		private bool _IgnoreResolverCache;

		private bool _SystemDnsFallback;

		private bool _CacheDnsResults;

		private int _CacheTTL;

		private Dictionary<string, DnsResult> Cache;

		public IPAddress PreferredDnsServer
		{
			get
			{
				return _PreferredDnsServer;
			}
			set
			{
				_PreferredDnsServer = value;
				ClearCache();
			}
		}

		public IPAddress AlternateDnsServer
		{
			get
			{
				return _AlternateDnsServer;
			}
			set
			{
				_AlternateDnsServer = value;
				ClearCache();
			}
		}

		public bool IgnoreHostsFile
		{
			get
			{
				return _IgnoreHostsFile;
			}
			set
			{
				_IgnoreHostsFile = value;
				ClearCache();
			}
		}

		public bool IgnoreResolverCache
		{
			get
			{
				return _IgnoreResolverCache;
			}
			set
			{
				_IgnoreResolverCache = value;
				ClearCache();
			}
		}

		public bool SystemDnsFallback
		{
			get
			{
				return _SystemDnsFallback;
			}
			set
			{
				_SystemDnsFallback = value;
				ClearCache();
			}
		}

		public bool CacheDnsResults
		{
			get
			{
				return _CacheDnsResults;
			}
			set
			{
				_CacheDnsResults = value;
				ClearCache();
			}
		}

		public int CacheTTL
		{
			get
			{
				return _CacheTTL;
			}
			set
			{
				_CacheTTL = value;
			}
		}

		public DnsClient()
		{
			_PreferredDnsServer = new IPAddress(new byte[4]
			{
				8,
				8,
				8,
				8
			});
			_AlternateDnsServer = new IPAddress(new byte[4]
			{
				8,
				8,
				4,
				4
			});
			_CacheTTL = 900;
			_IgnoreHostsFile = true;
			_IgnoreResolverCache = true;
			_SystemDnsFallback = true;
			_CacheDnsResults = true;
			Cache = new Dictionary<string, DnsResult>();
		}

		public IPAddress[] Resolve(string hostName)
		{
			IPAddress none = IPAddress.None;
			if (IPAddress.TryParse(hostName, out none))
			{
				if (none.AddressFamily == AddressFamily.InterNetwork)
				{
					return new IPAddress[1]
					{
						none
					};
				}
				throw new NotImplementedException("IPv6 addresses are not supported.");
			}
			if (IsHostNameValid(hostName))
			{
				IPAddress[] array = null;
				string hostName2 = hostName.Trim().ToLower();
				if (CacheDnsResults)
				{
					array = QueryCache(hostName2);
					if (array.Length != 0)
					{
						return array;
					}
				}
				if (PreferredDnsServer != null)
				{
					array = GetDnsRecords(hostName2, PreferredDnsServer);
					if (array.Length != 0)
					{
						return CacheResults(hostName2, array);
					}
				}
				if (AlternateDnsServer != null)
				{
					array = GetDnsRecords(hostName2, AlternateDnsServer);
					if (array.Length != 0)
					{
						return CacheResults(hostName2, array);
					}
				}
				if (SystemDnsFallback)
				{
					array = GetDnsRecords(hostName2, null);
					if (array.Length != 0)
					{
						return CacheResults(hostName2, array);
					}
				}
			}
			return new IPAddress[0];
		}

		private IPAddress[] GetDnsRecords(string hostName, IPAddress dnsServer)
		{
			IntPtr ptr = default(IntPtr);
			List<IPAddress> list = new List<IPAddress>();
			IntPtr zero = IntPtr.Zero;
			IPv4Array iPv4ArrayFromIPAddress = GetIPv4ArrayFromIPAddress(dnsServer);
			if (DnsQueryA(hostName, 1, 72, ref iPv4ArrayFromIPAddress, ref ptr, ref zero) == 0)
			{
				DnsRecordA dnsRecordA = (DnsRecordA)Marshal.PtrToStructure(ptr, typeof(DnsRecordA));
				IPAddress addressFromRecord = GetAddressFromRecord(dnsRecordA);
				if (addressFromRecord != IPAddress.None)
				{
					list.Add(addressFromRecord);
				}
				while (!(dnsRecordA.NextRecord == IntPtr.Zero))
				{
					dnsRecordA = (DnsRecordA)Marshal.PtrToStructure(dnsRecordA.NextRecord, typeof(DnsRecordA));
					addressFromRecord = GetAddressFromRecord(dnsRecordA);
					if (addressFromRecord != IPAddress.None)
					{
						list.Add(addressFromRecord);
					}
				}
			}
			return list.ToArray();
		}

		private IPv4Array GetIPv4ArrayFromIPAddress(IPAddress address)
		{
			IPv4Array result = default(IPv4Array);
			if (address != null)
			{
				result.Count = 1;
				result.Addresses = new uint[1]
				{
					BitConverter.ToUInt32(address.GetAddressBytes(), 0)
				};
			}
			return result;
		}

		private IPAddress GetAddressFromRecord(DnsRecordA record)
		{
			if (record.Type != 1)
			{
				return IPAddress.None;
			}
			if ((record.Flags & 3) >= 2)
			{
				return IPAddress.None;
			}
			return new IPAddress(record.Data);
		}

		private void ClearCache()
		{
			Cache.Clear();
		}

		private IPAddress[] QueryCache(string hostName)
		{
			if (Cache.ContainsKey(hostName))
			{
				DnsResult dnsResult = Cache[hostName];
				if ((DateTime.Now - dnsResult.ResolutionTime).TotalSeconds > (double)CacheTTL)
				{
					Cache.Remove(hostName);
					goto IL_0052;
				}
				return dnsResult.AddressList;
			}
			goto IL_0052;
			IL_0052:
			return new IPAddress[0];
		}

		private IPAddress[] CacheResults(string hostName, IPAddress[] addressList)
		{
			if (CacheDnsResults)
			{
				Cache.Add(hostName, new DnsResult(addressList));
			}
			return addressList;
		}

		private bool IsHostNameValid(string hostName)
		{
			if (hostName.Length > 255)
			{
				throw new ArgumentOutOfRangeException("hostName", "Host name must not exceed 255 characters.");
			}
			string[] array = null;
			array = ((!hostName.Contains(".")) ? new string[1]
			{
				hostName
			} : hostName.Split('.'));
			string[] array2 = array;
			int num = 0;
			while (num < array2.Length)
			{
				string text = array2[num];
				if (text.Length != 0 && text.Length <= 63)
				{
					int value = Convert.ToInt32(text[0]);
					int value2 = Convert.ToInt32(text[text.Length - 1]);
					if (!IsLetterOrDigit(value) && !IsLetterOrDigit(value2))
					{
						throw new FormatException("Labels in host names must begin and end with alphanumeric ASCII characters.");
					}
					for (int i = 1; i <= text.Length - 2; i++)
					{
						int value3 = Convert.ToInt32(text[i]);
						if (!IsLetterOrDigit(value3) && !IsHyphen(value3))
						{
							throw new FormatException("Host names may only contain alphanumeric ASCII characters, hyphens (-), and periods (.).");
						}
					}
					num++;
					continue;
				}
				throw new FormatException("Labels in host names must be between 1 and 63 characters in length.");
			}
			return true;
		}

		private bool IsLetterOrDigit(int value)
		{
			if (value >= 48 && value <= 57)
			{
				goto IL_0024;
			}
			if (value >= 65 && value <= 90)
			{
				goto IL_0024;
			}
			if (value >= 97)
			{
				return value <= 122;
			}
			return false;
			IL_0024:
			return true;
		}

		private bool IsHyphen(int value)
		{
			return value == 45;
		}

		[DllImport("dnsapi.dll", EntryPoint = "DnsQuery_A")]
		private static extern int DnsQueryA(string hostName, short type, int options, ref IPv4Array dnsServers, ref IntPtr recordList, ref IntPtr reserved);
	}
}

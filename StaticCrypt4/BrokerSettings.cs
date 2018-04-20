namespace StaticCrypt4
{
	internal sealed class BrokerSettings
	{
		public DialogTheme DialogTheme
		{
			get;
			set;
		}

		public bool CatchUnhandledExceptions
		{
			get;
			set;
		}

		public bool DeferAutomaticUpdates
		{
			get;
			set;
		}

		public bool SilentAuthentication
		{
			get;
			set;
		}

		public bool VerifyRuntimeIntegrity
		{
			get;
			set;
		}

		public BrokerSettings()
		{
			CatchUnhandledExceptions = true;
			VerifyRuntimeIntegrity = true;
			DialogTheme = DialogTheme.Light;
		}
	}
}

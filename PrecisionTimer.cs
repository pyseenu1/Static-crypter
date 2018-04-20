using System;
using System.Runtime.InteropServices;

internal class PrecisionTimer : IDisposable
{
	public delegate void TimerDelegate(IntPtr r1, bool r2);

	private bool _Enabled;

	private IntPtr Handle;

	private TimerDelegate TimerCallback;

	public bool Enabled => _Enabled;

	[DllImport("kernel32.dll")]
	private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

	[DllImport("kernel32.dll")]
	private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

	public void Create(uint dueTime, uint period, TimerDelegate callback)
	{
		if (!_Enabled)
		{
			TimerCallback = callback;
			bool flag = CreateTimerQueueTimer(ref Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0u);
			if (!flag)
			{
				ThrowNewException("CreateTimerQueueTimer");
			}
			_Enabled = flag;
		}
	}

	public void Delete()
	{
		if (_Enabled)
		{
			bool flag = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero);
			if (!flag && Marshal.GetLastWin32Error() != 997)
			{
				ThrowNewException("DeleteTimerQueueTimer");
			}
			_Enabled = !flag;
		}
	}

	private void ThrowNewException(string name)
	{
		throw new Exception($"{name} failed. Win32Error: {Marshal.GetLastWin32Error()}");
	}

	public void Dispose()
	{
		Delete();
	}
}

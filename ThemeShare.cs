using System;
using System.Collections.Generic;

internal static class ThemeShare
{
	public delegate void AnimationDelegate(bool invalidate);

	private static int Frames;

	private static bool Invalidate;

	public static PrecisionTimer ThemeTimer = new PrecisionTimer();

	private const int FPS = 50;

	private const int Rate = 10;

	private static List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();

	private static void HandleCallbacks(IntPtr state, bool reserve)
	{
		Invalidate = (Frames >= 50);
		if (Invalidate)
		{
			Frames = 0;
		}
		lock (Callbacks)
		{
			for (int i = 0; i <= Callbacks.Count - 1; i++)
			{
				Callbacks[i](Invalidate);
			}
		}
		Frames += 10;
	}

	private static void InvalidateThemeTimer()
	{
		if (Callbacks.Count == 0)
		{
			ThemeTimer.Delete();
		}
		else
		{
			ThemeTimer.Create(0u, 10u, HandleCallbacks);
		}
	}

	public static void AddAnimationCallback(AnimationDelegate callback)
	{
		lock (Callbacks)
		{
			if (!Callbacks.Contains(callback))
			{
				Callbacks.Add(callback);
				InvalidateThemeTimer();
			}
		}
	}

	public static void RemoveAnimationCallback(AnimationDelegate callback)
	{
		lock (Callbacks)
		{
			if (Callbacks.Contains(callback))
			{
				Callbacks.Remove(callback);
				InvalidateThemeTimer();
			}
		}
	}
}

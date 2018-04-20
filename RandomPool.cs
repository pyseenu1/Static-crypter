using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

internal class RandomPool : ThemeControl
{
	public delegate void CharacterSelectionEventHandler(object s, char c);

	private Graphics GO;

	private Size _Size;

	[CompilerGenerated]
	private CharacterSelectionEventHandler CharacterSelectionEvent;

	private string _Range;

	private int _RangePadding;

	private Brush _Brush;

	private int Count;

	private int Index1;

	private int Index2;

	private char[] Items;

	private Random RN;

	public string Range
	{
		get
		{
			return _Range;
		}
		set
		{
			_Range = value;
			UpdateSize();
		}
	}

	public int RangePadding
	{
		get
		{
			return _RangePadding;
		}
		set
		{
			_RangePadding = value;
			UpdateSize();
		}
	}

	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			UpdateSize();
		}
	}

	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
			_Brush = new SolidBrush(value);
			base.Invalidate();
		}
	}

	public event CharacterSelectionEventHandler CharacterSelection
	{
		[CompilerGenerated]
		add
		{
			CharacterSelectionEventHandler characterSelectionEventHandler = CharacterSelectionEvent;
			CharacterSelectionEventHandler characterSelectionEventHandler2;
			do
			{
				characterSelectionEventHandler2 = characterSelectionEventHandler;
				CharacterSelectionEventHandler value2 = (CharacterSelectionEventHandler)Delegate.Combine(characterSelectionEventHandler2, value);
				characterSelectionEventHandler = Interlocked.CompareExchange(ref CharacterSelectionEvent, value2, characterSelectionEventHandler2);
			}
			while (characterSelectionEventHandler != characterSelectionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CharacterSelectionEventHandler characterSelectionEventHandler = CharacterSelectionEvent;
			CharacterSelectionEventHandler characterSelectionEventHandler2;
			do
			{
				characterSelectionEventHandler2 = characterSelectionEventHandler;
				CharacterSelectionEventHandler value2 = (CharacterSelectionEventHandler)Delegate.Remove(characterSelectionEventHandler2, value);
				characterSelectionEventHandler = Interlocked.CompareExchange(ref CharacterSelectionEvent, value2, characterSelectionEventHandler2);
			}
			while (characterSelectionEventHandler != characterSelectionEventHandler2);
		}
	}

	public RandomPool()
	{
		_Range = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		_RangePadding = 2;
		_Brush = SystemBrushes.ControlText;
		GO = Graphics.FromHwndInternal(base.Handle);
	}

	private void UpdateSize()
	{
		_Size = new Size(0, 0);
		checked
		{
			int num = _Range.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				Size size = GO.MeasureString(Convert.ToString(_Range[i]), Font).ToSize();
				size.Width += _RangePadding;
				size.Height += _RangePadding;
				if (size.Height > _Size.Height)
				{
					_Size.Height = size.Height;
				}
				if (size.Width > _Size.Width)
				{
					_Size.Width = size.Width;
				}
			}
			Randomize();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		checked
		{
			try
			{
				Index1 = GetIndex(e.X, e.Y);
				if (Index1 != Index2)
				{
					CharacterSelectionEventHandler characterSelectionEvent = CharacterSelectionEvent;
					characterSelectionEvent?.Invoke(this, Items[Index1]);
					Randomize(Index1 - Count);
					Randomize(Index1 - 1);
					Randomize(Index1);
					Randomize(Index1 + 1);
					Randomize(Index1 + Count);
					Index2 = Index1;
					base.Invalidate();
				}
			}
			catch (Exception)
			{
			}
		}
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		if (_Size.Width == 0)
		{
			UpdateSize();
		}
		else
		{
			Randomize();
		}
		base.OnSizeChanged(e);
	}

	public override void PaintHook()
	{
		base.G.Clear(BackColor);
		checked
		{
			int num = base.Width - 1;
			int width = _Size.Width;
			for (int i = 0; (width >> 31 ^ i) <= (width >> 31 ^ num); i += width)
			{
				int num2 = base.Height - 1;
				int height = _Size.Height;
				for (int j = 0; (height >> 31 ^ j) <= (height >> 31 ^ num2); j += height)
				{
					unchecked
					{
						base.G.DrawString(Convert.ToString(Items[GetIndex(i, j)]), Font, _Brush, (float)i, (float)j);
					}
				}
			}
		}
	}

	private int GetIndex(int x, int y)
	{
		return checked(unchecked(y / _Size.Height) * Count + unchecked(x / _Size.Width));
	}

	private void Randomize()
	{
		checked
		{
			Count = (int)Math.Round(Math.Ceiling(unchecked((double)base.Width / (double)_Size.Width)));
			RN = new Random(Guid.NewGuid().GetHashCode());
			Items = new char[(int)Math.Round(unchecked(Math.Ceiling((double)base.Width / (double)_Size.Width) * Math.Ceiling((double)base.Height / (double)_Size.Height))) - 1 + 1];
			int num = Items.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				Items[i] = _Range[RN.Next(_Range.Length)];
			}
			base.Invalidate();
		}
	}

	private void Randomize(int index)
	{
		if (index > -1 && index < Items.Length)
		{
			Items[index] = _Range[RN.Next(_Range.Length)];
		}
	}
}

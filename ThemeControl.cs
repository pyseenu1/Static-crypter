using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

internal abstract class ThemeControl : Control
{
	protected enum State : byte
	{
		MouseNone,
		MouseOver,
		MouseDown
	}

	protected Graphics G;

	protected Bitmap B;

	protected State MouseState;

	private bool _NoRounding;

	private Image _Image;

	private Size _Size;

	private Rectangle _Rectangle;

	private LinearGradientBrush _Gradient;

	private SolidBrush _Brush;

	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			base.Invalidate();
		}
	}

	public bool NoRounding
	{
		get
		{
			return _NoRounding;
		}
		set
		{
			_NoRounding = value;
			base.Invalidate();
		}
	}

	public Image Image
	{
		get
		{
			return _Image;
		}
		set
		{
			_Image = value;
			base.Invalidate();
		}
	}

	public int ImageWidth
	{
		get
		{
			if (_Image == null)
			{
				return 0;
			}
			return _Image.Width;
		}
	}

	public int ImageTop
	{
		get
		{
			if (_Image == null)
			{
				return 0;
			}
			return checked(unchecked(base.Height / 2) - unchecked(_Image.Height / 2));
		}
	}

	public ThemeControl()
	{
		base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		B = new Bitmap(1, 1);
		G = Graphics.FromImage(B);
	}

	public void AllowTransparent()
	{
		base.SetStyle(ControlStyles.Opaque, false);
		base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		ChangeMouseState(State.MouseNone);
		base.OnMouseLeave(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		ChangeMouseState(State.MouseOver);
		base.OnMouseEnter(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		ChangeMouseState(State.MouseOver);
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			ChangeMouseState(State.MouseDown);
		}
		base.OnMouseDown(e);
	}

	private void ChangeMouseState(State e)
	{
		MouseState = e;
		base.Invalidate();
	}

	public abstract void PaintHook();

	protected sealed override void OnPaint(PaintEventArgs e)
	{
		if (base.Width != 0 && base.Height != 0)
		{
			PaintHook();
			e.Graphics.DrawImage(B, 0, 0);
		}
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		if (base.Width != 0 && base.Height != 0)
		{
			B = new Bitmap(base.Width, base.Height);
			G = Graphics.FromImage(B);
			base.Invalidate();
		}
		base.OnSizeChanged(e);
	}

	protected void DrawCorners(Color c, Rectangle rect)
	{
		checked
		{
			if (!_NoRounding)
			{
				B.SetPixel(rect.X, rect.Y, c);
				B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
				B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
				B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
			}
		}
	}

	protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
	{
		checked
		{
			G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
			G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
		}
	}

	protected void DrawText(HorizontalAlignment a, Color c, int x)
	{
		DrawText(a, c, x, 0);
	}

	protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
	{
		if (!string.IsNullOrEmpty(Text))
		{
			_Size = G.MeasureString(Text, Font).ToSize();
			_Brush = new SolidBrush(c);
			switch (a)
			{
			case HorizontalAlignment.Left:
				G.DrawString(Text, Font, _Brush, (float)x, (float)checked(unchecked(base.Height / 2) - unchecked(_Size.Height / 2) + y));
				break;
			case HorizontalAlignment.Right:
				G.DrawString(Text, Font, _Brush, (float)checked(base.Width - _Size.Width - x), (float)checked(unchecked(base.Height / 2) - unchecked(_Size.Height / 2) + y));
				break;
			case HorizontalAlignment.Center:
				G.DrawString(Text, Font, _Brush, (float)checked(unchecked(base.Width / 2) - unchecked(_Size.Width / 2) + x), (float)checked(unchecked(base.Height / 2) - unchecked(_Size.Height / 2) + y));
				break;
			}
		}
	}

	protected void DrawIcon(HorizontalAlignment a, int x)
	{
		DrawIcon(a, x, 0);
	}

	protected void DrawIcon(HorizontalAlignment a, int x, int y)
	{
		checked
		{
			if (_Image != null)
			{
				switch (a)
				{
				case HorizontalAlignment.Left:
					G.DrawImage(_Image, x, unchecked(base.Height / 2) - unchecked(_Image.Height / 2) + y);
					break;
				case HorizontalAlignment.Right:
					G.DrawImage(_Image, base.Width - _Image.Width - x, unchecked(base.Height / 2) - unchecked(_Image.Height / 2) + y);
					break;
				case HorizontalAlignment.Center:
					G.DrawImage(_Image, unchecked(base.Width / 2) - unchecked(_Image.Width / 2), unchecked(base.Height / 2) - unchecked(_Image.Height / 2));
					break;
				}
			}
		}
	}

	protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
	{
		_Rectangle = new Rectangle(x, y, width, height);
		_Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
		G.FillRectangle(_Gradient, _Rectangle);
	}
}

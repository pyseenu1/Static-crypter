using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class ThirteenComboBox : ComboBox
{
	public enum ColorSchemes
	{
		Light,
		Dark
	}

	private ColorSchemes _ColorScheme;

	private Color _AccentColor;

	private int _StartIndex;

	public ColorSchemes ColorScheme
	{
		get
		{
			return _ColorScheme;
		}
		set
		{
			_ColorScheme = value;
			base.Invalidate();
		}
	}

	public Color AccentColor
	{
		get
		{
			return _AccentColor;
		}
		set
		{
			_AccentColor = value;
			base.Invalidate();
		}
	}

	private int StartIndex
	{
		get
		{
			return _StartIndex;
		}
		set
		{
			_StartIndex = value;
			try
			{
				base.SelectedIndex = value;
			}
			catch
			{
			}
			base.Invalidate();
		}
	}

	public void ReplaceItem(object sender, DrawItemEventArgs e)
	{
		e.DrawBackground();
		try
		{
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(_AccentColor), e.Bounds);
			}
			else
			{
				switch (ColorScheme)
				{
				case ColorSchemes.Dark:
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
					break;
				case ColorSchemes.Light:
					e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
					break;
				}
			}
			switch (ColorScheme)
			{
			case ColorSchemes.Dark:
				e.Graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), e.Font, Brushes.Black, e.Bounds);
				break;
			case ColorSchemes.Light:
				e.Graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), e.Font, Brushes.Black, e.Bounds);
				break;
			}
		}
		catch
		{
		}
	}

	protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
	{
		List<Point> list = new List<Point>();
		list.Add(FirstPoint);
		list.Add(SecondPoint);
		list.Add(ThirdPoint);
		G.FillPolygon(new SolidBrush(Clr), list.ToArray());
	}

	public ThirteenComboBox()
	{
		base.DrawItem += ReplaceItem;
		base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		base.SetStyle(ControlStyles.ResizeRedraw, true);
		base.SetStyle(ControlStyles.UserPaint, true);
		base.SetStyle(ControlStyles.DoubleBuffer, true);
		base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		base.DrawMode = DrawMode.OwnerDrawFixed;
		BackColor = Color.FromArgb(255, 255, 255);
		ForeColor = Color.Black;
		AccentColor = Color.Black;
		ColorScheme = ColorSchemes.Dark;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		Font = new Font("Segoe UI Semilight", 9.75f);
		StartIndex = 0;
		DoubleBuffered = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Bitmap bitmap = new Bitmap(base.Width, base.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		switch (ColorScheme)
		{
		case ColorSchemes.Dark:
			graphics.Clear(Color.FromArgb(255, 255, 255));
			graphics.DrawLine(new Pen(Color.Black, 2f), new Point(base.Width - 18, 10), new Point(base.Width - 14, 14));
			graphics.DrawLine(new Pen(Color.Black, 2f), new Point(base.Width - 14, 14), new Point(base.Width - 10, 10));
			graphics.DrawLine(new Pen(Color.Black), new Point(base.Width - 14, 15), new Point(base.Width - 14, 14));
			break;
		case ColorSchemes.Light:
			graphics.Clear(Color.Black);
			graphics.DrawLine(new Pen(Color.FromArgb(0, 0, 0), 2f), new Point(base.Width - 18, 10), new Point(base.Width - 14, 14));
			graphics.DrawLine(new Pen(Color.FromArgb(0, 0, 0), 2f), new Point(base.Width - 14, 14), new Point(base.Width - 10, 10));
			graphics.DrawLine(new Pen(Color.FromArgb(0, 0, 0)), new Point(base.Width - 14, 15), new Point(base.Width - 14, 14));
			break;
		}
		graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
		try
		{
			switch (ColorScheme)
			{
			case ColorSchemes.Dark:
				graphics.DrawString(Text, Font, Brushes.Black, new Rectangle(7, 0, base.Width - 1, base.Height - 1), new StringFormat
				{
					LineAlignment = StringAlignment.Center,
					Alignment = StringAlignment.Near
				});
				break;
			case ColorSchemes.Light:
				graphics.DrawString(Text, Font, Brushes.Black, new Rectangle(7, 0, base.Width - 1, base.Height - 1), new StringFormat
				{
					LineAlignment = StringAlignment.Center,
					Alignment = StringAlignment.Near
				});
				break;
			}
		}
		catch
		{
		}
		e.Graphics.DrawImage(bitmap, 0, 0);
		graphics.Dispose();
		bitmap.Dispose();
	}
}

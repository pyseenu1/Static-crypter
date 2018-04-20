using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("CheckedChanged")]
public class ChromeRadioButton : ThemeControl154
{
	public delegate void CheckedChangedEventHandler(object sender);

	private int X;

	private Color TextColor;

	private Color G1;

	private Color G2;

	private Color Bo;

	private Color Bb;

	private int _Field = 23;

	private bool _Checked;

	public int Field
	{
		get
		{
			return _Field;
		}
		set
		{
			if (value >= 4)
			{
				_Field = value;
				base.LockHeight = value;
				base.Invalidate();
			}
		}
	}

	public bool Checked
	{
		get
		{
			return _Checked;
		}
		set
		{
			_Checked = value;
			InvalidateControls();
			if (this.CheckedChanged != null)
			{
				this.CheckedChanged(this);
			}
			base.Invalidate();
		}
	}

	public event CheckedChangedEventHandler CheckedChanged;

	public ChromeRadioButton()
	{
		Font = new Font("Segoe UI", 9f);
		base.LockHeight = 23;
		base.SetColor("Text", 0, 0, 0);
		base.SetColor("Gradient top", byte.MaxValue, byte.MaxValue, byte.MaxValue);
		base.SetColor("Gradient bottom", byte.MaxValue, byte.MaxValue, byte.MaxValue);
		base.SetColor("Borders", 0, 0, 0);
		base.SetColor("Bullet", 0, 0, 0);
		base.Width = 180;
	}

	protected override void ColorHook()
	{
		TextColor = base.GetColor("Text");
		G1 = base.GetColor("Gradient top");
		G2 = base.GetColor("Gradient bottom");
		Bb = base.GetColor("Bullet");
		Bo = base.GetColor("Borders");
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		X = e.Location.X;
		base.Invalidate();
	}

	protected override void PaintHook()
	{
		base.G.Clear(BackColor);
		base.G.SmoothingMode = SmoothingMode.HighQuality;
		if (_Checked)
		{
			LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), G1, G2, 90f);
			base.G.FillEllipse(brush, new Rectangle(new Point(0, 0), new Size(18, 18)));
		}
		else
		{
			LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
			base.G.FillEllipse(brush2, new Rectangle(new Point(0, 0), new Size(18, 18)));
		}
		if (base.State == MouseState.Over & X < 25)
		{
			SolidBrush brush3 = new SolidBrush(Color.FromArgb(20, Color.Black));
			base.G.FillEllipse(brush3, new Rectangle(new Point(0, 0), new Size(18, 18)));
		}
		else if (base.State == MouseState.Down & X < 19)
		{
			SolidBrush brush4 = new SolidBrush(Color.FromArgb(18, Color.Black));
			base.G.FillEllipse(brush4, new Rectangle(new Point(0, 0), new Size(18, 18)));
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(new Rectangle(0, 0, 18, 18));
		base.G.SetClip(graphicsPath);
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, 2, 1), Color.FromArgb(150, Color.White), Color.Transparent, 90f);
		base.G.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
		base.G.ResetClip();
		base.G.DrawEllipse(new Pen(Bo), new Rectangle(new Point(0, 0), new Size(18, 18)));
		if (_Checked)
		{
			SolidBrush brush5 = new SolidBrush(Bb);
			base.G.FillEllipse(brush5, new Rectangle(new Point(6, 6), new Size(6, 6)));
		}
		base.DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 24, -2);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!_Checked)
		{
			Checked = true;
		}
		base.OnMouseDown(e);
	}

	protected override void OnCreation()
	{
		InvalidateControls();
	}

	private void InvalidateControls()
	{
		if (base.IsHandleCreated && _Checked)
		{
			foreach (Control control in base.Parent.Controls)
			{
				if (control != this && control is ChromeRadioButton)
				{
					((ChromeRadioButton)control).Checked = false;
				}
			}
		}
	}
}

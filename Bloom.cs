using System.Drawing;

public struct Bloom
{
	public string _Name;

	private Color _Value;

	public string Name => _Name;

	public Color Value
	{
		get
		{
			return _Value;
		}
		set
		{
			_Value = value;
		}
	}

	public string ValueHex
	{
		get
		{
			byte b = _Value.R;
			string str = b.ToString("X2", null);
			b = _Value.G;
			string str2 = b.ToString("X2", null);
			b = _Value.B;
			return "#" + str + str2 + b.ToString("X2", null);
		}
		set
		{
			try
			{
				_Value = ColorTranslator.FromHtml(value);
			}
			catch
			{
			}
		}
	}

	public Bloom(string name, Color value)
	{
		_Name = name;
		_Value = value;
	}
}

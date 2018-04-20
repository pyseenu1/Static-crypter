using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace StaticCrypt4.Utilies
{
	public class FrameGIF
	{
		private Image _gif;

		private FrameDimension _dim;

		private int _frameCount;

		private int _currentFrame = -1;

		private int _step = 1;

		private bool _reverse;

		public bool ReverseAtEnd
		{
			get
			{
				return _reverse;
			}
			set
			{
				_reverse = value;
			}
		}

		public FrameGIF(string path)
		{
			_gif = Image.FromFile(path);
			_dim = new FrameDimension(_gif.FrameDimensionsList[0]);
			_frameCount = _gif.GetFrameCount(_dim);
		}

		public Image GetNextFrame()
		{
			_currentFrame += _step;
			if (_currentFrame >= _frameCount || _currentFrame < 1)
			{
				if (_reverse)
				{
					_step *= -1;
					Thread.Sleep(100);
					_currentFrame += _step;
				}
				else
				{
					_currentFrame = 0;
				}
			}
			return GetFrame(_currentFrame);
		}

		private Image GetFrame(int index)
		{
			_gif.SelectActiveFrame(_dim, index);
			return (Image)_gif.Clone();
		}
	}
}

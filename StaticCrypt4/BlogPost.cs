using System;

namespace StaticCrypt4
{
	internal sealed class BlogPost
	{
		private int _Id;

		private string _Title;

		private int _TimesRead;

		private DateTime _DatePosted;

		private Delegate _GetPostBodyDelegate;

		public int Id => _Id;

		public string Title => _Title;

		public int TimesRead => _TimesRead;

		public DateTime DatePosted => _DatePosted;

		public BlogPost(int id, string title, int timesRead, DateTime datePosted, Delegate getPostBodyDelegate)
		{
			_Id = id;
			_Title = title;
			_TimesRead = timesRead;
			_DatePosted = datePosted;
			_GetPostBodyDelegate = getPostBodyDelegate;
		}

		public string GetPostBody()
		{
			return (string)_GetPostBodyDelegate.DynamicInvoke(_Id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace _04_Balking
{
    class Data
    {
		readonly string _filename;
		string _content;
		bool _changed;

		object _lock = new object();

		public Data(string filename, string content)
		{
			_filename = filename;
			_content = content;
			_changed = true;
		}

		public void Change(string newContent)
		{
			lock (_lock)
			{
				_content = newContent;
				_changed = true;
			}
		}

		public void Save()
		{
			lock (_lock)
			{
				if (!_changed)
				{
					return;
				}

				try
				{
					DoSave();
				}
				catch
				{
					throw;
				}

				_changed = false;
			}
		}

		private void DoSave()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " calls DoSave, content = " + _content);

			try
			{
				File.WriteAllText(_filename, _content);
			}
			catch
			{
				throw;
			}
		}
    }
}

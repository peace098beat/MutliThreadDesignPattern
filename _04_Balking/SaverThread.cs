using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _04_Balking
{
    class SaverThread
    {
		readonly Data _data;
		readonly string _name;

		public SaverThread(string name, Data data)
		{
			_name = name;
			_data = data; 
		}

		public void Run()
		{
			try
			{
				// １秒ごとに保存
				while (true)
				{
					_data.Save();
					Thread.Sleep(1000);
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}

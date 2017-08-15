using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
    class ReaderThread
    {
		readonly Data _data;
		static int _id;
		readonly string _name;

		public ReaderThread(Data data)
		{
			_data = data;
			_name = "Thread No." + _id;
			_id++;
		}

		public void Run()
		{
			try
			{
				while (true)
				{
					string readbuf = new string(_data.Read());
					Console.WriteLine(_name + " reads " + readbuf);
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
    class ReaderThread
    {
		readonly Data _data;

		public ReaderThread(Data data)
		{
			_data = data;
		}

		public void Run()
		{
			try
			{
				while (true)
				{
					char[] readbuf = _data.Read();
					Console.WriteLine(Thread.CurrentThread.Name + " reads " + readbuf.ToString());
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}

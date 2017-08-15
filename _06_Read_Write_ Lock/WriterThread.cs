using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
    class WriterThread
    {
		static readonly Random _random = new Random();
		readonly Data _data;
		readonly string _filler;

		int _index = 0;

		public WriterThread(Data data, string filler)
		{
			_data = data;
			_filler = filler;
		}

		public void Run()
		{
			try
			{
				while (true)
				{
					char c = Nextchar();
					_data.Write(c);
					Thread.Sleep(_random.Next(3000));
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		char Nextchar()
		{
			char c = _filler[_index];
			_index++;
			if(_index >= _filler.Length)
			{
				_index = 0;
			}
			return c;
		}
    }
}

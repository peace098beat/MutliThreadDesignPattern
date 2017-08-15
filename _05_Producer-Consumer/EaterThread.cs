using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _05_Producer_Consumer
{
    class EaterThread
    {
		readonly Random _random;
		readonly Table _table;

		public EaterThread(string name, Table table, int seed)
		{
			Thread.CurrentThread.Name = name;
			_table = table;
			_random = new Random(seed);
		}

		public void Run()
		{
			try
			{
				while (true)
				{
					string cake = _table.Take();
					Thread.Sleep(_random.Next(1000));
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}

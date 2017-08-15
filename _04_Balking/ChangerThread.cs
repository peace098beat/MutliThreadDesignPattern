using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _04_Balking
{
    class ChangerThread
	{
		readonly Data _data;
		readonly string _name;
		readonly Random _random = new Random();

		public ChangerThread(string name, Data data)
		{
			_name = name;
			_data = data;
		}

		public void Run()
		{
			try
			{
				for(int i = 0; true; i++)
				{
					_data.Change("No. " + i);
					Thread.Sleep(_random.Next(1000));   // something working
					_data.Save();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _03_GuardedSuspension
{
    class ServerThread
	{
		readonly Random _random;
		readonly IResultQueue _requestQueue;

		public ServerThread(IResultQueue requestQueue, string name, int seed)
		{
			Thread.CurrentThread.Name = name;
			_requestQueue = requestQueue;
			_random = new Random(seed);
		}

		public void Run()
		{
			for (int i = 0; i < 10000; i++)
			{
				Request request = _requestQueue.GetRequest();

				Console.WriteLine(Thread.CurrentThread.Name + " handles " + request);

				try
				{
					Thread.Sleep(_random.Next(1000));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
	}
}

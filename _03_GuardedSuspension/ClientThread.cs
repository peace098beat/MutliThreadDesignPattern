using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_GuardedSuspension
{
    class ClientThread
    {
		readonly Random _random;
		readonly RequestQueue _requestQueue;

		public ClientThread(RequestQueue requestQueue, string name, int seed)
		{
			Thread.CurrentThread.Name = name;
			_requestQueue = requestQueue;
			_random = new Random(seed);
		}

		public void Run()
		{
			for(int i=0; i < 10000; i++)
			{
				Request request = new Request("No." + i);

				Console.WriteLine(Thread.CurrentThread.Name + " requests " + request);
				_requestQueue.PutRequest(request);

				try
				{
					Thread.Sleep(_random.Next(1000));
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
    }
}

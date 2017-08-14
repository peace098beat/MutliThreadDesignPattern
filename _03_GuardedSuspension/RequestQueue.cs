using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _03_GuardedSuspension
{
    class RequestQueue
    {
		readonly Queue<Request> _queue = new Queue<Request>();
		Object _lock = new Object();

		public Request GetRequest()
		{
			lock (_lock)
			{
				while(_queue.Count == 0)	// ガード条件
				{
					try
					{
						Monitor.Wait(_lock);
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
				return _queue.Dequeue();
			}
		}

		public void PutRequest(Request request)
		{
			lock (_lock)
			{
				_queue.Enqueue(request);
				Monitor.PulseAll(_lock);
			}
		}
    }
}

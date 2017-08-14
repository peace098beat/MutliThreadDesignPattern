using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension
{
	/// <summary>
	/// ConcurrentQueueを使用して実現してmi
	/// る
	/// </summary>
	class RequestQueue2 : IResultQueue
	{
		readonly ConcurrentQueue<Request> _queue = new ConcurrentQueue<Request>();

		public Request GetRequest()
		{
			Request req = null;

			try
			{
				while (!_queue.TryDequeue(out req)) ;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
			return req;
		}

		public void PutRequest(Request request)
		{
			try
			{
				_queue.Enqueue(request);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}

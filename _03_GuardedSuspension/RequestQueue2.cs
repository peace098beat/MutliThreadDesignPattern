using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension
{
    /// <summary>
    /// BlockingCollectionを使用して実現してみる
    /// </summary>
    class RequestQueue2 : IResultQueue
	{
		readonly BlockingCollection<Request> _queue = new BlockingCollection<Request>();

		public Request GetRequest()
		{
			Request req = null;

			try
			{
				req = _queue.Take();
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
				_queue.Add(request);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}

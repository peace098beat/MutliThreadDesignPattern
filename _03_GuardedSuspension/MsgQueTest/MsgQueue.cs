using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension.MsgQueTest
{
    class MsgQueue<T>
	{
		static readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
		
		public T RecvMsg()
		{
			var obj = default(T);

			_queue.TryDequeue(out obj);

			return obj;
		}

		public void SendMsg(T obj)
		{
			_queue.Enqueue(obj);
		}
	}
}

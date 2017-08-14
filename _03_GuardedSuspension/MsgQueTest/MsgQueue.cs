using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension.MsgQueTest
{
    class MsgQueue<T>
	{
		static readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
		
		public bool RecvMsg(out T recv)
		{
			return _queue.TryDequeue(out recv);
		}

		public void SendMsg(T send)
		{
			_queue.Enqueue(send);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _03_GuardedSuspension.MsgQueTest
{
	abstract class MsgQueueClientBase
    {
		protected readonly Random _random;
		protected readonly MsgQueue<string> _queue;
		protected readonly string _name;
		protected static readonly int LoopNum = 10000;

		public MsgQueueClientBase(string name, int seed)
		{
			_name = name;
			_random = new Random(seed);
			_queue = new MsgQueue<string>();
		}

		abstract public void Run();

		protected void Sleep()
		{
			Thread.Sleep(_random.Next(1000));
		}
    }
}

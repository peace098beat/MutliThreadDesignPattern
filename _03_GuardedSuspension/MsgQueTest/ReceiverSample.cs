using System;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension.MsgQueTest
{
    class ReceiverSample : MsgQueueClientBase
	{
		public ReceiverSample(string name, int seed) : base(name, seed)
		{
		}

		public override void Run()
		{
			for (int i = 0; i < LoopNum; i++)
			{
				string recvMsg = null;

				while (!_queue.RecvMsg(out recvMsg))
				{
					Sleep();
				}

				Console.WriteLine(_name + " recv message:" + recvMsg);
			}
		}
	}
}

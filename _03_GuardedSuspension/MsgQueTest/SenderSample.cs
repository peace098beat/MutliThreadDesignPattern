using System;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension.MsgQueTest
{
	class SenderSample : MsgQueueClientBase
	{
		public SenderSample(string name, int seed) : base(name, seed)
		{
		}

		public override void Run()
		{
			for(int i=0; i < LoopNum; i++)
			{
				string sendMsg = "Send Message " + _name + i;

				Console.WriteLine(_name + " send message:" + sendMsg);

				_queue.SendMsg(sendMsg);

				Sleep();
			}
		}
	}
}

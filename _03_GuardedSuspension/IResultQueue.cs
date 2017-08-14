using System;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension
{
    interface IResultQueue
    {
		Request GetRequest();
		void PutRequest(Request request);
    }
}

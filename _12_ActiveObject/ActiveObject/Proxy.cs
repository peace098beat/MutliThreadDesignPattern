using _12_ActiveObject.ActiveObject.MethodRequest;
using _12_ActiveObject.ActiveObject.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject
{
    class Proxy : IActiveObject
    {
        readonly SchedulerThread scheduler;
        readonly Servant servant;

        public Proxy(SchedulerThread scheduler, Servant servant)
        {
            this.scheduler = scheduler;
            this.servant = servant;
        }

        public ResultBase<string> MakeString(int count, char fillchar)
        {
            var future = new FutureResult<string>();
            scheduler.Invoke(new MakeStringRequest(servant, future, count, fillchar));
            return future;
        }

        public void DisplayString(string str)
        {
            scheduler.Invoke(new DisplayStringRequest(servant, str));
        }
    }
}

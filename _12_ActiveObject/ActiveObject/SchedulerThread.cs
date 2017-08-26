using _12_ActiveObject.ActiveObject.MethodRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject
{
    class SchedulerThread
    {
        readonly ActivationQueue queue;

        public SchedulerThread(ActivationQueue queue)
        {
            this.queue = queue;
        }

        public void Invoke(MethodRequest<string> request)
        {
            queue.PutRequest(request);
        }

        public void Run()
        {
            while (true)
            {
                var request = queue.TakeRequest();
                request.Execute();
            }
        }
    }
}

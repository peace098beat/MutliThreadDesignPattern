using System;
using System.Collections.Generic;
using System.Text;
using _12_ActiveObject.ActiveObject.MethodRequest;
using System.Collections.Concurrent;

namespace _12_ActiveObject.ActiveObject
{
    class ActivationQueue
    {
        static readonly int MaxMethodRequest = 100;
        readonly BlockingCollection<MethodRequest<string>> requestQueue;

        public ActivationQueue()
        {
            this.requestQueue = new BlockingCollection<MethodRequest<string>>(MaxMethodRequest);
        }

        public void PutRequest(MethodRequest<string> request)
        {
            this.requestQueue.Add(request);
        }

        public MethodRequest<string> TakeRequest()
        {
            return this.requestQueue.Take();
        }

    }
}

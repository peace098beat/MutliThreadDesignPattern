using System;
using System.Collections.Generic;
using System.Text;
using _12_ActiveObject.ActiveObject.Result;

namespace _12_ActiveObject.ActiveObject.MethodRequest
{
    abstract class MethodRequest<T>
    {
        protected readonly Servant servant;
        protected readonly FutureResult<T> future;
        
        protected MethodRequest(Servant servant, FutureResult<T> future)
        {
            this.servant = servant;
            this.future = future;
        }

        public abstract void Execute();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _12_ActiveObject.ActiveObject.Result
{
    class FutureResult<T> : ResultBase<T>
    {
        ResultBase<T> result;
        bool ready = false;
        object locker = new object();

        public void SetResult(ResultBase<T> result)
        {
            lock (locker)
            {
                this.result = result;
                this.ready = true;
                Monitor.PulseAll(this.locker);
            }
        }

        public override T GetResultValue()
        {
            lock (locker)
            {
                while (!ready)
                {
                    Monitor.Wait(this.locker);
                }

                return result.GetResultValue();
            }
        }
    }
}

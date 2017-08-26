using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _12_ActiveObject.ActiveObject
{
    public class ActiveObjectFactory
    {
        public static IActiveObject CreateActiveObject()
        {
            var queue = new ActivationQueue();
            var scheduler = new SchedulerThread(queue);

            var proxy = new Proxy(scheduler, new Servant());

            Task.Run(() => scheduler.Run());

            return proxy;
        }
    }
}

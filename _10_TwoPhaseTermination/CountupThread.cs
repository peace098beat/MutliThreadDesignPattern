using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_TwoPhaseTermination
{
    class CountupThread
    {
        long _counter = 0;
        volatile bool _shutdownRequested = false;

        public void ShutdownRequest()
        {
            _shutdownRequested = true;
        }

        public bool IsShutdownRequested()
        {
            return _shutdownRequested;
        }

        public Task Task()
        {
            return new Task(()=>{
                try
                {
                    while (!IsShutdownRequested())
                    {
                        // 作業中
                        DoWork();
                    }
                }
                finally
                {
                    // 終了処理中
                    DoShutdown();
                }
            });
        }

        void DoWork()
        {
            _counter++;
            Console.WriteLine("DoWork: counter = " + _counter);
            Thread.Sleep(500);
        }

        void DoShutdown()
        {
            Console.WriteLine("DoShutdown: counter = ", _counter);
        }


    }
}

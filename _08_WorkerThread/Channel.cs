using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_WorkerThread
{
    class Channel
    {
        static readonly int MaxRequest = 100;
        readonly BlockingCollection<Request> _requestQueue = new BlockingCollection<Request>(MaxRequest);
        readonly WorkerThread[] _threadPool;

        public Channel(int threads)
        {
            _threadPool = new WorkerThread[threads];

            for(int i=0; i<_threadPool.Length; i++)
            {
                _threadPool[i] = new WorkerThread("Worker-" + i, this);
            }
        }

        public void StartWorkers()
        {
            foreach(var thread in _threadPool)
            {
                Task.Run(() =>
                {
                    Thread.CurrentThread.Name = thread.Name;
                    thread.Run();
                });
            }
        }

        // BlockingCollectionで排他制御が行われるので、自前の排他処理はしない
        // というか、たとえばlock等を行うとデッドロックになる
        // →内部でwait処理が実行されるため、自前のlockがデッドロックになるっぽい？
        public void PutRequest(Request request)
        {
            _requestQueue.Add(request);
        }

        // BlockingCollectionで排他制御が行われるので、自前の排他処理はしない
        // というか、たとえばlock等を行うとデッドロックになる
        // →内部でwait処理が実行されるため、自前のlockがデッドロックになるっぽい？
        public Request TakeRequest()
        {
            return _requestQueue.Take();
        }
    }
}

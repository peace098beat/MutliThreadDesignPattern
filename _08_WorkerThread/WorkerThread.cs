using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _08_WorkerThread
{
    class WorkerThread
    {
        readonly Channel _channel;
        readonly string _name;
        public string Name => _name;

        public WorkerThread(string name, Channel channel)
        {
            _name = name;
            _channel = channel;
        }

        public Task Run()
        {
            while (true)
            {
                Request request = _channel.TakeRequest();
                request.Execute();
            }
        }
    }
}

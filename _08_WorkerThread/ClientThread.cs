using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _08_WorkerThread
{
    class ClientThread
    {
        readonly Channel _channel;
        static readonly Random _random = new Random();

        public ClientThread(string name, Channel channel)
        {
            Thread.CurrentThread.Name = name;
            _channel = channel;
        }

        public void Run()
        {
            try
            {
                for (int i = 0; true; i++)
                {
                    Request request = new Request(Thread.CurrentThread.Name, i);
                    _channel.PutRequest(request);
                    Thread.Sleep(_random.Next(1000));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

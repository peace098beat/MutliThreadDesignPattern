using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _08_WorkerThread
{
    class Request
    {
        readonly string _name;  // 依頼者
        readonly int _number;   // リクエスト番号
        static readonly Random _random = new Random();

        public Request(string name, int number)
        {
            _name = name;
            _number = number;
        }

        public void Execute()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " executes " + this);
            Thread.Sleep(_random.Next(1000));
        }

        public override string ToString()
        {
            return "[ Request from " + _name + " No, " + _number + " ]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _09_Future
{
    class RealData : IData
    {
        readonly string _content;

        public RealData(int count, char c)
        {
            Console.WriteLine("        making RealData(" + count + ", " + c + ") BEGIN");

            char[] buffer = new char[count];
            for(int i=0; i<count; i++)
            {
                buffer[i] = c;
                Thread.Sleep(100);
            }

            Console.WriteLine("        making RealData(" + count + ", " + c + ") END");
            _content = new string(buffer);
        }

        public string GetContext()
        {
            return _content;
        }
    }
}

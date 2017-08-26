using System;
using System.Collections.Generic;
using System.Text;
using _12_ActiveObject.ActiveObject.Result;
using System.Threading;

namespace _12_ActiveObject.ActiveObject
{
    class Servant : IActiveObject
    {
        public ResultBase<string> MakeString(int count, char fillchar)
        {
            char[] buffer = new char[count];

            for(int i = 0; i < count; i++)
            {
                buffer[i] = fillchar;
                Thread.Sleep(100);
            }

            return new RealResult<string>(new string(buffer));
        }

        public void DisplayString(string str)
        {
            Console.WriteLine("DisplayString: " + str);
            Thread.Sleep(10);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using _12_ActiveObject.ActiveObject;
using System.Threading;
using _12_ActiveObject.ActiveObject.Result;

namespace _12_ActiveObject
{
    public class MakerClientThread
    {
        readonly IActiveObject activeObject;
        readonly char fillchar;
        readonly string name;

        public MakerClientThread(string name, IActiveObject activeObject)
        {
            this.name = name;
            this.activeObject = activeObject;
            this.fillchar = name[0];
        }

        public void Run()
        {
            for(int i=0; true; i++)
            {
                ResultBase<string> result = this.activeObject.MakeString(i, fillchar);
                Thread.Sleep(10);
                var value = result.GetResultValue();
                Console.WriteLine(this.name + ": value = " + value);
            }
        }
    }
}

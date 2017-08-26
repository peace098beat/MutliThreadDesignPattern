using System;
using System.Collections.Generic;
using System.Text;
using _12_ActiveObject.ActiveObject;
using System.Threading;

namespace _12_ActiveObject
{
    class DisplayClientThread
    {
        readonly IActiveObject activeObject;
        readonly string name;

        public DisplayClientThread(string name, IActiveObject activeObject)
        {
            this.name = name;
            this.activeObject = activeObject;
        }

        public void Run()
        {
            for(int i = 0; true; i++)
            {
                string str = this.name + " " + i;
                this.activeObject.DisplayString(str);
                Thread.Sleep(200);
            }
        }
    }
}

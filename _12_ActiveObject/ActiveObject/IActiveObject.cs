using _12_ActiveObject.ActiveObject.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject
{
    public interface IActiveObject
    {
        ResultBase<string> MakeString(int count, char fillchar);
        void DisplayString(string str);
    }
}

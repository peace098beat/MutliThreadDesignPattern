using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject.Result
{
    public abstract class ResultBase<T>
    {
        public abstract T GetResultValue();
    }
}

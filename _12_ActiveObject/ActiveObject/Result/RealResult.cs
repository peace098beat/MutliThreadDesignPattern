using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject.Result
{
    class RealResult<T> : ResultBase<T>
    {
        readonly T resultValue;

        public RealResult(T resultValue)
        {
            this.resultValue = resultValue;
        }

        public override T GetResultValue()
        {
            return this.resultValue;
        }
    }
}

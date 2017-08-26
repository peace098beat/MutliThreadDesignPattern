using _12_ActiveObject.ActiveObject.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject.MethodRequest
{
    class MakeStringRequest : MethodRequest<string>
    {
        readonly int count;
        readonly char fillchar;

        public MakeStringRequest(Servant servant, FutureResult<string> future, int count, char fillchar) 
            : base(servant, future)
        {
            this.count = count;
            this.fillchar = fillchar;
        }

        public override void Execute()
        {
            var result = servant.MakeString(count, fillchar);
            future.SetResult(result);
        }
    }
}

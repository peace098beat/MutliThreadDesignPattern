using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ActiveObject.ActiveObject.MethodRequest
{
    class DisplayStringRequest : MethodRequest<string>
    {
        readonly string str;

        public DisplayStringRequest(Servant servant, string str)
            :base(servant, null)
        {
            this.str = str;
        }

        public override void Execute()
        {
            servant.DisplayString(str);
        }
    }
}

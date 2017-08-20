using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _09_Future
{
    class FutureData : IData
    {
        RealData _realdata = null;
        bool _ready = false;

        object _lock = new object();

        public void SetRealData(RealData realdata)
        {
            lock (_lock)
            {
                if (_ready)
                {
                    return; // balk
                }
                _realdata = realdata;
                _ready = true;
                Monitor.PulseAll(_lock);
            }
        }

        public string GetContext()
        {
            lock (_lock)
            {
                while (!_ready)
                {
                    Monitor.Wait(_lock);
                }

                return _realdata.GetContext();
            }
        }
    }
}

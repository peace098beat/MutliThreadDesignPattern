using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _09_Future
{
    class FutureData : IData
    {
        Task _task;
        RealData _realdata;

        public FutureData(int count, char c)
        {
            _task = new Task(() =>
            {
                _realdata = new RealData(count, c);
            });
            _task.Start();
        }

        public string GetContext()
        {
            Task.Run(async () => await _task).Wait();
            return _realdata.GetContext();
        }
    }
}

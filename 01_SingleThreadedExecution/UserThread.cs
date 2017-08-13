using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_SingleThreadedExecution
{
    class UserThread
    {
		readonly Gate _gate;
		readonly string _myname;
		readonly string _myaddress;

		public UserThread(Gate gate, string myname, string myaddress)
		{
			_gate = gate;
			_myname = myname;
			_myaddress = myaddress;
		}

		public Task Run()
		{
			Console.WriteLine(_myname + " BEGIN");
			while (true)
			{
				_gate.Pass(_myname, _myaddress);
				Thread.Sleep(10);
			}
		}
    }
}

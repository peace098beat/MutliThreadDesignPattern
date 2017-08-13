using System;
using System.Collections.Generic;
using System.Text;

namespace _01_SingleThreadedExecution
{
    class Gate
    {
		int _counter = 0;
		string _name = "Nobody";
		string _address = "Nowhere";

		public void Pass(string name, string address)
		{
			_counter++;
			_name = name;
			_address = address;
			Check();
		}

		public override string ToString()
		{
			return "No." + _counter + ": " + _name + ", " + _address;
		}

		public void Check()
		{
			if(_name[0] != _address[0])
			{
				Console.WriteLine("******* BROKEN ******* " + this.ToString());
			}
		}
	}
}

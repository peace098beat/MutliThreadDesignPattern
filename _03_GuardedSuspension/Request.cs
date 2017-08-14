using System;
using System.Collections.Generic;
using System.Text;

namespace _03_GuardedSuspension
{
    class Request
    {
		readonly string _name;
		public string Name => _name;

		public Request(string name)
		{
			_name = name;
		}

		public override string ToString()
		{
			return "[ Request " + _name + " ]";
		}
	}
}

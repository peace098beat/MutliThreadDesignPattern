using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Immutable
{
    class Person
    {
		readonly string _name;
		public string Name => _name;

		readonly string _address;
		public string Address => _address;

		public Person(string name, string address)
		{
			_name = name;
			_address = address;
		}

		public override string ToString()
		{
			return "[ Person: name = " + _name + ", address = " + _address + " ]";
		}
	}
}

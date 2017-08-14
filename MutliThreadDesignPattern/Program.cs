using System;
using System.Collections.Generic;
using System.Linq;

namespace MutliThreadDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			List<string> list = new List<string>(100);

			list.ForEach(v => v = "test");
		}
    }
}
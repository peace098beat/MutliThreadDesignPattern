using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _07_Thread_Per_Message
{
    class Host
    {
		readonly Helper _helper = new Helper();

		public void Request(int count, char c)
		{
			Console.WriteLine("  Request(" + count + ", " + c + ") BEGIN");

			Task.Run(() =>
			{
				_helper.Handle(count, c);
			});

			Console.WriteLine("  Request(" + count + ", " + c + ") END");
		}
	}
}

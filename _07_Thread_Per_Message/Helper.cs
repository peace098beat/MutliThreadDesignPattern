using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _07_Thread_Per_Message
{
    class Helper
    {
		public void Handle(int count, char c)
		{
			Console.WriteLine("    Handle(" + count + ", " + c + ") BEGIN");

			for(int i=0; i<count; i++)
			{
				Slowly();
				Console.Write(c);
			}
			Console.WriteLine("");

			Console.WriteLine("    Handle(" + count + ", " + c + ") END");
		}

		void Slowly()
		{
			Thread.Sleep(100);
		}
    }
}

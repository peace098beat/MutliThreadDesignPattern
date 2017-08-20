using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _09_Future
{
    class Host
    {
        public IData Request(int count, char c)
        {
            Console.WriteLine("    request(" + count + ", " + c + ") BEGIN");

            var futureData = new FutureData(count, c);

            Console.WriteLine("    request(" + count + ", " + c + ") END");

            return futureData;
        }
    }
}

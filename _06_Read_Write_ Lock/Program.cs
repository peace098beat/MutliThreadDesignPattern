using System;
using System.Threading.Tasks;

namespace _06_Read_Write_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
			Data data = new Data(10);

			Task[] tasks = new Task[8]
			{
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new ReaderThread(data).Run()),
				Task.Run(()=>new WriterThread(data, "ABCDEFGHIJKLMNOPQRSPUVWXYZ").Run()),
				Task.Run(()=>new WriterThread(data, "abcdefghijklmnopqrstuvwxyz").Run()),
			};

			Task.WaitAll(tasks);
        }
    }
}
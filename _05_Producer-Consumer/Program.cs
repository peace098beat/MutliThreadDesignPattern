using System;
using System.Threading.Tasks;

namespace _05_Producer_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
			var table = new Table(3);   // ケーキ３個までおけるテーブル

			Task.Run(() => new MakerThread(nameof(MakerThread) + "-1", table, 12345).Run());
			Task.Run(() => new MakerThread(nameof(MakerThread) + "-2", table, 23456).Run());
			Task.Run(() => new MakerThread(nameof(MakerThread) + "-3", table, 34567).Run());

			Task.Run(() => new EaterThread(nameof(EaterThread) + "-1", table, 45678).Run());
			Task.Run(() => new EaterThread(nameof(EaterThread) + "-2", table, 56789).Run());
			Task.Run(() => new EaterThread(nameof(EaterThread) + "-3", table, 67890).Run());

			Console.ReadKey();
        }
    }
}
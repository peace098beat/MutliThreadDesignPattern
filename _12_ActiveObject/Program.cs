using System;
using _12_ActiveObject.ActiveObject;
using System.Threading.Tasks;

namespace _12_ActiveObject
{
    class Program
    {
        static void Main(string[] args)
        {
            IActiveObject activeObject = ActiveObjectFactory.CreateActiveObject();

            Task.Run(() => new MakerClientThread("Alice", activeObject).Run());
            Task.Run(() => new MakerClientThread("Bobby", activeObject).Run());
            Task.Run(() => new DisplayClientThread("Chirs", activeObject).Run());

            Console.ReadKey();
        }
    }
}

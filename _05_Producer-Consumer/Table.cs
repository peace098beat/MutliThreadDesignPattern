using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _05_Producer_Consumer
{
    class Table
    {
		readonly string[] _buffer;

		int _tail;
		int _head;
		int _count;

		object _lock = new object();

		public Table(int count)
		{
			_buffer = new string[count];
			_head = 0;
			_tail = 0;
			_count = 0;
		}

		public void Put(string cake)
		{
			lock (_lock)
			{
				Console.WriteLine(Thread.CurrentThread.Name + " puts " + cake);

				try
				{
					while (_count >= _buffer.Length)
					{
						Monitor.Wait(_lock);
					}

					_buffer[_tail] = cake;
					_tail = (_tail + 1) % _buffer.Length;
					_count++;
					Monitor.PulseAll(_lock);
				}
				catch
				{
					throw;
				}
			}
		}

		public string Take()
		{
			lock (_lock)
			{
				try
				{
					while(_count <= 0)
					{
						Monitor.Wait(_lock);
					}

					string cake = _buffer[_head];
					_head = (_head + 1) % _buffer.Length;
					_count--;
					Monitor.PulseAll(_lock);

					Console.WriteLine(Thread.CurrentThread.Name + " takes " + cake);
					return cake;
				}
				catch
				{
					throw;
				}
			}
		}
    }
}

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

		readonly object _lock = new object();
		readonly ManualResetEventSlim _resetevent = new ManualResetEventSlim();

		public Table(int count)
		{
			_buffer = new string[count];
			_head = 0;
			_tail = 0;
			_count = 0;
		}

		public void Put(string cake, CancellationToken token)
		{
			Console.WriteLine(Thread.CurrentThread.Name + " puts " + cake);

			while (true)
			{
				lock (_lock)
				{
					if (_count < _buffer.Length)
					{
						break;
					}
					_resetevent.Reset();
				}
				try
				{
					_resetevent.Wait(Timeout.Infinite, token);
				}
				catch
				{
					throw;
				}
			}

			lock (_lock)
			{
				_buffer[_tail] = cake;
				_tail = (_tail + 1) % _buffer.Length;
				_count++;
				_resetevent.Set();
			}
		}

		public string Take(CancellationToken token)
		{
			while (true)
			{
				lock (_lock)
				{
					if (_count > 0)
					{
						break;
					}
					_resetevent.Reset();
				}
				try
				{
					_resetevent.Wait(Timeout.Infinite, token);
				}
				catch
				{
					throw;
				}
			}

			lock (_lock)
			{

				string cake = _buffer[_head];
				_head = (_head + 1) % _buffer.Length;
				_count--;
				_resetevent.Set();

				Console.WriteLine(Thread.CurrentThread.Name + " takes " + cake);
				return cake;
			}
		}
    }
}

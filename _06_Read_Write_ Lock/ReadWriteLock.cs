using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
	/// <summary>
	/// C#でlockとManualResetEventSlimを使用して処理すると、すごく可読性が低くなる・・・
	/// </summary>
	class ReadWriteLock
    {
		int _readingReaders = 0;
		int _waitingWriters = 0;
		int _writingWriters = 0;
		bool _preferWriter = true;  // 書くのを優先するならtrue

		object _lock = new object();
		readonly ManualResetEventSlim _resetevent = new ManualResetEventSlim();

		readonly CancellationToken _token;

		public ReadWriteLock(CancellationToken token)
		{
			_token = token;
		}

		public void ReadLock()
		{
			while (true)
			{
				lock (_lock)
				{
					if ((_writingWriters == 0) && (!_preferWriter || (_waitingWriters == 0)))
					{
						break;
					}
					_resetevent.Reset();
				}
				try
				{
					_resetevent.Wait(Timeout.Infinite, _token);
				}
				catch { throw; }
			}

			_readingReaders++;	
		}

		public void ReadUnlock()
		{
			lock (_lock)
			{
				_readingReaders--;	
				_preferWriter = true;
				_resetevent.Set();
			}
		}

		public void WriteLock()
		{
			while (true)
			{
				lock (_lock)
				{
					_waitingWriters++;

					if((_readingReaders == 0) && (_writingWriters == 0))
					{
						break;
					}
					_resetevent.Reset();
				}
				try
				{
					_resetevent.Wait(Timeout.Infinite, _token);
				}
				catch { throw; }
				finally
				{
					lock (_lock)
					{
						_waitingWriters--;
					}
				}
			}

			lock (_lock)
			{
				_writingWriters++;
			}
    }
}

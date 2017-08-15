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

		public void ReadLock()
		{
			lock (_lock)
			{
				try
				{
					while ((_writingWriters > 0) || (_preferWriter && (_waitingWriters > 0)))
					{
						Monitor.Wait(_lock);
					}
				}
				catch { throw; }

				_readingReaders++;
			}
		}

		public void ReadUnlock()
		{
			lock (_lock)
			{
				_readingReaders--;	

				_preferWriter = true;
				Monitor.PulseAll(_lock);
			}
		}

		public void WriteLock()
		{
			lock (_lock)
			{
				_waitingWriters++;
				try
				{
					while ((_readingReaders > 0) || (_writingWriters > 0))
					{
						Monitor.Wait(_lock);
					}
				}
				catch { throw; }
				finally
				{
					_waitingWriters--;
				}

				_writingWriters++;
			}
		}

		public void WriteUnlock()
		{
			lock (_lock)
			{
				_writingWriters--;

				_preferWriter = false;
				Monitor.PulseAll(_lock);
			}
		}
    }
}

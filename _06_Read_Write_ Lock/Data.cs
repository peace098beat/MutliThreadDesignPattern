using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
    class Data
    {
		readonly char[] _buffer;
		//readonly ReadWriteLock _rwLock = new ReadWriteLock();
		readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

		public Data(int size)
		{
			_buffer = new char[size];
			for(int i=0; i < size; i++)
			{
				_buffer[i] = '*';
			}
		}

		public char[] Read()
		{
			try
			{
				_rwLock.EnterReadLock();
				return DoRead();
			}
			finally
			{
				_rwLock.ExitReadLock();
			}
		}

		public void Write(char c)
		{
			try
			{
				_rwLock.EnterWriteLock();
				DoWrite(c);
			}
			finally
			{
				_rwLock.ExitWriteLock();
			}
		}

		char[] DoRead()
		{
			char[] newbuf = new char[_buffer.Length];
			for (int i = 0; i < _buffer.Length; i++)
			{
				newbuf[i] = _buffer[i];
				Slowy();
			}
			return newbuf;
		}

		void DoWrite(char c)
		{
			for(int i=0; i<_buffer.Length; i++)
			{
				_buffer[i] = c;
				Slowy();
			}
		}

		void Slowy()
		{
			Thread.Sleep(50);
		}
    }
}

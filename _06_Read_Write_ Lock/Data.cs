using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _06_Read_Write_Lock
{
    class Data
    {
		readonly char[] _buffer;
		readonly ReadWriteLock _rwLock = new ReadWriteLock();

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
				_rwLock.ReadLock();
				return DoRead();
			}
			finally
			{
				_rwLock.ReadUnlock();
			}
		}

		public void Write(char c)
		{
			try
			{
				_rwLock.WriteLock();
				DoWrite(c);
			}
			finally
			{
				_rwLock.WriteUnlock();
			}
		}

		char[] DoRead()
		{
			char[] newbuf = new char[_buffer.Length];
			Array.Copy(_buffer, newbuf, _buffer.Length);
			Slowy();
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

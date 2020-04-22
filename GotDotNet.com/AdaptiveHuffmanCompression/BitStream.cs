// Stephen Toub
// stoub@microsoft.com
//
// BitStream.cs
// Stream for reading and writing individual bits from and to another stream.
//
// v1.0.0
// July 17th, 2002

#region Namespaces
using System;
using System.IO;
#endregion

namespace Toub.IO
{
	/// <summary>Stream for reading and writing individual bits from and to another stream.</summary>
	public class BitStream : Stream, IDisposable
	{
		#region Member Variables
		/// <summary>The number of bits that have been processed in the stream.</summary>
		private long _bitsProcessed;
		/// <summary>The direction in which this stream is processing bits.</summary>
		private StreamDirection _direction;
		/// <summary>The underlying stream for the bit stream (i.e. a FileStream).</summary>
		private Stream _baseStream;
		/// <summary>The bit buffer for buffering read or written bits.</summary>
		private byte _bitBuffer;
		/// <summary>The current position in the bit buffer.</summary>
		private int _curPos;
		/// <summary>Whether the stream is open.  Used primarily when closing the stream.</summary>
		private bool _open;
		/// <summary>Whether to close the base stream when this stream is closed.</summary>
		private bool _closeBaseStream;
		#endregion

		#region Construction
		/// <summary>Initialize the BitStream.</summary>
		/// <param name="baseStream">The underlying stream for the bit stream.</param>
		/// <param name="direction">The direction of the stream.</param>
		public BitStream(Stream baseStream, StreamDirection direction)
		{
			// Store the data
			_direction = direction;
			_baseStream = baseStream;

			// Make sure we can process the underlying stream in the requested direction
			if (direction == StreamDirection.Read && !baseStream.CanRead) 
			{
				throw new ArgumentException("Can't read from the underlying stream.");
			} 
			else if (direction == StreamDirection.Write && !baseStream.CanWrite) 
			{
				throw new ArgumentException("Can't write to the underlying stream.");
			}

			// Setup stream
			_bitBuffer = 0;
			_curPos = 0;
			_bitsProcessed = 0;
			_open = true;
			_closeBaseStream = true;
		}
		#endregion

		#region Properties
		/// <summary>Gets whether we can read bits from this stream.</summary>
		public override bool CanRead { get { return _open && _direction == StreamDirection.Read; } }
        
		/// <summary>Gets whether we can seek on this stream.  Always returns false.</summary>
		public override bool CanSeek { get { return false; } }
        
		/// <summary>Gets whether we can write bits to this stream.</summary>
		public override bool CanWrite { get { return _open && _direction == StreamDirection.Write; } }

		/// <summary>Not Supported.</summary>
		public override long Length { get { throw new NotSupportedException("Can't seek on a bit stream."); } }
        
		/// <summary>Gets the number of bits processed by the stream (either read or written).</summary>
		public override long Position
		{
			get { return _bitsProcessed; }
			set { throw new NotSupportedException("Can't seek on a bit stream."); }
		}

		/// <summary>
		/// Gets or sets whether to close the base stream when this stream is closed.
		/// Default is true.
		/// </summary>
		public bool CloseBaseStream { get { return _closeBaseStream; } set { _closeBaseStream = value; } }
		#endregion
        
		#region Writing
		/// <summary>Writes a bit to the output stream.</summary>
		/// <param name="bit">The bit to be written.</param>
		public void WriteBit(int bit)
		{
			// Make sure we can write and that we have valid input.
			if (!CanWrite) throw new NotSupportedException("Can't write on this stream.");
			if (bit != 0 && bit != 1) throw new ArgumentException("The bit must be 0 or 1.", "bit");

			// Write the bit into the buffer
			_bitBuffer = (byte)(_bitBuffer | (bit << (7-_curPos)));

			// Move the internal pointer along.  If we've reached the end
			// of the buffer, dump it into the real stream.
			if (++_curPos == 8)
			{
				_baseStream.WriteByte(_bitBuffer);
				_bitBuffer = 0;
				_curPos = 0;
			}

			// Update our count of how many bits we've processed
			_bitsProcessed++;
		}

		/// <summary>Writes a byte worth of bits to the output stream.</summary>
		/// <param name='value'>The byte to be written.</param>
		public override void WriteByte(byte value)
		{
			// Write out each bit in the number
			for(int i=0; i<8; i++) 
			{
				// Get the bit from the value buffer and write it
				int bit = ((1 << (7 - i)) & value) > 0 ? 1 : 0;
				WriteBit(bit);
			}
		}
        
		/// <summary>Writes an array of bits (integers with 0 or 1 values) to the stream.</summary>
		/// <param name="bits">The array of bits to write.</param>
		/// <param name="offset">The offset into the array at which to begin writing.</param>
		/// <param name="count">The number of bits to write.</param>
		public void Write(int [] bits, int offset, int count)
		{
			// Write each bit in the array.
			for(int i=offset; i<offset+count; i++) WriteBit(bits[i]);
		}

		/// <summary>Writes a buffer's worth of bytes to the output stream.</summary>
		/// <param name='buffer'>The bytes to be written.</param>
		/// <param name='offset'>The position in the array of bytes at which to begin writing.</param>
		/// <param name='count'>The number of bytes to write.</param>
		public override void Write(byte [] buffer, int offset, int count)
		{
			// Write each byte to the output stream.
			for(int i=offset; i<offset+count; i++) WriteByte(buffer[i]);
		}
		#endregion
        
		#region Reading
		/// <summary>Reads a bit from the input stream.</summary>
		/// <returns>0 or 1, or -1 if at the end of the stream.</returns>
		public int ReadBit()
		{
			int bit, tempBuffer;

			// Make sure we can read.
			if (!CanRead) throw new NotSupportedException("Can't read on this stream.");

			// Now read the bit.  If we need to get more data from the stream, do so.
			if (_curPos == 0)
			{
				// We need to read another byte from the stream.  If the
				// stream is empty, return -1.  Otherwise, fill the bitbuffer
				// with the read in byte.
				if ((tempBuffer = _baseStream.ReadByte()) == -1)
				{
					_bitBuffer = 0;
					return -1;
				} 
				else _bitBuffer = (byte)tempBuffer;
			}

			// Grab the appropriate bit from the buffer and move to the next bit.
			bit = ((1 << (7 - _curPos)) & _bitBuffer) > 0 ? 1 : 0;
			_curPos = (_curPos + 1) % 8;

			// Update our count of how many bits we've processed
			_bitsProcessed++;

			// Return the newly read bit
			return bit;
		}

		/// <summary>Read a byte from the input stream.</summary>
		/// <returns>The byte read from the input stream.</returns>
		public override int ReadByte()
		{
			byte tempBuffer = 0;

			// Get enough bits to fill a byte.
			for(int i=0; i<8; i++) 
			{
				// Read a bit and make sure we were able to get one.
				// Then store it into our byte.
				int bit = ReadBit();
				if (bit < 0) return bit;
				tempBuffer = (byte)(tempBuffer | (bit << (7-i)));
			}

			// Return the byte.
			return tempBuffer;
		}

		/// <summary>Read a series of bits from the input stream and store them in an array.</summary>
		/// <param name='bits'>The destination buffer for the read bits.</param>
		/// <param name='offset'>The position in the buffer at which to begin storing the read bits.</param>
		/// <param name='count'>The number of bytes to read.</param>
		/// <returns>The number of bits actually read.</returns>
		public int Read(int [] bits, int offset, int count)
		{
			// Read each bit.  If it is valid, store it to the buffer.
			// Otherwise return how many bytes we've already read.  If we read
			// all required bytes, return the requested number.
			for(int i=offset; i<offset+count; i++) 
			{
				int bit = ReadBit();
				if (bit >= 0) bits[i] = bit;
				else return i-offset;
			}
			return count;
		}
        
		/// <summary>Read an array of bytes from the input stream.</summary>
		/// <param name='buffer'>The destination buffer for the read bytes.</param>
		/// <param name='offset'>The position in the buffer at which to begin storing the read bytes.</param>
		/// <param name='count'>The number of bytes to read.</param>
		/// <returns>The number of bytes actually read.</returns>
		public override int Read(byte [] buffer, int offset, int count)
		{
			// Read each byte.  If it is valid, store it to the buffer.
			// Otherwise return how many bytes we've already read.  If we read
			// all required bytes, return the requested number.
			for(int i=offset; i<offset+count; i++) 
			{
				int readByte = ReadByte();
				if (readByte >= 0) buffer[i] = (byte)readByte;
				else return i-offset;
			}
			return count;
		}
		#endregion

		#region Other Stream Operations
		/// <summary>Flushes the stream underlying the BitStream.</summary>
		public override void Flush() 
		{ 
			// Just flush the base stream.  This may not flush up to 8 bits still stored in
			// our buffer, but flushing those could cause problems if there is more writing
			// to be done.
			_baseStream.Flush();
		}
        
		/// <summary>Flushes the last bits to the underlying stream and closes it.</summary>
		public override void Close() 
		{
			// Only do work if we're still open
			if (_open)
			{
				// If there are any bits remaining in the buffer, and if we're writing,
				// write the bits to the buffer.
				if (CanWrite && _curPos != 0) _baseStream.WriteByte(_bitBuffer);

				// Close the stream and reset the buffers for idealogical reasons.
				if (CloseBaseStream) _baseStream.Close(); 
				_baseStream = null;
				_bitBuffer = 0;
				_curPos = 0;

				// Mark as closed and cleaned up
				_open = false;
			}
		}
		#endregion

		#region IDisposable and Finalization
		/// <summary>Clean up after the Huffman stream.</summary>
		void IDisposable.Dispose()
		{
			// Close the stream and suppress finalization
			Close();
			GC.SuppressFinalize(this);
		}

		/// <summary>Clean up after the Huffman stream.</summary>
		~BitStream()
		{
			Close();
		}
		#endregion
        
		#region Not Supported Stream Operations
		/// <summary>Sets the length of the stream.  Unsupported.</summary>
		public override void SetLength(long value) 
		{ 
			throw new NotSupportedException("Can't set the length of a BitStream."); 
		}
        
		/// <summary>Not Supported.</summary>
		public override long Seek(long offset, System.IO.SeekOrigin origin)
		{
			throw new NotSupportedException("Can't seek on a bit stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override void EndWrite(System.IAsyncResult asyncResult)
		{
			throw new NotSupportedException("Can't asynchronously access a bit stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override System.IAsyncResult BeginWrite(System.Byte[] buffer, int offset, int count, System.AsyncCallback callback, object state)
		{
			throw new NotSupportedException("Can't asynchronously access a bit stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override int EndRead(System.IAsyncResult asyncResult)
		{
			throw new NotSupportedException("Can't asynchronously access a bit stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override System.IAsyncResult BeginRead(System.Byte[] buffer, int offset, int count, System.AsyncCallback callback, object state)
		{
			throw new NotSupportedException("Can't asynchronously access a bit stream.");
		}
		#endregion
	}

	/// <summary>The direction in which a bit stream is processing bits.</summary>
	public enum StreamDirection 
	{
		/// <summary>Reading from the stream.</summary>
		Read,
		/// <summary>Writing to the stream.</summary>
		Write 
	}
}



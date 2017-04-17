using System;
using System.IO;

namespace Emu.Types
{
	/// <summary>
	/// Wraps a stream for all operations except Close and Dispose, which
	/// merely flush the stream and prevent further operations from being
	/// carried out using this wrapper.
	/// </summary>
	public sealed class NonClosingStreamWrapper : Stream
	{
		/// <summary>
		/// Creates a new instance of the class, wrapping the specified stream.
		/// </summary>
		/// <param name="stream">The stream to wrap. Must not be null.</param>
		/// <exception cref="ArgumentNullException">stream is null</exception>
		public NonClosingStreamWrapper(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.stream = stream;
		}

		Stream stream;
		/// <summary>
		/// Stream wrapped by this wrapper
		/// </summary>
		public Stream BaseStream => this.stream;

		/// <summary>
		/// Whether this stream has been closed or not
		/// </summary>
		Boolean closed = false;

		/// <summary>
		/// Throws an InvalidOperationException if the wrapper is closed.
		/// </summary>
		void CheckClosed()
		{
			if (this.closed)
			{
				throw new InvalidOperationException("Wrapper has been closed or disposed");
			}
		}

		/// <summary>
		/// Indicates whether or not the underlying stream can be read from.
		/// </summary>
		public override Boolean CanRead => this.closed ? false : this.stream.CanRead;
		/// <summary>
		/// Indicates whether or not the underlying stream supports seeking.
		/// </summary>
		public override Boolean CanSeek => this.closed ? false : this.stream.CanSeek;
		/// <summary>
		/// Indicates whether or not the underlying stream can be written to.
		/// </summary>
		public override Boolean CanWrite => this.closed ? false : this.stream.CanWrite;
		
		/// <summary>
		/// Flushes the underlying stream.
		/// </summary>
		public override void Flush()
		{
			CheckClosed();
			this.stream.Flush();
		}

		/// <summary>
		/// Returns the length of the underlying stream.
		/// </summary>
		public override Int64 Length
		{
			get
			{
				CheckClosed();
				return this.stream.Length;
			}
		}

		/// <summary>
		/// Gets or sets the current position in the underlying stream.
		/// </summary>
		public override Int64 Position
		{
			get
			{
				CheckClosed();
				return this.stream.Position;
			}
			set
			{
				CheckClosed();
				this.stream.Position = value;
			}
		}

		/// <summary>
		/// Reads a sequence of bytes from the underlying stream and advances the 
		/// position within the stream by the number of bytes read.
		/// </summary>
		/// <param name="buffer">
		/// An array of bytes. When this method returns, the buffer contains 
		/// the specified Byte array with the values between offset and 
		/// (offset + count- 1) replaced by the bytes read from the underlying source.
		/// </param>
		/// <param name="offset">
		/// The zero-based Byte offset in buffer at which to begin storing the data 
		/// read from the underlying stream.
		/// </param>
		/// <param name="count">
		/// The maximum number of bytes to be read from the 
		/// underlying stream.
		/// </param>
		/// <returns>The total number of bytes read into the buffer. 
		/// This can be less than the number of bytes requested if that many 
		/// bytes are not currently available, or zero (0) if the end of the 
		/// stream has been reached.
		/// </returns>
		public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count)
		{
			CheckClosed();
			return this.stream.Read(buffer, offset, count);
		}

		/// <summary>
		/// Reads a Byte from the stream and advances the position within the 
		/// stream by one Byte, or returns -1 if at the end of the stream.
		/// </summary>
		/// <returns>The unsigned Byte cast to an Int32, or -1 if at the end of the stream.</returns>
		public override Int32 ReadByte()
		{
			CheckClosed();
			return this.stream.ReadByte();
		}

		/// <summary>
		/// Sets the position within the current stream.
		/// </summary>
		/// <param name="offset">A Byte offset relative to the origin parameter.</param>
		/// <param name="origin">
		/// A value of type SeekOrigin indicating the reference 
		/// point used to obtain the new position.
		/// </param>
		/// <returns>The new position within the underlying stream.</returns>
		public override Int64 Seek(Int64 offset, SeekOrigin origin)
		{
			CheckClosed();
			return this.stream.Seek(offset, origin);
		}

		/// <summary>
		/// Sets the length of the underlying stream.
		/// </summary>
		/// <param name="value">The desired length of the underlying stream in bytes.</param>
		public override void SetLength(Int64 value)
		{
			CheckClosed();
			this.stream.SetLength(value);
		}

		/// <summary>
		/// Writes a sequence of bytes to the underlying stream and advances 
		/// the current position within the stream by the number of bytes written.
		/// </summary>
		/// <param name="buffer">
		/// An array of bytes. This method copies count bytes 
		/// from buffer to the underlying stream.
		/// </param>
		/// <param name="offset">
		/// The zero-based Byte offset in buffer at 
		/// which to begin copying bytes to the underlying stream.
		/// </param>
		/// <param name="count">The number of bytes to be written to the underlying stream.</param>
		public override void Write(Byte[] buffer, Int32 offset, Int32 count)
		{
			CheckClosed();
			this.stream.Write(buffer, offset, count);
		}

		/// <summary>
		/// Writes a Byte to the current position in the stream and
		/// advances the position within the stream by one Byte.
		/// </summary>
		/// <param name="value">The Byte to write to the stream. </param>
		public override void WriteByte(Byte value)
		{
			CheckClosed();
			this.stream.WriteByte(value);
		}
	}
}

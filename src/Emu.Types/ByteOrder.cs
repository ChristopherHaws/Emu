﻿namespace Emu.Types
{
	public enum ByteOrder
	{
		Unknown,

		/// <summary>
		/// Big endian (Motorola) byte order
		/// </summary>
		BigEndian,

		/// <summary>
		/// Little endian (Intel) byte order
		/// </summary>
		LittleEndian,

		/// <summary>
		/// Native byte order
		/// </summary>
		NativeEndian
	}
}

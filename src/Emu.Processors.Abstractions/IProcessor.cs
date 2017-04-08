using System;
using System.Collections.Generic;

namespace Emu.Processors
{
	public interface IProcessor
	{
		String Name { get; }

		String FullName { get; }

		ByteOrder ByteOrder { get; }

		UInt32 DelaySlots { get; }

		UInt32 ByteSize { get; }

		/// <summary>
		/// Gets the word size of the processor, which refers to the number of bits processed by a computer's CPU in one go (these days,
		/// typically 32 bits or 64 bits). Data bus size, instruction size, address size are usually multiples of the word size.
		/// </summary>
		UInt32 WordSize { get; }
		UInt32 FloatSize { get; }
		UInt32 AddressSize { get; }
		IDictionary<RegisterType, RegisterInfo> RegisterTypes { get; }

		Double ClockSpeedInMegahertz { get; }

		UInt32 Cores { get; }
	}
}

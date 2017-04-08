using System;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	[Flags]
	public enum FloatingPointStatusAndControlRegisters : Byte
	{
		Register1 = 0b1000,
		Register2 = 0b0100,
		Register3 = 0b0010,
		Register4 = 0b0001,
	}
}

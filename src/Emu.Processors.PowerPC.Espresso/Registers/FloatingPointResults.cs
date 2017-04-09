using System;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	[Flags]
    public enum FloatingPointResults : UInt32
	{
		QuietNotANumber = 0b10001,
		NegativeInfinity = 0b01001,
		NegativeNormalizedNumber = 0b01000,
		NegativeDenormalizedNumber = 0b11000,
		NegativeZero = 0b10010,
		PositiveZero = 0b00010,
		PositiveDenormalizedNumber = 0b10100,
		PositiveNormalizedNumber = 0b00100,
		PositiveInfinity = 0b00101,
	}
}

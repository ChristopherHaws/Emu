using System;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	[Flags]
	public enum AlgebraicComparisonResult
	{
		/// <summary>
		/// Negative (LT)—This bit is set when the result is negative.
		/// </summary>
		Negative = 0b0001,

		/// <summary>
		/// Positive (GT)—This bit is set when the result is positive (and not zero).
		/// </summary>
		Positive = 0b0010,

		/// <summary>
		/// Zero (EQ)—This bit is set when the result is zero.
		/// </summary>
		Zero = 0b0100,

		/// <summary>
		///  Summary overflow (SO)—This is a copy of the final state of XER[SO] at the completion of the instruction.
		/// </summary>
		SummaryOverflow = 0b1000,
	}
}

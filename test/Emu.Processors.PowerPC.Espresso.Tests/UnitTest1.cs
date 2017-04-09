using System;
using System.Collections.Generic;
using Emu.Processors.PowerPC.Espresso.Registers;
using Xunit;

namespace Emu.Processors.PowerPC.Espresso.Tests
{
    public class UnitTest1
    {
        [Theory]
		[InlineData("FX", (UInt32)0b0000_0000_0000_0000_0000_0000_0000_0001, (UInt32)0b1)]
		[InlineData("FEX", (UInt32)0b0000_0000_0000_0000_0000_0000_0000_0010, (UInt32)0b1)]
		[InlineData("VX", (UInt32)0b0000_0000_0000_0000_0000_0000_0000_0100, (UInt32)0b1)]
		[InlineData("OX", (UInt32)0b0000_0000_0000_0000_0000_0000_0000_1000, (UInt32)0b1)]
		[InlineData("UX", (UInt32)0b0000_0000_0000_0000_0000_0000_0001_0000, (UInt32)0b1)]
		[InlineData("ZX", (UInt32)0b0000_0000_0000_0000_0000_0000_0010_0000, (UInt32)0b1)]
		[InlineData("XX", (UInt32)0b0000_0000_0000_0000_0000_0000_0100_0000, (UInt32)0b1)]
		[InlineData("VXSNAN", (UInt32)0b0000_0000_0000_0000_0000_0000_1000_0000, (UInt32)0b1)]
		[InlineData("VXISI", (UInt32)0b0000_0000_0000_0000_0000_0001_0000_0000, (UInt32)0b1)]
		[InlineData("VXIDI", (UInt32)0b0000_0000_0000_0000_0000_0010_0000_0000, (UInt32)0b1)]
		[InlineData("VXZDZ", (UInt32)0b0000_0000_0000_0000_0000_0100_0000_0000, (UInt32)0b1)]
		[InlineData("VXIMZ", (UInt32)0b0000_0000_0000_0000_0000_1000_0000_0000, (UInt32)0b1)]
		[InlineData("VXVC", (UInt32)0b0000_0000_0000_0000_0001_0000_0000_0000, (UInt32)0b1)]
		[InlineData("FR", (UInt32)0b0000_0000_0000_0000_0010_0000_0000_0000, (UInt32)0b1)]
		[InlineData("FI", (UInt32)0b0000_0000_0000_0000_0100_0000_0000_0000, (UInt32)0b1)]
		[InlineData("FPRF", (UInt32)0b0000_0000_0000_1111_1000_0000_0000_0000, (UInt32)0b1_1111)]
		[InlineData("ReservedBit", (UInt32)0b0000_0000_0001_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("VXSOFT", (UInt32)0b0000_0000_0010_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("VXSQRT", (UInt32)0b0000_0000_0100_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("VXCVI", (UInt32)0b0000_0000_1000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("VE", (UInt32)0b0000_0001_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("OE", (UInt32)0b0000_0010_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("UE", (UInt32)0b0000_0100_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("ZE", (UInt32)0b0000_1000_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("XE", (UInt32)0b0001_0000_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("NI", (UInt32)0b0010_0000_0000_0000_0000_0000_0000_0000, (UInt32)0b1)]
		[InlineData("RN", (UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, (UInt32)0b11)]
		public void Test1(String register, UInt32 data, UInt32 expected)
        {
			// arrange
			var registers = new FloatingPointStatusAndControlRegisters(data);

			var lookup = new Dictionary<String, Func<UInt32>>
			{
				["RN"] = () => registers.RoundingMode,
				["NI"] = () => registers.FlushToZeroEnable,
				["XE"] = () => registers.InexactExceptionEnable,
				["FPRF"] = () => registers.FloatingPointResultFlags,
				["ReservedBit"] = () => registers.Reserved,
				["VXSOFT"] = () => registers.InvalidOperationExceptionForSoftwareRequest,
				["VXSQRT"] = () => registers.InvalidOperationExceptionForInvalidSquareRoot,
				["VXCVI"] = () => registers.InvalidOperationExceptionForInvalidIntegerConvert,
				["VE"] = () => registers.InvalidOperationExceptionEnable,
				["OE"] = () => registers.OverflowExceptionEnable,
				["UE"] = () => registers.UnderflowExceptionEnable,
				["ZE"] = () => registers.DivideByZeroExceptionEnable,
				["FI"] = () => registers.FractionInexact,
				["FR"] = () => registers.FractionRounded,
				["VXVC"] = () => registers.InvalidOperationExceptionForInvalidComparison,
				["VXIMZ"] = () => registers.InvalidOperationExceptionForInvalidInfMultZero,
				["VXZDZ"] = () => registers.InvalidOperationExceptionForInvalidDivideByZero,
				["VXIDI"] = () => registers.InvalidOperationExceptionForInvalidInfDivideByInf,
				["VXISI"] = () => registers.InvalidOperationExceptionForInvalidInfMinusInf,
				["VXSNAN"] = () => registers.InvalidOperationExceptionForInvalidNotANumber,
				["XX"] = () => registers.InexactException,
				["ZX"] = () => registers.DivisionByZeroException,
				["UX"] = () => registers.UnderflowException,
				["OX"] = () => registers.OverflowException,
				["VX"] = () => registers.InvalidOperationExceptionSummary,
				["FEX"] = () => registers.ExceptionSummaryEnabled,
				["FX"] = () => registers.ExceptionSummary,
			};


			// Act
			var actual = lookup[register]();

			// Assert
			Assert.Equal(expected, actual);
		}
    }
}

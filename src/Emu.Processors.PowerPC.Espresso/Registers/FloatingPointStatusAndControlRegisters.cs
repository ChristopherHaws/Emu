using System;
using Emu.Types;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Section 2.1.4 (Page 63) of "PowerPC Microprocessor Family - The Programming Environtments 32-bit.pdf"
	/// </remarks>
	public struct FloatingPointStatusAndControlRegisters
	{
		// We will use this to read the bits in reverse.
		private const UInt16 RegisterSize = 0;

		private static UInt32BitVector.Section FX = UInt32BitVector.CreateSection(1, 0);
		private static UInt32BitVector.Section FEX = UInt32BitVector.CreateSection(1, 1);
		private static UInt32BitVector.Section VX = UInt32BitVector.CreateSection(1, 2);
		private static UInt32BitVector.Section OX = UInt32BitVector.CreateSection(1, 3);
		private static UInt32BitVector.Section UX = UInt32BitVector.CreateSection(1, 4);
		private static UInt32BitVector.Section ZX = UInt32BitVector.CreateSection(1, 5);
		private static UInt32BitVector.Section XX = UInt32BitVector.CreateSection(1, 6);
		private static UInt32BitVector.Section VXSNAN = UInt32BitVector.CreateSection(1, 7);
		private static UInt32BitVector.Section VXISI = UInt32BitVector.CreateSection(1, 8);
		private static UInt32BitVector.Section VXIDI = UInt32BitVector.CreateSection(1, 9);
		private static UInt32BitVector.Section VXZDZ = UInt32BitVector.CreateSection(1, 10);
		private static UInt32BitVector.Section VXIMZ = UInt32BitVector.CreateSection(1, 11);
		private static UInt32BitVector.Section VXVC = UInt32BitVector.CreateSection(1, 12);
		private static UInt32BitVector.Section FR = UInt32BitVector.CreateSection(1, 13);
		private static UInt32BitVector.Section FI = UInt32BitVector.CreateSection(1, 14);
		private static UInt32BitVector.Section FPRF = UInt32BitVector.CreateSection(5, 15);
		private static UInt32BitVector.Section ReservedBit = UInt32BitVector.CreateSection(1, 20);
		private static UInt32BitVector.Section VXSOFT = UInt32BitVector.CreateSection(1, 21);
		private static UInt32BitVector.Section VXSQRT = UInt32BitVector.CreateSection(1, 22);
		private static UInt32BitVector.Section VXCVI = UInt32BitVector.CreateSection(1, 23);
		private static UInt32BitVector.Section VE = UInt32BitVector.CreateSection(1, 24);
		private static UInt32BitVector.Section OE = UInt32BitVector.CreateSection(1, 25);
		private static UInt32BitVector.Section UE = UInt32BitVector.CreateSection(1, 26);
		private static UInt32BitVector.Section ZE = UInt32BitVector.CreateSection(1, 27);
		private static UInt32BitVector.Section XE = UInt32BitVector.CreateSection(1, 28);
		private static UInt32BitVector.Section NI = UInt32BitVector.CreateSection(1, 29);
		private static UInt32BitVector.Section RN = UInt32BitVector.CreateSection(2, 30);


		private UInt32BitVector vector;

		public FloatingPointStatusAndControlRegisters(UInt32 data)
		{
			this.vector = new UInt32BitVector(data);
		}

		/// <summary>
		/// Gets or sets the rounding mode (towards: nearest, zero, +inf, -inf).
		/// </summary>
		/// <remarks>
		/// Name: RN
		/// </remarks>
		public UInt32 RoundingMode
		{
			get => this.vector[RN];
			set => this.vector[RN] = value;
		}

		/// <summary>
		/// Gets or sets the Non-IEEE mode enable (aka flush-to-zero).
		/// </summary>
		/// <remarks>
		/// Name: NI
		/// </remarks>
		public UInt32 FlushToZeroEnable
		{
			get => this.vector[NI];
			set => this.vector[NI] = value;
		}

		/// <summary>
		/// Gets or sets the inexact exception enable.
		/// </summary>
		/// <remarks>
		/// Name: XE
		/// </remarks>
		public UInt32 InexactExceptionEnable
		{
			get => this.vector[XE];
			set => this.vector[XE] = value;
		}

		/// <summary>
		/// Gets or sets the reserved.
		/// </summary>
		/// <remarks>
		/// Name: ReservedBit
		/// </remarks>
		public UInt32 Reserved
		{
			get => this.vector[ReservedBit];
			set => this.vector[ReservedBit] = value;
		}

		/// <summary>
		/// Gets or sets the invalid operation exception for software request.
		/// </summary>
		/// <remarks>
		/// Name: VXSOFT
		/// </remarks>
		public UInt32 InvalidOperationExceptionForSoftwareRequest
		{
			get => this.vector[VXSOFT];
			set => this.vector[VXSOFT] = value;
		}

		/// <summary>
		/// Gets or sets the invalid operation exception for invalid square root.
		/// </summary>
		/// <remarks>
		/// Name: VXSQRT
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidSquareRoot
		{
			get => this.vector[VXSQRT];
			set => this.vector[VXSQRT] = value;
		}

		/// <summary>
		/// Gets or sets the invalid operation exception for invalid integer convert.
		/// </summary>
		/// <remarks>
		/// Name: VXCVI
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidIntegerConvert
		{
			get => this.vector[VXCVI];
			set => this.vector[VXCVI] = value;
		}

		/// <summary>
		/// Gets or sets the invalid operation exception enable.
		/// </summary>
		/// <remarks>
		/// Name: VE
		/// </remarks>
		public UInt32 InvalidOperationExceptionEnable
		{
			get => this.vector[VE];
			set => this.vector[VE] = value;
		}

		/// <summary>
		/// Gets or sets the overflow exception enable.
		/// </summary>
		/// <remarks>
		/// Name: OE
		/// </remarks>
		public UInt32 OverflowExceptionEnable
		{
			get => this.vector[OE];
			set => this.vector[OE] = value;
		}

		/// <summary>
		/// Gets or sets the underflow exception enable.
		/// </summary>
		/// <remarks>
		/// Name: UE
		/// </remarks>
		public UInt32 UnderflowExceptionEnable
		{
			get => this.vector[UE];
			set => this.vector[UE] = value;
		}

		/// <summary>
		/// Gets or sets the divide by zero exception enable.
		/// </summary>
		/// <remarks>
		/// Name: ZE
		/// </remarks>
		public UInt32 DivideByZeroExceptionEnable
		{
			get => this.vector[ZE];
			set => this.vector[ZE] = value;
		}
		
		/// <summary>
		/// Floating point result flags (includes FPCC) (not sticky) from more to less significand: class, <, >, =, ?	
		/// </summary>
		/// <remarks>
		/// Name: FPRF
		/// </remarks>
		public UInt32 FloatingPointResultFlags
		{
			get => this.vector[FPRF];
			set => this.vector[FPRF] = value;
		}

		/// <summary>
		/// Fraction inexact (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FI
		/// </remarks>
		public UInt32 FractionInexact
		{
			get => this.vector[FI];
			set => this.vector[FI] = value;
		}

		/// <summary>
		/// Fraction rounded (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FR
		/// </remarks>
		public UInt32 FractionRounded
		{
			get => this.vector[FR];
			set => this.vector[FR] = value;
		}

		/// <summary>
		/// Invalid operation exception for invalid comparison (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXVC
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidComparison
		{
			get => this.vector[VXVC];
			set => this.vector[VXVC] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf * 0 (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXIMZ
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfMultZero
		{
			get => this.vector[VXIMZ];
			set => this.vector[VXIMZ] = value;
		}

		/// <summary>
		/// Invalid operation exception for 0 / 0 (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXZDZ
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidDivideByZero
		{
			get => this.vector[VXZDZ];
			set => this.vector[VXZDZ] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf / inf (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXIDI
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfDivideByInf
		{
			get => this.vector[VXIDI];
			set => this.vector[VXIDI] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf - inf (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXISI
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfMinusInf
		{
			get => this.vector[VXISI];
			set => this.vector[VXISI] = value;
		}

		/// <summary>
		/// Invalid operation exception for SNaN (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXSNAN
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidNotANumber
		{
			get => this.vector[VXSNAN];
			set => this.vector[VXSNAN] = value;
		}

		/// <summary>
		/// Inexact exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: XX
		/// </remarks>
		public UInt32 InexactException
		{
			get => this.vector[XX];
			set => this.vector[XX] = value;
		}

		/// <summary>
		/// Division by zero exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: ZX
		/// </remarks>
		public UInt32 DivisionByZeroException
		{
			get => this.vector[ZX];
			set => this.vector[ZX] = value;
		}

		/// <summary>
		/// Underflow exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: UX
		/// </remarks>
		public UInt32 UnderflowException
		{
			get => this.vector[UX];
			set => this.vector[UX] = value;
		}

		/// <summary>
		/// Overflow exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: OX
		/// </remarks>
		public UInt32 OverflowException
		{
			get => this.vector[OX];
			set => this.vector[OX] = value;
		}

		/// <summary>
		/// Invalid operation exception summary (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: VX
		/// </remarks>
		public UInt32 InvalidOperationExceptionSummary
		{
			get => this.vector[VX];
			set => this.vector[VX] = value;
		}

		/// <summary>
		/// Enabled exception summary (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FEX
		/// </remarks>
		public UInt32 ExceptionSummaryEnabled
		{
			get => this.vector[FEX];
			set => this.vector[FEX] = value;
		}

		/// <summary>
		/// Exception summary (sticky)
		/// </summary>
		/// <remarks>
		/// Name: FX
		/// </remarks>
		public UInt32 ExceptionSummary
		{
			get => this.vector[FX];
			set => this.vector[FX] = value;
		}
	}
}

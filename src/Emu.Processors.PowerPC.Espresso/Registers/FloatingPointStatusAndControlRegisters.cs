using System;
using Emu.Types;

namespace Emu.Processors.PowerPC.Espresso.Registers
{	
	public struct FloatingPointStatusAndControlRegisters
	{
		// Modes
		private static UInt32BitVector.Section RoundingModeSection = UInt32BitVector.CreateSection(2);
		private static UInt32BitVector.Section FlushToZeroEnableSection = UInt32BitVector.CreateSection(1, RoundingModeSection);

		// IEEE Exceptions
		private static UInt32BitVector.Section InexactExceptionEnableSection = UInt32BitVector.CreateSection(1, FlushToZeroEnableSection);
		private static UInt32BitVector.Section DivisionByZeroEnableSection = UInt32BitVector.CreateSection(1, InexactExceptionEnableSection);
		private static UInt32BitVector.Section UnderflowExceptionEnableSection = UInt32BitVector.CreateSection(1, DivisionByZeroEnableSection);
		private static UInt32BitVector.Section OverflowExceptionEnableSection = UInt32BitVector.CreateSection(1, UnderflowExceptionEnableSection);

		// Invalid Operation Exceptions
		private static UInt32BitVector.Section InvalidOperationExceptionEnableSection = UInt32BitVector.CreateSection(1, OverflowExceptionEnableSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForIntegerConversionEnableSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionEnableSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForSquareRootEnableSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForIntegerConversionEnableSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForSoftwareRequestEnableSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForSquareRootEnableSection);

		// Reserved
		private static UInt32BitVector.Section ReservedSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForSoftwareRequestEnableSection);

		// Floating Point
		private static UInt32BitVector.Section FloatingPointResultFlagsSection = UInt32BitVector.CreateSection(5, ReservedSection);
		private static UInt32BitVector.Section FractionInexactSection = UInt32BitVector.CreateSection(1, FloatingPointResultFlagsSection);
		private static UInt32BitVector.Section FractionRoundedSection = UInt32BitVector.CreateSection(1, FractionInexactSection);

		// Invalid Operation Exception
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidComparisonSection = UInt32BitVector.CreateSection(1, FractionRoundedSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidInfMultZeroSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidComparisonSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidDivideByZeroSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidInfMultZeroSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidInfDivideByInfSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidDivideByZeroSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidInfMinusInfSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidInfDivideByInfSection);
		private static UInt32BitVector.Section InvalidOperationExceptionForInvalidNotANumberSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidInfMinusInfSection);

		// Aritmatic
		private static UInt32BitVector.Section InexactExceptionSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionForInvalidNotANumberSection);
		private static UInt32BitVector.Section DivisionByZeroExceptionSection = UInt32BitVector.CreateSection(1, InexactExceptionSection);
		private static UInt32BitVector.Section UnderflowExceptionSection = UInt32BitVector.CreateSection(1, DivisionByZeroExceptionSection);
		private static UInt32BitVector.Section OverflowExceptionSection = UInt32BitVector.CreateSection(1, UnderflowExceptionSection);
		private static UInt32BitVector.Section InvalidOperationExceptionSummarySection = UInt32BitVector.CreateSection(1, OverflowExceptionSection);

		// Exception Summary
		private static UInt32BitVector.Section ExceptionSummaryEnabledSection = UInt32BitVector.CreateSection(1, InvalidOperationExceptionSummarySection);
		private static UInt32BitVector.Section ExceptionSummarySection = UInt32BitVector.CreateSection(1, ExceptionSummaryEnabledSection);


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
			get => this.vector[RoundingModeSection];
			set => this.vector[RoundingModeSection] = value;
		}

		/// <summary>
		/// Gets or sets the Non-IEEE mode enable (aka flush-to-zero).
		/// </summary>
		/// <remarks>
		/// Name: NI
		/// </remarks>
		public UInt32 FlushToZeroEnable
		{
			get => this.vector[FlushToZeroEnableSection];
			set => this.vector[FlushToZeroEnableSection] = value;
		}

		/// <summary>
		/// Gets or sets the inexact exception enable.
		/// </summary>
		/// <remarks>
		/// Name: XE
		/// </remarks>
		public UInt32 InexactExceptionEnable
		{
			get => this.vector[InexactExceptionEnableSection];
			set => this.vector[InexactExceptionEnableSection] = value;
		}

		/// <summary>
		/// Floating point result flags (includes FPCC) (not sticky) from more to less significand: class, <, >, =, ?	
		/// </summary>
		/// <remarks>
		/// Name: FPRF
		/// </remarks>
		public UInt32 FloatingPointResultFlags
		{
			get => this.vector[FloatingPointResultFlagsSection];
			set => this.vector[FloatingPointResultFlagsSection] = value;
		}

		/// <summary>
		/// Fraction inexact (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FI
		/// </remarks>
		public UInt32 FractionInexact
		{
			get => this.vector[FractionInexactSection];
			set => this.vector[FractionInexactSection] = value;
		}

		/// <summary>
		/// Fraction rounded (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FR
		/// </remarks>
		public UInt32 FractionRounded
		{
			get => this.vector[FractionRoundedSection];
			set => this.vector[FractionRoundedSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for invalid comparison (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXVC
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidComparison
		{
			get => this.vector[InvalidOperationExceptionForInvalidComparisonSection];
			set => this.vector[InvalidOperationExceptionForInvalidComparisonSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf * 0 (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXIMZ
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfMultZero
		{
			get => this.vector[InvalidOperationExceptionForInvalidInfMultZeroSection];
			set => this.vector[InvalidOperationExceptionForInvalidInfMultZeroSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for 0 / 0 (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXZDZ
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidDivideByZero
		{
			get => this.vector[InvalidOperationExceptionForInvalidDivideByZeroSection];
			set => this.vector[InvalidOperationExceptionForInvalidDivideByZeroSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf / inf (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXIDI
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfDivideByInf
		{
			get => this.vector[InvalidOperationExceptionForInvalidInfDivideByInfSection];
			set => this.vector[InvalidOperationExceptionForInvalidInfDivideByInfSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for inf - inf (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXISI
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidInfMinusInf
		{
			get => this.vector[InvalidOperationExceptionForInvalidInfMinusInfSection];
			set => this.vector[InvalidOperationExceptionForInvalidInfMinusInfSection] = value;
		}

		/// <summary>
		/// Invalid operation exception for SNaN (sticky)
		/// </summary>
		/// <remarks>
		/// Name: VXSNAN
		/// </remarks>
		public UInt32 InvalidOperationExceptionForInvalidNotANumber
		{
			get => this.vector[InvalidOperationExceptionForInvalidNotANumberSection];
			set => this.vector[InvalidOperationExceptionForInvalidNotANumberSection] = value;
		}

		/// <summary>
		/// Inexact exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: XX
		/// </remarks>
		public UInt32 InexactException
		{
			get => this.vector[InexactExceptionSection];
			set => this.vector[InexactExceptionSection] = value;
		}

		/// <summary>
		/// Division by zero exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: ZX
		/// </remarks>
		public UInt32 DivisionByZeroException
		{
			get => this.vector[DivisionByZeroExceptionSection];
			set => this.vector[DivisionByZeroExceptionSection] = value;
		}

		/// <summary>
		/// Underflow exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: UX
		/// </remarks>
		public UInt32 UnderflowException
		{
			get => this.vector[UnderflowExceptionSection];
			set => this.vector[UnderflowExceptionSection] = value;
		}

		/// <summary>
		/// Overflow exception (sticky)
		/// </summary>
		/// <remarks>
		/// Name: OX
		/// </remarks>
		public UInt32 OverflowException
		{
			get => this.vector[OverflowExceptionSection];
			set => this.vector[OverflowExceptionSection] = value;
		}

		/// <summary>
		/// Invalid operation exception summary (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: VX
		/// </remarks>
		public UInt32 InvalidOperationExceptionSummary
		{
			get => this.vector[InvalidOperationExceptionSummarySection];
			set => this.vector[InvalidOperationExceptionSummarySection] = value;
		}

		/// <summary>
		/// Enabled exception summary (not sticky)
		/// </summary>
		/// <remarks>
		/// Name: FEX
		/// </remarks>
		public UInt32 ExceptionSummaryEnabled
		{
			get => this.vector[ExceptionSummaryEnabledSection];
			set => this.vector[ExceptionSummaryEnabledSection] = value;
		}

		/// <summary>
		/// Exception summary (sticky)
		/// </summary>
		/// <remarks>
		/// Name: FX
		/// </remarks>
		public UInt32 ExceptionSummary
		{
			get => this.vector[ExceptionSummarySection];
			set => this.vector[ExceptionSummarySection] = value;
		}
	}
}

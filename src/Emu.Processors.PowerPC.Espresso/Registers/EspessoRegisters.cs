using System;
using Emu.Types;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	public class EspessoRegisters
	{
		/// <summary>
		/// Gets or sets the condition register (CR). Consists of eight four-bit fields that reflect the results of certain operations,
		/// such as move, integer and floating-point compare, arithmetic, and logical instructions, and provide a
		/// mechanism for testing and branching.
		/// </summary>
		/// <remarks>
		/// Level: User
		/// Name: CR
		/// </remarks>
		public EightNibbles ConditionRegisters;

		/// <summary>
		/// Gets the algebraic comparison result. For all integer instructions, when the CR is set to reflect the result of the operation (that is,
		/// when Rc = 1), and for addic., andi., and andis., the first three bits of CR0 are set by an
		/// algebraic comparison of the result to zero; the fourth bit of CR0 is copied from XER[SO].
		/// For integer instructions, CR bits 0–3 are set to reflect the result as a signed quantity.
		/// The CR bits are interpreted as shown in Table 2-1. If any portion of the result is undefined,
		/// the value placed into the first three bits of CR0 is undefined.
		/// 
		/// Note that CR0 may not reflect the true (that is, infinitely precise) result if overflow occurs.
		/// </summary>
		/// <value>
		/// The algebraic comparison result.
		/// </value>
		public AlgebraicComparisonResult AlgebraicComparisonResult => (AlgebraicComparisonResult)this.ConditionRegisters[0];

		/// <summary>
		/// Gets the 32 floating-point registers (FPRs) serve as the data source or destination for floating-point instructions.
		/// These 64-bit registers can hold single, paired single or double-precision floating-point values.
		/// </summary>
		/// <remarks>
		/// Level: User
		/// Name: FPR's
		/// </remarks>
		public UInt64[] FloatingPointRegisters { get; } = new UInt64[32];

		/// <summary>
		/// The floating-point status and control register (FPSCR) contains the floating-point exception signal bits,
		/// exception summary bits, exception enable bits, and rounding control bits needed for compliance with the
		/// IEEE-754 standard.
		/// </summary>
		/// <remarks>
		/// Level: User
		/// Name: FPSCR
		/// </remarks>
		public FloatingPointStatusAndControlRegisters FloatingPointStatusAndControlRegisters { get; set; }

		/// <summary>
		/// The 32 GPRs contain the address and data arguments addressed from source or destination fields in integer
		/// instructions. Also floating-point load and store instructions use GPRs for addressing memory.
		/// </summary>
		/// <remarks>
		/// Level: User
		/// Name: GPRs
		/// </remarks>
		public UInt32[] GeneralPurposeRegisters { get; } = new UInt32[32];


		/// <summary>
		/// Level: User
		/// Name: GPRs
		/// </remarks>
		public UInt32[] SpecialPurposeRegisters { get; } = new UInt32[32];

		/// <summary>
		/// The machine state register (MSR) defines the processor state. Its contents are saved when an exception
		/// is taken and restored when exception handling completes. The 750CL implements MSR[POW], (defined
		/// by the architecture as optional), which is used to enable the power management feature.
		/// The 750CL-specific MSR[PM] bit is used to mark a process for the performance monitor.
		/// </summary>
		/// <remarks>
		/// Level: Supervisor
		/// Name: MSR
		/// </remarks>
		public Int32 MachineStateRegister { get; set; }

		/// <summary>
		/// The sixteen 32-bit segment registers (SRs) define the 4-GB space as sixteen 256-MB segments. 750CL
		/// implements segment registers as two arrays—a main array for data accesses and a shadow array for
		/// instruction accesses; see Figure 8-2 on page 276. Loading a segment entry with the Move to Segment
		/// Register (mtsr) instruction loads both arrays. The mfsr instruction reads the master register, shown as
		/// </summary>
		/// <remarks>
		/// Level: Supervisor
		/// Name: SR0-SR15
		/// </remarks>
		public UInt32[] SegmentRegisters { get; } = new UInt32[16];
	}
}

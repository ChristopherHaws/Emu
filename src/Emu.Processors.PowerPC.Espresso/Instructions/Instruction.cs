using System;
using System.Collections.Generic;
using System.Text;

namespace Emu.Processors.PowerPC.Espresso.Instructions
{
    public abstract class Instruction
	{
		public abstract String Name { get; }
		public abstract String Mnemonic { get; }
		public abstract String Syntax { get; }
	}

	/// <summary>
	/// Represents an integer instruction. Integer instructions operate on byte, half-word, and word operands.
	/// </summary>
	/// <seealso cref="Instruction" />
	public abstract class IntegerInstruction : Instruction
	{

	}

	public abstract class IntegerArithmeticInstruction : IntegerInstruction
	{

	}

	/// <summary>
	/// The sum (rA|0) + SIMM is placed into rD.
	/// 
	/// The addi instruction is preferred for addition because it sets few status bits. Note that addi uses
	/// the value 0, not the contents of GPR0, if rA = 0.
	/// </summary>
	/// <seealso cref="Emu.Processors.PowerPC.Espresso.Instructions.IntegerArithmeticInstruction" />
	/// <remarks>
	/// See page 425 of PowerPC Microprocessor Family - The Programming Environments
	/// </remarks>
	public class AddImmediateInstruction : IntegerArithmeticInstruction
	{
		public override String Name { get; } = "Add Immediate";

		public override String Mnemonic { get; } = "addi";

		public override String Syntax { get; } = "rD,rA,SIMM";
	}

	public abstract class IntegerCompareInstruction : IntegerInstruction
	{

	}
	public abstract class IntegerLogicalInstruction : IntegerInstruction
	{

	}
	public abstract class IntegerRotateAndShiftInstruction : IntegerInstruction
	{

	}

	/// <summary>
	/// Represents a floating point instruction. Floating point instructions operate on single-precision (one word) and
	/// double-precision (two word) floating point operands.
	/// </summary>
	/// <seealso cref="Instruction" />
	public abstract class FloatingPointInstruction : Instruction
	{

	}
	public abstract class LoadAndStoreInstruction : Instruction
	{

	}
	public abstract class FlowControlInstruction : Instruction
	{

	}
	public abstract class ProcessControlInstruction : Instruction
	{

	}
	public abstract class MemoryControlInstruction : Instruction
	{

	}
}

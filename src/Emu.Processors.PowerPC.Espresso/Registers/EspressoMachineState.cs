using System;

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	[Flags]
	public enum EspressoMachineState : Byte
	{
		PriviledgeLevel,
		PerformanceMonitor
	}
}

namespace Emu.Processors.PowerPC.Espresso.Registers
{
	public enum PriviledgeLevel
	{
		/// <summary>
		/// The user mode of operation (used by the application software, it is also called problem state).
		/// </summary>
		/// <remarks>
		/// While running in user mode (problem state) many of the registers and facilities are
		/// not accessible and any attempt to read or write these register results in a program exception.
		/// </remarks>
		User,

		/// <summary>
		/// The supervisor mode of operation (typically used by the operating system).
		/// </summary>
		/// <remarks>
		/// While running in supervisor mode the operating system is able to execute all instructions and access all registers
		/// defined in the PowerPC Architecture. In this mode the operating system establishes all address translations
		/// and protection mechanisms, loads all processor state registers. and sets up all other control mechanisms defined on the 750CL processor.
		/// </remarks>
		Supervisor
	}
}

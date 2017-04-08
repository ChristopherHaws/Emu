using System;
using System.Collections.Generic;

namespace Emu.Processors.PowerPC.Espresso
{
	/// <summary>
	/// Represents a variant of the PowerPC 750CL (Broadway) which is present in the Wii U.
	/// </summary>
	/// <remarks>
	/// https://fail0verflow.com/media/files/ppc_750cl.pdf
	/// https://www.ecse.rpi.edu/courses/CStudio/ppc603e/MPCFPE.pdf
	/// https://stuff.mit.edu/afs/sipb/contrib/doc/specs/ic/cpu/powerpc/MPCFPE32B.pdf
	/// https://www.gamefaqs.com/boards/631516-wii-u/68074239
	/// 
	/// Micro-Architecture: PowerPC 7xx
	/// Variant: PowerPC 750CL (Wii Broadway)
	/// 
	/// L2 Cache:
	///		Core 0 = 512KB
	///		Core 1 = 2MB
	///		Core 2 = 512KB
	///		Total DRAM = 3MB
	/// </remarks>
	/// <seealso cref="IProcessor" />
	public class EspessoProcessor : IProcessor
	{
		public Double ClockSpeedInMegahertz { get; } = 1243.125;

		public UInt32 Cores { get; } = 3;

		public String Name { get; } = "PowerPC";

		public String FullName { get; } = "PowerPC 750CL";

		public ByteOrder ByteOrder { get; } = ByteOrder.BigEndian;

		public UInt32 DelaySlots { get; } = 0;

		public UInt32 ByteSize { get; } = 8;

		public UInt32 WordSize { get; } = 32;

		public UInt32 FloatSize { get; } = 64;

		public UInt32 AddressSize { get; } = 32;

		public IDictionary<RegisterType, RegisterInfo> RegisterTypes { get; } = new Dictionary<RegisterType, RegisterInfo>
		{
			[RegisterType.GeneralPurpose] = new RegisterInfo
			{
				Count = 32,
				Size = 32
			}
		};
	}
}

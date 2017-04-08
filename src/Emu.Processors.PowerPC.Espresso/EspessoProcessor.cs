using System;
using System.Collections.Generic;

namespace Emu.Processors.PowerPC.Espresso
{
	/// <summary>
	/// Represents a variant of the PowerPC 750CL which is present in the Wii U.
	/// </summary>
	/// <remarks>
	/// https://fail0verflow.com/media/files/ppc_750cl.pdf
	/// https://www.ecse.rpi.edu/courses/CStudio/ppc603e/MPCFPE.pdf
	/// https://stuff.mit.edu/afs/sipb/contrib/doc/specs/ic/cpu/powerpc/MPCFPE32B.pdf
	/// </remarks>
	/// <seealso cref="IProcessor" />
	public class EspessoProcessor : IProcessor
	{
		public Double ClockSpeedInMegahertz { get; } = 1243;

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

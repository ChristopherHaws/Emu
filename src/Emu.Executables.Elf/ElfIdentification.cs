using Emu.Types;
using System;

namespace Emu.Executables.Elf
{
	public struct ElfIdentification
	{
		public ProcessorClassification ProcessorClassification { get; set; }
		public ByteOrder ByteOrder { get; set; }
		public Int32 ElfVersion { get; set; }
		public ElfTargetOperatingSystem TargetOperatingSystem { get; set; }
		public Int32 ApplicationBinaryInterfaceVersion { get; set; }
	}
}

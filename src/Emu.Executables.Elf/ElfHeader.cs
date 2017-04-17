using System;

namespace Emu.Executables.Elf
{
	public class ElfHeader
	{
		public ElfFileType FileType { get; set; }
		public ElfTargetMachineArchitecture TargetMachineArchitecture { get; set; }
		public UInt64 ObjectFileVersion { get; set; }
		public UInt64 EntryPoint { get; set; }
		public Int64 ProgramHeaderPoint { get; set; }
		public Int64 SectionHeaderPoint { get; set; }
		public UInt32 Flags { get; set; }
		public UInt32 ExecutableHeaderSize { get; set; }
		public UInt32 ProgramHeaderSize { get; set; }
		public UInt32 ProgramHeaderEntryCount { get; set; }
		public UInt32 SectionHeaderTableSize { get; set; }
		public UInt32 SectionHeaderTableEntryCount { get; set; }
		public UInt32 SelectionHeaderTableSectionNameIndex { get; set; }
	}
}

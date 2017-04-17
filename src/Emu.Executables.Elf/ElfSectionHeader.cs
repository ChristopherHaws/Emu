using System;

namespace Emu.Executables.Elf
{
	public class ElfSectionHeader
	{
		public UInt32 NameOffset { get; set; }
		public UInt32 Type { get; set; }
		public UInt64 Flags { get; set; }
		public UInt64 VirtualAddress { get; set; }
		public UInt64 SectionFileOffset { get; set; }
		public UInt64 SizeInBytes { get; set; }
		public UInt32 SectionIndex { get; set; }
		public UInt32 ExtraInfo { get; set; }
		public UInt64 AddressAllignment { get; set; }
		public UInt64 EntrySize { get; set; }
	}
}

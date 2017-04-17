namespace Emu.Executables.Elf
{
	public class ElfFile
	{
		public ElfIdentification Identification { get; set; }
		public ElfHeader Header { get; set; }
		public ElfSectionHeader SectionHeader { get; set; }
	}
}

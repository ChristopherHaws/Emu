using Emu.Types;

namespace Emu.Executables.Elf
{
	public class ElfHeaderLoader
	{
		public ElfHeader Load(EndianBinaryReader reader, ProcessorClassification classification)
		{
			var header = new ElfHeader();

			header.FileType = (ElfFileType)reader.ReadUInt16();
			header.TargetMachineArchitecture = (ElfTargetMachineArchitecture)reader.ReadUInt16();
			header.ObjectFileVersion = reader.ReadUInt32();
			header.EntryPoint = classification == ProcessorClassification.Bit32
				? reader.ReadUInt32()
				: reader.ReadUInt64();

			header.ProgramHeaderPoint = classification == ProcessorClassification.Bit32
				? reader.ReadUInt32()
				: reader.ReadInt64();

			header.SectionHeaderPoint = classification == ProcessorClassification.Bit32
				? reader.ReadUInt32()
				: reader.ReadInt64();

			header.Flags = reader.ReadUInt32();
			header.ExecutableHeaderSize = reader.ReadUInt16();
			header.ProgramHeaderSize = reader.ReadUInt16();
			header.ProgramHeaderEntryCount = reader.ReadUInt16();
			header.SectionHeaderTableSize = reader.ReadUInt16();
			header.SectionHeaderTableEntryCount = reader.ReadUInt16();
			header.SelectionHeaderTableSectionNameIndex = reader.ReadUInt16();

			return header;
		}
	}
}

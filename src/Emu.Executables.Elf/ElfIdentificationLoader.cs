using Emu.Types;
using System.IO;

namespace Emu.Executables.Elf
{
	public class ElfIdentificationLoader
	{
		public ElfIdentification Load(Stream stream)
		{
			using (var reader = new BinaryReader(stream))
			{
				var identification = new ElfIdentification();

				switch (reader.ReadByte())
				{
					case 1:
						identification.ProcessorClassification = ProcessorClassification.Bit32;
						break;
					case 2:
						identification.ProcessorClassification = ProcessorClassification.Bit64;
						break;
					default:
						identification.ProcessorClassification = ProcessorClassification.Unknown;
						break;
				}

				switch (reader.ReadByte())
				{
					case 1:
						identification.ByteOrder = ByteOrder.LittleEndian;
						break;
					case 2:
						identification.ByteOrder = ByteOrder.LittleEndian;
						break;
					default:
						identification.ByteOrder = ByteOrder.Unknown;
						break;
				}

				identification.ElfVersion = reader.ReadByte();
				identification.TargetOperatingSystem = (ElfTargetOperatingSystem)reader.ReadByte();
				identification.ApplicationBinaryInterfaceVersion = reader.ReadByte();

				// Skip the next 7 bytes, they are unused (EI_PAD)
				reader.ReadBytes(7);

				return identification;
			}
		}
	}
}

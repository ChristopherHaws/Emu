using Emu.Types;
using System;
using System.IO;

namespace Emu.Executables.Elf
{
	public class ElfExecutableLoader
	{
		private readonly ElfIdentificationLoader identificationLoader;
		private readonly ElfHeaderLoader headerLoader;

		public ElfExecutableLoader(ElfIdentificationLoader identificationLoader, ElfHeaderLoader headerLoader)
		{
			this.identificationLoader = identificationLoader;
			this.headerLoader = headerLoader;
		}

		public ElfFile Load(String path)
		{
			using (var stream = File.OpenRead(path))
			{
				// Skip the magic header
				stream.Seek(0x04, SeekOrigin.Begin);

				var identification = this.identificationLoader.Load(new NonClosingStreamWrapper(stream));

				var converter = identification.ByteOrder == ByteOrder.BigEndian
					? new BigEndianBitConverter() as EndianBitConverter
					: new LittleEndianBitConverter();

				using (var reader = new EndianBinaryReader(converter, stream))
				{
					var file = new ElfFile
					{
						Identification = identification,
						Header = this.headerLoader.Load(reader, identification.ProcessorClassification)
					};

					//stream.Seek(file.Header.SectionHeaderPoint, SeekOrigin.Begin);
					//file.SectionHeader = this.LoadSectionHeader(reader, identification.TargetPlatform);

					return file;
				}
			}
		}
	}
}

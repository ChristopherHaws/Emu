namespace Emu.Executables.Elf
{
	public enum ElfFileType
	{
		Relocatable = 1,
		Executable = 2,
		Shared = 3,
		Core = 4,
		BeginOperatingSystemSpecificTypes = 0xFE00,
		WiiUExecutable = 0xFE01,
		EndOperatingSystemSpecificTypes = 0xFEFF,
		BeginProcessorSpecificTypes = 0xFF00,
		EndProcessorSpecificTypes = 0xFFFF,
	}
}

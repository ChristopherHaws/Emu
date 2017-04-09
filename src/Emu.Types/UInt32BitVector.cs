using System;

namespace Emu.Types
{
	public struct UInt32BitVector
	{
		private const Byte BitSize = 1;

		public UInt32 Data { get; set; }

		public UInt32BitVector(UInt32 data)
		{
			this.Data = data;
		}

		public UInt32 this[Section section]
		{
			get => this.Get(section);
			set => this.Set(section, value);
		}

		private UInt32 Get(Section section)
		{
			return this.Data >> section.Offset & section.Mask;
		}

		private void Set(Section section, UInt32 value)
		{
			this.Data |= value << section.Offset;
		}

		public override String ToString()
		{
			return Convert.ToString(this.Data, 2).PadLeft(32, '0');
		}

		public static Section CreateSection(Int16 size)
		{
			return CreateSection(size, 0);
		}

		public static Section CreateSection(Int16 size, Section previous)
		{
			return CreateSection(size, (Int16)(previous.Offset + previous.Size));
		}

		public static Section CreateSection(Int16 size, Int16 offset)
		{
			return new Section
			{
				Offset = offset,
				Size = size,
				Mask = (UInt32)((1L << size) - BitSize)
			};
		}

		public struct Section
		{
			public Int16 Offset { get; set; }
			public Int16 Size { get; set; }
			public UInt32 Mask { get; set; }
		}
	}

}

using System;

namespace Emu.Processors
{
	/// <summary>
	/// Represents 8x 4-bit values.
	/// </summary>
	public struct EightNibbles
	{
		public UInt32 Value { get; set; }

		public Byte this[Int32 i]
		{
			get => this.Get(i);
			set => this.Set(i, value);
		}

		public override String ToString()
		{
			return Convert.ToString(this.Value, 2).PadLeft(32, '0');
		}

		private Byte Get(Int32 position)
		{
			position *= 4;

			return (Byte)((this.Value >> position) & 0xF);
		}

		private void Set(Int32 position, UInt32 value)
		{
			if (value > 15)
			{
				throw new ArgumentOutOfRangeException("Value cannot be greater than 15");
			}

			position *= 4;

			if (position > 0)
			{
				value = value << position;
			}

			this.Value = value | this.Value;
		}
	}
}

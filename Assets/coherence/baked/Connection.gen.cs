// Copyright (c) coherence ApS.
// See the license file in the project root for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Utils;
	using Coherence.Toolkit;
	using UnityEngine;
	using Unity.Collections;
	using Unity.Mathematics;

	public struct Connection : ICoherenceComponentData
	{
		public int id;
		public int type;

		public override string ToString()
		{
			return $"Connection(id: {id}, type: {type})";
		}

		public uint GetComponentType() => Definition.InternalConnection;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _id_Min = 0;
		private static readonly int _id_Max = 2147483647;
		private static readonly int _type_Min = 0;
		private static readonly int _type_Max = 8;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Connection)data;
			if ((mask & 0x01) != 0)
			{
				id = other.id;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				type = other.type;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (Connection)data;

			if (id != newData.id) {
				mask |= 0b00000000000000000000000000000001;
			}
			if (type != newData.type) {
				mask |= 0b00000000000000000000000000000010;
			}

			return mask;
		}

		public static void Serialize(Connection data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.id, _id_Min, _id_Max, "Connection.id");

				bitStream.WriteIntegerRange(data.id, 31, 0);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.type, _type_Min, _type_Max, "Connection.type");

				bitStream.WriteIntegerRange(data.type, 3, 0);
			}
			mask >>= 1;
		}

		public static (Connection, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Connection();
			if (bitStream.ReadMask())
			{
				val.id = bitStream.ReadIntegerRange(31, 0);
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.type = bitStream.ReadIntegerRange(3, 0);
				mask |= 0b00000000000000000000000000000010;
			}
			return (val, mask, null);
		}
	}
}
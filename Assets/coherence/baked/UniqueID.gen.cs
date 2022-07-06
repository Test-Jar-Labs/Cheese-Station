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

	public struct UniqueID : ICoherenceComponentData
	{
		public string uuid;

		public override string ToString()
		{
			return $"UniqueID(uuid: {uuid})";
		}

		public uint GetComponentType() => Definition.InternalUniqueID;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;


		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (UniqueID)data;
			if ((mask & 0x01) != 0)
			{
				uuid = other.uuid;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (UniqueID)data;

			if (uuid.DiffersFrom(newData.uuid)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(UniqueID data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteShortString(data.uuid);
			}
			mask >>= 1;
		}

		public static (UniqueID, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new UniqueID();
			if (bitStream.ReadMask())
			{
				val.uuid = bitStream.ReadShortString();
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, null);
		}
	}
}
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

	public struct InputOwnerComponent : ICoherenceComponentData
	{
		public int clientId;

		public override string ToString()
		{
			return $"InputOwnerComponent(clientId: {clientId})";
		}

		public uint GetComponentType() => Definition.InternalInputOwnerComponent;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _clientId_Min = 0;
		private static readonly int _clientId_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (InputOwnerComponent)data;
			if ((mask & 0x01) != 0)
			{
				clientId = other.clientId;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (InputOwnerComponent)data;

			if (clientId != newData.clientId) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(InputOwnerComponent data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.clientId, _clientId_Min, _clientId_Max, "InputOwnerComponent.clientId");

				bitStream.WriteIntegerRange(data.clientId, 31, 0);
			}
			mask >>= 1;
		}

		public static (InputOwnerComponent, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new InputOwnerComponent();
			if (bitStream.ReadMask())
			{
				val.clientId = bitStream.ReadIntegerRange(31, 0);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, null);
		}
	}
}
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

	public struct GenericScale : ICoherenceComponentData
	{
		public float3 value;

		public override string ToString()
		{
			return $"GenericScale(value: {value})";
		}

		public uint GetComponentType() => Definition.InternalGenericScale;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _value_Min = -2400f;
		private static readonly float _value_Max = 2400f;
		private static readonly float _value_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericScale)data;
			if ((mask & 0x01) != 0)
			{
				value = other.value;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericScale)data;

			if (value.DiffersFrom(newData.value, _value_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericScale data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.value.x, _value_Min, _value_Max, "GenericScale.value.x");

				Coherence.Utils.Bounds.Check(data.value.y, _value_Min, _value_Max, "GenericScale.value.y");

				Coherence.Utils.Bounds.Check(data.value.z, _value_Min, _value_Max, "GenericScale.value.z");

				bitStream.WriteVector3f(CoherenceToUnityConverters.FromUnityfloat3(data.value), 24, 2400);
			}
			mask >>= 1;
		}

		public static (GenericScale, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericScale();
			if (bitStream.ReadMask())
			{
				val.value = CoherenceToUnityConverters.ToUnityfloat3(bitStream.ReadVector3f(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, null);
		}
	}
}
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

	public struct GenericFieldFloat7 : ICoherenceComponentData
	{
		public float number;

		public override string ToString()
		{
			return $"GenericFieldFloat7(number: {number})";
		}

		public uint GetComponentType() => Definition.InternalGenericFieldFloat7;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _number_Min = -2400f;
		private static readonly float _number_Max = 2400f;
		private static readonly float _number_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericFieldFloat7)data;
			if ((mask & 0x01) != 0)
			{
				number = other.number;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericFieldFloat7)data;

			if (number.DiffersFrom(newData.number, _number_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldFloat7 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.number, _number_Min, _number_Max, "GenericFieldFloat7.number");

				bitStream.WriteFixedPoint(CoherenceToUnityConverters.FromUnityfloat(data.number), 24, 2400);
			}
			mask >>= 1;
		}

		public static (GenericFieldFloat7, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldFloat7();
			if (bitStream.ReadMask())
			{
				val.number = CoherenceToUnityConverters.ToUnityfloat(bitStream.ReadFixedPoint(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, null);
		}
	}
}
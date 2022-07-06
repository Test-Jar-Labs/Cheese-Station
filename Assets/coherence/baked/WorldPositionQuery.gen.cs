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

	public struct WorldPositionQuery : ICoherenceComponentData
	{
		public float3 position;
		public float radius;

		public override string ToString()
		{
			return $"WorldPositionQuery(position: {position}, radius: {radius})";
		}

		public uint GetComponentType() => Definition.InternalWorldPositionQuery;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _position_Min = -2400f;
		private static readonly float _position_Max = 2400f;
		private static readonly float _position_Epsilon = 0.000286102294921875f;
		private static readonly float _radius_Min = -2400f;
		private static readonly float _radius_Max = 2400f;
		private static readonly float _radius_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (WorldPositionQuery)data;
			if ((mask & 0x01) != 0)
			{
				position = other.position;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				radius = other.radius;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (WorldPositionQuery)data;

			if (position.DiffersFrom(newData.position, _position_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}
			if (radius.DiffersFrom(newData.radius, _radius_Epsilon)) {
				mask |= 0b00000000000000000000000000000010;
			}

			return mask;
		}

		public static void Serialize(WorldPositionQuery data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.position.x, _position_Min, _position_Max, "WorldPositionQuery.position.x");

				Coherence.Utils.Bounds.Check(data.position.y, _position_Min, _position_Max, "WorldPositionQuery.position.y");

				Coherence.Utils.Bounds.Check(data.position.z, _position_Min, _position_Max, "WorldPositionQuery.position.z");

				bitStream.WriteVector3f(CoherenceToUnityConverters.FromUnityfloat3(data.position), 24, 2400);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.radius, _radius_Min, _radius_Max, "WorldPositionQuery.radius");

				bitStream.WriteFixedPoint(CoherenceToUnityConverters.FromUnityfloat(data.radius), 24, 2400);
			}
			mask >>= 1;
		}

		public static (WorldPositionQuery, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new WorldPositionQuery();
			if (bitStream.ReadMask())
			{
				val.position = CoherenceToUnityConverters.ToUnityfloat3(bitStream.ReadVector3f(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.radius = CoherenceToUnityConverters.ToUnityfloat(bitStream.ReadFixedPoint(24, 2400));
				mask |= 0b00000000000000000000000000000010;
			}
			return (val, mask, null);
		}
	}
}
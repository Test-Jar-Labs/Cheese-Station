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

	public struct GlobalQuery : ICoherenceComponentData
	{

		public override string ToString()
		{
			return $"GlobalQuery()";
		}

		public uint GetComponentType() => Definition.InternalGlobalQuery;

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
			var other = (GlobalQuery)data;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GlobalQuery)data;


			return mask;
		}

		public static void Serialize(GlobalQuery data, uint mask, IOutProtocolBitStream bitStream)
		{
		}

		public static (GlobalQuery, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GlobalQuery();
			return (val, mask, null);
		}
	}
}
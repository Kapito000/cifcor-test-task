using System;
using Feature.Energy.Behaviour;
using Infrastructure.ECS;

namespace Feature.Energy.Component
{
	public struct EnergyComponent { public int Value; }
	[Serializable]
	public struct EnergyDisplayComponent { public EnergyDisplay Value; }
	public struct ChangeEnergyRequest { public int Value; }
}
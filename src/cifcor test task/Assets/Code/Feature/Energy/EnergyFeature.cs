using Factory.SystemFactory;
using Feature.Energy.System;

namespace Feature.Energy
{
	public sealed class EnergyFeature : Infrastructure.ECS.Feature
	{
		public EnergyFeature(ISystemFactory systemFactory) : base(systemFactory)
		{
			AddInit<CreateEnergySystem>();
			AddUpdate<ChangeEnergySystem>();
			AddUpdate<EnergyDisplaySystem>();
			AddCleanup<Cleanup>();
		}
	}
}
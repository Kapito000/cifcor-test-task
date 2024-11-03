using Feature.Energy.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Feature.Energy.System
{
	public sealed class EnergyDisplaySystem : EcsSystem, IEcsRunSystem
	{
		readonly EcsFilterInject<Inc<EnergyDisplayComponent>> _displayFilter;
		readonly EcsFilterInject<Inc<ChangeEnergyRequest, EnergyComponent>> _energyFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var energyEntity in _energyFilter.Value)
			foreach (var display in _displayFilter.Value)
			{
				ref var energyDisplay = ref _world.GetPool<EnergyDisplayComponent>()
					.Get(display);
				ref var energy = ref _world.GetPool<EnergyComponent>()
					.Get(energyEntity);
				energyDisplay.Value.SetValue(energy.Value);
			}
		}
	}
}
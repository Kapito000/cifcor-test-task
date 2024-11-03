using Feature.Energy.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Feature.Energy.System
{
	public sealed class ChangeEnergySystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _energy;
		
		readonly EcsFilterInject<Inc<ChangeEnergyRequest, EnergyComponent>> _filter;
		
		public void Run(IEcsSystems systems)
		{
			foreach (var e in _filter.Value)
			{
				_energy.SetEntity(e);
				var value = _energy.ChangeEnergyRequest();
				var energyValue = _energy.Energy();
				_energy.SetEnergy(energyValue - value);
			}
		}
	}
}
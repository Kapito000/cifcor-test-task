using Extensions;
using Feature.Energy.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Feature.Energy.System
{
	public sealed class Cleanup : EcsSystem, IEcsRunSystem
	{
		readonly EcsFilterInject<Inc<ChangeEnergyRequest>> _changeFilter;
		
		public void Run(IEcsSystems systems)
		{
			foreach (var e in _changeFilter.Value) 
				_world.Remove<ChangeEnergyRequest>(e);
		}
	}
}
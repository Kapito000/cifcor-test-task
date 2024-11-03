using Extensions;
using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Feature.Tap.System
{
	public sealed class Cleanup : EcsSystem, IEcsRunSystem
	{
		readonly EcsFilterInject<Inc<Taped>> _tapedFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var e in _tapedFilter.Value) 
				_world.Remove<Taped>(e);
		}
	}
}
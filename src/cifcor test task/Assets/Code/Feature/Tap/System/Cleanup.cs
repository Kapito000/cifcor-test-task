using Extensions;
using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Feature.Tap.System
{
	public sealed class Cleanup : EcsSystem, IEcsRunSystem
	{
		readonly EcsFilterInject<Inc<Taped>> _filter;
		
		public void Run(IEcsSystems systems)
		{
			foreach (var e in _filter.Value)
			{
				_world.Remove<Taped>(e);
			}
		}
	}
}
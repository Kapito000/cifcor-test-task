using Feature.Input.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Feature.Input.System
{
	public sealed class TapCleanupSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _tap;

		readonly EcsFilterInject<Inc<TapComponent, ScreenPosition>> _filter;

		public void Run(IEcsSystems systems)
		{
			foreach (var e in _filter.Value)
			{
				_tap.SetEntity(e);
				_tap
					.Remove<TapComponent>()
					.Remove<ScreenPosition>()
					;
			}
		}
	}
}
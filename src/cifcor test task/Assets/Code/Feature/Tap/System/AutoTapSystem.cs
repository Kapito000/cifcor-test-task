using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class AutoTapSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _autoTap;
		[Inject] EntityWrapper _tapTarget;

		readonly EcsFilterInject<Inc<TapTarget>> _tapTargetFilter;
		readonly EcsFilterInject<Inc<AutoTap, AutoTapRequest>> _autoTapFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var autoTap in _autoTapFilter.Value)
			foreach (var target in _tapTargetFilter.Value)
			{
				_tapTarget.SetEntity(target);
				_tapTarget.Replace<Taped>();

				_autoTap.SetEntity(autoTap);
				_autoTap.Remove<AutoTapRequest>();
			}
		}
	}
}
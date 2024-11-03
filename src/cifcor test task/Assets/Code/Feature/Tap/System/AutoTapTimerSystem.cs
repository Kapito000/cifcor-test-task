using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class AutoTapTimerSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _timer;

		readonly EcsFilterInject<Inc<AutoTapTimer, AutoTapInterval>> _timerFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var e in _timerFilter.Value)
			{
				_timer.SetEntity(e);
				var autoTapTimerValue = _timer.AutoTapTimer();
				if (autoTapTimerValue > 0)
				{
					_timer.SetAutoTapTimer(autoTapTimerValue - Time.deltaTime);
					continue;
				}

				var interval = _timer.AutoTapInterval();
				_timer.SetAutoTapTimer(interval);
				_timer.Add<AutoTapRequest>();
			}
		}
	}
}
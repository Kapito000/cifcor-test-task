using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class CreateAutoTap : EcsSystem, IEcsInitSystem
	{
		[Inject] EntityWrapper _autoTap;
		[Inject] IGameBalance _gameBalance;
		
		public void Init(IEcsSystems systems)
		{
			var e = _world.NewEntity();
			_autoTap.SetEntity(e);
			_autoTap
				.Add<AutoTap>()
				.Add<AutoTapTimer>()
				.AddAutoTapInterval(_gameBalance.AutoTapInterval)
			;
		}
	}
}
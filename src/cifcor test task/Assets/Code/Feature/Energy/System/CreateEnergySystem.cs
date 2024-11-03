using Feature.Player.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Energy.System
{
	public sealed class CreateEnergySystem : IEcsInitSystem
	{
		[Inject] EntityWrapper _player;
		[Inject] IGameBalance _gameBalance;

		readonly EcsFilterInject<Inc<PlayerComponent>> _playerFilter;

		public void Init(IEcsSystems systems)
		{
			foreach (var e in _playerFilter.Value)
			{
				_player.SetEntity(e);
				_player
					.AddEnergy(_gameBalance.StartEnergy)
					;
			}
		}
	}
}
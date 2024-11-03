using Feature.Player.Component;
using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Feature.Wallet.System
{
	public sealed class CreateWalletSystem : IEcsInitSystem
	{
		[Inject] EntityWrapper _player;
		
		readonly EcsFilterInject<Inc<PlayerComponent>> _playerFilter;
		
		public void Init(IEcsSystems systems)
		{
			foreach (var e in _playerFilter.Value)
			{
				_player.SetEntity(e);
				_player
					.Add<WalletComponent>()
					.Add<WalletCurrency>()
					;
			}
		}
	}
}
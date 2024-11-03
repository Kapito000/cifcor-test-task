using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Feature.Wallet.System
{
	public sealed class DisplayBalanceSystem : EcsSystem, IEcsRunSystem
	{
		readonly EcsFilterInject<Inc<WalletBalanceDisplay>> _displayFilter;
		readonly EcsFilterInject<Inc<WalletCurrency, ChangeBalanceRequest>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var walletEntity in _walletFilter.Value)
			foreach (var display in _displayFilter.Value)
			{
				ref var balanceDisplay = ref _world.GetPool<WalletBalanceDisplay>()
					.Get(display);
				ref var wallet = ref _world.GetPool<WalletCurrency>()
					.Get(walletEntity);
				balanceDisplay.Value.SetValue(wallet.Value);
			}
		}
	}
}
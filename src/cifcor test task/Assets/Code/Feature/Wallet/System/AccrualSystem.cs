using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Wallet.System
{
	public sealed class AccrualSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _wallet;
		[Inject] EntityWrapper _tapTarget;
		[Inject] IGameBalance _gameBalance;

		readonly EcsFilterInject<
			Inc<WalletComponent, WalletCurrency, ChangeBalanceRequest>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var wallet in _walletFilter.Value)
			{
				_wallet.SetEntity(wallet);
				_wallet.AppendCurrency(_gameBalance.AccrualByTap);
				_wallet.Remove<ChangeBalanceRequest>();
			}
		}
	}
}
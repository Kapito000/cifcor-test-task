using Feature.Tap.Component;
using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class TapSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _target;
		[Inject] EntityWrapper _wallet;
		[Inject] IGameBalance _gameBalance;

		readonly EcsFilterInject<Inc<TapTarget, Taped>> _tapTargetFilter;
		readonly EcsFilterInject<Inc<WalletCurrency>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var target in _tapTargetFilter.Value)
			foreach (var wallet in _walletFilter.Value)
			{
				_wallet.SetEntity(wallet);
				_wallet.ChangeWalletBalanceRequest(_gameBalance.AccrualByTap);
				
				_target.SetEntity(target);
				_target.Remove<Taped>();
			}
		}
	}
}
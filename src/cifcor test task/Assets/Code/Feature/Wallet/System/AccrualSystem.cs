using Feature.Tap.Component;
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

		readonly EcsFilterInject<Inc<TapTarget, Taped>> _tapTargetFilter;
		readonly EcsFilterInject<Inc<WalletComponent, WalletCurrency>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var target in _tapTargetFilter.Value)
			foreach (var wallet in _walletFilter.Value)
			{
				_wallet.SetEntity(wallet);
				_tapTarget.SetEntity(target);

				_wallet.AppendCurrency(_gameBalance.AccrualByTap);
			}
		}
	}
}
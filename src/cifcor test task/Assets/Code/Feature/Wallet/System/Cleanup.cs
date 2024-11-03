using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Wallet.System
{
	public sealed class Cleanup : IEcsRunSystem
	{
		[Inject] EntityWrapper _wallet;
		[Inject] IGameBalance _gameBalance;

		readonly EcsFilterInject<Inc<ChangeBalanceRequest>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var wallet in _walletFilter.Value)
			{
				_wallet.SetEntity(wallet);
				_wallet.Remove<ChangeBalanceRequest>();
			}
		}
	}
}
using Factory.SystemFactory;
using Feature.Wallet.System;

namespace Feature.Wallet
{
	public sealed class WalletFeature : Infrastructure.ECS.Feature
	{
		public WalletFeature(ISystemFactory systemFactory) : base(systemFactory)
		{
			AddInit<CreateWalletSystem>();
			AddUpdate<AccrualSystem>();
			AddUpdate<DisplayBalanceSystem>();
			AddCleanup<Cleanup>();
		}
	}
}
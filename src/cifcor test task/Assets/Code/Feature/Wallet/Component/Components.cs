using System;
using Feature.Wallet.Behaviour;

namespace Feature.Wallet.Component
{
	public struct WalletCurrency { public int Value; }
	public struct WalletComponent { }
	public struct ChangeBalanceRequest { public int Value; }
	[Serializable]
	public struct WalletBalanceDisplay { public BalanceDisplay Value; }
}
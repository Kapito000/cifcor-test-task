using StaticData.GameBalance;
using Zenject;

namespace Feature.TapProcessor
{
	public sealed class StandardAccrualModifier : IAccrualModifier
	{
		[Inject] IGameBalance _balance;

		public int Modify(int accrual) =>
			accrual + (int)(_balance.AutoTapAccrual * _balance.AutoTapModifier);
	}
}
using PlayerProgress;
using StaticData.GameBalance;
using Zenject;

namespace Feature.TapProcessor
{
	public sealed class StandardTapProcessor : ITapProcessor
	{
		[Inject] IGameBalance _balance;
		[Inject] IPlayerProgress _player;
		[Inject] IAccrualModifier _accrualModifier;

		public bool IsCanTap() =>
			_player.Energy > _balance.TapEnergyCost;

		public int ProcessTap()
		{
			_player.Energy -= _balance.TapEnergyCost;
			var accrual = _accrualModifier.Modify(_balance.AccrualByTap);
			return _player.Currency = accrual;
		}
	}
}
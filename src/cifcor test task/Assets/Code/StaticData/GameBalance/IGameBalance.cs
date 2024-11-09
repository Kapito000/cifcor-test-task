namespace StaticData.GameBalance
{
	public interface IGameBalance : IStaticData
	{
		int AccrualByTap { get; }
		int StartEnergy { get; }
		int TapEnergyCost { get; }
		int AutoTapAccrual { get; }
		float AutoTapInterval { get; }
		float AutoTapModifier { get; }
	}
}
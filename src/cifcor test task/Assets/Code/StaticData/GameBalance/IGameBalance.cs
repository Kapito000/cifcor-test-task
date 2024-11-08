﻿namespace StaticData.GameBalance
{
	public interface IGameBalance : IStaticData
	{
		int AccrualByTap { get; }
		int StartEnergy { get; }
		int TapCost { get; }
		float AutoTapInterval { get; }
	}
}
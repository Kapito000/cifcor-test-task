using System;

namespace PlayerProgress
{
	public interface IPlayerProgress
	{
		int Energy { get; set; }
		int Currency { get; set; }
		
		event Action<int> EnergyValueChanged;
		event Action<int> CurrencyValueChanged;
	}
}
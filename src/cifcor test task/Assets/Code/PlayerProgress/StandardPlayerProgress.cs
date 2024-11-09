using System;
using UnityEngine;

namespace PlayerProgress
{
	public sealed class StandardPlayerProgress : MonoBehaviour, IPlayerProgress
	{
		[SerializeField] public int _energy;
		[SerializeField] public int _currency;

		public int Energy
		{
			get => _energy;
			set
			{
				_energy = value;
				EnergyValueChanged?.Invoke(value);
			}
		}
		public int Currency
		{
			get => _currency;
			set
			{
				_currency = value;
				CurrencyValueChanged?.Invoke(value);
			}
		}

		public event Action<int> EnergyValueChanged;
		public event Action<int> CurrencyValueChanged;
	}
}
using Common;
using PlayerProgress;
using StaticData.GameBalance;
using UnityEngine;
using Zenject;

namespace Feature
{
	public sealed class AutoTapHandler : MonoBehaviour
	{
		[Inject] IGameBalance _balance;
		[Inject] IPlayerProgress _progress;

		readonly Timer _timer = new();

		void Awake()
		{
			_timer.Init(TapInterval());
		}

		void Update()
		{
			if (_timer.Update(Time.deltaTime) == false)
				return;

			_progress.Currency += _balance.AutoTapAccrual;
			ResetTimer();
		}

		void ResetTimer()
		{
			_timer.Init(TapInterval());
		}

		float TapInterval() =>
			_balance.AutoTapInterval;
	}
}
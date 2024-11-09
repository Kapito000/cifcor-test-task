using PlayerProgress;
using StaticData.GameBalance;
using UnityEngine;
using Zenject;

namespace Infrastructure.SceneInitializer
{
	public sealed class StandardSceneInitializer : MonoBehaviour, ISceneInitializer
	{
		[Inject] IGameBalance _balance;
		[Inject] IPlayerProgress _progress;

		public void Init()
		{
			_progress.Currency = 0;
			_progress.Energy = _balance.StartEnergy;
		}
	}
}
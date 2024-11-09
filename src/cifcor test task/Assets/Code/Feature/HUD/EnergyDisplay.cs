using PlayerProgress;
using Zenject;

namespace Feature.HUD
{
	public sealed class EnergyDisplay : TextDisplay
	{
		[Inject] IPlayerProgress _progress;

		protected override void OnAwake()
		{
			_progress.EnergyValueChanged += OnEnergyValueChanged;
		}

		void OnDestroy()
		{
			_progress.EnergyValueChanged -= OnEnergyValueChanged;
		}

		void OnEnergyValueChanged(int value)
		{
			_text.text = value.ToString();
		}
	}
}
using PlayerProgress;
using Zenject;

namespace Feature.HUD
{
	public sealed class CurrencyDisplay : TextDisplay
	{
		[Inject] IPlayerProgress _progress;

		protected override void OnAwake()
		{
			_progress.CurrencyValueChanged += OnCurrencyValueChanged;
		}

		void OnDestroy()
		{
			_progress.CurrencyValueChanged -= OnCurrencyValueChanged;
		}

		void OnCurrencyValueChanged(int value)
		{
			_text.text = value.ToString();
		}
	}
}
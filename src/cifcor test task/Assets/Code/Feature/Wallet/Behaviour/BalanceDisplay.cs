using TMPro;
using UnityEngine;

namespace Feature.Wallet.Behaviour
{
	public sealed class BalanceDisplay : MonoBehaviour
	{
		[SerializeField] TMP_Text _value;

		public void SetValue(int value)
		{
			_value.text = value.ToString();
		}
	}
}
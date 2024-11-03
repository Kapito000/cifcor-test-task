using TMPro;
using UnityEngine;

namespace Feature.Energy.Behaviour
{
	public sealed class EnergyDisplay : MonoBehaviour
	{
		[SerializeField] TMP_Text _value;

		public void SetValue(int value)
		{
			_value.text = value.ToString();
		}
	}
}
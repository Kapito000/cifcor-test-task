using TMPro;
using UnityEngine;

namespace Feature.Tap.Behaviour
{
	public sealed class TapFX : MonoBehaviour
	{
		[SerializeField] TMP_Text _num;

		public void SetNum(int num)
		{
			_num.text = num.ToString();
		}
	}
}
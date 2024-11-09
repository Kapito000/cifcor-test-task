using TMPro;
using UnityEngine;

namespace Feature
{
	public sealed class TapFX : MonoBehaviour
	{
		[SerializeField] float _life = 2;
		[SerializeField] TMP_Text _num;

		void Awake()
		{
			Destroy(this.gameObject, _life);
		}

		public void SetNum(int num)
		{
			_num.text = num.ToString();
		}
	}
}
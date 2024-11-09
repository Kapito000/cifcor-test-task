using TMPro;
using UnityEngine;

namespace Feature.HUD
{
	[RequireComponent(typeof(TMP_Text))]
	public abstract class TextDisplay : MonoBehaviour
	{
		protected TMP_Text _text;

		void Awake()
		{
			_text = GetComponent<TMP_Text>();
			OnAwake();
		}

		protected virtual void OnAwake()
		{ }
	}
}
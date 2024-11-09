using UnityEngine;

namespace PlayerProgress
{
	public sealed class StandardPlayerProgress : MonoBehaviour, IPlayerProgress
	{
		[field: SerializeField] public int Energy { get; set; }
		[field: SerializeField] public int Currency { get; set; }
	}
}
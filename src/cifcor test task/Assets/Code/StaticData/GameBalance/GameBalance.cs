using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace StaticData.GameBalance
{
	[CreateAssetMenu(menuName = Menu.Path.c_StaticData + nameof(GameBalance))]
	public sealed class GameBalance : ScriptableObject, IGameBalance
	{
		[field: SerializeField] public int AccrualByTap { get; private set; } = 10;
		[field: SerializeField] public int StartEnergy { get; private set; } = 100;
		[field: SerializeField] public int TapEnergyCost { get; private set; } = 1;
		[field: SerializeField] public int AutoTapAccrual { get; private set; } = 2;
		[field: SerializeField] public float AutoTapInterval { get; private set; } = 2;
		[field: SerializeField] public float AutoTapModifier { get; private set; } = .1f;
	}
}
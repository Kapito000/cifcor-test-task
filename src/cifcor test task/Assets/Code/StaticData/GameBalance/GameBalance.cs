using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace StaticData.GameBalance
{
	[CreateAssetMenu(menuName = Menu.Path.c_StaticData + nameof(GameBalance))]
	public sealed class GameBalance : ScriptableObject, IGameBalance
	{
		[field: SerializeField] public int AccrualByTap { get; private set; } = 1;
	}
}
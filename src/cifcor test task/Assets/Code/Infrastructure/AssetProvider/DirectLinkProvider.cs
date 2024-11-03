using UnityEngine;
using UnityEngine.EventSystems;
using Menu = Constant.CreateAssetMenu;

namespace Infrastructure.AssetProvider
{
	[CreateAssetMenu(
		menuName = Menu.Path.c_AssetProvider + nameof(DirectLinkProvider),
		fileName = nameof(DirectLinkProvider))]
	public sealed class DirectLinkProvider : ScriptableObject, IAssetProvider
	{
		[Header("UI")]
		[SerializeField] EventSystem _eventSystem;
		[SerializeField] Canvas _hudRoot;

		public Canvas HudRoot() => _hudRoot;
		public EventSystem EventSystem() => _eventSystem;
	}
}
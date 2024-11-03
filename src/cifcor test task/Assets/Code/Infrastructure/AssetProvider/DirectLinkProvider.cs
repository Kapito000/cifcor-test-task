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
		[SerializeField] GameObject _tapTarget;
		[Header("UI")]
		[SerializeField] Canvas _hudRoot;
		[SerializeField] EventSystem _eventSystem;

		public GameObject TapTarget() => _tapTarget;
		public Canvas HudRoot() => _hudRoot;
		public EventSystem EventSystem() => _eventSystem;
	}
}
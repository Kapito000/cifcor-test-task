using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.AssetProvider
{
	public interface IAssetProvider : IService
	{
		Canvas HudRoot();
		EventSystem EventSystem();
	}
}
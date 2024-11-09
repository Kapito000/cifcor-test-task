using Factory.Kit;
using UnityEngine;
using Zenject;

namespace Feature.Tap.Factory
{
	public sealed class TapFactory : ITapFactory
	{
		[Inject] IFactoryKit _factoryKit;
		
		public void CreateTapFX(Vector2 pos, Transform parent, int accruedCurrency)
		{
			var prefab = _factoryKit.AssetProvider.TapFX();
			var tapFX = _factoryKit.InstantiateService
				.Instantiate<TapFX>(prefab, pos, parent);
			tapFX.SetNum(accruedCurrency);
		}
	}
}
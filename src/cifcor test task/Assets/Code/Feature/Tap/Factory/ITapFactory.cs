using Factory;
using UnityEngine;

namespace Feature.Tap.Factory
{
	public interface ITapFactory : IFactory
	{
		void CreateTapFX(Vector2 pos, Transform parent, int accruedCurrency);
	}
}
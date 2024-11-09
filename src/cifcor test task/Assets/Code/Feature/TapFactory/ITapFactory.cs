using Factory;
using UnityEngine;

namespace Feature.TapFactory
{
	public interface ITapFactory : IFactory
	{
		void CreateTapFX(Vector2 pos, Transform parent, int accruedCurrency);
	}
}
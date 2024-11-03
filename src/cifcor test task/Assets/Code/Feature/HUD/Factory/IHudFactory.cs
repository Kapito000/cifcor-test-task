using Factory;
using UnityEngine;

namespace Feature.HUD.Factory
{
	public interface IHudFactory : IFactory
	{
		int CreateHudRoot();
		void CreateEventSystem();
	}
}
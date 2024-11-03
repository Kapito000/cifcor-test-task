using Factory;
using Feature.Tap.Behaviour;
using UnityEngine;

namespace Feature.Tap.Factory
{
	public interface ITapFactory : IFactory
	{
		int CreateTapHandler();
		int CreateTapTarget();
		TapFX CreateTapFX(Vector3 pos, int numText);
	}
}
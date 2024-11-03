using Feature.Tap.Factory;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class CreateTapTarget : IEcsInitSystem
	{
		[Inject] ITapFactory _tapFactory;
		
		public void Init(IEcsSystems systems)
		{
			_tapFactory.CreateTapTarget();
		}
	}
}
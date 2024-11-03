using Feature.Tap.Factory;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class CreateTapHandler : IEcsInitSystem
	{
		[Inject] ITapFactory _tapFactory;
		
		public void Init(IEcsSystems systems)
		{
			var e = _tapFactory.CreateTapHandler();
		}
	}
}
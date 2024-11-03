using Factory.SystemFactory;
using Feature.Tap.System;

namespace Feature.Tap
{
	public sealed class TapFeature : Infrastructure.ECS.Feature
	{
		public TapFeature(ISystemFactory systemFactory) : base(systemFactory)
		{
			AddInit<CreateTapHandler>();
			AddInit<CreateTapTarget>();
			AddUpdate<TapSystem>();
			AddCleanup<Cleanup>();
		}
	}
}
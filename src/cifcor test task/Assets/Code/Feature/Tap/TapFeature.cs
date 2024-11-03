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
			AddInit<CreateAutoTap>();
			
			AddUpdate<ProseccTapInputSystem>();
			AddUpdate<AutoTapTimerSystem>();
			AddUpdate<AutoTapSystem>();
			AddUpdate<TapSystem>();
			AddUpdate<TapFxSystem>();
			
			AddCleanup<Cleanup>();
		}
	}
}
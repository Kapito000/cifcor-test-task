using Factory.SystemFactory;
using Feature.Player.System;

namespace Feature.Player
{
	public sealed class PlayerFeature : Infrastructure.ECS.Feature
	{
		public PlayerFeature(ISystemFactory systemFactory) : base(systemFactory)
		{
			AddInit<CreatePlayerSystem>();
		}
	}
}
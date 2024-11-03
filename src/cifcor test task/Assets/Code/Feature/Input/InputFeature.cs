using Factory.SystemFactory;

namespace Feature.Input
{
	public sealed class InputFeature : Infrastructure.ECS.Feature
	{
		public InputFeature(ISystemFactory systemFactory) : base(systemFactory)
		{ }
	}
}
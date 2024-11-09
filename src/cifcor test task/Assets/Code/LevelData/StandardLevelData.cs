using Infrastructure.Boot;
using Infrastructure.SceneInitializer;

namespace LevelData
{
	public sealed class StandardLevelData : ILevelData
	{
		public IDevSceneRunner DevSceneRunner { get; set; }
		public ISceneInitializer SceneInitializer { get; set; }
	}
}
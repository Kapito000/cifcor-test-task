using Infrastructure;
using Infrastructure.Boot;
using Infrastructure.SceneInitializer;

namespace LevelData
{
	public interface ILevelData : IService
	{
		IDevSceneRunner DevSceneRunner { get; set; }
		ISceneInitializer SceneInitializer { get; set; }
	}
}
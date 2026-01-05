namespace Modules.Grih.SceneChanger.Public.Interfaces
{
    public interface ISceneChanger
    {
        public void Init(SceneChangerScript sceneChanger, string loadScene)
        {
            sceneChanger.Init(loadScene);
            sceneChanger.NewScene += OnNewScene;
        }

        public void OnNewScene(string value);
    }
}
using System;
using Modules.Grih.SceneChanger.Public.Interfaces;
using Modules.Grih.SceneChanger;
using YG;

namespace Game
{
    internal class SceneChangerSource : ISceneChanger
    {
        private Modules.Grih.SceneChanger.Public.Interfaces.ISceneChanger _source;

        public void Init(ISceneChanger source, SceneChangerScript sceneChanger, string loadScene)
        {
            _source = source;
            _source.Init(sceneChanger, loadScene);
        }

        public void OnNewScene(string value)
        {
            YG2.saves.CurrentScene = value;
            YG2.SaveProgress();
        }
    }
}
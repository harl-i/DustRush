using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Grih.SceneChanger
{
    public class SceneChangerScript : MonoBehaviour
    {
        private const string Sity = "Sity";
        private const string SampleScene = "SampleScene";

        private string _loadScene;

        public event Action<string> NewScene;

        public void Init(string loadScene)
        {
            _loadScene = loadScene; 
            
            if (SceneManager.GetActiveScene().name != _loadScene)
            {
                SceneManager.LoadScene(_loadScene);
            }
        }

        public void ChangeLocation(bool isSity)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (isSity == false)
            {
                NewScene?.Invoke(SampleScene);
                SceneManager.LoadScene(SampleScene);
            }
            else
            {
                NewScene?.Invoke(Sity);
                SceneManager.LoadScene(Sity);
            }
        }
    }
}
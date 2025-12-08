using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modules.Grih.SceneChanger
{
    public class SceneChangerScript : MonoBehaviour
    {
        private const string Sity = "Sity";
        private const string SampleScene = "SampleScene";

        [SerializeField] private Button _changeButton;

        private string _loadScene;

        public event Action<string> NewScene;

        public void Init(string loadScene)
        {
            _loadScene = loadScene; 
            
            if (SceneManager.GetActiveScene().name != _loadScene)
            {
                Debug.Log(_loadScene);
                SceneManager.LoadScene(_loadScene);
            }
        }

        private void Start()
        {
            _changeButton.onClick.AddListener(OnSceneChange);
        }

        private void OnDestroy()
        {
            _changeButton.onClick.RemoveListener(OnSceneChange);
        }

        private void OnSceneChange()
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == Sity)
            {
                NewScene?.Invoke(SampleScene);
                SceneManager.LoadScene(SampleScene);
            }
            else if (currentScene == SampleScene)
            {
                NewScene?.Invoke(Sity);
                SceneManager.LoadScene(Sity);
            }
        }

    }
}
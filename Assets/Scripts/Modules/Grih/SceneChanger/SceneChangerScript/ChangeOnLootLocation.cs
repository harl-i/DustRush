using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.SceneChanger
{
    public class ChangeOnLootLocation : MonoBehaviour
    {
        [SerializeField] private SceneChangerScript _sceneChanger;
        [SerializeField] private Button _enterButton;

        public event Action Activated;

        private void Start()
        {
            _enterButton.onClick.AddListener(OnClickEnter);
        }

        private void OnDestroy()
        {
            _enterButton.onClick.RemoveListener(OnClickEnter);
        }

        private void OnClickEnter()
        {
            Activated?.Invoke();
            _sceneChanger.ChangeOnLootLocation();
        }
    }
}
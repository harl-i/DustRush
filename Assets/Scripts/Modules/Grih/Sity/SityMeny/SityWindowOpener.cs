using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class SityWindowOpener : MonoBehaviour
    {
        [SerializeField] private Button _changeActivity;
        [SerializeField] private GameObject _window;

        public event Action<bool, SityWindowOpener> Pressed;

        private void OnEnable()
        {
            _changeActivity.onClick.AddListener(ChangeActivity);
        }

        private void OnDisable()
        {
            _changeActivity.onClick.RemoveListener(ChangeActivity);
        }

        public void ChangeView(bool isActive)
        {
            _window.SetActive(isActive);
        }

        private void ChangeActivity()
        {
            Pressed?.Invoke(!_window.activeSelf, this);
        }
    }
}
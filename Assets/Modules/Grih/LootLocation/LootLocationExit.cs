using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.LootLocation
{
    public class LootLocationExit: MonoBehaviour
    {
        [SerializeField] private Button _exit;
        [SerializeField] private SceneChanger.SceneChangerScript _sceneChanger;

        private bool _isPrediosIsSity;

        private void OnDestroy()
        {
            _exit.onClick.RemoveListener(OnExit);
        }

        public void Init(bool isPrediosIsSity)
        {
            _exit.onClick.AddListener(OnExit);
            _isPrediosIsSity = isPrediosIsSity;
        }

        private void OnExit()
        {
            _sceneChanger.ChangeLocation(_isPrediosIsSity);
        }
    }
}
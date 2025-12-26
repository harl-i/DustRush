using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class CooldownDumpTimer : MonoBehaviour
    {
        private const int OneSecond = 1;

        [SerializeField] private int _cooldownLife;
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private Button _dumbEnter;
        [SerializeField] private GlobalMap.GlobalMap _globalMap;

        public event Action<int> CooldownSave;

        private int _curentTime;
        private WaitForSeconds _wait;
        private Coroutine _waitngCooldown = null;

        void OnDisable()
        {
            _dumbEnter.onClick.RemoveListener(OnTryEnter);
            _globalMap.Finished -= OnFinished;
            Save();
        }

        public void Init(int savedPredios)
        {
            _counterText.gameObject.SetActive(false);
            _dumbEnter.onClick.AddListener(OnTryEnter);
            _curentTime = savedPredios;
            _wait = new WaitForSeconds(OneSecond);
            _globalMap.Finished += OnFinished;

            if (_curentTime > 0)
            {
                _counterText.gameObject.SetActive(true);
                _dumbEnter.interactable = false;

                if (_waitngCooldown == null)
                    _waitngCooldown = StartCoroutine(Cooldowning());
            }
            else
            {
                _dumbEnter.interactable = true;
                _counterText.gameObject.SetActive(false);
            }
        }

        private void OnFinished()
        {
            _curentTime = 0;
            Save();
        }

        private void OnTryEnter()
        {
            _curentTime = _cooldownLife;
            Save();
        }

        private IEnumerator Cooldowning()
        {
            while (_curentTime > 0)
            {
                _counterText.text = (_curentTime -= OneSecond).ToString();

                yield return _wait;
            }

            _dumbEnter.interactable = true;
            _counterText.gameObject.SetActive(false);
        }

        private void Save()
        {
            CooldownSave?.Invoke(_curentTime);
        }
    }
}
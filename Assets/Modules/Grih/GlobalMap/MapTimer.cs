using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Grih.GlobalMap
{
    public class MapTimer : MonoBehaviour
    {
        [SerializeField] private GlobalMapView _mapView;
        [SerializeField] private TextMeshProUGUI _counterText;

        private Coroutine _cooldowningRound = null;
        private WaitForSeconds _wait;

        public void Init()
        {
            _wait = new WaitForSeconds(1);

            if (SceneManager.GetActiveScene().name != "Sity")
                SetNewTimer(_mapView.GetCurrentMapCellTimet());
        }

        public void SetNewTimer(float longTime)
        {
            if (_cooldowningRound == null)
                _cooldowningRound = StartCoroutine(CooldowningRound(longTime));
        }

        private IEnumerator CooldowningRound(float longTime)
        {
            while (longTime > 0)
            {
                _counterText.text = (longTime -= 1).ToString();

                yield return _wait;
            }

            _mapView.OnFinishPont();
            _cooldowningRound = null;
        }
    }
}
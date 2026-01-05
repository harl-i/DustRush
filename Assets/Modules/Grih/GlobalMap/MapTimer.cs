using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Grih.GlobalMap
{
    public class MapTimer : MonoBehaviour
    {
        private const int DividerUnFinishMap = 2;

        [SerializeField] private GlobalMapView _mapView;
        [SerializeField] private TextMeshProUGUI _counterText;

        private Coroutine _cooldowningRound = null;
        private WaitForSeconds _wait;

        public void Init(bool isUnfinishedPath)
        {
            _wait = new WaitForSeconds(1);

            if (SceneManager.GetActiveScene().name != "Sity")
            {
                if (isUnfinishedPath == false)
                {
                    SetNewTimer(_mapView.GetCurrentMapCellTime());
                }
                else
                {
                    SetNewTimer(_mapView.GetCurrentMapCellTime() / DividerUnFinishMap);
                }
            }
        }

        public void SetNewTimer(int longTime)
        {
            if (_cooldowningRound == null)
                _cooldowningRound = StartCoroutine(CooldowningRound(longTime));
        }

        private IEnumerator CooldowningRound(int longTime)
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
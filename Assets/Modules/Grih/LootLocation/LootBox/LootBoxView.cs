using System.Collections;
using TMPro;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class LootBoxView : MonoBehaviour
    {
        [SerializeField] private GameObject _moneyPrize;
        [SerializeField] private GameObject _metalPrize;
        [SerializeField] private GameObject _blueprintPrize;
        [SerializeField] private TextMeshProUGUI _valueView;

        [SerializeField] private float _viewLongValue;

        private WaitForSeconds _viewingTimeWait;

        private void Start()
        {
            _viewingTimeWait = new WaitForSeconds(_viewLongValue);

            _valueView.gameObject.SetActive(false);
            _moneyPrize.SetActive(false);
            _metalPrize.SetActive(false);
            _blueprintPrize.SetActive(false);
        }

        public void ViewPrizeMetal(int value)
        {
            _valueView.text = "+ " + value.ToString();
            _valueView.gameObject.SetActive(true);
            _metalPrize.gameObject.SetActive(true);

            StartCoroutine(OffViewing());
        }

        public void ViewPrizeMoney(int value)
        {
            _valueView.text = "+ " + value.ToString();
            _valueView.gameObject.SetActive(true);
            _moneyPrize.gameObject.SetActive(true);

            StartCoroutine(OffViewing());
        }

        public void ViewPrizeBlueprint()
        {
            _blueprintPrize.gameObject.SetActive(true);

            StartCoroutine(OffViewing());
        }

        private IEnumerator OffViewing()
        {
            yield return _viewingTimeWait;
            _valueView.gameObject.SetActive(false);
            _moneyPrize.SetActive(false);
            _metalPrize.SetActive(false);
            _blueprintPrize.SetActive(false);
        }
    }
}
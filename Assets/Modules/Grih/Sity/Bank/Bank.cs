using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int _moneyRate;
        [SerializeField] private int _metalRate;

        [SerializeField] private SumExchange _moneySum;
        [SerializeField] private SumExchange _metalSum;

        [SerializeField] private Button _acceptMoney;
        [SerializeField] private Button _acceptMetal;

        [SerializeField] private TextMeshProUGUI _moneyRateText;
        [SerializeField] private TextMeshProUGUI _metalRateText;

        [SerializeField] private Inventory.Metal _countMetal;
        [SerializeField] private Inventory.Money _countMoney;

        public int MoneyRate => _moneyRate;
        public int MetalRate => _metalRate;

        private void OnEnable()
        {
            _acceptMoney.onClick.AddListener(OnAcceptClickMoney);
            _acceptMetal.onClick.AddListener(OnAcceptClickMetal);
            _moneyRateText.text = _moneyRate.ToString();
            _metalRateText.text = _metalRate.ToString();
        }

        private void OnDisable()
        {
            _acceptMoney.onClick.RemoveListener(OnAcceptClickMoney);
            _acceptMetal.onClick.RemoveListener(OnAcceptClickMetal);
        }

        private void OnAcceptClickMoney()
        {
            if (_moneySum.Value > 0)
            {
                if (_countMetal.Value < _moneySum.Value * _moneyRate)
                {
                    _countMetal.ShowEffectGive();
                    return;
                }

                _countMoney.ChangeValue(_moneySum.Value);
                _countMetal.ChangeValue(- (_moneySum.Value * _moneyRate));
                SaveChange();
            }
        }

        private void OnAcceptClickMetal()
        {
            if (_metalSum.Value > 0)
            {
                if (_countMoney.Value < _metalSum.Value * _metalRate)
                {
                    _countMoney.ShowEffectGive();
                    return;
                }

                _countMetal.ChangeValue(_metalSum.Value);
                _countMoney.ChangeValue(-(_metalSum.Value * _metalRate));
                SaveChange();
            }
        }

        private void SaveChange()
        {
   //         _countMetal.Save();
  //          _countMoney.Save();
        }
    }
}
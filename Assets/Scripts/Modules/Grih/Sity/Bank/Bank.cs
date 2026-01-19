using Modules.Grih.InventoryGroup;
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

        [SerializeField] private Modules.Grih.InventoryGroup.Metal _countMetal;
        [SerializeField] private Modules.Grih.InventoryGroup.Money _countMoney;

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
            TryChangeValue(_moneySum, _countMoney, _countMetal);
        }

        private void OnAcceptClickMetal()
        {
            TryChangeValue(_metalSum, _countMetal, _countMoney);
        }

        private void TryChangeValue(
            SumExchange sum,
            InventoryItem counter,
            InventoryItem counterPayments)
        {
            if (sum.Value > 0)
            {
                if (counterPayments.Value < sum.NeedForChange)
                {
                    counterPayments.ShowEffectGive();
                    return;
                }

                counter.ChangeValue(sum.Value);
                counterPayments.ChangeValue(-sum.NeedForChange);
            }
        }
    }
}
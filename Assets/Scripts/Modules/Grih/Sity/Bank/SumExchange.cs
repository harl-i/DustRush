using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class SumExchange : MonoBehaviour
    {
        private const int ValueForOne = 1;
        private const int ValueTen = 10;

        public enum Type
        {
            Money,
            Metal,
        }

        [SerializeField] private Type _type;

        [SerializeField] private Button _add;
        [SerializeField] private Button _reduce;
        [SerializeField] private Button _addTen;
        [SerializeField] private Button _reduceTen;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _textNeedForChange;
        [SerializeField] private Bank _bank;

        private int _textNeedForChangeValue = 0;

        public int NeedForChange => _textNeedForChangeValue;

        public int Value { get; private set; }

        private void OnEnable()
        {
            _add.onClick.AddListener(OnClickAdd);
            _reduce.onClick.AddListener(OnClickReduce);
            _addTen.onClick.AddListener(OnClickAddTen);
            _reduceTen.onClick.AddListener(OnClickReduceTen);

            Value = 0;
            _text.text = 0.ToString();
            _textNeedForChange.text = 0.ToString();
        }

        private void OnDisable()
        {
            _add.onClick.RemoveListener(OnClickAdd);
            _reduce.onClick.RemoveListener(OnClickReduce);
            _addTen.onClick.RemoveListener(OnClickAddTen);
            _reduceTen.onClick.RemoveListener(OnClickReduceTen);
        }

        private void OnClickAdd()
        {
            ChangeCounter(ValueForOne);
        }

        private void OnClickReduce()
        {
            if (Value > 0)
                ChangeCounter(-ValueForOne);
        }

        private void OnClickAddTen()
        {
            ChangeCounter(ValueTen);
        }

        private void OnClickReduceTen()
        {
            if (Value - ValueTen > 0)
                ChangeCounter(-ValueTen);
        }

        private void ChangeCounter(int import)
        {
            Value += import;
            _text.text = Value.ToString();

            if (_type == Type.Metal)
            {
                _textNeedForChangeValue = Value * _bank.MoneyRate;
                _textNeedForChange.text = _textNeedForChangeValue.ToString();
            }
            else
            {
                _textNeedForChangeValue = Value * _bank.MetalRate;
                _textNeedForChange.text = _textNeedForChangeValue.ToString();
            }
        }
    }
}
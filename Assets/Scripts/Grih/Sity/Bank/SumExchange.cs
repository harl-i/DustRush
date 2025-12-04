using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sity
{
    public class SumExchange : MonoBehaviour
    {
        private const int ValueForOne = 1;
        private const int ValueForTen = 10;

        public enum TypeExchange
        {
            Money,
            Metal
        }

        [SerializeField] private TypeExchange _type;

        [SerializeField] private Button _add;
        [SerializeField] private Button _reduce;
        [SerializeField] private Button _addTen;
        [SerializeField] private Button _reduceTen;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _textNeedForChange;
        [SerializeField] private Bank _bank;

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
            ChangeCounter(ValueForTen);
        }

        private void OnClickReduceTen()
        {
            if (Value - ValueForTen > 0)
                ChangeCounter(-ValueForTen);
        }

        private void ChangeCounter(int import)
        {
            Value += import;
            _text.text = Value.ToString();

            if (_type == TypeExchange.Metal)
                _textNeedForChange.text = (Value * _bank.MetalRate).ToString();
            else
                _textNeedForChange.text = (Value * _bank.MoneyRate).ToString();
        }
    }
}
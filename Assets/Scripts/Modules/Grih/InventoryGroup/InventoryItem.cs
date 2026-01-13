using System;
using TMPro;
using UnityEngine;

namespace Modules.Grih.InventoryGroup
{
    public abstract class InventoryItem : MonoBehaviour
    {
        [SerializeField] private CounterEffector _effector;
        [SerializeField] private TextMeshProUGUI _text;

        public int Value { get; private set; }

        public event Action<int> ValueChange;

        public void Init(int value)
        {
            ChangeValue(value);
        }

        public void ChangeValue(int value)
        {
            Value += value;
            _text.text = Value.ToString();

            if (value > 0)
                ShowEffectAdd();
            else
                ShowEffectGive();

            ValueChange?.Invoke(Value);
        }

        public void ShowEffectAdd()
        {
            _effector.ShowPositiveEffect();
        }

        public void ShowEffectGive()
        {
            _effector.ShowNegativeEffect();
        }
    }
}

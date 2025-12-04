using TMPro;
using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItem : MonoBehaviour
    {
        [SerializeField] private CounterEffector _effector;
        [SerializeField] private TextMeshProUGUI _text;

        public int Value { get; private set; }

        public void ChangeValue(int value)
        {
            Value += value;
            _text.text = Value.ToString();

            if (value > 0)
                ShowEffectAdd();
            else
                ShowEffectGive();

            Save();
        }

        public void ShowEffectAdd()
        {
            _effector.ShowPositiveEffect();
        }

        public void ShowEffectGive()
        {
            _effector.ShowNegativeEffect();
        }

        public abstract void Save();
    }
}

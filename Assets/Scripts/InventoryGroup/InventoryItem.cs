using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItem : MonoBehaviour
    {
        public int Value { get; private set; }

        [SerializeField] private CounterEffector _effector;

        public void ChangeValue(int value)
        {
            Value += value;

            if (value > 0)
                ShowEffectAdd();
            else
                ShowEffectGive();
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

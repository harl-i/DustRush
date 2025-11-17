using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItem : MonoBehaviour
    {
        [SerializeField] private CounterEffector _effector;

        public int Value { get; private set; }

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

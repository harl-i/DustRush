using UnityEngine;

namespace Inventory
{
    public class PlayerStorage : MonoBehaviour
    {
        [SerializeField] private Money _money;
        [SerializeField] private Metal _metal;

        public int Money => _money.Value;

        public int Metal => _metal.Value;

        public void ChangeMoney(int valueChange)
        {
            _money.ChangeValue(valueChange);
        }

        public void ChangeMetal(int valueChange)
        {
            _metal.ChangeValue(valueChange);
        }
    }
}
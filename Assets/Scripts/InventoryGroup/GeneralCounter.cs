using UnityEngine;

namespace Inventory
{
    public class GeneralCounter : MonoBehaviour
    {
        [SerializeField] private Money _money;
        [SerializeField] private Metal _metal;

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
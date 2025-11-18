using UnityEngine;
using UnityEngine.UI;

namespace RoadTrane
{
    public class Coupling : MonoBehaviour
    {
        [SerializeField] private Common.Health _health;
        [SerializeField] private int _maxHealth;

        [SerializeField] private Button _separateStart;

        private FabricTrane _fabric = null;

        public int Place { get; private set; }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealChange;
            _health.ChangeMaxHealth(_maxHealth);

            _separateStart.onClick.AddListener(SeparateStart);
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealChange;
            _separateStart.onClick.RemoveListener(SeparateStart);
        }

        private void SeparateStart()
        {
            _health.Damaged(50);
        }

        public void Init(int placeValue, FabricTrane fabric)
        {
            Place = placeValue;
            _fabric = fabric;
        }

        private void OnHealChange(int value)
        {

            if (_health.Value <= 0)
            {
                _fabric.SeparateWagon(Place);
            }
        }
    }
}
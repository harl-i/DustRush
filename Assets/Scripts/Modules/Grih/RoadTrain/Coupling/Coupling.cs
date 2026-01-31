using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.RoadTrain
{
    public class Coupling : MonoBehaviour
    {
        private const int DamageValue = 50;

        [SerializeField] private Common.Health _health;
        [SerializeField] private int _maxHealth;

        [SerializeField] private Button _separateStart;

        private FabricTrain _fabric = null;

        public int Place { get; private set; }

        private void Start()
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

        public void Init(int placeValue, FabricTrain fabric)
        {
            Place = placeValue;
            _fabric = fabric;
        }

        private void OnHealChange(int value)
        {
            if (_health.Value <= 0)
            {
                Debug.Log(value);
                _fabric.SeparateWagon(Place);
            }
        }

        private void SeparateStart()
        {
            _health.Damaged(DamageValue);
        }
    }
}
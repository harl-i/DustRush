using System;
using UnityEngine;

namespace RoadTrane
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _damge;
        [SerializeField] private float _range;
        [SerializeField] private int _maxHealth;
        [SerializeField] private Common.Health _health;

        public event Action<int> TowerDead;

        private int _positionOnTrane;
        private int _idTower;
        private int _fullId;

        public void OnEnable()
        {
            _health.ChangeMaxHealth(_maxHealth);
            _health.HealthChanged += OnHealChange;
        }

        public void OnDisable()
        {
            _health.HealthChanged -= OnHealChange;
        }

        private void OnHealChange(int value)
        {
            if (value == 0)
                TowerDead?.Invoke(_fullId);
        }

        public void SetID(int key)
        {
            _idTower = key;
        }

        public void SetPositionOnTrane(int value)
        {
            _positionOnTrane = value;
            _fullId = (_positionOnTrane * 100) + _idTower;
        }
    }
}

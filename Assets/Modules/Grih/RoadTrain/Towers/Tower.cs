using System;
using UnityEngine;

namespace Modules.Grih.RoadTrane
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _damge;
        [SerializeField] private float _range;
        [SerializeField] private int _maxHealth;
        [SerializeField] private Common.Health _health;

        private int _positionOnTrane;
        private int _idTower;
        private int _wagonNumber;
        private int _fullId;
        private bool _isLeft;

        public event Action<int> TowerDead;

        public int FullId => _fullId;

        public int PositionOnTrane => _positionOnTrane;

        public bool IsLeft => _isLeft;

        public int TypeId => _idTower;

        public int WagonNumber => _wagonNumber;

        public bool IsRefrigeratorNearby { get; private set; }

        public bool IsStorageNearby { get; private set; }

        public void OnEnable()
        {
            DefineSide();
            _health.ChangeMaxHealth(_maxHealth);
            _health.HealthChanged += OnHealChange;
        }

        public void OnDisable()
        {
            _health.HealthChanged -= OnHealChange;
        }

        public void SetID(int key)
        {
            _idTower = key;
        }

        public void SetPositionOnTrane(int value)
        {
            if (value < 10)
                _wagonNumber = 0;
            else
                _wagonNumber = value / 10;

            _positionOnTrane = value;
            _fullId = (_positionOnTrane * 100) + _idTower;
        }

        public void SetRefrigeratorNearby(bool isNearby)
        {
            IsRefrigeratorNearby = isNearby;
        }

        public void SetStorageNearby(bool isNearby)
        {
            IsStorageNearby = isNearby;
        }

        private void OnHealChange(int value)
        {
            if (value == 0)
                TowerDead?.Invoke(_fullId + _idTower);
        }

        private void DefineSide()
        {
            if (transform.position.x < 0)
            {
                _isLeft = true;
            }
            else
            {
                _isLeft = false;
            }
        }
    }
}

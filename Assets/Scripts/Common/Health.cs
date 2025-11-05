using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour
    {
        private int _maxHealth;
        private int _partOfMaximum = 2;

        private bool _isUntouchable = false;
        private float _waitOffinValue = 5f;
        private WaitForSeconds _wait;

        public event Action<int> HealthChanged;

        public int Value { get; private set; }
        public bool IsDead { get; private set; }
        public int Max => _maxHealth;

        private void OnEnable()
        {
            _wait = new WaitForSeconds(_waitOffinValue);
            IsDead = false;
        }

        public void SetUntouchable()
        {
            _isUntouchable = true;
            StartCoroutine(OffingUnouchable());
        }

        public void Healing()
        {
            Value += Max / _partOfMaximum;

            if (Value > Max)
                Value = Max;

            HealthChanged?.Invoke(Value);
        }

        public void ComeAlive()
        {
            if (IsDead)
                IsDead = false;
        }

        public void ChangeMaxHealth(int newMax)
        {
            _maxHealth = newMax;
        }

        public void Damaged(int damage)
        {
            if (_isUntouchable)
                return;

            if (Value > 0)
                Value -= damage;

            if (Value <= 0)
            {
                Value = 0;
                IsDead = true;
            }

            HealthChanged?.Invoke(Value);
        }

        private IEnumerator OffingUnouchable()
        {
            yield return _wait;
            _isUntouchable = false;
        }
    }
}

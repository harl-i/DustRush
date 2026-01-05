using System;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        public event Action<int> HealthChanged;

        public int Value { get; private set; }

        public bool IsDead { get; private set; }

        public int Max => _maxHealth;

        private void OnEnable()
        {
            IsDead = false;
            Value = _maxHealth;
        }

        public void Healing()
        {
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
            Value = _maxHealth;
        }

        public void Damaged(int damage)
        {
            if (Value > 0)
                Value -= damage;

            if (Value <= 0)
            {
                Value = 0;
                IsDead = true;

                HealthChanged?.Invoke(Value);
                gameObject.SetActive(false);
            }
        }
    }
}

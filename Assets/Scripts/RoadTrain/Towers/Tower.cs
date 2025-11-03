using System;
using UnityEngine;

namespace RoadTrane
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _damge;
        [SerializeField] private float _range;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _sprite;

        public int IdTower { get; private set; }

        public void Awake()
        {
            //       _thisHealth.SetMaxHealth(MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            //       _thisHealth.Damaged(damage);
        }

        public void SetID(int key)
        {
            IdTower = key;
        }
    }
}

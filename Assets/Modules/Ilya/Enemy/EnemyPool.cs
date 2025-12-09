using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

namespace EnemyGroup
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private int _initialCount;

        private Pool<Enemy> _enemyPool;

        private void OnEnable()
        {
            _enemyPool = new Pool<Enemy>(_enemyPrefab);
        }

        private void Awake()
        {
            for (int i = 0; i < _initialCount; i++)
            {
                _enemyPool.GetItem();
            }
        }

        public void ReturnToPool(Enemy enemy)
        {
            _enemyPool.ReturnItem(enemy);
        }
    }
}
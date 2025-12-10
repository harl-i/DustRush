using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

namespace EnemyGroup
{
    public class EnemyPool
    {
        //private int _initialCount;
        private Enemy _enemyPrefab;
        private Pool<Enemy> _enemyPool;

        private List<Enemy> _createdEnemies;

        public EnemyPool(Enemy prefab)
        {
            _enemyPrefab = prefab;
        }

        public List<Enemy> CreateEnemy(int count)
        {
            SetEnemy(_enemyPrefab);
            FillEnemiesPool(count);
            return _createdEnemies;
        }

        public void ReturnToPool(Enemy enemy)
        {
            _enemyPool.ReturnItem(enemy);
        }

        private void SetEnemy(Enemy enemyPrefab)
        {
            _enemyPool = new Pool<Enemy>(enemyPrefab);
        }

        private void FillEnemiesPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //_createdEnemies.Add(_enemyPool.GetItem() as Enemy);
                Enemy enemy = _enemyPool.GetItem() as Enemy;
                Debug.Log(enemy);
                _createdEnemies.Add(enemy);
                Debug.Log(_createdEnemies);
            }
        }
    }
}
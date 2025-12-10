using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

namespace EnemyGroup
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;

        private EnemyPool _enemyPool;
        private List<List<Enemy>> _createdEnemies;

        private void OnEnable()
        {
            _enemyPool = new EnemyPool(_enemyPrefab);
            _createdEnemies.Add(_enemyPool.CreateEnemy(10));
            Debug.Log(_createdEnemies);
        }

        //private void OnEnable()
        //{
        //    _enemyPool.CreateEnemy(_enemyPrefab);
        //}
        //public Enemy CreateEnemy(Vector3 position, Quaternion rotation)
        //{
        //    Enemy enemy = _enemyPool.Get();
        //    enemy.SetPositionAndRotation(position, rotation);
        //    enemy.OnSpawned();
        //    return enemy;
        //}
    }
}
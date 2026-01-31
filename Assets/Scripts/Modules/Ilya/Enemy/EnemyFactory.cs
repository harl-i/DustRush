using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Modules.Grih.RoadTrain;
using System;

namespace EnemyGroup
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyLevelConfig _levelConfig;
        [SerializeField] private FabricTrain _fabricTrane;

        private EnemyPool _enemyPool;
        private List<EnemyPool> _readyMadeEnemiesPools = new List<EnemyPool>();

        public List<EnemyPool> ReadyMadeEnemiesPools => _readyMadeEnemiesPools;

        private void Start()
        {
            CreateEnemyPools();
        }

        private void CreateEnemyPools()
        {
            foreach (var enemy in _levelConfig.EnemyPrefab)
            {
                _enemyPool = new EnemyPool(enemy, _fabricTrane);
                _enemyPool.CreateEnemy(_levelConfig.PoolSize);
                _readyMadeEnemiesPools.Add(_enemyPool);
            }
        }
    }
}
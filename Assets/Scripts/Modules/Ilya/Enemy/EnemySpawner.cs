using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyGroup
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private float _delay;

        private void Start()
        {
            StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delay);
                SpawnRandomEnemy();
            }
        }

        private void SpawnRandomEnemy()
        {
            List<EnemyPool> pools = _enemyFactory.ReadyMadeEnemiesPools;

            if (pools.Count == 0)
                return;

            EnemyPool randomPool = pools[Random.Range(0, pools.Count)];
            Enemy enemy = randomPool.GetEnemy();

            if (enemy == null)
                return;

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform;

            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.DefineSide();
        }
    }
}
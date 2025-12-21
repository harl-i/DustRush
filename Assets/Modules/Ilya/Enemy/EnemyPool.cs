using System.Collections.Generic;
using Pool;
using Modules.Grih.RoadTrane;

namespace EnemyGroup
{
    public class EnemyPool
    {
        private Enemy _enemyPrefab;
        private Pool<Enemy> _enemyPool;

        private ITowerProvider _towerProvider;
        private List<Enemy> _createdEnemies = new List<Enemy>();

        public EnemyPool(Enemy prefab, ITowerProvider towerPrivider)
        {
            _enemyPrefab = prefab;
            _towerProvider = towerPrivider;
        }

        public List<Enemy> CreateEnemy(int count)
        {
            SetEnemy(_enemyPrefab);
            FillEnemiesPool(count);
            return _createdEnemies;
        }

        public Enemy GetEnemy()
        {
            Enemy enemy = _enemyPool.GetItem() as Enemy;
            enemy.Init(_towerProvider);
            return enemy;
        }

        public void ReturnToPool(Enemy enemy)
        {
            enemy.ResetTowers();
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
                Enemy enemy = _enemyPool.GetItem() as Enemy;
                enemy.gameObject.SetActive(false);

                _createdEnemies.Add(enemy);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyGroup
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        //public Enemy CreateEnemy(Vector3 position, Quaternion rotation)
        //{
        //    Enemy enemy = _enemyPool.Get();
        //    enemy.SetPositionAndRotation(position, rotation);
        //    enemy.OnSpawned();
        //    return enemy;
        //}
    }
}
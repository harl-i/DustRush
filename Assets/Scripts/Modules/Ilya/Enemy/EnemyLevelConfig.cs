using UnityEngine;
using System.Collections.Generic;

namespace EnemyGroup
{
    [CreateAssetMenu(
    fileName = "EnemyLevelConfig",
    menuName = "Game/Enemy Level Config"
    )]
    public class EnemyLevelConfig : ScriptableObject
    {
        public string LevelName;
        public float SpawnInterval = 3f;
        public List<Enemy> EnemyPrefab;
        public int PoolSize;
    }
}

using Inventory;
using Modules.Grih.Sity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class LootBoxFabric : MonoBehaviour
    {
        [SerializeField] private LootBox _prefab;
        [SerializeField] private List<Transform> _possiblePointSpawn;
        [SerializeField] private int _maxBoxCount;

        [SerializeField] private Money _moneyCounter;
        [SerializeField] private Metal _metalCounter;
        [SerializeField] private BlueprintObserver _blueprintObserver;
        [SerializeField] private Player _player;
        [SerializeField] private Common.HashTableLocation _hashTableLocation;

        private int _level;

        public void Init(string nameLevel)
        {
            _level = _hashTableLocation.LevelsForNames[nameLevel];

            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < _maxBoxCount; i++)
            {
                if (i == _possiblePointSpawn.Count)
                {
                    return;
                }

                Transform hash = _possiblePointSpawn[UnityEngine.Random.Range(0, _possiblePointSpawn.Count)];

                LootBox createdBox = Instantiate(_prefab);
                createdBox.Init(_level, _player, _blueprintObserver, _moneyCounter, _metalCounter);
                createdBox.transform.position = hash.position;
                createdBox.transform.SetParent(transform);

                _possiblePointSpawn.Remove(hash);
                hash = null;
            }
        }
    }
}
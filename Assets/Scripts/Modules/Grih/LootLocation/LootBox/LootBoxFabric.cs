using System.Collections.Generic;
using Modules.Grih.InventoryGroup;
using Modules.Grih.Sity;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class LootBoxFabric : MonoBehaviour
    {
        private const int OffsetCount = 1;

        [SerializeField] private LootBox _prefab;
        [SerializeField] private List<Transform> _possiblePointSpawnForTown;
        [SerializeField] private List<Transform> _possiblePointSpawnForStorage;
        [SerializeField] private int _maxBoxCount;

        [SerializeField] private Money _moneyCounter;
        [SerializeField] private Metal _metalCounter;
        [SerializeField] private BlueprintObserver _blueprintObserver;
        [SerializeField] private Player _player;
        [SerializeField] private LootLocationExit _exit;
        [SerializeField] private Common.HashTableLocation _hashTableLocation;

        [SerializeField] private BackLootLocation _backLootLocation;

        private List<Transform> _currentPossiblePosition = new List<Transform>();
        private int _level;

        public string CurrenLevelName { get; private set; }

        public void Init(string nameLevel)
        {
            CurrenLevelName = nameLevel;
            _level = _hashTableLocation.LevelsForNames[nameLevel];

            bool isSity = _hashTableLocation.LocationIsSity[CurrenLevelName];

            if (isSity)
                _currentPossiblePosition = _possiblePointSpawnForTown;
            else
                _currentPossiblePosition = _possiblePointSpawnForStorage;

            _backLootLocation.Init(CurrenLevelName);
            _exit.Init(isSity);
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < _maxBoxCount; i++)
            {
                if (i == _currentPossiblePosition.Count - OffsetCount)
                {
                    return;
                }

                Transform hash = _currentPossiblePosition[UnityEngine.Random.Range(0, _currentPossiblePosition.Count)];

                LootBox createdBox = Instantiate(_prefab);
                createdBox.Init(_level, _player, _blueprintObserver, _moneyCounter, _metalCounter);
                createdBox.transform.position = hash.position;
                createdBox.transform.SetParent(transform);

                _currentPossiblePosition.Remove(hash);
            }
        }
    }
}
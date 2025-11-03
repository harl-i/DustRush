using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RoadTrane
{
    public class FabricTrane : MonoBehaviour
    {
        [SerializeField] private TowersHashTable _towers;
        [SerializeField] private WagonsHashTable _wagons;

        private Dictionary<int, Tower> _hashTableTower;
        private Dictionary<int, Wagon> _hashTableWagon;

        private void OnEnable()
        {
            _hashTableTower = _towers.TowersTable;
            _hashTableWagon = _wagons.WagonsTable;
        }

        private void Start()
        {
            Load();
        }

        public void Create(Transform parent)
        {

        }

        public void Load()
        {
            //ServerTower.ActivateServer();
            //List<int> loaded = ServerTower.LoadData();

            List<int> loadedTower = YG2.saves.SavedTowers;
            List<int> loadedWagons = YG2.saves.SavedWagons;

            foreach (var item in loadedTower)
            {
                Debug.Log(_hashTableTower.TryGetValue(item, out Tower tower));
            }

            foreach (var item in loadedWagons)
            {
                Debug.Log(_hashTableWagon.TryGetValue(item, out Wagon wagon));
            }
        }
    }
    
}

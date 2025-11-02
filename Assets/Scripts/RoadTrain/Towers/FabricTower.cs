using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class FabricTower : MonoBehaviour
    {
        [SerializeField] private TowersHashTable _towers;

        private Dictionary<int, Tower> _hashTable;

        private void OnEnable()
        {
            _hashTable = _towers.TowersTable;
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
            ServerTower.ActivateServer();
            List<int> loaded = ServerTower.LoadData();

            foreach (var item in loaded)
            {
                Debug.Log(_hashTable.TryGetValue(item, out Tower tower));
            }
        }
    }
}

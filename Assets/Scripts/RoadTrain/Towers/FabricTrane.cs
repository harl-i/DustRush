using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RoadTrane
{
    public class FabricTrane : MonoBehaviour
    {
        [SerializeField] private TowersHashTable _towersHash;
        [SerializeField] private WagonsHashTable _wagonsHash;

        private Dictionary<int, GameObject> _hashTableTower = new Dictionary<int, GameObject>();
        private Dictionary<int, GameObject> _hashTableWagon = new Dictionary<int, GameObject>();

        private List<GameObject> _wagons = new List<GameObject>();
        private List<GameObject> _towers = new List<GameObject>();

        private void OnEnable()
        {
            _hashTableTower = _towersHash.TowersTable;
            _hashTableWagon = _wagonsHash.WagonsTable;
        }

        private void Start()
        {
            Load();
        }

        public void Create()
        {
            int countWagons = _wagons.Count;
            Vector2 _defaultPosition = Vector2.zero;

            for (int i = 0; i < _wagons.Count; i++)
            {
                if (i == 0)
                {
                    Instantiate(_wagons[i], _defaultPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(_wagons[i],
                        _wagons[i-1].GetComponent<Wagon>().FrontCouplingPosition.position,
                        Quaternion.identity);
                }
            }
        }

        public void Load()
        {
            List<int> loadedTower = new List<int>();
            List<int> loadedWagons = new List<int>();


            loadedTower = YG2.saves.SavedTowers;
            loadedWagons = YG2.saves.SavedWagons;

            foreach (var item in loadedTower)
            {
                _hashTableTower.TryGetValue(item, out GameObject tower);
                _towers.Add(tower);
            }

            foreach (var item in loadedWagons)
            {
                _hashTableWagon.TryGetValue(item, out GameObject wagon);
                _wagons.Add(wagon);
            }

            Create();
        }
    }

}

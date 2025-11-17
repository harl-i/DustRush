using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RoadTrane
{
    public class FabricTrane : MonoBehaviour
    {
        [SerializeField] private TowersHashTable _towersHash;
        [SerializeField] private WagonsHashTable _wagonsHash;

        [SerializeField] private Truck _truck; 
        [SerializeField] private TruckInstaller _truckInstaller; 

        private Dictionary<int, GameObject> _hashTableTower = new Dictionary<int, GameObject>();
        private Dictionary<int, GameObject> _hashTableWagon = new Dictionary<int, GameObject>();

        private List<GameObject> _wagons = new List<GameObject>();
        private List<Wagon> _createdWagons = new List<Wagon>();
        private List<GameObject> _towers = new List<GameObject>();
        private List<Tower> _createdTowers = new List<Tower>();

        private List<int> _loadedWagons = new List<int>();
        private List<int> _createdWagonsId = new List<int>();
        private List<int> _loadedTower = new List<int>();
        private List<int> _loadedWagonTower = new List<int>();
        private List<int> _loadedPositionTower = new List<int>();

        private void OnEnable()
        {
            _hashTableTower = _towersHash.TowersTable;
            _hashTableWagon = _wagonsHash.WagonsTable;
        }

        private void Start()
        {
            Load();
        }

        private void OnDisable()
        {
            Save();

            foreach (Tower tower in _createdTowers)
            {
                tower.TowerDead -= OnTowerDead;
            }
        }

        public void Create()
        {
            CreateWagon();
            CreateTower();
            CreateTruck();
        }

        private void CreateTruck()
        {
            Truck truck;

            truck = Instantiate(_truck,
                transform.position = _wagons[0].GetComponent<Wagon>().FrontCouplingPosition.position,
                Quaternion.identity);

            _truckInstaller.SetType(truck.TypeTrusk);
        }

        private void CreateWagon()
        {
            Vector2 _defaultPosition = Vector2.zero;

            Wagon wagon = null;

            for (int i = 0; i < _wagons.Count; i++)
            {
                if (i == 0)
                {
                    wagon = Instantiate(_wagons[i], _defaultPosition, Quaternion.identity).GetComponent<Wagon>();
                }
                else
                {
                    wagon = Instantiate(_wagons[i]).GetComponent<Wagon>();
                    wagon.transform.position = _wagons[i - 1].GetComponent<Wagon>().BackCouplingPosition.position;
                }

                _createdWagons.Add(wagon);
            }
        }

        private void CreateTower()
        {
            Tower tower = null;

            for (int i = 0; i < _towers.Count; i++)
            {
                Transform target = _createdWagons[_loadedWagonTower[i]]
                    .GetComponent<Wagon>()
                    .GetPointTower(_loadedPositionTower[i]);

                tower = Instantiate(_towers[i].GetComponent<Tower>());
                tower.transform.position = target.position;
                tower.SetPositionOnTrane((_loadedWagonTower[i] * 10) + _loadedPositionTower[i]);
                tower.TowerDead += OnTowerDead;
                _createdTowers.Add(tower);
            }
        }

        private void OnTowerDead(int fullId)
        {
            _createdWagonsId.Remove(fullId);
        }

        public void Load()
        {
            _loadedWagons = YG2.saves.SavedWagons;
            _createdWagonsId = YG2.saves.SavedTowers;

            foreach (int item in _createdWagonsId)
            {
                _loadedTower.Add(item % 100);
                _loadedWagonTower.Add(item / 1000);
                _loadedPositionTower.Add((item - (item / 1000 * 1000) - (item % 100)) / 100);
            }

            foreach (var item in _loadedTower)
            {
                _hashTableTower.TryGetValue(item, out GameObject tower);
                _towers.Add(tower);
            }

            foreach (var item in _loadedWagons)
            {
                _hashTableWagon.TryGetValue(item, out GameObject wagon);
                _wagons.Add(wagon);
            }

            Create();
        }

        public void Save()
        {
            List<int> savedWagans = new List<int>();
            List<int> savedTower = new List<int>();

            for (int i = 0; i < _wagons.Count; i++)
            {
                savedWagans.Add(_wagons[i].GetComponent<Wagon>().IdWagon);
            }

            for (int i = 0; i < _createdWagonsId.Count; i++)
            {
                savedTower.Add(_createdWagonsId[i]);
            }

            YG2.saves.SavedWagons = savedWagans;
            YG2.saves.SavedTowers = savedTower;
        }
    }
}

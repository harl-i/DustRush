using System;
using System.Collections.Generic;
using Environment;
using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class FabricTrain : MonoBehaviour, ITowerProvider
    {
        private const int IdFridge = 35;
        private const int IdMachineGunDepot = 36;
        private const int ValueTen = 10;
        private const int ValueHandred = 100;
        private const int ValueThousand = 1000;

        [SerializeField] private TowersHashTable _towersHash;
        [SerializeField] private WagonsHashTable _wagonsHash;

        [SerializeField] private Truck _truck;
        [SerializeField] private TruckInstaller _truckInstaller;
        [SerializeField] private Coupling _couplingPrefab;
        [SerializeField] private GroundMover _groundMover;

        private Dictionary<int, GameObject> _hashTableTower = new Dictionary<int, GameObject>();
        private Dictionary<int, GameObject> _hashTableWagon = new Dictionary<int, GameObject>();

        private List<Wagon> _wagons = new List<Wagon>();
        private List<Wagon> _createdWagons = new List<Wagon>();
        private List<Tower> _towers = new List<Tower>();
        private List<Tower> _createdTowers = new List<Tower>();

        private List<int> _loadedWagons = new List<int>();
        private List<int> _loadedTowers = new List<int>();

        private List<int> _loadedTowerId = new List<int>();
        private List<int> _loadedWagonTower = new List<int>();
        private List<int> _loadedPositionTower = new List<int>();

        private List<Wagon> _cashWagons = new List<Wagon>();
        private string _savedTrusk;

        public event Action<int> ContentRetern;

        public event Action<List<int>, List<int>, string> Saved;

        public List<Wagon> CreatedWagons => _createdWagons;

        public List<Tower> CreatedTowers => _createdTowers;

        public Truck CreatedTruck { get; private set; }

        private void OnDisable()
        {
            foreach (Tower tower in _createdTowers)
            {
                tower.TowerDead -= OnTowerDead;
            }

            Save();
        }

        public IReadOnlyList<Tower> GetAliveTowers()
        {
            return CreatedTowers;
        }

        public void Init(List<int> savedWagons, List<int> savedTower, string savedTrusk)
        {
            _loadedWagons = savedWagons;
            _loadedTowers = savedTower;
            _savedTrusk = savedTrusk;

            _hashTableTower = _towersHash.TowersTable;
            _hashTableWagon = _wagonsHash.WagonsTable;
            Load();
        }

        public void Save()
        {
            List<int> savedWagons = new List<int>();
            List<int> savedTower = new List<int>();

            for (int i = 0; i < _createdWagons.Count; i++)
            {
                if (_createdWagons[i].IsSepareted == false)
                {
                    savedWagons.Add(_createdWagons[i].IdWagon);
                }
            }

            for (int i = 0; i < _loadedTowers.Count; i++)
            {
                savedTower.Add(_loadedTowers[i]);
            }

            Saved?.Invoke(savedWagons, savedTower, CreatedTruck.TypeTrusk);
        }

        public void AddWagon(int id)
        {
            Wagon wagon = Instantiate(_hashTableWagon[id].GetComponent<Wagon>());
            wagon.SetID(id);

            if (_createdWagons.Count > 0)
                wagon.transform.position = _createdWagons[^1].GetComponent<Wagon>().BackCouplingPosition.position;
            else
                wagon.transform.position = Vector2.zero;

            wagon.transform.SetParent(this.transform);

            _createdWagons.Add(wagon);
        }

        public void ChangeWagon(int idContent, int changedWagon)
        {
            List<int> cashTower = new List<int>();

            Wagon wagon = Instantiate(_hashTableWagon[idContent].GetComponent<Wagon>());
            wagon.SetID(idContent);
            wagon.transform.SetParent(this.transform);

            if (_createdWagons[changedWagon].GetComponent<Wagon>().TypeWagon == Wagon.Type.Regular)
            {
                foreach (int item in _loadedTowers)
                {
                    if (item > changedWagon * 1000 && item < (changedWagon + 1) * 1000)
                    {
                        ContentRetern?.Invoke(item);
                        cashTower.Add(item);
                    }
                }

                foreach (var item in cashTower)
                {
                    _loadedTowers.Remove(item);
                }
            }

            for (int i = 0; i < _createdWagons.Count; i++)
            {
                if (i == changedWagon)
                {
                    _createdWagons[i].gameObject.SetActive(false);
                    _cashWagons.Add(wagon);
                }
                else
                {
                    _cashWagons.Add(_createdWagons[i]);
                }
            }

            _createdWagons = new List<Wagon>();
            _createdWagons = _cashWagons;
            _cashWagons = new List<Wagon>();

            for (int i = 0; i < _createdWagons.Count; i++)
            {
                if (i == 0)
                {
                    _createdWagons[i].transform.position = Vector2.zero;
                }
                else
                {
                    _createdWagons[i].transform.position = _createdWagons[i - 1].BackCouplingPosition.position;
                }
            }

            CreateCoupling();
        }

        public void SeparateWagon(int place)
        {
            List<Wagon> cashWagon = new List<Wagon>();

            for (int i = 0; i < _createdWagons.Count; i++)
            {
                if (place <= i)
                {
                    _createdWagons[i].GetComponent<Wagon>().Separate();
                }
                else
                {
                    cashWagon.Add(_createdWagons[i]);
                }
            }

            _createdWagons = cashWagon;

            List<int> cashTower = new List<int>();

            foreach (int item in _loadedTowers)
            {
                if (item < place * ValueThousand)
                    cashTower.Add(item);
            }

            _loadedTowers = cashTower;
        }

        public void AddTower(int idContent, int placeTower)
        {
            int numberWagon = placeTower / ValueTen;

            if (placeTower < ValueTen)
                numberWagon = 0;

            int place = placeTower % ValueTen;

            Tower newTower = Instantiate(_hashTableTower[idContent].GetComponent<Tower>());
            newTower.SetID(idContent);
            newTower.SetPositionOnTrain(placeTower);

            List<int> oldTowers = new List<int>();
            Transform target = _createdWagons[numberWagon].GetComponent<Wagon>().PointsTower[place];

            newTower.transform.position = target.position;
            newTower.transform.SetParent(target);

            foreach (int item in _loadedTowers)
            {
                if (item < ValueHandred && placeTower == 0)
                {
                    oldTowers.Add(item);
                }
                else if (item > placeTower * ValueHandred && item < (placeTower + 1) * ValueHandred)
                {
                    oldTowers.Add(item);
                }
            }

            foreach (int item in oldTowers)
            {
                _loadedTowers.Remove(item);
            }

            _loadedTowers.Add(newTower.FullId);
            DeactivateLowLayer(newTower);
        }

        private void SetBuff()
        {
            List<Tower> fridges = new List<Tower>();
            List<Tower> machineGunDepots = new List<Tower>();

            foreach (Tower item in CreatedTowers)
            {
                if (item.TypeId == IdFridge)
                {
                    fridges.Add(item);
                }
                else if (item.TypeId == IdMachineGunDepot)
                {
                    machineGunDepots.Add(item);
                }
            }

            if (fridges.Count > 0)
            {
                foreach (Tower fridge in fridges)
                {
                    foreach (Tower item in CreatedTowers)
                    {
                        if (fridge.WagonNumber == item.WagonNumber)
                        {
                            item.SetRefrigeratorNearby(true);
                        }
                    }
                }
            }

            if (machineGunDepots.Count > 0)
            {
                foreach (Tower machineGunDepot in machineGunDepots)
                {
                    foreach (Tower item in CreatedTowers)
                    {
                        if (machineGunDepot.WagonNumber == item.WagonNumber)
                        {
                            item.SetStorageNearby(true);
                        }
                    }
                }
            }
        }

        private void DeactivateLowLayer(Tower newTower)
        {
            foreach (Tower item in _createdTowers)
            {
                if (newTower.PositionOnTrain == item.PositionOnTrain)
                    item.gameObject.SetActive(false);
            }
        }

        private void Create()
        {
            CreateSavedWagons();
            CreateSavedTowers();
            CreateTruck();

            SetBuff();
        }

        private void CreateTruck()
        {
            CreatedTruck = Instantiate(
                _truck,
                _createdWagons[0].GetComponent<Wagon>().FrontCouplingPosition.position,
                Quaternion.identity);

            CreatedTruck.Init(_savedTrusk);
            CreatedTruck.transform.SetParent(transform);
            _truckInstaller.SetType(_savedTrusk);
        }

        private void CreateSavedWagons()
        {
            Vector2 currentPosition = Vector2.zero;

            for (int i = 0; i < _wagons.Count; i++)
            {
                Wagon wagon = Instantiate(_wagons[i], currentPosition, Quaternion.identity).GetComponent<Wagon>();
                wagon.SetID(_wagons[i].IdWagon);
                currentPosition = wagon.BackCouplingPosition.position;
                wagon.transform.SetParent(this.transform);

                _createdWagons.Add(wagon);
                wagon.Init(_groundMover);
            }

            CreateCoupling();
        }

        private void CreateCoupling()
        {
            Coupling coupling;

            for (int i = 0; i < _createdWagons.Count; i++)
            {
                coupling = Instantiate(_couplingPrefab);
                coupling.transform.position = _createdWagons[i].FrontCouplingPosition.position;
                coupling.transform.parent = _createdWagons[i].FrontCouplingPosition;
                coupling.Init(i, this);
            }
        }

        private void CreateSavedTowers()
        {
            Tower tower = null;

            for (int i = 0; i < _towers.Count; i++)
            {
                Transform target = _createdWagons[_loadedWagonTower[i]]
                    .GetComponent<Wagon>()
                    .GetPointTower(_loadedPositionTower[i]);

                tower = Instantiate(_towers[i].GetComponent<Tower>());
                tower.transform.position = target.position;
                tower.transform.parent = target.parent;
                tower.SetPositionOnTrain((_loadedWagonTower[i] * ValueTen) + _loadedPositionTower[i]);
                tower.SetID(_towers[i].GetComponent<Tower>().TypeId);
                tower.TowerDead += OnTowerDead;
                _createdTowers.Add(tower);
            }
        }

        private void OnTowerDead(int fullId)
        {
            _loadedTowers.Remove(fullId);
        }

        private void Load()
        {
            foreach (int item in _loadedTowers)
            {
                if (item < ValueHandred)
                {
                    _loadedTowerId.Add(item);
                    _loadedWagonTower.Add(0);
                    _loadedPositionTower.Add(0);
                }
                else
                {
                    _loadedTowerId.Add(item % ValueHandred);
                    _loadedWagonTower.Add(item / ValueThousand);
                    _loadedPositionTower.Add(
                        (item - (item / ValueThousand * ValueThousand) - (item % ValueHandred)) / ValueHandred);
                }
            }

            foreach (var item in _loadedTowerId)
            {
                _hashTableTower.TryGetValue(item, out GameObject tower);
                _towers.Add(tower.GetComponent<Tower>());
                tower.GetComponent<Tower>().SetID(item);
            }

            foreach (var item in _loadedWagons)
            {
                Wagon newWagon = _hashTableWagon[item].GetComponent<Wagon>();
                _wagons.Add(newWagon);
                newWagon.SetID(item);
            }

            Create();
        }
    }
}

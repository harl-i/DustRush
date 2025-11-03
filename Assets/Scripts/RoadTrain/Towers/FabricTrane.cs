using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
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

        private void OnDisable()
        {
            Save();
        }

        public void Create()
        {
            CreateWagon();
            CreateTower();
        }

        private void CreateWagon()
        {
            Vector2 _defaultPosition = Vector2.zero;

            Wagon wagon = null;

            for (int i = 0; i < _wagons.Count; i++)
            {
                if (i == 0)
                {
                    Instantiate(_wagons[i], _defaultPosition, Quaternion.identity);
                }
                else
                {
                    wagon = Instantiate(_wagons[i]).GetComponent<Wagon>();
                    wagon.transform.position = _wagons[i - 1].GetComponent<Wagon>().BackCouplingPosition.position;
                }
            }
        }

        private void CreateTower()
        {
            for (int i = 0; i < _towers.Count; i++)
            {

            }
        }

        public void Load()
        {
            List<int> loadedWagons = new List<int>();
            List<int> loadedTower = new List<int>();

            loadedWagons = YG2.saves.SavedWagons;
            loadedTower = YG2.saves.SavedTowers;

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

        public void Save()
        {
            List<int> saved = new List<int>();

            for (int i = 0; i < _wagons.Count; i++)
            {
                saved.Add(_wagons[i].GetComponent<Wagon>().IdWagon);
            }

            YG2.saves.SavedWagons = saved;
        }
    }

}

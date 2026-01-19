using System;
using System.Collections.Generic;
using Modules.Grih.RoadTrain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Grih.Sity
{
    public class BlueprintObserver : MonoBehaviour
    {
        private const int DeafultOpenCount = 9;
        private const int FirstTier = 1;
        private const int SecondTier = 2;
        private const string LootLocation = "LootLocation";

        [SerializeField] private Modules.Grih.RoadTrain.ItemTable _allItemsTable;

        private List<int> _blueprintsTier1 = new List<int>();
        private List<int> _blueprintsTier2 = new List<int>();
        private List<int> _blueprintsTier3 = new List<int>();

        private List<int> _openBluePrints = new List<int>();

        public event Action<List<int>> Saved;

        public List<int> OpenBluprints => _openBluePrints;

        public void Init(List<int> openBluePrints)
        {
            _openBluePrints = openBluePrints;

            if (_openBluePrints.Count < DeafultOpenCount)
            {
                foreach (HaveIdItem blueprint in _allItemsTable.CurrenTable.Values)
                {
                    if (blueprint.GetComponent<ShopCell>().IsStartPackage)
                    {
                        _openBluePrints.Add(blueprint.Id);
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == LootLocation)
            {
                foreach (HaveIdItem item in _allItemsTable.CurrenTable.Values)
                {
                    int tier = item.GetComponent<ShopCell>().Tier;

                    if (tier == FirstTier)
                    {
                        _blueprintsTier1.Add(item.GetComponent<ShopCell>().Id);
                    }
                    else if (tier == SecondTier)
                    {
                        _blueprintsTier2.Add(item.GetComponent<ShopCell>().Id);
                    }
                    else
                    {
                        _blueprintsTier3.Add(item.GetComponent<ShopCell>().Id);
                    }
                }
            }
        }

        public void Save()
        {
            Saved?.Invoke(_openBluePrints);
        }

        public bool IsHaveOnBlueprints(int id)
        {
            foreach (int i in _openBluePrints)
            {
                if (i == id)
                {
                    return true;
                }
            }

            return false;
        }

        public void OpenBlueprint(int id)
        {
            _openBluePrints.Add(id);
        }

        public bool TryOpenRandomBlueprintOnLevel(int level)
        {
            int randomId;

            if (level == FirstTier)
            {
                randomId = _blueprintsTier1[UnityEngine.Random.Range(0, _blueprintsTier1.Count)];
            }
            else if (level == SecondTier)
            {
                randomId = _blueprintsTier2[UnityEngine.Random.Range(0, _blueprintsTier2.Count)];
            }
            else if (level > SecondTier)
            {
                randomId = _blueprintsTier3[UnityEngine.Random.Range(0, _blueprintsTier3.Count)];
            }
            else
            {
                randomId = _blueprintsTier1[UnityEngine.Random.Range(0, _blueprintsTier1.Count)];
            }

            if (IsHaveOnBlueprints(randomId))
            {
                return false;
            }
            else
            {
                _openBluePrints.Add(randomId);
                return true;
            }
        }
    }
}
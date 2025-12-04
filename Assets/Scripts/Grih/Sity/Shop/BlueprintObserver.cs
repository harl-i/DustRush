using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Sity
{
    public class BlueprintObserver : MonoBehaviour
    {
        private List<int> _openBluePrints = new List<int>();

        public List<int> OpenBluePrints => _openBluePrints;
        private Dictionary<int, bool> _isOpenBlueprint = new Dictionary<int, bool>();

        private void OnEnable()
        {
            Load();

            if (OpenBluePrints.Count == 0)
            {
                _openBluePrints.Add(1);
                _openBluePrints.Add(11);
                _openBluePrints.Add(12);
                _openBluePrints.Add(14);
                _openBluePrints.Add(17);
                _openBluePrints.Add(20);

                _openBluePrints.Add(37);
                _openBluePrints.Add(38);
                _openBluePrints.Add(43);
            }
        }

        public void AddOpenBlueprint(int idContent)
        {
            _openBluePrints.Add(idContent);
        }

        public void Save()
        {
            YG2.saves.OpenBlueprint = _openBluePrints;
        }

        public bool IsHaveOnBlueprints(int id)
        {
            foreach (int i in _openBluePrints)
                if (i == id)
                    return true;

            return false;
        }

        private void Load()
        {
            _openBluePrints = YG2.saves.OpenBlueprint;
        }
    }
}
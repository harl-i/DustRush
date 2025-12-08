using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class BlueprintObserver : MonoBehaviour
    {
        private const int DeafultOpenCount = 9;

        private List<int> _openBluePrints = new List<int>();

        public List<int> OpenBluePrints => _openBluePrints;

        public event Action<List<int>> Saved;

        public void Init(List<int> openBluePrints)
        {
            _openBluePrints = openBluePrints;

            if (_openBluePrints.Count < DeafultOpenCount)
            {
                _openBluePrints.Add(1);
                _openBluePrints.Add(2);
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
            Saved?.Invoke(_openBluePrints);
        }

        public bool IsHaveOnBlueprints(int id)
        {
            Debug.Log(id + "///" + _openBluePrints.Count);

            foreach (int i in _openBluePrints)
                if (i == id)
                    return true;

            return false;
        }
    }
}
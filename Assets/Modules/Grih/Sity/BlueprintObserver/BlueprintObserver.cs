using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

namespace Modules.Grih.Sity
{
    public class BlueprintObserver : MonoBehaviour
    {
        private const int DeafultOpenCount = 9;

        private List<int> _openBluePrints = new List<int>();

        public List<int> OpenBluePrints => _openBluePrints;

        public event Action<List<int>> Saved;

        private List<int> _blueprintsTier1 = new List<int>();
        private List<int> _blueprintsTier2 = new List<int>();
        private List<int> _blueprintsTier3 = new List<int>();

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

            if (SceneManager.GetActiveScene().name == "LootLocation")
            {
                _blueprintsTier1.Add(17);
                _blueprintsTier1.Add(20);
                _blueprintsTier1.Add(23);
                _blueprintsTier1.Add(26);
                _blueprintsTier1.Add(29);
                _blueprintsTier1.Add(32);
                _blueprintsTier1.Add(40);
                _blueprintsTier1.Add(43);
                _blueprintsTier1.Add(46);
                _blueprintsTier1.Add(49);
                _blueprintsTier1.Add(52);
                _blueprintsTier1.Add(55);
                _blueprintsTier1.Add(58);

                _blueprintsTier2.Add(15);
                _blueprintsTier2.Add(21);
                _blueprintsTier2.Add(24);
                _blueprintsTier2.Add(27);
                _blueprintsTier2.Add(30);
                _blueprintsTier2.Add(36);
                _blueprintsTier2.Add(33);
                _blueprintsTier2.Add(41);
                _blueprintsTier2.Add(44);
                _blueprintsTier2.Add(47);
                _blueprintsTier2.Add(50);
                _blueprintsTier2.Add(53);
                _blueprintsTier2.Add(56);
                _blueprintsTier2.Add(59);

                _blueprintsTier3.Add(3);
                _blueprintsTier3.Add(13);
                _blueprintsTier3.Add(16);
                _blueprintsTier3.Add(22);
                _blueprintsTier3.Add(25);
                _blueprintsTier3.Add(28);
                _blueprintsTier3.Add(31);
                _blueprintsTier3.Add(35);
                _blueprintsTier3.Add(34);
                _blueprintsTier3.Add(39);
                _blueprintsTier3.Add(42);
                _blueprintsTier3.Add(45);
                _blueprintsTier3.Add(48);
                _blueprintsTier3.Add(51);
                _blueprintsTier3.Add(54);
                _blueprintsTier3.Add(57);
                _blueprintsTier3.Add(60);
            }
        }

        public void Save()
        {
            Saved?.Invoke(_openBluePrints);
        }

        public bool IsHaveOnBlueprints(int id)
        {
            foreach (int i in _openBluePrints)
                if (i == id)
                    return true;

            return false;
        }

        public bool TryOpenRandomBlueprintOnLevel(int level)
        {
            int randomId;

            if (level <= 1)
            {
                randomId = _blueprintsTier1[UnityEngine.Random.Range(0, _blueprintsTier1.Count)];
            }
            if (level == 2)
            {
                randomId = _blueprintsTier2[UnityEngine.Random.Range(0, _blueprintsTier2.Count)];
            }
            else
            {
                randomId = _blueprintsTier3[UnityEngine.Random.Range(0, _blueprintsTier3.Count)];
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
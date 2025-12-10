using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMap : MonoBehaviour
    {
        public bool IsGoingToPath { get; private set; }
        public string SavedDeport { get; private set; }
        public string SavedPointToRoad { get; private set; }

        public List<string> OpenLocals => _openLocals;

        private List<string> _openLocals = new List<string>();

        //    public int PercentGoing { get; private set; }

        public event Action<bool, string, string, List<string>> Saved;

        public void Init(bool isGoingToPath, string savedDeport, string savedPointToRoad, List<string> openLocals) //, int percentGoing)
        {
            IsGoingToPath = isGoingToPath;
            SavedDeport = savedDeport;
            SavedPointToRoad = savedPointToRoad;
            _openLocals = openLocals;

            //  PercentGoing = percentGoing;
        }

        public void Save()
        {
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _openLocals); //, PercentGoing);
        }

        public void SetNewCource(string cellName)
        {
            SavedPointToRoad = cellName;
        }

        public void OpenNextLocation(string cellName)
        {
            _openLocals.Add(cellName);
        }
    }
}
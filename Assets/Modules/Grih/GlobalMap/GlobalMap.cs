using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMap : MonoBehaviour
    {
        [SerializeField] private GlobalMapView _view;

        private List<string> _openLocals = new List<string>();

        public bool IsGoingToPath { get; private set; }
        public string SavedDeport { get; private set; }
        public string SavedPointToRoad { get; private set; }

        public List<string> OpenLocals => _openLocals;

        public event Action<bool, string, string, List<string>> Saved;

        public void Init(bool isGoingToPath, string savedDeport, string savedPointToRoad, List<string> openLocals)
        {
            IsGoingToPath = isGoingToPath;
            SavedDeport = savedDeport;
            SavedPointToRoad = savedPointToRoad;
            _openLocals = openLocals;

            if (_openLocals.Count == 0)
            {
                _openLocals.Add(SavedPointToRoad);
            }

            _view.Init();
        }

        public void Save()
        {
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _openLocals);
        }

        public void SetNewCource(string cellName)
        {
            SavedPointToRoad = cellName;
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _openLocals);
        }

        public void OpenLocation(string cellName)
        {
            foreach (string cell in _openLocals)
                if (cell == cellName)
                    return;

            _openLocals.Add(cellName);
        }

        public void OnFinish()
        {
            SavedDeport = SavedPointToRoad;
            OpenLocation(SavedPointToRoad);
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _openLocals);
        }
    }
}
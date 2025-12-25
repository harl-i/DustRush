using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMap : MonoBehaviour
    {
        [SerializeField] private GlobalMapView _view;

        private List<string> _openLocals = new List<string>();
        private List<string> _savedTowns = new List<string>();

        public bool IsGoingToPath { get; private set; }
        public string SavedDeport { get; private set; }
        public string SavedPointToRoad { get; private set; }

        public List<string> OpenLocals => _openLocals;
        public List<string> SavedTowns => _savedTowns;

        public event Action<bool, string, string, List<string>, List<string>> Saved;
        public event Action Finished;

        public void Init(bool isGoingToPath, string savedDeport, string savedPointToRoad, List<string> openLocals, List<string> savedTowns)
        {
            IsGoingToPath = isGoingToPath;
            SavedDeport = savedDeport;
            SavedPointToRoad = savedPointToRoad;
            _openLocals = openLocals;
            _savedTowns= savedTowns;

            if (_openLocals.Count == 0)
            {
                _openLocals.Add(SavedPointToRoad);
            }

            _view.Init(isGoingToPath);
        }

        public void Save()
        {
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _openLocals, _savedTowns);
        }

        public void SetNewCource(string cellName)
        {
            SavedPointToRoad = cellName;
            Save();
        }

        public void OpenLocation(string cellName)
        {
            foreach (string cell in _openLocals)
                if (cell == cellName)
                    return;

            _openLocals.Add(cellName);
        }

        public void OnEnterOnLootInActionScene()
        {
            IsGoingToPath = true;
            Save();
        }

        public void OnFinish()
        {
            Finished?.Invoke();
            IsGoingToPath = false;
            SavedDeport = SavedPointToRoad;
            OpenLocation(SavedPointToRoad);
            Save();
        }

        public void SaveOpenTown(string nameTown)
        {
            foreach (string cell in _savedTowns)
                if (cell == nameTown)
                    return;

            _savedTowns.Add(nameTown);
        }
    }
}
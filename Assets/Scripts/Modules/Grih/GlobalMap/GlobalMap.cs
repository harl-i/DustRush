using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMap : MonoBehaviour
    {
        [SerializeField] private GlobalMapView _view;

        private List<string> _savedTowns = new List<string>();

        public event Action<bool, string, string, List<string>> Saved;

        public event Action Finished;

        public List<string> SavedTowns => _savedTowns;

        public bool IsGoingToPath { get; private set; }

        public string SavedDeport { get; private set; }

        public string SavedPointToRoad { get; private set; }

        public void Init(bool isGoingToPath, string savedDeport, string savedPointToRoad, List<string> savedTowns)
        {
            IsGoingToPath = isGoingToPath;
            SavedDeport = savedDeport;
            SavedPointToRoad = savedPointToRoad;
            _savedTowns = savedTowns;

            _view.Init(isGoingToPath);
        }

        public void Save()
        {
            Saved?.Invoke(IsGoingToPath, SavedDeport, SavedPointToRoad, _savedTowns);
        }

        public void SetNewCource(string cellName)
        {
            SavedPointToRoad = cellName;
            Save();
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
            Save();
        }

        public void SaveOpenTown(string nameTown)
        {
            foreach (string cell in _savedTowns)
            {
                if (cell == nameTown)
                {
                    return;
                }
            }

            _savedTowns.Add(nameTown);
        }
    }
}
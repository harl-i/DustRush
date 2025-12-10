using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Modules.Grih.SceneChanger;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMapView : MonoBehaviour
    {
        [SerializeField] protected GlobalMap _global;
        [SerializeField] private Button _changeButton;
        [SerializeField] private SceneChangerScript _sceneChanger;
        [SerializeField] private List<GlobalMapCell> _allCells = new List<GlobalMapCell>();

        private List<string> _openLocalsNames = new List<string>();
        private List<GlobalMapCell> _openCell = new List<GlobalMapCell>();
        private Dictionary<string, GlobalMapCell> _cellsDictionary = new Dictionary<string, GlobalMapCell>();
        private Dictionary<string, bool> _cellsIsSity = new Dictionary<string, bool>();

        private void Start()
        {
            _changeButton.onClick.AddListener(OnClickNewLocal);
            _changeButton.gameObject.SetActive(false);

            foreach (GlobalMapCell cell in _allCells)
                _cellsDictionary.Add(cell.NamePoint, cell);

            foreach (GlobalMapCell cell in _allCells)
                _cellsIsSity.Add(cell.NamePoint, cell.IsSity);

            _openLocalsNames = _global.OpenLocals;

            foreach (string name in _openLocalsNames)
            {
                if (_cellsDictionary.TryGetValue(name, out GlobalMapCell cell))
                {
                    cell.ChangeActivatedEffect(true);
                    _openCell.Add(cell);
                    cell.OnStartClick += CellClick;
                }
                else
                {
                    cell.ChangeActivatedEffect(false);
                }
            }

            for (int i = 0; i < _allCells.Count; i++)
            {
                if (_allCells[i].NamePoint == _openLocalsNames[_openLocalsNames.Count - 1])
                {
                    if (_cellsDictionary.TryGetValue(_allCells[i + 1].NamePoint, out GlobalMapCell cell))
                    {
                        cell.ChangeActivatedEffect(true);
                        _openCell.Add(cell);
                        cell.OnStartClick += CellClick;
                    }
                }
            }

        }

        private void OnDestroy()
        {
            _changeButton.onClick.RemoveListener(OnClickNewLocal);

            foreach (GlobalMapCell cell in _openCell)
                cell.OnStartClick -= CellClick;

            _changeButton.gameObject.SetActive(true);

            _cellsDictionary = new Dictionary<string, GlobalMapCell>();
        }

        private void OnClickNewLocal()
        {
            bool isLocalIsSity = _cellsIsSity[_global.SavedPointToRoad];

            _global.Save();
            _sceneChanger.ChangeLocation(isLocalIsSity);
        }

        public void OnFinishPont()
        {
            GlobalMapCell nextLocation = GetNextLocation(_global.SavedPointToRoad);

            if (nextLocation != null)
                _global.OpenNextLocation(nextLocation.NamePoint);
        }

        private void CellClick(string cellName)
        {
            _global.SetNewCource(cellName);
            _changeButton.gameObject.SetActive(true);
        }

        private GlobalMapCell GetNextLocation(string current)
        {
            for (int i = 0; i < _allCells.Count; i++)
            {
                if (_allCells[i].NamePoint == current)
                {
                    if (_cellsDictionary.TryGetValue(_allCells[i + 1].NamePoint, out GlobalMapCell cell))
                    {
                        return cell;
                    }
                }
            }

            return null;
        }
    }
}
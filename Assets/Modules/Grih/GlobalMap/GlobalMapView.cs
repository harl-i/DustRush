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
        [SerializeField] private MapTimer _timer;
        [SerializeField] private GameObject _imageBack;
        [SerializeField] private List<GlobalMapCell> _allCells = new List<GlobalMapCell>();

        private List<string> _openLocalsNames = new List<string>();
        private List<GlobalMapCell> _openCell = new List<GlobalMapCell>();
        private Dictionary<string, GlobalMapCell> _cellsDictionary = new Dictionary<string, GlobalMapCell>();
        private Dictionary<string, bool> _cellsIsSity = new Dictionary<string, bool>();


        private void OnDestroy()
        {
            _changeButton.onClick.RemoveListener(OnClickNewLocal);

            foreach (GlobalMapCell cell in _openCell)
                cell.OnStartClick -= CellClick;

            _changeButton.gameObject.SetActive(false);

            _cellsDictionary = new Dictionary<string, GlobalMapCell>();
            _cellsIsSity = new Dictionary<string, bool>();
        }

        public void Init()
        {
            _changeButton.onClick.AddListener(OnClickNewLocal);
            _changeButton.gameObject.SetActive(false);

            foreach (GlobalMapCell cell in _allCells)
            {
                _cellsDictionary.Add(cell.NamePoint, cell);
                _cellsIsSity.Add(cell.NamePoint, cell.IsSity);
                cell.ChangeActivatedEffect(false);
            }

            _openLocalsNames = _global.OpenLocals;

            for (int i = 0; i < _allCells.Count; i++)
            {
                for (int j = 0; j < _openLocalsNames.Count; j++)
                {
                    if (_allCells[i].NamePoint == _openLocalsNames[j])
                    {
                        if (_cellsDictionary.TryGetValue(_allCells[i].NamePoint, out GlobalMapCell cell))
                        {
                            cell.ChangeActivatedEffect(true);
                            _openCell.Add(cell);
                            cell.OnStartClick += CellClick;
                        }
                    }
                }
            }

            _timer.Init();
        }

        public float GetCurrentMapCellTimet()
        {
            return _cellsDictionary[_global.SavedPointToRoad].LongTimerRound;
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

            bool isLocalIsSity = _cellsIsSity[_global.SavedPointToRoad];

            _global.OnFinish();

            if (nextLocation != null)
            {
                _global.OpenLocation(nextLocation.NamePoint);
            }

            if (isLocalIsSity)
            {
                _sceneChanger.ChangeLocation(isLocalIsSity);
            }
            else
            {
                _imageBack.gameObject.SetActive(true);
            }
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
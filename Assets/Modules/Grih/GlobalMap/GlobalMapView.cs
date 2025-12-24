using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Modules.Grih.SceneChanger;
using UnityEngine.SceneManagement;

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

        public List<GlobalMapCell> AllCells => _allCells;

        private void OnDestroy()
        {
            _changeButton.onClick.RemoveListener(OnClickNewLocal);

            foreach (GlobalMapCell cell in _openCell)
                cell.OnStartClick -= CellClick;

            _changeButton.gameObject.SetActive(false);

            _cellsDictionary = new Dictionary<string, GlobalMapCell>();
            _cellsIsSity = new Dictionary<string, bool>();
        }

        public void Init(bool isFinishedPath)
        {
            _imageBack.gameObject.SetActive(false);

            _changeButton.onClick.AddListener(OnClickNewLocal);
            _changeButton.gameObject.SetActive(false);
            _openLocalsNames = _global.OpenLocals;

            foreach (GlobalMapCell cell in _allCells)
            {
                _cellsDictionary.Add(cell.NamePoint, cell);
                _cellsIsSity.Add(cell.NamePoint, cell.IsSity);
                cell.ChangeActivatedEffect(false);
            }

            //for (int i = 0; i < _allCells.Count; i++)
            //{
            //    for (int j = 0; j < _openLocalsNames.Count; j++)
            //    {
            //        if (_allCells[i].NamePoint == _openLocalsNames[j])
            //        {
            //            _allCells[i].ChangeActivatedEffect(true);
            //            _allCells[i].OnStartClick += CellClick;
            //            _openCell.Add(_allCells[i]);
            //        }
            //    }
            //}

            SetOpenCell();

            if (SceneManager.GetActiveScene().name == "Sity")
            {
                _cellsDictionary[_global.SavedDeport].SetYouOnHere();
                _imageBack.gameObject.SetActive(true);
            }

            _timer.Init(isFinishedPath);

        }

        public int GetCurrentMapCellTime()
        {
            return _cellsDictionary[_global.SavedPointToRoad].LongTimerRound;
        }

        private void SetOpenCell()
        {
            foreach (GlobalMapCell item in _allCells)
            {
                item.ChangeActivatedEffect(false);
            }

            for (int i = 0; i < _allCells.Count; i++)
            {
                if (_allCells[i].NamePoint == _global.SavedDeport)
                {
                    if (i + 1 <= _allCells.Count)
                    {
                        _allCells[i + 1].ChangeActivatedEffect(true);
                        _allCells[i + 1].OnStartClick += CellClick;
                        _openCell.Add(_allCells[i]);
                    }
                    if (i - 1 >= 1)
                    {
                        _allCells[i - 1].ChangeActivatedEffect(true);
                        _allCells[i - 1].OnStartClick += CellClick;
                        _openCell.Add(_allCells[i]);
                    }
                }
            }

            foreach (string item in _global.SavedTowns)
            {
                _cellsDictionary[item].ChangeActivatedEffect(true);
                _cellsDictionary[item].OnStartClick += CellClick;
                _openCell.Add(_cellsDictionary[item]);
            }
        }

        private void OnClickNewLocal()
        {
            bool isLocalIsSity = _cellsIsSity[_global.SavedPointToRoad];
            bool isDeportSity = _cellsIsSity[_global.SavedDeport];

            if (isLocalIsSity)
            {
                OnFinishPont();
            }

            _global.Save();
            _sceneChanger.ChangeLocation(isDeportSity);
        }

        public void OnFinishPont()
        {
            GlobalMapCell nextLocation = GetNextLocation(_global.SavedPointToRoad);

            bool isLocalIsSity = _cellsIsSity[_global.SavedPointToRoad];
            bool isDeportSity = _cellsIsSity[_global.SavedDeport];

            if (nextLocation != null)
            {
                _global.OpenLocation(nextLocation.NamePoint);
                nextLocation.ChangeActivatedEffect(true);
                nextLocation.OnStartClick += CellClick;
                _openCell.Add(nextLocation);
            }

            _global.OnFinish();
            SetOpenCell();

            if (isLocalIsSity)
            {
                _sceneChanger.ChangeLocation(isDeportSity);

            }
            else
            {
                _imageBack.gameObject.SetActive(true);
                _cellsDictionary[_global.SavedPointToRoad].SetYouOnHere();
                _cellsDictionary[_global.SavedPointToRoad].ChangeActivatedEffect(false);
            }
        }

        private void CellClick(string cellName)
        {
            foreach (var cell in _allCells)
                cell.ChangeSetViewEffect(false);

            _cellsDictionary[cellName].ChangeSetViewEffect(true);

            _global.SetNewCource(cellName);
            _changeButton.gameObject.SetActive(true);
        }

        private GlobalMapCell GetNextLocation(string current)
        {
            for (int i = 0; i < _allCells.Count; i++)
            {
                if (_allCells[i].NamePoint == current)
                {
                    if (i + 1 == _allCells.Count)
                    {
                        return _cellsDictionary[_allCells[i].NamePoint];
                    }

                    if (_cellsDictionary.TryGetValue(_allCells[i + 1].NamePoint, out GlobalMapCell cell))
                    {
                        return cell;
                    }
                }
            }

            return _cellsDictionary[_allCells[1].NamePoint];
        }
    }
}
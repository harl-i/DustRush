using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class Hostel : MonoBehaviour
    {
        [SerializeField] private GlobalMap.GlobalMap _global;
        [SerializeField] private GlobalMap.GlobalMapView _mapView;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _saveButtonForRevard;
        [SerializeField] private Money _money;
        [SerializeField] private TextMeshProUGUI _coustView;
        [SerializeField] private GameObject _alreadyOpen;

        [SerializeField] private int _startCoust;
        [SerializeField] private bool _isHaveValue = false;

        private bool _isStarted = false;

        private void OnEnable()
        {
            if (_isStarted == false)
                return;

            Init();
        }

        private void FixedUpdate()
        {
            if (_isStarted == true)
                return;

            _isStarted = true;

            Init();
        }

        private void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(OnSaveClick);
        }

        public void OnReward(string _)
        {
            _global.SaveOpenTown(_global.SavedDeport);
            TrySetAlredyOpen();
        }

        private void Init()
        {
            TrySetAlredyOpen();
            _saveButton.onClick.AddListener(OnSaveClick);

            if (_isHaveValue)
                return;

            _isHaveValue = true;

            for (int i = 0; i < _mapView.AllCells.Count; i++)
            {
                if (_global.SavedDeport == _mapView.AllCells[i].NamePoint)
                {
                    _startCoust *= i;
                    _coustView.text = _startCoust.ToString();

                    return;
                }
            }
        }

        private void OnSaveClick()
        {
            if (_money.Value >= _startCoust)
            {
                _global.SaveOpenTown(_global.SavedDeport);
                _money.ChangeValue(-_startCoust);
                TrySetAlredyOpen();
            }
        }

        private void TrySetAlredyOpen()
        {
            foreach (string item in _global.SavedTowns)
            {
                if (item == _global.SavedDeport)
                {
                    _alreadyOpen.gameObject.SetActive(true);
                    _coustView.gameObject.SetActive(false);
                    _saveButton.gameObject.SetActive(false);
                    _saveButtonForRevard.gameObject.SetActive(false);

                    return;
                }
            }
        }
    }
}
using RoadTrane;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Sity
{
    public class ConstuctorTrane : MonoBehaviour
    {
        [SerializeField] private FabricTrane _fabricTrane;
        [SerializeField] private GarageInventoryPlayer _garageInventoryPlayer;
        [SerializeField] private UiForConstuctorTrane _placeUi;
        [SerializeField] private UiEndConstuctorTrane _clickedEnd;
        [SerializeField] private UiEndConstuctorTrane _clickedTrusk;

        private List<UiForConstuctorTrane> _createdUiWagons = new List<UiForConstuctorTrane>();
        private List<UiForConstuctorTrane> _createdUiTower = new List<UiForConstuctorTrane>();

        private bool _isWaitWagon = false;
        private bool _isWaitClickEnd = false;
        private bool _isWaitTower = false;
        private bool _isWaitTrusk = false;

        private Vector3 _offsetMiddle = new Vector2(0, -1.5f);
        private int _changedWagon = 0;
        private int _waitPlaceTower = 0;

        private Coroutine _waitingChoise;
        private WaitForSeconds _waitChoise;
        private float _waitValue = 0.5f;

        private void OnEnable()
        {
            _waitChoise = new WaitForSeconds(_waitValue);

            SetNewWagonButton();
            SetNewTruskButton();
            SetWagonButton();
            SetTowerButton();

            _clickedEnd.ClickedEnd += OnClickedEnd;
            _clickedTrusk.ClickedEnd += OnClickTrusk;

            foreach (ShopCell item in _garageInventoryPlayer.HaveCell)
            {
                item.OnUsed += OnUseNewItem;
            }
        }

        private void OnDestroy()
        {
            _clickedEnd.ClickedEnd -= OnClickedEnd;
            _clickedTrusk.ClickedEnd -= OnClickTrusk;

            foreach (ShopCell item in _garageInventoryPlayer.HaveCell)
            {
                item.OnUsed -= OnUseNewItem;
            }

            foreach (var item in _createdUiWagons)
            {

                _placeUi.Clicked -= OnWagonClicked;
            }

            foreach (UiForConstuctorTrane item in _createdUiTower)
            {
                item.Clicked -= OnTowerClicked;
            }
        }

        public void ChangeView(bool active)
        {
            foreach (var item in _createdUiWagons)
            {
                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(active);
                }
            }

            foreach (var item in _createdUiTower)
            {
                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(active);
                }
            }

            if (_clickedEnd.gameObject.activeSelf == false)
                _clickedEnd.gameObject.SetActive(active);
        }

        public void UpdateInventoryPlayer()
        {
            foreach (ShopCell item in _garageInventoryPlayer.HaveCell)
            {
                item.OnUsed -= OnUseNewItem;
            }

            foreach (ShopCell item in _garageInventoryPlayer.HaveCell)
            {
                item.OnUsed += OnUseNewItem;
            }
        }

        private void SetNewTruskButton()
        {
            _clickedTrusk.transform.position =
                _fabricTrane.CreatedTruck.transform.position - _offsetMiddle;
        }

        private void OnClickedEnd()
        {
            _garageInventoryPlayer.StopEffect();
            _isWaitClickEnd = true;
            _garageInventoryPlayer.ShowEffect("OnClickedEnd");
        }

        private void OnClickTrusk()
        {
            _garageInventoryPlayer.StopEffect();
            _isWaitTrusk = true;
            _garageInventoryPlayer.ShowEffect("OnClickTrusk");
        }

        private void OnWagonClicked(int id)
        {
            _garageInventoryPlayer.StopEffect();
            _isWaitWagon = true;
            _changedWagon = id;
            _garageInventoryPlayer.ShowEffect("OnWagonClicked");
        }

        private void OnTowerClicked(int id)
        {
            _garageInventoryPlayer.StopEffect();
            _waitPlaceTower = id;
            _isWaitTower = true;
            _garageInventoryPlayer.ShowEffect("OnTowerClicked");
        }

        private void OnUseNewItem(int idContent)
        {
            if (_isWaitWagon)
            {
                if (idContent > 36)
                {
                    _fabricTrane.ChangeWagon(idContent, _changedWagon);
                    _isWaitWagon = false;
                    _garageInventoryPlayer.RemoveCell(idContent);
                    _garageInventoryPlayer.StopEffect();
                }
            }

            if (_isWaitClickEnd)
            {
                if (idContent > 36)
                {
                    _fabricTrane.AddWagon(idContent);
                    _isWaitClickEnd = false;
                    _garageInventoryPlayer.RemoveCell(idContent);
                    _garageInventoryPlayer.StopEffect();
                }
            }

            if (_isWaitTower)
            {
                if (idContent < 36 && idContent > 5)
                {
                    _fabricTrane.AddTower(idContent, _waitPlaceTower);
                    _waitPlaceTower = 0;
                    _isWaitTower = false;
                    _garageInventoryPlayer.RemoveCell(idContent);
                    _garageInventoryPlayer.StopEffect();
                }
            }

            if (_isWaitTrusk)
            {
                if (idContent < 5)
                {
                    _fabricTrane.CreatedTruck.ChangeType(idContent);
                    _isWaitTrusk = false;
                    _garageInventoryPlayer.RemoveCell(idContent);
                    _garageInventoryPlayer.StopEffect();
                }
            }

            SetNewWagonButton();
            SetWagonButton();
            SetTowerButton();
            UpdateInventoryPlayer();
        }

        private void SetNewWagonButton()
        {
            _clickedEnd.transform.position =
                _fabricTrane.CreatedWagons[_fabricTrane.CreatedWagons.Count - 1]
                .GetComponent<Wagon>().BackCouplingPosition.position;
        }

        private void SetWagonButton()
        {
            foreach (var item in _createdUiWagons)
            {
                item.gameObject.SetActive(false);
            }

            _createdUiWagons = new List<UiForConstuctorTrane>();

            UiForConstuctorTrane button = null;

            for (int i = 0; i < _fabricTrane.CreatedWagons.Count; i++)
            {
                button = Instantiate(_placeUi);
                button.transform.position = _fabricTrane.CreatedWagons[i].GetComponent<Wagon>().FrontCouplingPosition.position + _offsetMiddle;
                button.transform.SetParent(_fabricTrane.CreatedWagons[i].transform);
                _createdUiWagons.Add(button);
                button.Init(i);
                button.Clicked += OnWagonClicked;
            }
        }

        private void SetTowerButton()
        {
            foreach (var item in _createdUiTower)
            {
                item.gameObject.SetActive(false);
            }

            _createdUiTower = new List<UiForConstuctorTrane>();

            UiForConstuctorTrane button = null;

            for (int i = 0; i < _fabricTrane.CreatedWagons.Count; i++)
            {
                if (_fabricTrane.CreatedWagons[i].TypeWagon == Wagon.Type.Regular)
                {
                    for (int j = 0; j < _fabricTrane.CreatedWagons[i].PointsTower.Count; j++)
                    {
                        button = Instantiate(_placeUi);
                        button.transform.position = _fabricTrane.CreatedWagons[i].PointsTower[j].transform.position;
                        button.transform.SetParent(_fabricTrane.CreatedWagons[i].transform);
                        button.Init(i * 10 + j);
                        _createdUiTower.Add(button);

                        button.Clicked += OnTowerClicked;
                    }
                }
            }
        }
    }
}
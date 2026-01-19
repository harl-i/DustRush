using System;
using System.Collections.Generic;
using Modules.Grih.RoadTrain;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class GarageInventoryPlayer : MonoBehaviour
    {
        private const string OnClickedEnd = "OnClickedEnd";
        private const string OnWagonClicked = "OnWagonClicked";
        private const string OnClickTrusk = "OnClickTrusk";
        private const string OnTowerClicked = "OnTowerClicked";

        private const int TowerMinId = 36;
        private const int TruskMaxId = 5;
        private const int OffsetOne = 1;
        private const int ValueTen = 10;
        private const int ValueHundred = 100;

        [SerializeField] private List<Transform> _placeInventory;
        [SerializeField] private ItemTable _inventoryHashTable;
        [SerializeField] private ConstuctorTrane _constuctor;
        [SerializeField] private FabricTrain _fabricTrane;
        [SerializeField] private Shop _shop;

        private Dictionary<int, ShopCell> _idContent = new Dictionary<int, ShopCell>();
        private List<int> _savedData = new List<int>();
        private List<ShopCell> _haveCell = new List<ShopCell>();

        public event Action<List<int>> Saved;

        public List<ShopCell> HaveCell => _haveCell;

        public int PlaceInventory => _placeInventory.Count;

        private void OnDestroy()
        {
            _savedData = new List<int>();
            _fabricTrane.ContentRetern -= ReterndTower;

            foreach (ShopCell item in _haveCell)
            {
                if (item.gameObject.activeSelf)
                {
                    _savedData.Add(item.IdContent);
                    item.Saled -= OnSaled;
                }
            }

            Saved?.Invoke(_savedData);
        }

        public void Init(List<int> savedData)
        {
            _savedData = savedData;
            _fabricTrane.ContentRetern += ReterndTower;

            foreach (var item in _inventoryHashTable.CurrenTable)
            {
                _idContent.Add(item.Key, item.Value.GetComponent<ShopCell>());
            }

            SetSavedItem();
        }

        public void AddCell(ShopCell prefab, int id)
        {
            if (_placeInventory.Count == _haveCell.Count)
                return;

            ShopCell newCell = Instantiate(prefab);
            newCell.transform.position = _placeInventory[_haveCell.Count].position;
            newCell.transform.SetParent(_placeInventory[_haveCell.Count]);
            newCell.SetBuyState(true);
            newCell.SetID(id);
            newCell.Saled += OnSaled;
            _haveCell.Add(newCell);

            _constuctor.UpdateInventoryPlayer();
        }

        public void RemoveCell(int id)
        {
            foreach (ShopCell item in _haveCell)
            {
                if (item.IdContent == id)
                {
                    _haveCell.Remove(item);
                    item.gameObject.SetActive(false);
                    _constuctor.UpdateInventoryPlayer();
                    SortDeleted();

                    return;
                }
            }
        }

        public void Save()
        {
            List<int> saved = new List<int>();

            foreach (ShopCell cell in _haveCell)
                saved.Add(cell.IdContent);
        }

        public void ShowEffect(string value)
        {
            if (value == OnClickedEnd || value == OnWagonClicked)
            {
                foreach (ShopCell cell in _haveCell)
                {
                    if (cell.IdContent > TowerMinId)
                    {
                        cell.ActivateShowing();
                    }
                }
            }
            else if (value == OnClickTrusk)
            {
                foreach (ShopCell cell in _haveCell)
                {
                    if (cell.IdContent < TruskMaxId)
                    {
                        cell.ActivateShowing();
                    }
                }
            }
            else if (value == OnTowerClicked)
            {
                foreach (ShopCell cell in _haveCell)
                {
                    if (cell.IdContent > TruskMaxId
                        && cell.IdContent < TowerMinId + OffsetOne)
                    {
                        cell.ActivateShowing();
                    }
                }
            }
        }

        public void StopEffect()
        {
            foreach (ShopCell item in _haveCell)
            {
                item.StopShowing();
            }
        }

        private void OnSaled(int arg1, int arg2, int arg3)
        {
            _shop.Sale(arg1, arg2, arg3);
        }

        private void ReterndTower(int id)
        {
            int currentID = id % ValueHundred;

            if (currentID > ValueHundred)
                currentID %= ValueTen;

            ShopCell shopCell = _idContent[currentID];
            AddCell(shopCell, currentID);
        }

        private void SortDeleted()
        {
            if (_haveCell.Count == 0)
                return;

            for (int i = 0; i < _haveCell.Count; i++)
            {
                _haveCell[i].transform.position = _placeInventory[i].position;
                _haveCell[i].transform.SetParent(_placeInventory[i]);
            }
        }

        private void SetSavedItem()
        {
            if (_savedData.Count == 0)
                return;

            ShopCell shopCell = null;

            for (int i = 0; i < _savedData.Count; i++)
            {
                if (i >= _placeInventory.Count)
                    return;

                shopCell = Instantiate(_idContent[_savedData[i]]);
                shopCell.transform.position = _placeInventory[i].position;
                shopCell.transform.SetParent(_placeInventory[i]);
                shopCell.SetID(_savedData[i]);
                shopCell.SetBuyState(true);
                shopCell.Saled += OnSaled;

                _haveCell.Add(shopCell);
                _constuctor.UpdateInventoryPlayer();
            }
        }
    }
}
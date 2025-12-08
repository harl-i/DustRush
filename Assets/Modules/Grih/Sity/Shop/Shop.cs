using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Transform> _placesForCell = new List<Transform>();
        [SerializeField] private InventoryHashTable _inventoryHashTable;
        [SerializeField] private Inventory.Money _money;
        [SerializeField] private Inventory.Metal _metal; 
        [SerializeField] private GarageInventoryPlayer _garageInventoryPlayer;
        [SerializeField] private BlueprintObserver _blueprintObserver;
        [SerializeField] private GameObject _boxNeedBlueprint;

        private List<ShopCell> _createdCell = new List<ShopCell>();

        private void Start()
        {
            SetCell();
        }

        private void OnDestroy()
        {
            foreach (ShopCell cell in _createdCell)
            {
                cell.Byed -= TryBye;
            }
        }

        public void Sale(int id, int moneyCoust, int metalCoust)
        {
            _money.ChangeValue(moneyCoust);
            _metal.ChangeValue(metalCoust);
            _garageInventoryPlayer.RemoveCell(id);
        }

        private void SetCell()
        {
            ShopCell cell = null;

            foreach (var item in _inventoryHashTable.ContentTable)
            {
                cell = Instantiate(item.Value.GetComponent<ShopCell>());
                cell.transform.localPosition = _placesForCell[_createdCell.Count].position;
                cell.transform.SetParent(_placesForCell[_createdCell.Count]);
                cell.SetID(item.Key);
                cell.SetBox(_boxNeedBlueprint);
                cell.Byed += TryBye;
                _createdCell.Add(cell);

                if (CheckOnOpenblueprint(item.Key) == false)
                {
                    cell.SetNonactiveState();
                }
            }
        }

        private bool CheckOnOpenblueprint(int id)
        {
            return _blueprintObserver.IsHaveOnBlueprints(id);
        }

        private void TryBye(int id, int moneyCoust, int metalCoust)
        {
            if (_money.Value > moneyCoust)
            {
                if (_metal.Value > metalCoust)
                {
                    if (_garageInventoryPlayer.PlaceInventory < _createdCell.Count)
                    {
                        _money.ChangeValue(-moneyCoust);
                        _metal.ChangeValue(-metalCoust);

                        _garageInventoryPlayer.AddCell(_inventoryHashTable.ContentTable[id], id);
                    }
                }
            }
        }
    }
}
using System.Collections.Generic;
using Modules.Grih.RoadTrain;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Transform> _placesForCell = new List<Transform>();
        [SerializeField] private ItemTable _inventoryHashTable;
        [SerializeField] private Modules.Grih.InventoryGroup.Money _money;
        [SerializeField] private Modules.Grih.InventoryGroup.Metal _metal;
        [SerializeField] private Modules.Grih.InventoryGroup.Dollars _dollars;
        [SerializeField] private GarageInventoryPlayer _garageInventoryPlayer;
        [SerializeField] private BlueprintObserver _blueprintObserver;
        [SerializeField] private ShopCellNeedBlueprint _boxNeedBlueprint;

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

            foreach (var item in _inventoryHashTable.CurrenTable)
            {
                cell = Instantiate(item.Value.GetComponent<ShopCell>());
                cell.transform.localPosition = _placesForCell[_createdCell.Count].position;
                cell.transform.SetParent(_placesForCell[_createdCell.Count]);
                cell.SetID(item.Key);
                cell.InitOnShop(_dollars, _blueprintObserver);
                cell.SetBox(_boxNeedBlueprint);
                cell.Byed += TryBye;
                _createdCell.Add(cell);

                if (CheckOnOpenblueprint(item.Key) == false)
                {
                    cell.SetActiveState(false);
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

                        _garageInventoryPlayer.AddCell(
                            _inventoryHashTable.CurrenTable[id].GetComponent<ShopCell>(), id);
                    }
                }
            }
        }
    }
}
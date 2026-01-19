using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class ItemTable : MonoBehaviour
    {
        [SerializeField] private List<HaveIdItem> _prefabHaveIdItems;

        private Dictionary<int, HaveIdItem> _itemsTable = new Dictionary<int, HaveIdItem>();

        public Dictionary<int, HaveIdItem> CurrenTable => _itemsTable;

        private void OnEnable()
        {
            foreach (HaveIdItem item in _prefabHaveIdItems)
            {
                if (_itemsTable.ContainsKey(item.Id) == false)
                    _itemsTable.Add(item.Id, item);
            }
        }

        private void OnDisable()
        {
            _itemsTable.Clear();
        }
    }
}
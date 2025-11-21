using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class WagonsHashTable : MonoBehaviour
    {
        private const int IdWagonEmpty_1 = 10;
        private const string IdWagonEmptyName_1 = "Empty_1";

        private const int IdWagonEmpty_2 = 11;
        private const string IdWagonEmptyName_2 = "Empty_2";

        private const int IdWagonEmpty_3 = 12;
        private const string IdWagonEmptyName_3 = "Empty_3";

        [SerializeField] private GameObject _wagonEmpty_1;
        [SerializeField] private GameObject _wagonEmpty_2;
        [SerializeField] private GameObject _wagonEmpty_3;

        public Dictionary<int, GameObject> _wagonsTable = new Dictionary<int, GameObject>();

        public Dictionary<int, GameObject> WagonsTable => _wagonsTable;

        private void OnEnable()
        {
            _wagonsTable.Add(IdWagonEmpty_1,
                _wagonEmpty_1);

            _wagonsTable.Add(IdWagonEmpty_2,
                _wagonEmpty_2);

            _wagonsTable.Add(IdWagonEmpty_3,
                _wagonEmpty_3);

            InitId();
        }

        private void InitId()
        {
            foreach (var item in _wagonsTable)
            {
                var wagon = item.Value.GetComponent<Wagon>();

                wagon.SetID(item.Key);
            }
        }
    }
}

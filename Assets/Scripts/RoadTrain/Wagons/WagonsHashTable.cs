using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class WagonsHashTable : MonoBehaviour
    {
        private const int IdWagonEmpty_1 = 1;
        private const string IdWagonEmptyName_1 = "Empty_1";
        [SerializeField] private GameObject _wagonEmpty_1;

        private const int IdWagonEmpty_2 = 2;
        private const string IdWagonEmptyName_2 = "Empty_2";
        [SerializeField] private GameObject _wagonEmpty_2;

        public Dictionary<int, GameObject> _wagonsTable = new Dictionary<int, GameObject>();

        public Dictionary<int, GameObject> WagonsTable => _wagonsTable;

        private void OnEnable()
        {

            _wagonsTable.Add(IdWagonEmpty_1,
                _wagonEmpty_1);

            _wagonsTable.Add(IdWagonEmpty_2,
                _wagonEmpty_2);
        }
    }

}

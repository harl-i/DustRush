using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class WagonsHashTable : MonoBehaviour
    {
        private const int IdWagonEmpty_1 = 1;
        private const string IdWagonEmptyName_1 = "Empty_1";

        private const int IdWagonEmpty_2 = 2;
        private const string IdWagonEmptyName_2 = "Empty_2";

        [SerializeField] private Sprite WagonEmptySprite_1;
        [SerializeField] private Sprite WagonEmptySprite_2;

        public Dictionary<int, Wagon> WagonsTable { get; private set; }

        private void OnEnable()
        {
            WagonsTable = new Dictionary<int, Wagon>();

            WagonsTable.Add(IdWagonEmpty_1,
                new Wagon(IdWagonEmptyName_1,
                Wagon.Type.Regular,
                WagonEmptySprite_1));

            WagonsTable.Add(IdWagonEmpty_2,
                new Wagon(IdWagonEmptyName_2,
                Wagon.Type.Regular,
                WagonEmptySprite_2));
        }
    }

}

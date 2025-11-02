using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RoadTrane
{
    public class Wagon : MonoBehaviour
    {
        public enum Type
        {
            Regular,
            Spesial
        }

        [SerializeField] private Type _typeVagon;
        [SerializeField] private List<Transform> _pointWeapons;

        [SerializeField] private int _numberOrder;
        [SerializeField] private FabricTower _fabricTower;

        private List<Tower> _savedTowers;
        private string _name;

        private void OnEnable()
        {
            SetTower();
        }

        private void SetTower()
        {
            if (_typeVagon != Type.Spesial)
            {
                switch (_numberOrder)
                {
                    //case 1:
                    //    _savedTowers = YG2.saves.SavedTowersVagon1;
                    //    break;
                    //case 2:
                    //    _savedTowers = YG2.saves.SavedTowersVagon2;
                    //    break;
                    //case 3:
                    //    _savedTowers = YG2.saves.SavedTowersVagon3;
                    //    break;
                    //case 4:
                    //    _savedTowers = YG2.saves.SavedTowersVagon4;
                    //    break;
                    //case 5:
                    //    _savedTowers = YG2.saves.SavedTowersVagon5;
                    //    break;
                    //case 6:
                    //    _savedTowers = YG2.saves.SavedTowersVagon6;
                    //    break;
                }

                for (int i = 0; i < _pointWeapons.Count; i++)
                {
                   // _fabricTower.Create(_savedTowers[i], _pointWeapons[i]);
                }
            }
        }
    }
}
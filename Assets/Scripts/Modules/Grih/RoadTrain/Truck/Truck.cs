using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class Truck : TrainPart
    {
        [SerializeField] private List<TruckStrategy> _truckTypes;

        private string _savedType;

        public string TypeTrusk => _savedType;

        public void Init(string type)
        {
            foreach (TruckStrategy strategy in _truckTypes)
            {
                strategy.ChangeActivity(strategy.NameType == type);

                if (strategy.NameType == type)
                {
                    _savedType = strategy.NameType;
                }
            }
        }

        public void ChangeType(int id)
        {
            foreach (TruckStrategy strategy in _truckTypes)
            {
                strategy.ChangeActivity(strategy.Id == id);

                if (strategy.Id == id)
                {
                    _savedType = strategy.NameType;
                }
            }
        }
    }
}

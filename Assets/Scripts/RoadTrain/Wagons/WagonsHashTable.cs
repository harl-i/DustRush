using System.Collections.Generic;
using TMPro;
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

        private const int IdWagonBattery = 21;
        private const string IdWagonBatteryWagonName = "BatteryWagon";

        private const int IdWagonBattery2 = 22;
        private const string IdWagonBatteryWagonName2 = "BatteryWagon2";

        private const int IdWagonBattery3 = 23;
        private const string IdWagonBatteryWagonName3 = "BatteryWagon3";

        private const int IdFuelWagon = 25;
        private const string IdFuelWagonName = "FuelWagon";

        private const int IdFuelWagon2 = 26;
        private const string IdFuelWagonName2 = "FuelWagon2";

        private const int IdFuelWagon3 = 27;
        private const string IdFuelWagonName3 = "FuelWagon3";

        private const int IdEngineeringWagon = 31;
        private const string IdEngineeringWagonName = "EngineeringWagon";

        private const int IdEngineeringWagon2 = 32;
        private const string IdEngineeringWagonName2 = "EngineeringWagon2";

        private const int IdEngineeringWagon3 = 33;
        private const string IdEngineeringWagonName3 = "EngineeringWagon3";

        private const int IdLivingWagon = 35;
        private const string IdLivingWagonName = "LivingWagon";

        private const int IdLivingWagon2 = 36;
        private const string IdLivingWagonName2 = "LivingWagon2";

        private const int IdLivingWagon3 = 37;
        private const string IdLivingWagonName3 = "LivingWagon3";

        private const int IdMlitaryWagon = 41;
        private const string IdMlitaryWagonName = "MlitaryWagon";

        private const int IdMlitaryWagon2 = 42;
        private const string IdMlitaryWagonName2 = "MlitaryWagon2";

        private const int IdMlitaryWagon3 = 43;
        private const string IdMlitaryWagonName3 = "MlitaryWagon3";

        private const int IdSolarBWagon = 45;
        private const string IdSolarBWagonName = "SolarBWagon";

        private const int IdSolarBWagon2 = 46;
        private const string IdSolarBWagonName2 = "SolarBWagon2";

        private const int IdSolarBWagon3 = 47;
        private const string IdSolarBWagonName3 = "SolarBWagon3";

        private const int IdFuelPowerGeneratorWagon = 51;
        private const string IdFuelPowerGeneratorWagonName = "FuelPowerGeneratorWagon";

        private const int IdFuelPowerGeneratorWagon2 = 52;
        private const string IdFuelPowerGeneratorWagonName2 = "FuelPowerGeneratorWagon2";

        private const int IdFuelPowerGeneratorWagon3 = 53;
        private const string IdFuelPowerGeneratorWagonName3 = "FuelPowerGeneratorWagon3";

        [SerializeField] private GameObject _wagonEmpty_1;
        [SerializeField] private GameObject _wagonEmpty_2;
        [SerializeField] private GameObject _wagonEmpty_3;

        [SerializeField] private GameObject _batteryWagon;
        [SerializeField] private GameObject _fuelWagon;
        [SerializeField] private GameObject _engineeringWagon;
        [SerializeField] private GameObject _livingWagon;
        [SerializeField] private GameObject _mlitaryWagon;
        [SerializeField] private GameObject _solarBWagon;
        [SerializeField] private GameObject _fuelPowerGeneratorWagon;

        [SerializeField] private GameObject _batteryWagon2;
        [SerializeField] private GameObject _fuelWagon2;
        [SerializeField] private GameObject _engineeringWagon2;
        [SerializeField] private GameObject _livingWagon2;
        [SerializeField] private GameObject _mlitaryWagon2;
        [SerializeField] private GameObject _solarBWagon2;
        [SerializeField] private GameObject _fuelPowerGeneratorWagon2;

        [SerializeField] private GameObject _batteryWagon3;
        [SerializeField] private GameObject _fuelWagon3;
        [SerializeField] private GameObject _engineeringWagon3;
        [SerializeField] private GameObject _livingWagon3;
        [SerializeField] private GameObject _mlitaryWagon3;
        [SerializeField] private GameObject _solarBWagon3;
        [SerializeField] private GameObject _fuelPowerGeneratorWagon3;

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

            _wagonsTable.Add(IdWagonBattery,
               _batteryWagon); 
            
            _wagonsTable.Add(IdLivingWagon,
               _livingWagon);

            _wagonsTable.Add(IdFuelWagon,
               _fuelWagon);

            _wagonsTable.Add(IdEngineeringWagon,
               _engineeringWagon);

            _wagonsTable.Add(IdMlitaryWagon,
               _mlitaryWagon);

            _wagonsTable.Add(IdSolarBWagon,
               _solarBWagon);

            _wagonsTable.Add(IdFuelPowerGeneratorWagon,
               _fuelPowerGeneratorWagon);

            _wagonsTable.Add(IdWagonBattery2,
               _batteryWagon2);

            _wagonsTable.Add(IdLivingWagon2,
               _livingWagon2);

            _wagonsTable.Add(IdFuelWagon2,
               _fuelWagon2);

            _wagonsTable.Add(IdEngineeringWagon2,
               _engineeringWagon2);

            _wagonsTable.Add(IdMlitaryWagon2,
               _mlitaryWagon2);

            _wagonsTable.Add(IdSolarBWagon2,
               _solarBWagon2);

            _wagonsTable.Add(IdFuelPowerGeneratorWagon2,
               _fuelPowerGeneratorWagon2);

            _wagonsTable.Add(IdWagonBattery3,
               _batteryWagon3);

            _wagonsTable.Add(IdLivingWagon3,
               _livingWagon3);

            _wagonsTable.Add(IdFuelWagon3,
               _fuelWagon3);

            _wagonsTable.Add(IdEngineeringWagon3,
               _engineeringWagon3);

            _wagonsTable.Add(IdMlitaryWagon3,
               _mlitaryWagon3);

            _wagonsTable.Add(IdSolarBWagon3,
               _solarBWagon3);

            _wagonsTable.Add(IdFuelPowerGeneratorWagon3,
               _fuelPowerGeneratorWagon3);


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

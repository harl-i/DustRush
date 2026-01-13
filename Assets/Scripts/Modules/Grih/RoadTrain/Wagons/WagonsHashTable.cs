using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class WagonsHashTable : MonoBehaviour
    {
        private const int IdWagonEmpty_1 = 37;
        private const int IdWagonEmpty_2 = 38;
        private const int IdWagonEmpty_3 = 39;
        private const int IdWagonBattery = 40;
        private const int IdWagonBattery2 = 41;
        private const int IdWagonBattery3 = 42;
        private const int IdFuelWagon = 43;
        private const int IdFuelWagon2 = 44;
        private const int IdFuelWagon3 = 45;
        private const int IdEngineeringWagon = 46;
        private const int IdEngineeringWagon2 = 47;
        private const int IdEngineeringWagon3 = 48;
        private const int IdLivingWagon = 49;
        private const int IdLivingWagon2 = 50;
        private const int IdLivingWagon3 = 51;
        private const int IdMlitaryWagon = 52;
        private const int IdMlitaryWagon2 = 53;
        private const int IdMlitaryWagon3 = 54;
        private const int IdSolarBWagon = 55;
        private const int IdSolarBWagon2 = 56; 
        private const int IdSolarBWagon3 = 57; 
        private const int IdFuelPowerGeneratorWagon = 58;
        private const int IdFuelPowerGeneratorWagon2 = 59;
        private const int IdFuelPowerGeneratorWagon3 = 60;

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

        private Dictionary<int, GameObject> _wagonsTable = new Dictionary<int, GameObject>();

        public Dictionary<int, GameObject> WagonsTable => _wagonsTable;

        private void OnEnable()
        {
            _wagonsTable.Add(
                IdWagonEmpty_1,
                _wagonEmpty_1);

            _wagonsTable.Add(
                IdWagonEmpty_2,
                _wagonEmpty_2);

            _wagonsTable.Add(
                IdWagonEmpty_3,
                _wagonEmpty_3);

            _wagonsTable.Add(
                IdWagonBattery,
               _batteryWagon);

            _wagonsTable.Add(IdLivingWagon,
               _livingWagon);

            _wagonsTable.Add(
                IdFuelWagon,
               _fuelWagon);

            _wagonsTable.Add(
                IdEngineeringWagon,
               _engineeringWagon);

            _wagonsTable.Add(
                IdMlitaryWagon,
               _mlitaryWagon);

            _wagonsTable.Add(
                IdSolarBWagon,
               _solarBWagon);

            _wagonsTable.Add(
                IdFuelPowerGeneratorWagon,
               _fuelPowerGeneratorWagon);

            _wagonsTable.Add(
                IdWagonBattery2,
               _batteryWagon2);

            _wagonsTable.Add(
                IdLivingWagon2,
               _livingWagon2);

            _wagonsTable.Add(
                IdFuelWagon2,
               _fuelWagon2);

            _wagonsTable.Add(
                IdEngineeringWagon2,
               _engineeringWagon2);

            _wagonsTable.Add(
                IdMlitaryWagon2,
               _mlitaryWagon2);

            _wagonsTable.Add(
                IdSolarBWagon2,
               _solarBWagon2);

            _wagonsTable.Add(
                IdFuelPowerGeneratorWagon2,
               _fuelPowerGeneratorWagon2);

            _wagonsTable.Add(
                IdWagonBattery3,
               _batteryWagon3);

            _wagonsTable.Add(
                IdLivingWagon3,
               _livingWagon3);

            _wagonsTable.Add(
                IdFuelWagon3,
               _fuelWagon3);

            _wagonsTable.Add(
                IdEngineeringWagon3,
               _engineeringWagon3);

            _wagonsTable.Add(
                IdMlitaryWagon3,
               _mlitaryWagon3);

            _wagonsTable.Add(
                IdSolarBWagon3,
               _solarBWagon3);

            _wagonsTable.Add(
                IdFuelPowerGeneratorWagon3,
               _fuelPowerGeneratorWagon3);
        }
    }
}

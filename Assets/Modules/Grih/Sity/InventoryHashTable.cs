using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class InventoryHashTable : MonoBehaviour
    {
        [Header("Trusk")]
        private const int IdSpeedster = 1;
        private const int IdAtacker = 2;
        private const int IdStealther = 3;

        [Header("Towers")]
        private const int IdMashineGun_1 = 11;
        private const int IdMashineGun_2 = 12;
        private const int IdMashineGun_3 = 13;

        private const int IdShotgun_1 = 14;
        private const int IdShotgun_2 = 15;
        private const int IdShotgun_3 = 16;

        private const int IdHarpoon_1 = 17;
        private const int IdHarpoon_2 = 18;
        private const int IdHarpoon_3 = 19;

        private const int IdMortar_1 = 20;
        private const int IdMortar_2 = 21;
        private const int IdMortar_3 = 22;

        private const int IdRocketLauncher_1 = 23;
        private const int IdRocketLauncher_2 = 24;
        private const int IdRocketLauncher_3 = 25;

        private const int IdFlamethrower_1 = 26;
        private const int IdFlamethrower_2 = 27;
        private const int IdFlamethrower_3 = 28;

        private const int IdGaussGun_1 = 29;
        private const int IdGaussGun_2 = 30;
        private const int IdGaussGun_3 = 31;

        private const int IdEMPCannon_1 = 32;
        private const int IdEMPCannon_2 = 33;
        private const int IdEMPCannon_3 = 34;

        private const int IdFridge = 35;
        private const int IdMachineGunDepot = 36;

        [Header("Wagons")]
        private const int IdWagonEmpty_1 = 37;
        private const string IdWagonEmptyName_1 = "Empty_1";

        private const int IdWagonEmpty_2 = 38;
        private const string IdWagonEmptyName_2 = "Empty_2";

        private const int IdWagonEmpty_3 = 39;
        private const string IdWagonEmptyName_3 = "Empty_3";

        private const int IdWagonBattery = 40;
        private const string IdWagonBatteryWagonName = "BatteryWagon";

        private const int IdWagonBattery2 = 41;
        private const string IdWagonBatteryWagonName2 = "BatteryWagon2";

        private const int IdWagonBattery3 = 42;
        private const string IdWagonBatteryWagonName3 = "BatteryWagon3";

        private const int IdFuelWagon = 43;
        private const string IdFuelWagonName = "FuelWagon";

        private const int IdFuelWagon2 = 44;
        private const string IdFuelWagonName2 = "FuelWagon2";

        private const int IdFuelWagon3 = 45;
        private const string IdFuelWagonName3 = "FuelWagon3";

        private const int IdEngineeringWagon = 46;
        private const string IdEngineeringWagonName = "EngineeringWagon";

        private const int IdEngineeringWagon2 = 47;
        private const string IdEngineeringWagonName2 = "EngineeringWagon2";

        private const int IdEngineeringWagon3 = 48;
        private const string IdEngineeringWagonName3 = "EngineeringWagon3";

        private const int IdLivingWagon = 49;
        private const string IdLivingWagonName = "LivingWagon";

        private const int IdLivingWagon2 = 50;
        private const string IdLivingWagonName2 = "LivingWagon2";

        private const int IdLivingWagon3 = 51;
        private const string IdLivingWagonName3 = "LivingWagon3";

        private const int IdMlitaryWagon = 52;
        private const string IdMlitaryWagonName = "MlitaryWagon";

        private const int IdMlitaryWagon2 = 53;
        private const string IdMlitaryWagonName2 = "MlitaryWagon2";

        private const int IdMlitaryWagon3 = 54;
        private const string IdMlitaryWagonName3 = "MlitaryWagon3";

        private const int IdSolarBWagon = 55;
        private const string IdSolarBWagonName = "SolarBWagon";

        private const int IdSolarBWagon2 = 56;
        private const string IdSolarBWagonName2 = "SolarBWagon2";

        private const int IdSolarBWagon3 = 57;
        private const string IdSolarBWagonName3 = "SolarBWagon3";

        private const int IdFuelPowerGeneratorWagon = 58;
        private const string IdFuelPowerGeneratorWagonName = "FuelPowerGeneratorWagon";

        private const int IdFuelPowerGeneratorWagon2 = 59;
        private const string IdFuelPowerGeneratorWagonName2 = "FuelPowerGeneratorWagon2";

        private const int IdFuelPowerGeneratorWagon3 = 60;
        private const string IdFuelPowerGeneratorWagonName3 = "FuelPowerGeneratorWagon3";

        [Header("Trusk")]
        [SerializeField] private ShopCell _speedster;
        [SerializeField] private ShopCell _atacker;
        [SerializeField] private ShopCell _stealther;

        [Header("TowersContent")]
        [SerializeField] private ShopCell _mashineGunPrefab_1;
        [SerializeField] private ShopCell _mashineGunPrefab_2;
        [SerializeField] private ShopCell _mashineGunPrefab_3;

        [SerializeField] private ShopCell _shotgunPrefab_1;
        [SerializeField] private ShopCell _shotgunPrefab_2;
        [SerializeField] private ShopCell _shotgunPrefab_3;

        [SerializeField] private ShopCell _harpoonPrefab_1;
        [SerializeField] private ShopCell _harpoonPrefab_2;
        [SerializeField] private ShopCell _harpoonPrefab_3;

        [SerializeField] private ShopCell _mortarPrefab_1;
        [SerializeField] private ShopCell _mortarPrefab_2;
        [SerializeField] private ShopCell _mortarPrefab_3;

        [SerializeField] private ShopCell _rocketLauncherPrefab_1;
        [SerializeField] private ShopCell _rocketLauncherPrefab_2;
        [SerializeField] private ShopCell _rocketLauncherPrefab_3;

        [SerializeField] private ShopCell _flamethrowerPrefab_1;
        [SerializeField] private ShopCell _flamethrowerPrefab_2;
        [SerializeField] private ShopCell _flamethrowerPrefab_3;

        [SerializeField] private ShopCell _gaussGunPrefab_1;
        [SerializeField] private ShopCell _gaussGunPrefab_2;
        [SerializeField] private ShopCell _gaussGunPrefab_3;

        [SerializeField] private ShopCell _EMPCannonPrefab_1;
        [SerializeField] private ShopCell _EMPCannonPrefab_2;
        [SerializeField] private ShopCell _EMPCannonPrefab_3;

        [SerializeField] private ShopCell _fridgePrefab;
        [SerializeField] private ShopCell _machineGunDepotPrefab;

        [Header("WagonsContent")]
        [SerializeField] private ShopCell _wagonEmpty_1;
        [SerializeField] private ShopCell _wagonEmpty_2;
        [SerializeField] private ShopCell _wagonEmpty_3;

        [SerializeField] private ShopCell _batteryWagon;
        [SerializeField] private ShopCell _batteryWagon2;
        [SerializeField] private ShopCell _batteryWagon3;

        [SerializeField] private ShopCell _fuelWagon;
        [SerializeField] private ShopCell _fuelWagon2;
        [SerializeField] private ShopCell _fuelWagon3;
        [SerializeField] private ShopCell _engineeringWagon;
        [SerializeField] private ShopCell _engineeringWagon2;
        [SerializeField] private ShopCell _engineeringWagon3;
        [SerializeField] private ShopCell _livingWagon;
        [SerializeField] private ShopCell _livingWagon2;
        [SerializeField] private ShopCell _livingWagon3;
        [SerializeField] private ShopCell _mlitaryWagon;
        [SerializeField] private ShopCell _mlitaryWagon2;
        [SerializeField] private ShopCell _mlitaryWagon3;
        [SerializeField] private ShopCell _solarBWagon;
        [SerializeField] private ShopCell _solarBWagon2;
        [SerializeField] private ShopCell _solarBWagon3;
        [SerializeField] private ShopCell _fuelPowerGeneratorWagon;
        [SerializeField] private ShopCell _fuelPowerGeneratorWagon2;
        [SerializeField] private ShopCell _fuelPowerGeneratorWagon3;

        private Dictionary<int, ShopCell> _contentTable = new Dictionary<int, ShopCell>();
        public Dictionary<int, ShopCell> ContentTable => _contentTable;

        private void OnEnable()
        {

            _contentTable.Add(IdSpeedster,
               _speedster);

            _contentTable.Add(IdAtacker,
               _atacker);

            _contentTable.Add(IdStealther,
               _stealther);

            _contentTable.Add(IdWagonEmpty_1,
                _wagonEmpty_1);

            _contentTable.Add(IdWagonEmpty_2,
                _wagonEmpty_2);

            _contentTable.Add(IdWagonEmpty_3,
                _wagonEmpty_3);

            _contentTable.Add(IdWagonBattery,
               _batteryWagon);

            _contentTable.Add(IdWagonBattery2,
               _batteryWagon2);

            _contentTable.Add(IdWagonBattery3,
               _batteryWagon3);

            _contentTable.Add(IdLivingWagon,
               _livingWagon);

            _contentTable.Add(IdLivingWagon2,
               _livingWagon2);

            _contentTable.Add(IdLivingWagon3,
               _livingWagon3);

            _contentTable.Add(IdFuelWagon,
               _fuelWagon);

            _contentTable.Add(IdFuelWagon2,
               _fuelWagon2);

            _contentTable.Add(IdFuelWagon3,
               _fuelWagon3);

            _contentTable.Add(IdEngineeringWagon,
               _engineeringWagon);

            _contentTable.Add(IdEngineeringWagon2,
               _engineeringWagon2);


            _contentTable.Add(IdEngineeringWagon3,
               _engineeringWagon3);

            _contentTable.Add(IdMlitaryWagon,
               _mlitaryWagon);

            _contentTable.Add(IdMlitaryWagon2,
               _mlitaryWagon2);

            _contentTable.Add(IdMlitaryWagon3,
               _mlitaryWagon3);

            _contentTable.Add(IdSolarBWagon,
               _solarBWagon);

            _contentTable.Add(IdSolarBWagon2,
               _solarBWagon2);

            _contentTable.Add(IdSolarBWagon3,
               _solarBWagon3);


            _contentTable.Add(IdFuelPowerGeneratorWagon,
               _fuelPowerGeneratorWagon);

            _contentTable.Add(IdFuelPowerGeneratorWagon2,
               _fuelPowerGeneratorWagon2);

            _contentTable.Add(IdFuelPowerGeneratorWagon3,
               _fuelPowerGeneratorWagon3);

            _contentTable.Add(IdMashineGun_1,
            _mashineGunPrefab_1);

            _contentTable.Add(IdMashineGun_2,
                 _mashineGunPrefab_2);

            _contentTable.Add(IdMashineGun_3,
                 _mashineGunPrefab_3);

            _contentTable.Add(IdShotgun_1,
                 _shotgunPrefab_1);

            _contentTable.Add(IdShotgun_2,
                 _shotgunPrefab_2);

            _contentTable.Add(IdShotgun_3,
                 _shotgunPrefab_3);

            _contentTable.Add(IdHarpoon_1,
                 _harpoonPrefab_1);

            _contentTable.Add(IdHarpoon_2,
                 _harpoonPrefab_2);

            _contentTable.Add(IdHarpoon_3,
                 _harpoonPrefab_3);

            _contentTable.Add(IdMortar_1,
                 _mortarPrefab_1);

            _contentTable.Add(IdMortar_2,
                 _mortarPrefab_2);

            _contentTable.Add(IdMortar_3,
                _mortarPrefab_3);

            _contentTable.Add(IdRocketLauncher_1,
                _rocketLauncherPrefab_1);

            _contentTable.Add(IdRocketLauncher_2,
                 _rocketLauncherPrefab_2);

            _contentTable.Add(IdRocketLauncher_3,
                _rocketLauncherPrefab_3);

            _contentTable.Add(IdFlamethrower_1,
               _flamethrowerPrefab_1);

            _contentTable.Add(IdFlamethrower_2,
                 _flamethrowerPrefab_2);

            _contentTable.Add(IdFlamethrower_3,
                _flamethrowerPrefab_3);

            _contentTable.Add(IdGaussGun_1,
                 _gaussGunPrefab_1);

            _contentTable.Add(IdGaussGun_2,
                 _gaussGunPrefab_2);

            _contentTable.Add(IdGaussGun_3,
                _gaussGunPrefab_3);

            _contentTable.Add(IdEMPCannon_1,
                _EMPCannonPrefab_1);

            _contentTable.Add(IdEMPCannon_2,
                 _EMPCannonPrefab_2);

            _contentTable.Add(IdEMPCannon_3,
                _EMPCannonPrefab_3);

            _contentTable.Add(IdFridge,
                _fridgePrefab);

            _contentTable.Add(IdMachineGunDepot,
                 _machineGunDepotPrefab);
        }

        private void OnDisable()
        {
            _contentTable.Clear();
        }
    }
}
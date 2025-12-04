using RoadTrane;
using System.Collections.Generic;
using UnityEngine;

public class TowersHashTable : MonoBehaviour
{
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

    [SerializeField] private GameObject _mashineGunPrefab_1;
    [SerializeField] private GameObject _mashineGunPrefab_2;
    [SerializeField] private GameObject _mashineGunPrefab_3;

    [SerializeField] private GameObject _shotgunPrefab_1;
    [SerializeField] private GameObject _shotgunPrefab_2;
    [SerializeField] private GameObject _shotgunPrefab_3;

    [SerializeField] private GameObject _harpoonPrefab_1;
    [SerializeField] private GameObject _harpoonPrefab_2;
    [SerializeField] private GameObject _harpoonPrefab_3;

    [SerializeField] private GameObject _mortarPrefab_1;
    [SerializeField] private GameObject _mortarPrefab_2;
    [SerializeField] private GameObject _mortarPrefab_3;

    [SerializeField] private GameObject _rocketLauncherPrefab_1;
    [SerializeField] private GameObject _rocketLauncherPrefab_2;
    [SerializeField] private GameObject _rocketLauncherPrefab_3;

    [SerializeField] private GameObject _flamethrowerPrefab_1;
    [SerializeField] private GameObject _flamethrowerPrefab_2;
    [SerializeField] private GameObject _flamethrowerPrefab_3;

    [SerializeField] private GameObject _gaussGunPrefab_1;
    [SerializeField] private GameObject _gaussGunPrefab_2;
    [SerializeField] private GameObject _gaussGunPrefab_3;

    [SerializeField] private GameObject _EMPCannonPrefab_1;
    [SerializeField] private GameObject _EMPCannonPrefab_2;
    [SerializeField] private GameObject _EMPCannonPrefab_3;

    [SerializeField] private GameObject _fridgePrefab;
    [SerializeField] private GameObject _machineGunDepotPrefab;

    private Dictionary<int, GameObject> _towersTable = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> TowersTable => _towersTable;

    private void OnEnable()
    {
        _towersTable.Add(IdMashineGun_1,
            _mashineGunPrefab_1);

        _towersTable.Add(IdMashineGun_2,
             _mashineGunPrefab_2);

        _towersTable.Add(IdMashineGun_3,
             _mashineGunPrefab_3);

        _towersTable.Add(IdShotgun_1,
             _shotgunPrefab_1);

        _towersTable.Add(IdShotgun_2,
             _shotgunPrefab_2);

        _towersTable.Add(IdShotgun_3,
             _shotgunPrefab_3);

        _towersTable.Add(IdHarpoon_1,
             _harpoonPrefab_1);

        _towersTable.Add(IdHarpoon_2,
             _harpoonPrefab_2);

        _towersTable.Add(IdHarpoon_3,
             _harpoonPrefab_3);

        _towersTable.Add(IdMortar_1,
             _mortarPrefab_1);

        _towersTable.Add(IdMortar_2,
             _mortarPrefab_2);

        _towersTable.Add(IdMortar_3,
            _mortarPrefab_3);

        _towersTable.Add(IdRocketLauncher_1,
            _rocketLauncherPrefab_1);

        _towersTable.Add(IdRocketLauncher_2,
             _rocketLauncherPrefab_2);

        _towersTable.Add(IdRocketLauncher_3,
            _rocketLauncherPrefab_3);

        _towersTable.Add(IdFlamethrower_1,
           _flamethrowerPrefab_1);

        _towersTable.Add(IdFlamethrower_2,
             _flamethrowerPrefab_2);

        _towersTable.Add(IdFlamethrower_3,
            _flamethrowerPrefab_3);

        _towersTable.Add(IdGaussGun_1,
             _gaussGunPrefab_1);

        _towersTable.Add(IdGaussGun_2,
             _gaussGunPrefab_2);

        _towersTable.Add(IdGaussGun_3,
            _gaussGunPrefab_3);

        _towersTable.Add(IdEMPCannon_1,
            _EMPCannonPrefab_1);

        _towersTable.Add(IdEMPCannon_2,
             _EMPCannonPrefab_2);

        _towersTable.Add(IdEMPCannon_3,
            _EMPCannonPrefab_3);

        _towersTable.Add(IdFridge,
            _fridgePrefab);

        _towersTable.Add(IdMachineGunDepot,
             _machineGunDepotPrefab);
    }
}

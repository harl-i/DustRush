using RoadTrane;
using System.Collections.Generic;
using UnityEngine;

public class TowersHashTable : MonoBehaviour
{
    private const int IdMashineGun_1 = 11;
    private const int IdMashineGun_2 = 12;
    private const int IdMashineGun_3 = 13;

    private const int IdShotgun_1 = 21;
    private const int IdShotgun_2 = 22;
    private const int IdShotgun_3 = 23;

    private const int IdHarpoon_1 = 31;
    private const int IdHarpoon_2 = 32;
    private const int IdHarpoon_3 = 33;

    private const int IdMortar_1 = 41;
    private const int IdMortar_2 = 42;
    private const int IdMortar_3 = 43;

    private const int IdRocketLauncher_1 = 51;
    private const int IdRocketLauncher_2 = 52;
    private const int IdRocketLauncher_3 = 53;

    private const int IdFlamethrower_1 = 61;
    private const int IdFlamethrower_2 = 62;
    private const int IdFlamethrower_3 = 63;

    private const int IdGaussGun_1 = 71;
    private const int IdGaussGun_2 = 72;
    private const int IdGaussGun_3 = 73;

    private const int IdEMPCannon_1 = 81;
    private const int IdEMPCannon_2 = 82;
    private const int IdEMPCannon_3 = 83;

    private const int IdFridge = 91;
    private const int IdMachineGunDepot = 92;

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

    private void InitId()
    {
        foreach (var item in _towersTable)
        {
            var towers = item.Value.GetComponent<Tower>();

            towers.SetID(item.Key);
        }
    }
}

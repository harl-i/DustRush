using RoadTrane;
using System.Collections.Generic;
using UnityEngine;

public class TowersHashTable : MonoBehaviour
{
    private const int IdMashineGun_1 = 1;
    [SerializeField] private GameObject _mashineGunPrefab_1;

    private const int IdMashineGun_2 = 2;
    [SerializeField] private GameObject _mashineGunPrefab_2;

    private Dictionary<int, GameObject> _towersTable = new Dictionary<int, GameObject>();

    public Dictionary<int, GameObject>  TowersTable => _towersTable;

    private void OnEnable()
    {
        _towersTable.Add(IdMashineGun_1,
            _mashineGunPrefab_1);

        _towersTable.Add(IdMashineGun_2,
             _mashineGunPrefab_2);
    }
}

using RoadTrane;
using System.Collections.Generic;
using UnityEngine;

public class TowersHashTable : MonoBehaviour
{
    private const int IdMashineGun_1 = 1;
    private const int MashineGunDamage_1 = 10;
    private const int MashineGunRange_1 = 15;
    private const int MashineGunMaxHealth_1 = 50;

    private const int IdMashineGun_2 = 2;
    private const int MashineGunDamage_2 = 12;
    private const int MashineGunRange_2 = 17;
    private const int MashineGunmaxHealth_2 = 55;

    [SerializeField] private Sprite MashineGunSprite_1;
    [SerializeField] private Sprite MashineGunSprite_2;

    public Dictionary<int, Tower> TowersTable { get; private set; }

    private void OnEnable()
    {
        TowersTable = new Dictionary<int, Tower>();

        TowersTable.Add(IdMashineGun_1,
            new Tower("MashineGun1",
            MashineGunDamage_1,
            MashineGunRange_1,
            MashineGunMaxHealth_1,
            MashineGunSprite_1));

        TowersTable.Add(IdMashineGun_2,
            new Tower("MashineGun1",
            MashineGunDamage_2,
            MashineGunRange_2,
            MashineGunmaxHealth_2,
            MashineGunSprite_1));
    }
}

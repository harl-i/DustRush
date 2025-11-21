using System.Collections.Generic;
using UnityEngine;
using YG;

public class FirstTrain : MonoBehaviour
{
    private List<int> _firstWagon = new List<int>();
    private List<int> _firstWeapon = new List<int>();

    private void OnEnable()
    {
        //  if (YG2.isFirstGameSession)
        //   {
        _firstWeapon.Add(0111);
        _firstWeapon.Add(0051);
        _firstWeapon.Add(0222);
        _firstWeapon.Add(0332);
        _firstWeapon.Add(0441);
        _firstWeapon.Add(0532);
        _firstWeapon.Add(0651);
        _firstWeapon.Add(0742);
        _firstWeapon.Add(1552);
        _firstWeapon.Add(1191);
        _firstWeapon.Add(2272);
        _firstWeapon.Add(2392);
        _firstWeapon.Add(3261);
        _firstWeapon.Add(3183);

        _firstWagon.Add(12);
        _firstWagon.Add(11);
        _firstWagon.Add(10);
        _firstWagon.Add(10);

        _firstWagon.Add(25);
        _firstWagon.Add(31);
        _firstWagon.Add(35);
        _firstWagon.Add(41);

        YG2.saves.SavedWagons = _firstWagon;
        YG2.saves.SavedTowers = _firstWeapon;
        //   }
    }
}
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
        _firstWeapon.Add(0412);
        _firstWeapon.Add(1212);
        _firstWeapon.Add(1311);

        _firstWagon.Add(10);
        _firstWagon.Add(15);

        YG2.saves.SavedWagons = _firstWagon;
        YG2.saves.SavedTowers = _firstWeapon;
        //   }
    }
}
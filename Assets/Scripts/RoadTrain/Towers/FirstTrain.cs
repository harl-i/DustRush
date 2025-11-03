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
        _firstWeapon.Add(1);
        _firstWeapon.Add(2);

        _firstWagon.Add(11);
        _firstWagon.Add(15);

        YG2.saves.SavedWagons = _firstWagon;
        YG2.saves.SavedTowers = _firstWeapon;
        //   }
    }
}
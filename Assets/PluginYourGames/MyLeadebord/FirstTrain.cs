using System.Collections.Generic;
using UnityEngine;
using YG;

public class FirstTrain : MonoBehaviour
{
    private List<int> _firstWagon = new List<int>();
    private List<int> _firstWeapon = new List<int>();

    private void Start()
    {
        if (YG2.saves.IsFirstTraneBuld == false)
        {
            _firstWeapon.Add(0111);
            _firstWeapon.Add(0012);
            _firstWeapon.Add(0213);
            _firstWeapon.Add(0314);
            _firstWeapon.Add(0415);
            _firstWeapon.Add(0516);
            _firstWeapon.Add(0617);
            _firstWeapon.Add(0718);
            _firstWeapon.Add(1519);
            _firstWeapon.Add(1120);
            _firstWeapon.Add(2221);
            _firstWeapon.Add(2322);
            _firstWeapon.Add(3223);
            _firstWeapon.Add(3124);

            _firstWagon.Add(39);
            _firstWagon.Add(38);
            _firstWagon.Add(37);
            _firstWagon.Add(39);

            //     _firstWagon.Add(40);
            //     _firstWagon.Add(45);
            //     _firstWagon.Add(49);
            //     _firstWagon.Add(52);

            YG2.saves.SavedWagons = _firstWagon;
            YG2.saves.SavedTowers = _firstWeapon;
            YG2.saves.IsFirstTraneBuld = true;
            YG2.SaveProgress();
        }
    }
}
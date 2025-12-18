using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

namespace Common
{
    public class HashTableLocation : MonoBehaviour
    {
        private const string Lesson = "Lesson";
        private const string FirstSity = "FirstSity";
        private const string FirstPathOnFirstSity = "FirstPathOnFirstSity";
        private const string SecondPathOnFirstSity = "SecondPathOnFirstSity";
        private const string SecondSity = "SecondSity";
        private const string SecondSityPath1 = "SecondSityPath1";
        private const string SecondSityPath2 = "SecondSityPath2";
        private const string ThirdSity = "ThirdSity";

        private const int Level1 = 1;
        private const int Level2 = 2;
        private const int Level3 = 3;

        private Dictionary<string, int> _levelsForNames = new Dictionary<string, int>();
        private Dictionary<string, bool> _locationIsSity = new Dictionary<string, bool>();

        public Dictionary<string, int> LevelsForNames => _levelsForNames;
        public Dictionary<string, bool> LocationIsSity => _locationIsSity;

        private void OnEnable()
        {
            _levelsForNames.Add(Lesson, Level1);
            _levelsForNames.Add(FirstSity, Level1);
            _levelsForNames.Add(FirstPathOnFirstSity, Level1);
            _levelsForNames.Add(SecondPathOnFirstSity, Level2);
            _levelsForNames.Add(SecondSity, Level2);
            _levelsForNames.Add(SecondSityPath1, Level2);
            _levelsForNames.Add(SecondSityPath2, Level3);
            _levelsForNames.Add(ThirdSity, Level3);

            _locationIsSity.Add(Lesson, false);
            _locationIsSity.Add(FirstSity, true);
            _locationIsSity.Add(FirstPathOnFirstSity, false);
            _locationIsSity.Add(SecondPathOnFirstSity, false);
            _locationIsSity.Add(SecondSity, true);
            _locationIsSity.Add(SecondSityPath1, false);
            _locationIsSity.Add(SecondSityPath2, false);
            _locationIsSity.Add(ThirdSity, true);
        }

        private void OnDisable()
        {
            _levelsForNames = new Dictionary<string, int>();
        }
    }
}
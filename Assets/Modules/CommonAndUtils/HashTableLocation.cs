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

        private const int Level1 = 1;
        private const int Level2 = 2;
        private const int Level3 = 3;

        private Dictionary<string, int> _levelsForNames = new Dictionary<string, int>();

        public Dictionary<string, int> LevelsForNames => _levelsForNames;

        private void OnEnable()
        {
            _levelsForNames.Add(Lesson, Level1);
            _levelsForNames.Add(FirstSity, Level1);
            _levelsForNames.Add(FirstPathOnFirstSity, Level1);
            _levelsForNames.Add(SecondPathOnFirstSity, Level2);
            _levelsForNames.Add(SecondSity, Level2);
        }

        private void OnDisable()
        {
            _levelsForNames = new Dictionary<string, int>();
        }
    }
}
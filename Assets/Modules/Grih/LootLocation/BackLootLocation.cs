using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class BackLootLocation : MonoBehaviour
    {
        public const string Town = "FirstSity";
        public const string Town2 = "SecondSity";
        public const int OffsetRandomCount = 1;

        [SerializeField] private Sprite _scrapyard1;
        [SerializeField] private Sprite _scrapyard2;
        [SerializeField] private Sprite _scrapyard3;
        [SerializeField] private Sprite _scrapyard4;

        [SerializeField] private Sprite _storage1;
        [SerializeField] private Sprite _storage2;

        [SerializeField] private SpriteRenderer _renderer;

        private List<Sprite> _townLocation = new List<Sprite>();
        private List<Sprite> _storageLocation = new List<Sprite>();
        private string _currentLevel;

        public void Init(string levelName)
        {
            _townLocation.Add(_scrapyard1);
            _townLocation.Add(_scrapyard2);
            _townLocation.Add(_scrapyard3);
            _townLocation.Add(_scrapyard4);

            _storageLocation.Add(_storage1);
            _storageLocation.Add(_storage2);

            _currentLevel = levelName;

            if (_currentLevel == Town || _currentLevel == Town2)
            {
                _renderer.sprite = _townLocation[Random.Range(0, _townLocation.Count)];
            }
            else
            {
                _renderer.sprite = _storageLocation[Random.Range(0, _storageLocation.Count)];
            }
        }
    }
}
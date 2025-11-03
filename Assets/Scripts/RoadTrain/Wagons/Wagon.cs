using System.Collections.Generic;
using UnityEngine;
using YG;

namespace RoadTrane
{
    public class Wagon : MonoBehaviour
    {
        public enum Type
        {
            Regular,
            Spesial
        }

        [SerializeField] private List<Transform> _pointWeapons;
        private List<Tower> _savedTowers;

        public Wagon(string name, Type typeVagon, Sprite sprite)
        {
            Name = name;
            TypeVagon = typeVagon;
            Sprite = sprite;
        }

        public string Name { get; private set; }
        public Type TypeVagon { get; private set; }
        public int NumberOrder { get; private set; }
        public Sprite Sprite { get; private set; }
        public List<Transform> PointWeapons => _pointWeapons;

        private void OnEnable()
        {
        }

        private void SetTower()
        {
        }
    }
}
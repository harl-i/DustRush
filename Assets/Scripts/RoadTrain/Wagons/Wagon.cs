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

        [SerializeField] private List<UnityEngine.Transform> _pointWeapons;

        [SerializeField] private Transform _front—ouplingPosition;
        [SerializeField] private Transform _backCouplingPosition;

        private List<Tower> _savedTowers;
        private Dictionary<int, Transform> _pointNamed = new();

        //public Wagon(string name, Type typeVagon, Sprite sprite)
        //{
        //    Name = name;
        //    TypeVagon = typeVagon;
        //    Sprite = sprite;
        //}

        [SerializeField] private string Name;
        [SerializeField] private Type TypeVagon;

        public Transform BackCouplingPosition => _backCouplingPosition;
        public Transform FrontCouplingPosition => _front—ouplingPosition;
        public Dictionary<int, Transform> PointNamed => _pointNamed;

        private void OnEnable()
        {
            if (TypeVagon != Type.Spesial)
            {
                for (int i = 0; i < _pointWeapons.Count; i++)
                {
                    _pointNamed.Add(i, _pointWeapons[i]);
                }
            }
        }

        public void MoveAround(Vector2 target)
        {
            _front—ouplingPosition.transform.position = target;
        }
    }
}
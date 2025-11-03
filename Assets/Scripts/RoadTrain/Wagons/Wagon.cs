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

        [SerializeField] private List<UnityEngine.Transform> _pointsTower;
        [SerializeField] private Transform _front—ouplingPosition;
        [SerializeField] private Transform _backCouplingPosition;

        private List<Tower> _savedTowers;
        private Dictionary<int, Transform> _pointNamed = new Dictionary<int, Transform>();

        [SerializeField] private string Name;
        [SerializeField] private Type TypeVagon;

        public Transform BackCouplingPosition => _backCouplingPosition;
        public Transform FrontCouplingPosition => _front—ouplingPosition;
        public Dictionary<int, Transform> PointNamed => _pointNamed;

        public int IdWagon { get; private set; }    

        private void OnEnable()
        {
            if (TypeVagon != Type.Spesial)
            {
                for (int i = 0; i < _pointsTower.Count; i++)
                {
                    _pointNamed.Add(i, _pointsTower[i]);
                }
            }
        }

        public Vector2 GetPointTower(int key)
        {
            return _pointNamed[key].position;
        }

        public void SetID(int key)
        {
            IdWagon = key;
        }
    }
}
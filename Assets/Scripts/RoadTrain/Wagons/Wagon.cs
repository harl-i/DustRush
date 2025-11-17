using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class Wagon : MonoBehaviour
    {
        public enum Type
        {
            Regular,
            Spesial
        }

        [SerializeField] private List<Transform> _pointsTower = new List<Transform>();
        [SerializeField] private Transform _front—ouplingPosition;
        [SerializeField] private Transform _backCouplingPosition;

        [SerializeField] private string Name;
        [SerializeField] private Type TypeWagon;

        public Transform BackCouplingPosition => _backCouplingPosition;
        public Transform FrontCouplingPosition => _front—ouplingPosition;

        public int IdWagon { get; private set; }

        public Transform GetPointTower(int key)
        {
            return _pointsTower[key];
        }

        public void SetID(int key)
        {
            IdWagon = key;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class Wagon : TranePart
    {
        private const float SeparateSpeed = -0.006f;

        public enum Type
        {
            Regular,
            Spesial
        }

        [SerializeField] private List<Transform> _pointsTower = new List<Transform>();
        [SerializeField] private Transform _frontÑouplingPosition;
        [SerializeField] private Transform _backCouplingPosition;

        [SerializeField] private string Name;
        [SerializeField] private Type TypeWagon;

        private Vector3 SeparateFinalPosition = new Vector3(0, -30f, 0);
        private Coroutine _separating = null;

        public Transform BackCouplingPosition => _backCouplingPosition;

        public Transform FrontCouplingPosition => _frontÑouplingPosition;

        public bool IsSepareted { get; private set; } = false;

        public int IdWagon { get; private set; }

        public Transform GetPointTower(int key)
        {
            return _pointsTower[key];
        }

        public void SetID(int key)
        {
            IdWagon = key;
        }

        public override void OnEnabled()
        {
        }

        private void OnDisable()
        {
            _separating = null;
        }

        public void Separate()
        {
            if (_separating == null && IsSepareted == false)
            {
                IsSepareted = true;
                StopVibration();
                _separating = StartCoroutine(Separating());
            }
        }

        private IEnumerator Separating()
        {
            while (transform.position.y >= SeparateFinalPosition.y)
            {
                transform.Translate(0, SeparateSpeed, 0);
                yield return null;
            }

            _separating = null;
            gameObject.SetActive(false);
        }
    }
}
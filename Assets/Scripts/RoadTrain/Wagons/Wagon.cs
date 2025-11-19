using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoadTrane
{
    public class Wagon : TranePart
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

        private Environment.GroundMover _groundMover;

        private Vector3 SeparateFinalPosition = new Vector3(0, -30f, 0);
        private Coroutine _separating = null;
        private float _separateSpeed;

        public Transform BackCouplingPosition => _backCouplingPosition;

        public Transform FrontCouplingPosition => _front—ouplingPosition;

        public bool IsSepareted { get; private set; } = false;

        public int IdWagon { get; private set; }

        private void OnDisable()
        {
            _separating = null;
            _groundMover.SpeedChanged -= OnSpeedShange;
        }

        public override void OnEnabled()
        {
        }

        public void Init(Environment.GroundMover groundMover)
        {
            _groundMover = groundMover;
            _separateSpeed = _groundMover.CurrentSpeed;
            _groundMover.SpeedChanged += OnSpeedShange;
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

        public Transform GetPointTower(int key)
        {
            return _pointsTower[key];
        }

        public void SetID(int key)
        {
            IdWagon = key;
        }

        private void OnSpeedShange(float value)
        {
            _separateSpeed = value;

            if (IsSepareted == false)
                return;

            _separating = null;
            _separating = StartCoroutine(Separating());
        }


        private IEnumerator Separating()
        {
            if (transform.position.y <= SeparateFinalPosition.y)
            {
                _separating = null;
                gameObject.SetActive(false);
            }

            while (transform.position.y >= SeparateFinalPosition.y)
            {
                transform.Translate(0, _separateSpeed, 0);
                yield return null;
            }

            _separating = null;
            gameObject.SetActive(false);
        }
    }
}
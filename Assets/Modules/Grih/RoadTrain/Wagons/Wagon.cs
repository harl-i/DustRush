using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Grih.RoadTrane
{
    public class Wagon : TranePart
    {
        public enum Type
        {
            Regular,
            Spesial,
        }

        [SerializeField] private List<Transform> _pointsTower = new List<Transform>();
        [SerializeField] private Transform _front—ouplingPosition;
        [SerializeField] private Transform _backCouplingPosition;

        [SerializeField] private string _name;
        [SerializeField] private Type _typeWagon;

        private Environment.GroundMover _groundMover;

        private Vector3 _separateFinalPosition = new Vector3(0, -30f, 0);
        private Coroutine _separating = null;
        private float _separateSpeed;

        public Type TypeWagon => _typeWagon;

        public List<Transform> PointsTower => _pointsTower;

        public Transform BackCouplingPosition => _backCouplingPosition;

        public Transform FrontCouplingPosition => _front—ouplingPosition;

        public bool IsSepareted { get; private set; } = false;

        public int IdWagon { get; private set; }

        private void OnDisable()
        {
            _separating = null;

            if (SceneManager.GetActiveScene().name == "Sity")
                return;

            _groundMover.SpeedChanged -= OnSpeedShange;
        }

        public override void OnEnabled()
        {
        }

        public void Init(Environment.GroundMover groundMover)
        {
            _groundMover = groundMover;

            if (SceneManager.GetActiveScene().name == "Sity")
                return;

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
            if (transform.position.y <= _separateFinalPosition.y)
            {
                _separating = null;
                gameObject.SetActive(false);
            }

            while (transform.position.y >= _separateFinalPosition.y)
            {
                transform.Translate(0, _separateSpeed, 0);
                yield return null;
            }

            _separating = null;
            gameObject.SetActive(false);
        }
    }
}
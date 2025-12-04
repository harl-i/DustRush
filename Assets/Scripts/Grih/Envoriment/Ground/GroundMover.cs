using System;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Environment
{
    public class GroundMover : MonoBehaviour
    {
        [Header("Position")]
        [SerializeField] private float _downPositionY;
        [SerializeField] private float _startPositionY;

        [Header("Speed")]
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _fullSpeed;
        [SerializeField] private float _eachSecondAcceleration;

        [Header("SpritesBackgounds")]
        [SerializeField] private Transform _backgroundImage;

        private WaitForSeconds _waitFullSpeed;

        private WaitForSeconds _waitPlayBoost;
        private float _boostDelayValue = 5f;
        private Coroutine _boostingSpeed = null;

        public float CurrentSpeed { get; private set; }

        public event Action<float> SpeedChanged;

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == "Sity")
                return;

            _waitFullSpeed = new WaitForSeconds(_eachSecondAcceleration);
            _waitPlayBoost = new WaitForSeconds(_boostDelayValue);
            StartMoving();
        }

        public void BoostSpeed(float speedBoost)
        {
            if (_boostingSpeed == null)
                _boostingSpeed = StartCoroutine(Boost(speedBoost));
        }

        private void StartMoving()
        {
            if (SceneManager.GetActiveScene().name == "Sity")
                return;

            StartCoroutine(Acceleration());
            StartCoroutine(Moving());
        }

        private IEnumerator Acceleration()
        {
            CurrentSpeed = _startSpeed;

            yield return _waitFullSpeed;

            CurrentSpeed = _fullSpeed;
        }

        private void MovingUp()
        {
            if (SceneManager.GetActiveScene().name == "Sity")
                return;

            Vector2 targetUp = new Vector2(_backgroundImage.position.x, (_startPositionY - CurrentSpeed));

            _backgroundImage.transform.position = targetUp;
            StartCoroutine(Moving());
        }

        private IEnumerator Moving()
        {
            Vector2 target = new Vector2(_backgroundImage.position.x, _downPositionY);

            while (_backgroundImage.position.y > target.y)
            {
                _backgroundImage.transform.Translate(0, CurrentSpeed, 0);

                yield return null;
            }

            MovingUp();
        }

        private IEnumerator Boost(float speedBoost)
        {
            float currentSpeed = _fullSpeed + speedBoost;
            CurrentSpeed = currentSpeed;

            SpeedChanged?.Invoke(CurrentSpeed);
            yield return _waitPlayBoost;

            CurrentSpeed = _fullSpeed;
            SpeedChanged?.Invoke(CurrentSpeed);
            _boostingSpeed = null;
        }
    }
}
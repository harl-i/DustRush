using System;
using System.Collections;
using UnityEngine;


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
        [SerializeField] private float _eachSecondFullSpeed;

        [Header("SpritesBackgounds")]
        [SerializeField] private Transform _backgroundImage;

        private float _currentSpeed;
        private WaitForSeconds _waitFullSpeed;

        private void OnEnable()
        {
            _waitFullSpeed = new WaitForSeconds(_eachSecondFullSpeed);
            StartMovie();
        }

        private void StartMovie()
        {
            StartCoroutine(SetSpeed());
            StartCoroutine(Moving());
        }

        private IEnumerator SetSpeed()
        {
            _currentSpeed = _startSpeed;

            yield return _waitFullSpeed;

            _currentSpeed = _fullSpeed;

        }

        private IEnumerator Moving()
        {
            Vector2 target = new Vector2(_backgroundImage.position.x, _downPositionY);

            while (_backgroundImage.position.y > target.y)
            {
                _backgroundImage.transform.Translate(0, _currentSpeed, 0);

                yield return null;
            }

            MovingUp();
        }

        private void MovingUp()
        {
            Vector2 targetUp = new Vector2(_backgroundImage.position.x, (_startPositionY - _currentSpeed));

            _backgroundImage.transform.position = targetUp;
            StartCoroutine(Moving());
        }
    }
}
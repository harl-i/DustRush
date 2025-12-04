using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoadTrane
{
    public abstract class TranePart : MonoBehaviour
    {
        private const float MaxDelay = 3f;
        private const float MinDelay = 1f;
        private const int RandomLimit = 2;

        private const float MinDirectionVibration = -0.15f;
        private const float MaxDirectionVibration = 0.15f;

        private float _randomStartDelayValue;
        private float _randomDirectionValue;
        private float _reternValue = 0.2f;

        private WaitForSeconds _waitVibration;
        private WaitForSeconds _waitReternVibration;

        private bool _isActive = true;

        private void OnEnable()
        {
            _waitReternVibration = new WaitForSeconds(_reternValue);
            OnEnabled();

            if (SceneManager.GetActiveScene().name == "Sity")
                return;

            Vibration();
        }

        public abstract void OnEnabled();

        public void StopVibration()
        {
            _isActive = false;
        }

        private void Vibration()
        {
            if (_isActive == false)
            {
                return;
            }

            _randomStartDelayValue = Random.Range(MinDelay, MaxDelay);
            _waitVibration = new WaitForSeconds(_randomStartDelayValue);

            StartCoroutine(Virationing());
        }

        private IEnumerator Virationing()
        {
            float randomDirection;

            randomDirection = Random.Range(MinDirectionVibration, MaxDirectionVibration);

            yield return _waitVibration;

            transform.position = new Vector2(
                randomDirection,
                transform.position.y);

            yield return _waitReternVibration;

            transform.position = new Vector2(
                0,
                transform.position.y);

            if (Random.Range(0, RandomLimit) == 0)
            {
                transform.position = new Vector2(
                0,
                transform.position.y + randomDirection);

                yield return _waitReternVibration;

                transform.position = new Vector2(
                0,
                transform.position.y - randomDirection);
            }

            Vibration();
        }
    }
}
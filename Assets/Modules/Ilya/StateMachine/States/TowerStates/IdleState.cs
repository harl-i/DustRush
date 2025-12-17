using UnityEngine;

namespace StateMachine
{
    public class IdleState : State 
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _rotationSpeed;
        
        private bool _isLeft;
        private float _startAngle;
        private float _rightStartAngle = 270f;
        private float _leftStartAngle = -270f;

        private void OnEnable()
        {
            SetSide();
        }

        private void SetSide()
        {
            if (transform.position.x < 0)
            {
                _isLeft = true;
            }
            else
            {
                _isLeft = false;
            }

            if (_isLeft)
            {
                _startAngle = _leftStartAngle;
            }
            else
            {
                _startAngle = _rightStartAngle;
            }
        }

        private void Update()
        {
            float currentAngle = _barrel.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, _startAngle, _rotationSpeed * Time.deltaTime);

            _barrel.rotation = Quaternion.Euler(0f, 0f, newAngle);
        }
    }
}
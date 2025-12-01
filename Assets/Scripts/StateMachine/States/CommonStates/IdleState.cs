using UnityEngine;

namespace StateMachine
{
    public class IdleState : State {

        [SerializeField] private Transform _barrel;
        [SerializeField] private float _rotationSpeed;

        private float _startAngle = 270f;

        private void Update()
        {
            float currentAngle = _barrel.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, _startAngle, _rotationSpeed * Time.deltaTime);

            _barrel.rotation = Quaternion.Euler(0f, 0f, newAngle);
        }
    }
}
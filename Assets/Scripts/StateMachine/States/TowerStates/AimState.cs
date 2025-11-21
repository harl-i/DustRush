using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class AimState : State
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _rotationSpeed = 180f;
        [SerializeField] private float _angleOffset = 0f;

        private Transform _target;

        private void OnEnable()
        {
            _target = Enemy;
        }

        private void Update()
        {
            if (_target == null) return;

            Vector3 direction = _target.position - _barrel.position;

            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetAngle += _angleOffset;

            float currentAngle = _barrel.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, _rotationSpeed * Time.deltaTime);

            _barrel.rotation = Quaternion.Euler(0f, 0f, newAngle);
        }
    }
}
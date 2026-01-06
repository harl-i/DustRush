using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class AimEndTransition : Transition
    {
        [SerializeField] private Transform _turretBarrelTransform;
        [SerializeField] private float _minAngelToShoot;

        private Vector2 _directionToTarget;

        private void Update()
        {
            _directionToTarget = (_turretBarrelTransform.position - Target.position).normalized;
            float angle = Mathf.Abs(Vector2.SignedAngle(-_turretBarrelTransform.up, _directionToTarget));

            Debug.Log($"{gameObject} = {angle} < {_minAngelToShoot}");
            if (angle < _minAngelToShoot)
            {
                NeedTransit = true;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class AimEndTransition : Transition
    {
        [SerializeField] private Transform _turretBarrelTransform;

        private Vector2 _directionToTarget;
        private float _minAngelToShoot = 2f;

        private void Update()
        {
            _directionToTarget = (_turretBarrelTransform.position - Target.position).normalized;
            float angle = Mathf.Abs(Vector2.SignedAngle(-_turretBarrelTransform.up, _directionToTarget));
            Debug.Log(angle);

            if (angle < _minAngelToShoot)
            {
                NeedTransit = true;
            }
        }
    }
}
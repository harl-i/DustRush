using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class AimLostTransition : Transition
    {
        [SerializeField] private Transform _turretBarrelTransform;
        [SerializeField] private float _maxAngleToKeepShooting;

        private void Update()
        {
            if (Target == null) return;

            Vector2 directionToTarget =
                (Target.position - _turretBarrelTransform.position).normalized;

            float angle = Mathf.Abs(
                Vector2.SignedAngle(-_turretBarrelTransform.up, directionToTarget)
            );

            if (angle > _maxAngleToKeepShooting)
            {
                NeedTransit = true;
            }
        }
    }
}
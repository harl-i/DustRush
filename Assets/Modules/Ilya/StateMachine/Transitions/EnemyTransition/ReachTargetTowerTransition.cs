using Modules.Grih.RoadTrane;
using UnityEngine;

namespace StateMachine
{
    public class ReachTargetTowerTransition : Transition
    {
        [SerializeField] private float _triggerDistance = 2.5f;
        [SerializeField] private TakingPositionForAttackState _takingPositionForAttackState;

        private Tower _targetTower;

        public void OnEnable()
        {
            NeedTransit = false;

            _targetTower = _takingPositionForAttackState.TargetTower;
        }

        private void Update()
        {
            if (_targetTower == null)
                return;

            float sqrDistance = (_targetTower.transform.position - transform.position).sqrMagnitude;

            if (sqrDistance <= _triggerDistance * _triggerDistance)
            {
                TargetState.SetEnemyTransform(_targetTower.transform);
                NeedTransit = true;
            }
        }
    }
}
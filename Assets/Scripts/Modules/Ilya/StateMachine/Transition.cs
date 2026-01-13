using UnityEngine;

namespace StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] protected State TargetState;

        public State TargetStateProperty => TargetState;
        public bool NeedTransit { get; protected set; }
        public Transform Target { get; private set; }

        private void OnEnable() => NeedTransit = false;

        public void SetTarget(Transform target)
        {
            Target = target;
            TargetState.SetEnemyTransform(target);
        }
    }
}

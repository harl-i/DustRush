using UnityEngine;
using EnemyGroup;

namespace StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class TakingPositionForAttackState : State
    {
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            TestDebug();
        }

        private void TestDebug()
        {
            var targets = _enemy.GetTargets();

            if (targets.Count == 0)
            {
                Debug.Log("No towers to attack");
                return;
            }

            foreach (var tower in targets)
                Debug.Log(tower);
        }
    }
}
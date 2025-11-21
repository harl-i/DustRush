using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace StateMachine
{
    [ExecuteInEditMode]
    public class DetectTransition : Transition
    {
        [SerializeField] private float _detectionRadius = 5f;
        [SerializeField, Range(0f, 360f)] private float _viewAngle = 180f;
        [SerializeField] private float _detectReactionDelay;
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private bool _isCooldownActive;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _offsetX;

        private Transform _enemyTransform;

        private void Update()
        {
            DetectUsingCircle();
        }

        private void DetectUsingCircle()
        {
            Collider2D[] hits;

            hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _targetLayer);

            if (hits != null)
            {
                Vector2 forward = transform.right;

                foreach (var hit in hits)
                {
                    Vector2 toTarget = (hit.transform.position - transform.position).normalized;

                    float angle = Vector2.Angle(forward, toTarget);

                    if (angle <= _viewAngle)
                    {
                        SendPlayerTransform(hit.transform);
                        StartCoroutine(TransitAfterDelay(_detectReactionDelay));
                    }
                }
            }
        }

        private void SendPlayerTransform(Transform playerTransform)
        {
            _enemyTransform = playerTransform;
            TargetState.SetEnemyTransform(_enemyTransform);
        }

        private IEnumerator TransitAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            NeedTransit = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);

            Vector3 origin = transform.position;
            Vector3 forward = transform.right;

            float halfAngle = _viewAngle * 0.5f;

            Quaternion leftRot = Quaternion.Euler(0, 0, -halfAngle);
            Quaternion rightRot = Quaternion.Euler(0, 0, halfAngle);

            Vector3 leftDir = leftRot * forward;
            Vector3 rightDir = rightRot * forward;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(origin, origin + leftDir * _detectionRadius);
            Gizmos.DrawLine(origin, origin + rightDir * _detectionRadius);

#if UNITY_EDITOR
            Handles.color = new Color(1f, 0.92f, 0.016f, 0.15f); 
            Handles.DrawSolidArc(
                origin,
                Vector3.forward,         
                leftDir,                
                _viewAngle,              
                _detectionRadius         
            );
#endif
        }
    }
}
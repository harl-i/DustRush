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
        //[SerializeField] private float _detectReactionDelay = 0.1f;
        [SerializeField] private LayerMask _targetLayer;
        
        private bool _isLeft;
        private Vector2 _forward;
        private Coroutine _detectCoroutine;
        private Transform _enemyTransform;

        private void OnDisable()
        {
            NeedTransit = false;
            _detectCoroutine = null;
        }

        private void Update()
        {
            Detect();
        }

        private void Detect()
        {
            Collider2D[] hits =
                Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _targetLayer);

            if (hits.Length == 0) return;

            SetSide();

            float halfViewAngle = _viewAngle * 0.5f;

            foreach (var hit in hits)
            {
                Vector2 toTarget =
                    (hit.transform.position - transform.position).normalized;

                float angle = Vector2.Angle(_forward, toTarget);

                if (angle <= halfViewAngle)
                {
                    SendEnemyTransform(hit.transform);

                    if (_detectCoroutine == null)
                    {
                        _detectCoroutine = StartCoroutine(TransitAfterDelay(1f));
                    }

                    return;
                }
            }
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

            _forward = _isLeft ? -transform.right : transform.right;
        }

        private void SendEnemyTransform(Transform playerTransform)
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
            Vector3 forward = _isLeft ? -transform.right : transform.right;

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
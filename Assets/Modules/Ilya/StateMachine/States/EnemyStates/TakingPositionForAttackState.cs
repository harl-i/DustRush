using UnityEngine;
using EnemyGroup;
using Modules.Grih.RoadTrane;
using System.Linq;

namespace StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class TakingPositionForAttackState : State
    {
        [SerializeField] private float _distanceFromTower;
        [SerializeField] private Vector2 _areaSize = new Vector2(1.5f, 2f);
        [SerializeField] private float _moveSpeed;

        private Enemy _enemy;
        private Tower _targetTower;
        private Vector3 _targetPosition;

        public Tower TargetTower => _targetTower;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        public void OnEnable()
        {
            TrySelectTargetAndPosition();
        }

        private void Update()
        {
            MoveToPosition();
        }

        private void TrySelectTargetAndPosition()
        {
            var towers = _enemy.GetTargets();

            if (towers.Count == 0)
            {
                Debug.LogWarning("No towers available");
                return;
            }

            bool enemyIsLeft = _enemy.IsLeft;

            var matchingTowers = towers.Where(tower => tower.IsLeft == enemyIsLeft).ToList();

            if (matchingTowers.Count == 0)
            {
                Debug.LogWarning("No matching tower for enemy side");
                return;
            }

            int randomIndex = Random.Range(0, matchingTowers.Count);
            _targetTower = matchingTowers[randomIndex];

            _targetPosition = CalculateRandomPositionNearTower(_targetTower);
        }


        private Vector3 CalculateRandomPositionNearTower(Tower tower)
        {
            Vector3 towerPos = tower.transform.position;

            // Направление: влево или вправо от турели
            Vector3 sideDirection = tower.IsLeft ? Vector3.left : Vector3.right;

            // Центр области
            Vector3 areaCenter = towerPos + sideDirection * _distanceFromTower;

            // Случайное смещение внутри области
            float randomX = Random.Range(-_areaSize.x * 0.5f, _areaSize.x * 0.5f);
            float randomY = Random.Range(-_areaSize.y * 0.5f, _areaSize.y * 0.5f);

            return areaCenter + new Vector3(randomX, randomY, 0f);
        }

        private void MoveToPosition()
        {
            if (_targetTower == null)
                return;

            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetPosition,
                _moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            {
                OnReachedAttackPosition();
            }
        }

        private void OnReachedAttackPosition()
        {
            Debug.Log($"Enemy reached position near {_targetTower.name}");
        }

        private void OnDrawGizmos()
        {
            if (_targetTower == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPosition, 0.1f);
        }
    }
}
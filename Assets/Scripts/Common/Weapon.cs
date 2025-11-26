using Pool;
using UnityEngine;

namespace Common
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _prefabBullet;
        [SerializeField] private int _damage;
        [SerializeField] private bool _isPlayerBullet;
        [SerializeField] private Transform _shootPoint;

        private Pool<Bullet> _buletPool;
        private Transform _enemy;

        private void OnEnable()
        {
            _buletPool = new Pool<Bullet>(_prefabBullet);
        }

        public void SetEnemyTransform(Transform enemy)
        {
            _enemy = enemy;
        }

        public void Shoot()
        {
            Bullet bulet = _buletPool.GetItem().GetComponent<Bullet>();

            Vector3 direction = _enemy.position - _shootPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bulet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            bulet.Init(_shootPoint.position, _damage, this, _isPlayerBullet);
        }

        public void ReturnToPool(Bullet bullet)
        {
            _buletPool.ReturnItem(bullet);
        }
    }
}
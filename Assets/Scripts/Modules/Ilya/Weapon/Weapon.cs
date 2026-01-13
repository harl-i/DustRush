using Pool;
using UnityEngine;

namespace WeaponGroup
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
            OnShoot(_enemy.position);
        }

        public void Shoot(Vector2 target)
        {
            Vector3 targetVector3 = new Vector3(target.x, target.y, 0);
            OnShoot(targetVector3);
        }
        public void ReturnToPool(Bullet bullet)
        {
            _buletPool.ReturnItem(bullet);
        }

        private void OnShoot(Vector3 target)
        {
            Bullet bulet = _buletPool.GetItem().GetComponent<Bullet>();

            Vector3 direction = target - _shootPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bulet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            bulet.Init(_shootPoint.position, _damage, this, _isPlayerBullet);
        }
    }
}
using RoadTrane;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime = 1;

        private Weapon _bulletPool;
        private int _damage;
        private bool _isPlayerBullet;
        private Coroutine _shooting = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isPlayerBullet)
            {
                if (collision.TryGetComponent(out Enemy enemy))
                {
                    enemy.GetComponent<Health>().Damaged(_damage);
                }
            }
            else
            {
                if (collision.TryGetComponent(out Tower tower))
                {
                    tower.GetComponent<Health>().Damaged(_damage);
                }
            }
        }

        public void Init(Vector2 pointShoot, int damage, Weapon bulletPool, bool isPlayerBullet)
        {
            _bulletPool = bulletPool;
            gameObject.SetActive(true);
            _damage = damage;
            transform.position = pointShoot;
            _isPlayerBullet = isPlayerBullet;
            Shoot();
        }

        public void Deativate()
        {
            gameObject.SetActive(false);

            _bulletPool.Retern(this);
        }

        private void Shoot()
        {
            _shooting = StartCoroutine(Shooting());
        }

        private IEnumerator Shooting()
        {
            float time = 0;

            while (time < _lifeTime)
            {
                float step = _speed * Time.deltaTime;

                transform.Translate(transform.right * step, Space.World);
                time += Time.deltaTime;

                yield return null;
            }

            _shooting = null;

            if (gameObject.activeSelf)
                Deativate();
        }
    }
}


using System.Collections;
using UnityEngine;
using Common;

namespace WeaponGroup
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime = 1;
        
        private int _damage; //дамаг получается регулирутся турелью, ком2/да, удаляй шо не надо :)
        private Weapon _bulletPool;
        private bool _isPlayerBullet;
        private Coroutine _shooting = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isPlayerBullet)
            {
                if (collision.TryGetComponent(out Enemy enemy))
                {
                    enemy.GetComponent<Health>().Damaged(_damage);

                    // добавил что бы пуля отключалась и возвращалась в пул
                    Disable();
                }
            }
            else
            {
                if (collision.TryGetComponent(out Modules.Grih.RoadTrane.Tower tower))
                {
                    tower.GetComponent<Health>().Damaged(_damage);
                    Disable();
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

        public void Disable()
        {
            gameObject.SetActive(false);
            _bulletPool.ReturnToPool(this);
        }

        // Очень странно что пуля имеет компоненты Shoot и Shooting.
        // Получается что пуля почему то отвечает за выстрел и саму стрельбу в целом.
        // Для проведеняи выстрела есть класс Weapon который очень логично 
        // берет пулю и производит ей выстрел.
        // А за саму стрельбу, когда и сколько стрелять уже отвечает 
        // состояние стрельбы.

        // UPD: Разобрался, это не стрельба, а полет пули
        // названия методов Shoot и Shooting сбили с толку

        // UPD: Да, соглы, меняй названия как хош, тут умсетно Life думаю
        //типо жизнь пули

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
                Disable();
        }
    }
}

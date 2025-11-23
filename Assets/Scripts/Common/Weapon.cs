using Pool;
using UnityEngine;

namespace Common
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _prefabBullet;
        [SerializeField] private int _damage;
        [SerializeField] private bool _isPlayerBullet;

        private Pool<Bullet> _buletPool;

        private void OnEnable()
        {
            _buletPool = new Pool<Bullet>(_prefabBullet);
        }

        public void Shoot(Vector3 aimRotate)
        {
            Bullet bulet = _buletPool.GetItem().GetComponent<Bullet>();
            bulet.transform.rotation = Quaternion.Euler(aimRotate);
            bulet.Init(transform.position, _damage, this, _isPlayerBullet);
        }

        public void Retern(Bullet bullet)
        {
            _buletPool.ReturnItem(bullet);
        }
    }
}
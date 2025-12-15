using System;
using System.Collections;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class Player : MonoBehaviour
    {
        private const int DividerSpeed = 100;

        [SerializeField] private InputForLootLocation _input;
        [SerializeField] private WeaponGroup.Weapon _weapon;
        [SerializeField] private float _cooldownAfteShoot;
        [SerializeField] private GameObject _view;

        private Coroutine _shooting = null;
        private WaitForSeconds _wait;
        private bool _isMayShoot = true;

        private void OnEnable()
        {
            _wait = new WaitForSeconds(_cooldownAfteShoot);

            _input.Shoot += OnShoot;
            _input.Moved += OnMoved;
        }

        private void OnDisable()
        {
            _input.Shoot -= OnShoot;
            _input.Moved -= OnMoved;
        }

        private void OnMoved(Vector2 vector)
        {
            Vector2 newVector = new Vector2(
                transform.position.x, transform.position.y)
                + (vector / DividerSpeed);
            transform.position = newVector;
        }

        private void OnShoot(Vector2 vector)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            _view.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (_isMayShoot)
            {
                _isMayShoot = false;
                _weapon.Shoot(vector);
            }

            if (_shooting == null)
                _shooting = StartCoroutine(Shooting());

        }

        private IEnumerator Shooting()
        {
            yield return _wait;
            _isMayShoot = true;
            _shooting = null;
        }
    }
}
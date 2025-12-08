using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Починить доступ к Weapon 
namespace StateMachine
{
    //[RequireComponent(typeof(Weapon))]
    public class ShootState : State
    {
        [SerializeField] private float _shootDelay = 0.8f;

        private float _shootElapsedTime = 0f;
        //private Weapon _weapon;

        private void Awake()
        {
            //_weapon = GetComponent<Weapon>();
        }

        private void OnEnable()
        {
            //_weapon.SetEnemyTransform(Enemy);
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            _shootElapsedTime += Time.deltaTime;
            if (_shootElapsedTime >= _shootDelay)
            {
                //_weapon.Shoot();
                _shootElapsedTime = 0f;
            }
        }
    }
}
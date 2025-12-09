using System;
using UnityEngine;

namespace EnemyGroup
{
    [RequireComponent(typeof(Common.Health))]
    public class Enemy : MonoBehaviour
    {
        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public void OnSpawned()
        {
            throw new NotImplementedException();
        }
    }
}
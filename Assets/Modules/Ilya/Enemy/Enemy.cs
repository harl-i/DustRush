using System;
using UnityEngine;
using Modules.Grih.RoadTrane;
using System.Collections.Generic;

namespace EnemyGroup
{
    [RequireComponent(typeof(Common.Health))]
    public class Enemy : MonoBehaviour
    {
        private ITowerProvider _towerProvider;

        private List<Tower> _towers;
        private bool _isInitialized;

        public void Init(ITowerProvider towerProvider)
        {
            _towerProvider = towerProvider;
            _isInitialized = true;
        }

        public IReadOnlyList<Tower> GetTargets()
        {
            if (!_isInitialized)
                return Array.Empty<Tower>();

            return _towerProvider.GetAliveTowers();
        }

        public void ResetTowers()
        {
            //удалить если в дальнейшем не понадобится
        }

        private void Update()
        {
            transform.Translate(Vector3.up * 1f * Time.deltaTime);
        }
    }
}
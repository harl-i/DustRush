using System;
using UnityEngine;
using Modules.Grih.RoadTrain;
using System.Collections.Generic;

namespace EnemyGroup
{
    [RequireComponent(typeof(Common.Health))]
    public class Enemy : MonoBehaviour
    {
        private ITowerProvider _towerProvider;

        private bool _isInitialized;
        private bool _isLeft;

        public bool IsLeft => _isLeft;


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

        public void DefineSide()
        {
            if (transform.position.x < 0)
            {
                _isLeft = true;
            }
            else
            {
                _isLeft = false;
            }
        }
    }
}
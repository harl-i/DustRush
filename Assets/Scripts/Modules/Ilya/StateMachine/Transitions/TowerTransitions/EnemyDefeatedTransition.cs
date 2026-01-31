using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class EnemyDefeatedTransition : Transition
    {
        private void Update()
        {
            if (Target.gameObject.activeSelf == false)
            {
                NeedTransit = true;
            }
        }
    }
}
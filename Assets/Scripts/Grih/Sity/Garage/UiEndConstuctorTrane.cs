using System;
using UnityEngine;

namespace Sity
{

    [RequireComponent(typeof(Collider2D))]  

    public class UiEndConstuctorTrane : MonoBehaviour
    {
        [SerializeField] private ConstuctorTrane _constructor;

        public event Action ClickedEnd;

        private void OnMouseDown()
        {
            ClickedEnd?.Invoke();
        }
    }
}
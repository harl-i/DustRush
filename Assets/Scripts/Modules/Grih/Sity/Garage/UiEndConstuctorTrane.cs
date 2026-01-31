using System;
using UnityEngine;

namespace Modules.Grih.Sity
{

    [RequireComponent(typeof(Collider2D))]

    public class UiEndConstuctorTrane : MonoBehaviour
    {
        [SerializeField] private ConstuctorTrane _constructor;

        public event Action ClickedEnd;

        private void OnMouseDown()
        {
            Click();
        }

        public void Click()
        {
            ClickedEnd?.Invoke();
        }
    }
}
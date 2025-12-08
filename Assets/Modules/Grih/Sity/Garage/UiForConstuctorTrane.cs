using System;
using UnityEngine;

namespace Modules.Grih.Sity
{
    [RequireComponent(typeof(Collider2D))]
    public class UiForConstuctorTrane : MonoBehaviour
    {
        [SerializeField] private ConstuctorTrane _constructor;

        private int _id;

        public event Action <int> Clicked;

        private void OnMouseDown()
        {
            Clicked?.Invoke(_id);
        }

        public void Init(int idContent)
        {
            _id = idContent;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Grih.Sity
{
    [RequireComponent(typeof(Collider2D))]
    public class UiForConstuctorTrane : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ConstuctorTrane _constructor;

        private int _id;

        public event Action<int> Clicked;

        private void OnMouseDown()
        {
            Clicked?.Invoke(_id);
        }

        public void Init(int idContent)
        {
            _id = idContent;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(_id);
        }
    }
}
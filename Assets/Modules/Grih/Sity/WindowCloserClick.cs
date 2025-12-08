using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Grih.Sity
{
    public class WindowCloserClick : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _windowsForClose;

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                foreach (GameObject window in _windowsForClose)
                {
                    window.gameObject.SetActive(false);
                }
            }
        }
    }
}
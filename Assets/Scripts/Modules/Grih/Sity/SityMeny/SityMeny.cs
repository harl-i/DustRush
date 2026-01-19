using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class SityMeny : MonoBehaviour
    {
        [SerializeField] private List<SityWindowOpener> _menus;

        private void OnEnable()
        {
            foreach (SityWindowOpener window in _menus)
            {
                window.Pressed += OnPrees;
            }
        }

        private void OnDisable()
        {
            foreach (SityWindowOpener window in _menus)
            {
                window.Pressed -= OnPrees;
            }
        }

        private void OnPrees(bool change, SityWindowOpener currentWindow)
        {
            if (change)
            {
                foreach (SityWindowOpener window in _menus)
                {
                    window.ChangeView(window == currentWindow);
                }
            }
            else
            {
                foreach (SityWindowOpener window in _menus)
                {
                    window.ChangeView(false);

                }
            }
        }
    }
}
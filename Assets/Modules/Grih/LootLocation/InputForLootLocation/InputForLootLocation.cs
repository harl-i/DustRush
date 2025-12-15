using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Grih.LootLocation
{
    public class InputForLootLocation : MonoBehaviour
    {
        public const int LeftMouse = 0;

        [SerializeField] private Joystick _joystick;
        [SerializeField] private bool _isMobleField;

        public event Action<Vector2> Moved;
        public event Action<Vector2> Shoot;

        private bool _isMoble = false;

        public void Init(bool isMobile)
        {
            Debug.Log("Мобиольный? " + isMobile + " Исправить на проде");
      //      _isMoble = isMobile;
        }

        private void Update()
        {
            if (_isMobleField) // поменять под ассембли
            {
                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                    Moved?.Invoke(new Vector2(_joystick.Horizontal, _joystick.Vertical));
                }

                if (Input.touchCount > 0)
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }

                    Touch touch = Input.GetTouch(0);
                    Shoot?.Invoke(Camera.main.ScreenToWorldPoint(touch.position));
                }
            }

            else
            {
                _joystick.gameObject.SetActive(false);

                if (Input.GetKey(KeyCode.W))
                {
                    Moved?.Invoke(new Vector2(0, 1));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    Moved?.Invoke(new Vector2(0, -1));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Moved?.Invoke(new Vector2(-1, 0));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Moved?.Invoke(new Vector2(1, 0));
                }

                if (Input.GetMouseButton(LeftMouse))
                {
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        Shoot?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    }
                }
            }
        }
    }
}
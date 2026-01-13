using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Grih.LootLocation
{
    public class InputForLootLocation : MonoBehaviour
    {
        public const int LeftMouse = 0;

        public event Action<Vector2> Moved;
        public event Action<Vector2> Shoot;

        private bool _isMoble = false;

        private void Update()
        {
            if (_isMoble)
            {
                if (Input.touchCount > 0)
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }

                    Touch touch = Input.GetTouch(0);

                    Vector3 tochPos = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(tochPos, Vector2.zero);

                    if (hit.collider != null)
                    {
                        if (hit.collider.TryGetComponent(out LootBox box))
                        {
                            box.ChoisedOnMobile();
                            return;
                        }
                    }

                    Shoot?.Invoke(tochPos);
                }
            }

            else
            {
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

        public void Init(bool isMoble)
        {
            _isMoble = isMoble;
        }

        public void JoustikUse(float x, float y)
        {
            if (_isMoble)
                Moved?.Invoke(new Vector2(x, y));
        }
    }
}
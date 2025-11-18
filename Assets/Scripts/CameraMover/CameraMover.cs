using UnityEngine;
using UnityEngine.EventSystems;

namespace CameraMover
{
    public class CameraMover : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private const float ChangeZoomValue = 1f;
        private const float ChangeYPositionValue = 2f;

        private const float MaxYValue = 6f;
        private const float MinYValue = -12f;

        private const float MaxZoom = 8f;
        private const float MinZoom = 4f;

        [SerializeField] private Camera _camera;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {

                if (eventData.delta.x > 0)
                {
                    if (_camera.orthographicSize >= MaxZoom)
                    {
                        return;
                    }

                    _camera.orthographicSize += ChangeZoomValue;
                }

                else
                {
                    if (_camera.orthographicSize <= MinZoom)
                    {
                        return;
                    }

                    _camera.orthographicSize -= ChangeZoomValue;
                }
            }

            else
            {
                if (eventData.delta.y > 0)
                {
                    if (_camera.transform.position.y <= MinYValue)
                    {
                        return;
                    }

                    _camera.transform.position = new Vector3(_camera.transform.position.x,
                        _camera.transform.position.y + ChangeYPositionValue,
                        _camera.transform.position.z);
                }
                else
                {
                    if (_camera.transform.position.y >= MaxYValue)
                    {
                        return;
                    }

                    _camera.transform.position = new Vector3(_camera.transform.position.x,
                        _camera.transform.position.y - ChangeYPositionValue,
                        _camera.transform.position.z);
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
    }
}
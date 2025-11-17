using UnityEngine;
using UnityEngine.EventSystems;

namespace CameraMover
{
    public class CameraMover : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private const float ChangeZoomValue = 1f;
        private const float ChangeYPositionValue = 2f;

        [SerializeField] private Camera _camera;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {

                if (eventData.delta.x > 0)
                {
                    Debug.Log("Right");
                    _camera.orthographicSize += ChangeZoomValue;
                }

                else
                {
                    Debug.Log("Left");

                    _camera.orthographicSize -= ChangeZoomValue;
                }
            }

            else
            {
                if (eventData.delta.y > 0)
                {
                    Debug.Log("Up");
                    _camera.transform.position = new Vector3(_camera.transform.position.x,
                        _camera.transform.position.y - ChangeYPositionValue,
                        _camera.transform.position.z);
                }
                else
                {
                    Debug.Log("Down");
                    _camera.transform.position = new Vector3(_camera.transform.position.x,
                        _camera.transform.position.y + ChangeYPositionValue,
                        _camera.transform.position.z);
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
    }
}
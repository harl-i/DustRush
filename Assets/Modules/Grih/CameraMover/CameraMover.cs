using UnityEngine;

namespace CameraMover
{
    public class CameraMover : MonoBehaviour
    {
        private const int MaxPrtographicScale = 8;
        private const int MinPrtographicScale = 4;
        private const int ValueChangeZoomOnWheelMouse = 1;
        private const int ZCamera = -10;

        [SerializeField] private int MaxXValue = 5;
        [SerializeField] private int MinXValue = -5;

        [SerializeField] private int MaxYValue = 6;
        [SerializeField] private int MinYValue = -20;

        [SerializeField] private Camera _camera;

        private float _scroll;

        private void Update()
        {
            _scroll = Input.GetAxis("Mouse ScrollWheel");

            if (_scroll != 0.0f)
            {
                if (_scroll > 0)
                {
                    if (_camera.orthographicSize >= MinPrtographicScale)
                    {
                        _camera.orthographicSize -= ValueChangeZoomOnWheelMouse;
                    }
                }
                else
                {
                    if (_camera.orthographicSize <= MaxPrtographicScale)
                    {
                        _camera.orthographicSize += ValueChangeZoomOnWheelMouse;
                    }
                }
            }

            if (transform.position.y > MaxYValue)
                transform.position = new Vector3(transform.position.x, MaxYValue, ZCamera);
            else if (transform.position.y < MinYValue)
                transform.position = new Vector3(transform.position.x, MinYValue, ZCamera);

            if (transform.position.x > MaxXValue)
                transform.position = new Vector3(MaxXValue, transform.position.y, ZCamera);
            else if (transform.position.x < MinXValue)
                transform.position = new Vector3(MinXValue, transform.position.y, ZCamera);

            if (_camera.orthographicSize >= MaxPrtographicScale)
                _camera.orthographicSize = MaxPrtographicScale;
            else if (_camera.orthographicSize <= MinPrtographicScale)
                _camera.orthographicSize = MinPrtographicScale;
        }
    }
}
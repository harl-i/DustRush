using UnityEngine;

namespace CameraMover
{
    public class CameraMover : MonoBehaviour
    {
        private const int MaxPrtographicScale = 8;
        private const int MinPrtographicScale = 4;
        private const int ValueChangeZoomOnWheelMouse = 1;
        private const int ZCamera = -10;

        [SerializeField] private int _maxXValue = 5;
        [SerializeField] private int _minXValue = -5;

        [SerializeField] private int _maxYValue = 6;
        [SerializeField] private int _minYValue = -15;

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

            if (transform.position.y > _maxYValue)
                transform.position = new Vector3(transform.position.x, _maxYValue, ZCamera);
            else if (transform.position.y < _minYValue)
                transform.position = new Vector3(transform.position.x, _minYValue, ZCamera);

            if (transform.position.x > _maxXValue)
                transform.position = new Vector3(_maxXValue, transform.position.y, ZCamera);
            else if (transform.position.x < _minXValue)
                transform.position = new Vector3(_minXValue, transform.position.y, ZCamera);

            if (_camera.orthographicSize >= MaxPrtographicScale)
                _camera.orthographicSize = MaxPrtographicScale;
            else if (_camera.orthographicSize <= MinPrtographicScale)
                _camera.orthographicSize = MinPrtographicScale;
        }
    }
}
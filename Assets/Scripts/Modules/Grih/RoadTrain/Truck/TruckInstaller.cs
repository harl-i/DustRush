using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.RoadTrain
{
    public class TruckInstaller : MonoBehaviour
    {
        private const string SpeedTrusk = "Speeder";

        private const float SpeedBoost = -0.01f;

        [SerializeField] private Environment.GroundMover _mover;
        [SerializeField] private Button _startBoost;
        [SerializeField] private Truck _truck;

        private string _type;

        private void Start()
        {
            _type = _truck.TypeTrusk;
            _startBoost.onClick.AddListener(ApplyBoost);
        }

        private void OnDisable()
        {
            _startBoost.onClick.RemoveListener(ApplyBoost);
        }

        public void SetType(string value)
        {
            _type = value;
        }

        private void ApplyBoost()
        {
            if (_type == SpeedTrusk)
            {
                IncreaseSpeed();
            }
        }

        private void IncreaseSpeed()
        {
            _mover.BoostSpeed(SpeedBoost);
        }
    }
}

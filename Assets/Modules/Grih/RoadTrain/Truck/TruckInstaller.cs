using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.RoadTrane
{
    [RequireComponent (typeof(Truck))]
    public class TruckInstaller : MonoBehaviour
    {
        public const string SpeedTrusk = "Speeder";
        public const string Attacker = "Attacker";
        public const string Stealther = "Stealther";

        public const float SpeedBoost = -0.01f;

        [SerializeField] private Environment.GroundMover _mover;
        [SerializeField] private Button _startBoost;

        private Truck _truck;
        private string _type;

        private void OnEnable()
        {
            _truck = GetComponent<Truck>();
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
            else if (_type == Attacker)
            {
                IncreaseDamage();
            }
            else if (_type == Stealther)
            {
                IncreaseStealth();
            }
        }
        private void IncreaseSpeed()
        {
            _mover.BoostSpeed(SpeedBoost);
        }

        private void IncreaseDamage()
        {
            throw new NotImplementedException();
        }

        private void IncreaseStealth()
        {
            throw new NotImplementedException();
        }
    }
}

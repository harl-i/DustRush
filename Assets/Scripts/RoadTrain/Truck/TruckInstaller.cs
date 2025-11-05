using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RoadTrane
{
    public class TruckInstaller : MonoBehaviour
    {
        public const string SpeedTrusk = "Speeder";
        public const string Attacker = "Attacker";
        public const string Stealther = "Stealther";

        public const float SpeedBoost = -0.01f;

        [SerializeField] private Environment.GroundMover _mover;
        [SerializeField] private Button _startBoost;

        private string _type;

        private void OnEnable()
        {
            _startBoost.onClick.AddListener(PlayBoost);
        }

        public void SetType(string value)
        {
            _type = value;
        }

        private void PlayBoost()
        {
            ApplyBoost();
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

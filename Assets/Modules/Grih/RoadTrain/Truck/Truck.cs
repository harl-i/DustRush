using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Modules.Grih.RoadTrane
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Truck : TranePart
    {
        public const string SpeedTrusk = "Speeder";
        public const string Attacker = "Attacker";
        public const string Stealther = "Stealther";

        private const int AttackerId = 2;
        private const int SpeedId = 1;
        private const int StealtherId = 3;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _speedSprite;
        [SerializeField] private Sprite _attackerSprite;
        [SerializeField] private Sprite _stealtherSprite;

        private string _savedType;

        public string TypeTrusk { get; private set; }

        public void Init(string type)
        {
            _savedType = type;
            SetLoadType();
        }

        private void SetLoadType()
        {
            if (_savedType == SpeedTrusk)
            {
                TypeTrusk = SpeedTrusk;
                _spriteRenderer.sprite = _speedSprite;
            }
            else if (_savedType == Attacker)
            {
                TypeTrusk = Attacker;
                _spriteRenderer.sprite = _attackerSprite;

            }
            else if (_savedType == Stealther)
            {
                TypeTrusk = Stealther;
                _spriteRenderer.sprite = _stealtherSprite;

            }
        }

        public void ChangeType(int id)
        {
            if (id == AttackerId)
                _savedType = Attacker;
            else if (id == SpeedId)
                _savedType = Stealther;
            else
                _savedType = SpeedTrusk;

            SetLoadType();
        }

        public int TypeTruskToInt()
        {
            if (_savedType == Attacker)
               return AttackerId;
            else if (_savedType == Stealther)
               return StealtherId;
            else
               return StealtherId;
        }

        public override void OnEnabled()
        {
        }
    }
}

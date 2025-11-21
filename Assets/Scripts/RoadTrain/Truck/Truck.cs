using UnityEngine;
using YG;

namespace RoadTrane
{
    [RequireComponent(typeof (SpriteRenderer))]
    public class Truck : TranePart
    {
        public const string SpeedTrusk = "Speeder";
        public const string Attacker = "Attacker";
        public const string Stealther = "Stealther";

        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _speedSprite;
        [SerializeField] private Sprite _attackerSprite;
        [SerializeField] private Sprite _stealtherSprite;

        public string TypeTrusk { get; private set; }

        public override void OnEnabled()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            string saved = YG2.saves.TruskType;

            if (saved == SpeedTrusk)
            {
                TypeTrusk = SpeedTrusk;
                _spriteRenderer.sprite = _speedSprite;
            }
            else if (saved == Attacker)
            {
                TypeTrusk = Attacker;
                _spriteRenderer.sprite = _attackerSprite;

            }
            else if (saved == Stealther)
            {
                TypeTrusk = Stealther;
                _spriteRenderer.sprite = _stealtherSprite;

            }
        }
    }
}

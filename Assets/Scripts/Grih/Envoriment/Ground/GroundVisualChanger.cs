using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class GroundVisualChanger : MonoBehaviour
    {
        [SerializeField] private Sprite _desertSprite;
        [SerializeField] private Sprite _forestSprite;
        [SerializeField] private List<SpriteRenderer> _currentSpriteList;

        private Sprite _currentSprite;

        private void OnEnable()
        {
            SetSprite();
        }

        public void SetSprite()
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
                _currentSprite = _desertSprite;
            else
                _currentSprite = _forestSprite;

            foreach (SpriteRenderer sprite in _currentSpriteList)
            {
                sprite.sprite = _currentSprite;
            }
        }
    }
}

using UnityEngine;

namespace Modules.Grih.Sity
{
    public class BackSity : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        [SerializeField] private Sprite _spriteSity1;
        [SerializeField] private Sprite _spriteSity2;

        public void Init(string nameTown)
        {
            if (nameTown == "FirstSity")
                _renderer.sprite = _spriteSity1;
            else if (nameTown == "SecondSity")
                _renderer.sprite = _spriteSity2;
        }
    }
}
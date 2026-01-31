using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class TruckStrategy : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public string NameType => _name;

        public int Id => _id;

        public void ChangeActivity(bool isActive)
        {
            if (isActive)
            {
                _spriteRenderer.sprite = _sprite;
            }
        }
    }
}

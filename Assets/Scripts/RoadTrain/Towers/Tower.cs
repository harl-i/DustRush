using UnityEngine;

namespace RoadTrane
{
    public class Tower : MonoBehaviour
    {
    //    [SerializeField] private Health _thisHealth;

        public Tower(string name, int damge, float range, float maxHealth, Sprite sprite)
        {
            Name = name;
            Damge = damge;
            Range = range;
            MaxHealth = maxHealth;
            Sprite = sprite;
        }

        public string Name { get; private set; }

        public int Damge { get; private set; }

        public float Range { get; private set; }

        public float MaxHealth { get; private set; }

        public Sprite Sprite { get; private set; }


        public void Awake()
        {
     //       _thisHealth.SetMaxHealth(MaxHealth);
        }

        public void TakeDamage(float damage)
        {
     //       _thisHealth.Damaged(damage);
        }
    }
}

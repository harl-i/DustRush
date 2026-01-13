using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public int Max => _health.Max;

        public Slider Slider { get; private set; }

        private void Awake()
        {
            Slider = GetComponent<Slider>();
            Slider.maxValue = Max;
            Slider.value = Slider.maxValue;
        }

        private void OnEnable()
        {
            _health.HealthChanged += ChandgedHealthValue;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= ChandgedHealthValue;
        }

        private void ChandgedHealthValue(int healthValue)
        {
            ChangeSlider(healthValue);
        }

        private void ChangeSlider(int healthValue)
        {
            Slider.value = healthValue;

            if (healthValue == 0)
                Slider.gameObject.SetActive(false);
        }
    }
}

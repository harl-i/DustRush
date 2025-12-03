using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
      //  [SerializeField] private TextMeshProUGUI _text;

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
      //      _text.text = (_health.Max + "/" + _health.Max);
        }

        private void OnDisable()
        {
            _health.HealthChanged -= ChandgedHealthValue;
        }

        private void ChandgedHealthValue(int healthValue)
        {
            //     _text.text = (healthValue.ToString() + "/" + _health.Max);
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

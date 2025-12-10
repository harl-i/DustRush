using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.GlobalMap
{
    public class GlobalMapCell : MonoBehaviour
    {
        [SerializeField] private string _namePoint;
        [SerializeField] private Button _start;
        [SerializeField] private bool _isSity;
        [SerializeField] private float _longTimerRound;
        public string NamePoint => _namePoint;
        public bool IsSity => _isSity;
        public float LongTimerRound => _longTimerRound;

        public event Action<string> OnStartClick;

        private void OnEnable()
        {
            _start.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(OnClick);
        }

        public void ChangeActivatedEffect(bool isActive)
        {
            _start.enabled = isActive;
        }

        private void OnClick()
        {
            OnStartClick?.Invoke(_namePoint);
        }
    }
}
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
        [SerializeField] private int _longTimerRound;

        [SerializeField] private GameObject _viewYouOnHere;
        [SerializeField] private GameObject _pointToChange;

        public string NamePoint => _namePoint;
        public bool IsSity => _isSity;
        public int LongTimerRound => _longTimerRound;

        public event Action<string> OnStartClick;

        private void OnEnable()
        {
            _start.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(OnClick);
        }

        public void SetYouOnHere()
        {
            _viewYouOnHere.gameObject.SetActive(true);
        }

        public void ChangeSetViewEffect(bool isActive)
        {
            _pointToChange.gameObject.SetActive(isActive);
        }

        public void ChangeActivatedEffect(bool isActive)
        {
            _start.enabled = isActive;
        }

        private void OnClick()
        {
            _pointToChange.gameObject.SetActive(true);
            OnStartClick?.Invoke(_namePoint);
        }
    }
}
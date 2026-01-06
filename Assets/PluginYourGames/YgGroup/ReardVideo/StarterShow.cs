using UnityEngine;
using UnityEngine.UI;

namespace YG
{
    public class StarterShow : MonoBehaviour
    {
        [SerializeField] private string _adID;
        [SerializeField] private Button _starterShowing;

        private void Start()
        {
            _starterShowing.onClick.AddListener(ButtonRewardClick);
        }

        private void OnDestroy()
        {
            _starterShowing.onClick.RemoveListener(ButtonRewardClick);
        }

        public void ButtonRewardClick()
        {
            YG2.RewardedAdvShow(_adID);
        }
    }
}

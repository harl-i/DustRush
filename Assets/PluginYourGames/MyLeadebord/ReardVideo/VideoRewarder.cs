using Modules.Grih.Sity;
using System;
using UnityEngine;

namespace YG
{
    public class VideoRewarder : MonoBehaviour
    {
        [SerializeField] private string _adID;
        [SerializeField] private Hostel _hostel;

        public event Action<string> RewardDead;

        private void OnEnable()
        {
            YG2.onRewardAdv += Rewarded;
        }

        private void OnDisable()
        {
            YG2.onRewardAdv -= Rewarded;
        }

        private void Rewarded(string id)
        {
            if (id == _adID)
                _hostel.OnReward(id);
        }
    }
}

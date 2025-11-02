using UnityEngine;
using YG.Utils.LB;

namespace YG
{
    public class LeaderbordCounter : MonoBehaviour
    {
        private const string TechnoName = "***";

        [SerializeField] private LeaderboardYG _board;

        private int _scorePlayer;

        private void OnEnable()
        {
            YG2.onGetLeaderboard += OnGetLeaderboards;
        }

        private void OnDisable()
        {
            YG2.onGetLeaderboard -= OnGetLeaderboards;
        }

        private void Start()
        {
            YG2.GetLeaderboard(TechnoName);
        }

        public void TrySetNewScore(int currentScore)
        {
            OnScoreChange(currentScore);
        }

        private void OnScoreChange(int currentScore)
        {
            
            if (_scorePlayer < currentScore)
            {
                _scorePlayer = currentScore;
                _board.SetLeaderboard(_scorePlayer);
                _board.UpdateLB();
            }
        }

        private void OnGetLeaderboards(LBData lb)
        {
            if (lb.technoName == TechnoName)
                if (lb.currentPlayer != null)
                    _scorePlayer = lb.currentPlayer.score;
        }
    }
}

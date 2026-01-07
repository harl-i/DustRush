using UnityEngine;
using YG.Utils.LB;

namespace YG
{
    public class LeaderbordCounter : MonoBehaviour
    {
        private const int _scoreForFinish = 30;
        private const string TechnoName = "PathLength";

        [SerializeField] private YG.LeaderboardYG _board;
        [SerializeField] private Modules.Grih.GlobalMap.GlobalMap _map;

        private int _scorePlayer;

        private void OnEnable()
        {
            YG2.onGetLeaderboard += OnGetLeaderboards;
        }

        private void OnDisable()
        {
            YG2.onGetLeaderboard -= OnGetLeaderboards;
            _map.Finished -= OnScoreChange;
        }

        private void Start()
        {
            YG2.GetLeaderboard(TechnoName);
            _map.Finished += OnScoreChange;
        }

        private void OnScoreChange()
        {
            _scorePlayer += _scoreForFinish;
            _board.SetLeaderboard(_scorePlayer);
            _board.UpdateLB();
        }

        private void OnGetLeaderboards(LBData lb)
        {
            if (lb.technoName == TechnoName)
                if (lb.currentPlayer != null)
                    _scorePlayer = lb.currentPlayer.score;
        }
    }
}

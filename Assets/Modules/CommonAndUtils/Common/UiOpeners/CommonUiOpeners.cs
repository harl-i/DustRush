using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class CommonUiOpeners : MonoBehaviour
    {
        [SerializeField] private Button _leaderbordOpen;
        [SerializeField] private GameObject _leaderboard;

        private void Start ()
        {
            _leaderbordOpen.onClick.AddListener(ChangeLeaderBord);
        }

        private void OnDestroy()
        {
            _leaderbordOpen.onClick.RemoveListener(ChangeLeaderBord);
        }

        private void ChangeLeaderBord()
        {
            _leaderboard.SetActive(!_leaderboard.activeSelf);
        }
    }
}

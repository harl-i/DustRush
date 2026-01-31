using Modules.Grih.InventoryGroup;
using Modules.Grih.Sity;
using UnityEngine;

namespace Modules.Grih.LootLocation
{
    public class LootBox : MonoBehaviour
    {
        private const float RangeForOpen = 3f;

        private const int MinRandomRange = 1;
        private const int MaxRandomRange = 4;

        [SerializeField] private int _minMoney;
        [SerializeField] private int _maxMoney;
        [SerializeField] private int _minMetal;
        [SerializeField] private int _maxMetal;
        [SerializeField] private LootBoxView _view;
        [SerializeField] private Sprite _openedSprite;
        [SerializeField] private SpriteRenderer _renderer;

        private Money _moneyCounter;
        private Metal _metalCounter;
        private BlueprintObserver _blueprintObserver;
        private Player _player;
        private int _level;

        private bool _isOpen = false;

        private void OnMouseDown()
        {
            ChoisedOnMobile();
        }

        public void ChoisedOnMobile()
        {
            if (Vector2.Distance(
                _player.transform.position, transform.position) < RangeForOpen
                 || _player.transform.position == transform.position)
            {
                if (_isOpen)
                    return;

                _isOpen = true;

                Open();
            }
        }

        public void Init(
            int level,
            Player player,
            BlueprintObserver blueprintObserver,
            Money moneyCounter,
            Metal metalCounter)
        {
            _level = level;
            _player = player;
            _blueprintObserver = blueprintObserver;
            _moneyCounter = moneyCounter;
            _metalCounter = metalCounter;
            _isOpen = false;

            SetCurrenValues();
        }

        private void SetCurrenValues()
        {
            _minMoney *= _level;
            _maxMoney *= _level;
            _minMetal *= _level;
            _maxMetal *= _level;
        }

        private void Open()
        {
            int randomValueType = UnityEngine.Random.Range(MinRandomRange, MaxRandomRange);

            switch (randomValueType)
            {
                case MinRandomRange:
                    GetMoney();
                    break;
                case MinRandomRange + MinRandomRange:
                    GetMetal();
                    break;
                case >= MinRandomRange + MinRandomRange:
                    GetBlueprint();
                    break;
            }

            _renderer.sprite = _openedSprite;
        }

        private void GetBlueprint()
        {
            if (_blueprintObserver.TryOpenRandomBlueprintOnLevel(_level))
            {
                _view.ViewPrizeBlueprint();
                return;
            }
            else
            {
                GetMetal();
            }
        }

        private void GetMetal()
        {
            int value = UnityEngine.Random.Range(_minMetal, _maxMetal);
            _metalCounter.ChangeValue(value);

            _view.ViewPrizeMetal(value);
        }

        private void GetMoney()
        {
            int value = UnityEngine.Random.Range(_minMoney, _maxMoney);
            _moneyCounter.ChangeValue(value);

            _view.ViewPrizeMoney(value);
        }
    }
}
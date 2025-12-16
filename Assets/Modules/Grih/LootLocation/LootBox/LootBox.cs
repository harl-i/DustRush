using UnityEngine;
using Inventory;
using Modules.Grih.Sity;

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

        private Money _moneyCounter;
        private Metal _metalCounter;
        private BlueprintObserver _blueprintObserver;
        private Player _player;
        private int _level;

        private Collider2D _collider2D;

        private void OnMouseDown()
        {
            ChoisedOmMobile();
        }

        public void ChoisedOmMobile()
        {
            if (Vector2.Distance(_player.transform.position, transform.position) < RangeForOpen
                 || _player.transform.position == transform.position)
            {
                Open();
            }
        }

        public void Init(int level, Player player, BlueprintObserver blueprintObserver, Money moneyCounter, Metal metalCounter)
        {
            _level = level;
            _player = player;
            _blueprintObserver = blueprintObserver;
            _moneyCounter = moneyCounter;
            _metalCounter = metalCounter;

            SetCurrenValues();

            _collider2D = GetComponent<Collider2D>();
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
                case (MinRandomRange + MinRandomRange):
                    GetMetal();
                    break;
                case >= (MinRandomRange + MinRandomRange):
                    GetBlueprint();
                    break;
            }

            gameObject.SetActive(false);
        }

        private void GetBlueprint()
        {
            if (_blueprintObserver.TryOpenRandomBlueprintOnLevel(_level))
            {
                Debug.Log("Чертёж добаивили");
                return;
            }
            else
            {
                GetMetal();
                GetMoney();
                Debug.Log("Чертёж есть, добавили денег метала");
            }

        }

        private void GetMetal()
        {
            int value = UnityEngine.Random.Range(_minMetal, _maxMetal);
            _metalCounter.ChangeValue(value);
            Debug.Log("Метал " + value);
        }

        private void GetMoney()
        {
            int value = UnityEngine.Random.Range(_minMoney, _maxMoney);
            _moneyCounter.ChangeValue(value);
            Debug.Log("дЕнег " + value);
        }
    }
}
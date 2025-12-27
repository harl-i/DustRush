using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class ShopCellNeedBlueprint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textCoust;
        [SerializeField] private Button _tryBuy;

        private InventoryGroup.InventoryItem _dollar;
        private BlueprintObserver _observer;
        private ShopCell _shopCell;
        private int _coust;

        private void OnDestroy()
        {
            _tryBuy.onClick.RemoveListener(OnTryBye);
        }

        public void Init(ShopCell shopCell, int coust, InventoryGroup.InventoryItem dollar, BlueprintObserver observer)
        {
            _shopCell = shopCell;
            _coust = coust;
            _textCoust.text = _coust.ToString();
            _dollar = dollar;
            _observer = observer;

            _tryBuy.onClick.AddListener(OnTryBye);
        }

        private void OnTryBye()
        {
           if (_dollar.Value >= _coust)
            {
                _dollar.ChangeValue(-_coust);
                _observer.OpenBlueprint(_shopCell.IdContent);
                _shopCell.SetActiveState(true);
                gameObject.SetActive(false);
            }
        }
    }
}
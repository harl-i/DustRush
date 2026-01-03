using Inventory;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Grih.Sity
{
    public class ShopCell : MonoBehaviour
    {
        [SerializeField] private int _coustMoney;
        [SerializeField] private int _coustMetal;
        [SerializeField] private Button _buttonActivate;
        [SerializeField] private Button _buttonSale;
        [SerializeField] private GameObject _effector;
        [SerializeField] private int _coustOnBlueprint;

        [SerializeField] private TextMeshProUGUI _coustMoneyView;
        [SerializeField] private TextMeshProUGUI _coustMetalView;

        private ShopCellNeedBlueprint _boxNeedBlueprint;
        private Dollars _dollars;
        private BlueprintObserver _blueprintObserver;

        public int IdContent { get; private set; }
        public bool IsByed { get; private set; } = false;

        public event Action<int, int, int> Byed;
        public event Action<int> OnUsed;
        public event Action<int, int, int> Saled;

        private void OnEnable()
        {
            _buttonActivate.onClick.AddListener(OnClick);
            _buttonSale.onClick.AddListener(OnClickSale);
            _coustMoneyView.text = _coustMoney.ToString();
            _coustMetalView.text = _coustMetal.ToString();
            StopShowing();

            if (IsByed == false)
                _buttonSale.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _buttonActivate.onClick.RemoveListener(OnClick);
            _buttonSale.onClick.RemoveListener(OnClickSale);

        }

        private void Start()
        {
            StopShowing();
        }

        public void SetID(int key)
        {
            if (key > 0)
                IdContent = key;
        }

        public void InitOnShop(Dollars dollars, BlueprintObserver blueprintObserver)
        {
            _dollars = dollars;
            _blueprintObserver = blueprintObserver;
        }

        private void OnClickSale()
        {
            Saled?.Invoke(IdContent, _coustMoney, _coustMetal);
        }

        public void SetBuyState(bool isByed)
        {
            IsByed = isByed;

            if (IsByed)
            {
                _buttonSale.gameObject.SetActive(true);
                _coustMoneyView.gameObject.SetActive(false);
                _coustMetalView.gameObject.SetActive(false);
            }
        }

        public void ActivateShowing()
        {
            if (IsByed == false)
                return;

            _effector.gameObject.SetActive(true);
            _buttonActivate.interactable = true;
        }

        public void SetActiveState(bool isActive)
        {
            _buttonActivate.interactable = isActive;

            if (isActive == false)
            {
                ShopCellNeedBlueprint boxNeedBlueprintNew = Instantiate(_boxNeedBlueprint);

                boxNeedBlueprintNew.transform.position = transform.position;
                boxNeedBlueprintNew.transform.SetParent(transform);

                boxNeedBlueprintNew.Init(this, _coustOnBlueprint, _dollars, _blueprintObserver);
            }
        }

        public void StopShowing()
        {
            _effector.gameObject.SetActive(false);

            if (IsByed == false)
                return;

            _buttonActivate.interactable = false;
        }

        private void OnClick()
        {
            if (IsByed == false)
            {
                Byed?.Invoke(IdContent, _coustMoney, _coustMetal);
            }
            else
            {
                OnUsed?.Invoke(IdContent);
            }
        }

        public void SetBox(ShopCellNeedBlueprint boxNeedBlueprint)
        {
            _boxNeedBlueprint = boxNeedBlueprint;
        }
    }
}
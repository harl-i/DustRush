using UnityEngine;

namespace YG
{
    public class InapObserver : MonoBehaviour
    {
        private const string Dollar5 = "Dollar5";
        private const string Dollar50 = "Dollar50";
        private const string Dollar100 = "Dollar100";

        private const int Dollar5Value = 5;
        private const int Dollar50Value = 50;
        private const int Dollar100Value = 100;

        [SerializeField] private Modules.Grih.InventoryGroup.Dollars _dollarCounter;

        private void OnEnable()
        {
            YG2.onPurchaseSuccess += SuccessPurchased;
        }

        private void OnDisable()
        {
            YG2.onPurchaseSuccess -= SuccessPurchased;
        }

        private void SuccessPurchased(string id)
        {
            Debug.Log(id);

            if (id == Dollar5)
                _dollarCounter.ChangeValue(Dollar5Value);
            else if (id == Dollar50)
                _dollarCounter.ChangeValue(Dollar50Value);
            else if (id == Dollar100)
                _dollarCounter.ChangeValue(Dollar100Value);
        }
    }
}
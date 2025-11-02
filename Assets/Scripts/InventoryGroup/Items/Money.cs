using YG;

namespace Inventory
{
    public class Money : InventoryItem
    {
        public void OnEnable()
        {
            ChangeValue(YG2.saves.Money);
        }

        public override void Save()
        {
            YG2.saves.Money = Value;
        }
    }
}

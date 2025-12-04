using YG;

namespace Inventory
{
    public class Metal : InventoryItem
    {
        public void OnEnable()
        {
            ChangeValue(YG2.saves.Metal);
        }

        public override void Save()
        {
            YG2.saves.Metal = Value;
        }
    }
}

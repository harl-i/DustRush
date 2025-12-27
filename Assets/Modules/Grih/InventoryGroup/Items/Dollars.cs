using Modules.Grih.InventoryGroup;

namespace Inventory
{
    public class Dollars : InventoryItem
    {
        public override void Init(int savedValue)
        {
            ChangeValue(savedValue);
        }
    }
}

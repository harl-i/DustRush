namespace Modules.Grih.InventoryGroup.Public.Interfaces
{
    public interface ICounterSource
    {
        public void Init(InventoryItem money, InventoryItem metal, int savedScoreMoney, int savedScoreMetal)
        {
            money.Init(savedScoreMoney);
            metal.Init(savedScoreMetal);

            metal.ValueChange += OnMetalSave;
            money.ValueChange += OnMoneySave;
        }

        public void OnMetalSave(int value);
        public void OnMoneySave(int value);
    }
}

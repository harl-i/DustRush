namespace Modules.Grih.InventoryGroup.Public.Interfaces
{
    public interface ICounterSource
    {
        public void Init(InventoryItem money,
            InventoryItem metal,
            InventoryItem dollars,
            int savedScoreMoney,
            int savedScoreMetal,
            int savedScoreDollars)
        {
            money.Init(savedScoreMoney);
            metal.Init(savedScoreMetal);
            dollars.Init(savedScoreDollars);

            metal.ValueChange += OnMetalSave;
            money.ValueChange += OnMoneySave;
            dollars.ValueChange += OnDollarsSave;
        }

        public void OnDollarsSave(int value);
        public void OnMetalSave(int value);
        public void OnMoneySave(int value);
    }
}

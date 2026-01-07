using Modules.Grih.InventoryGroup;
using Modules.Grih.InventoryGroup.Public.Interfaces;
using YG;

namespace Game
{
    internal class CounerItemsSource : ICounterSource
    {
        private ICounterSource _source;

        public void Init(
            ICounterSource source,
            InventoryItem money,
            InventoryItem metal,
            InventoryItem dollars,
            int savedScoreMoney,
            int savedScoreMetal,
            int savedScoreDollars)
        {
            _source = source;
            _source.Init(
                money,
                metal, 
                dollars, 
                savedScoreMoney, 
                savedScoreMetal, 
                savedScoreDollars);
        }

        public void OnDollarsSave(int value)
        {
            YG2.saves.Dollars = value;
            YG2.SaveProgress();
        }

        public void OnMetalSave(int value)
        {
            YG2.saves.Metal = value;
            YG2.SaveProgress();
        }

        public void OnMoneySave(int value)
        {
            YG2.saves.Money = value;
            YG2.SaveProgress();
        }
    }
}
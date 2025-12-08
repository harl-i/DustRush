using Modules.Grih.InventoryGroup;
using Modules.Grih.InventoryGroup.Public.Interfaces;
using System;
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
            int savedScoreMoney,
            int savedScoreMetal)
        {
            _source = source;
            _source.Init(money, metal, savedScoreMoney, savedScoreMetal);
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
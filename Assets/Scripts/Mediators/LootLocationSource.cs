using Modules.Grih.LootLocation;
using Modules.Grih.LootLocation.Public.Interfaces;
using Modules.Grih.Sity;
using System.Collections.Generic;

namespace Game
{
    internal class LootLocationSource : ISourceLootLocation
    {
        private Modules.Grih.LootLocation.Public.Interfaces.ISourceLootLocation _source;

        public void Init(
            Modules.Grih.LootLocation.Public.Interfaces.ISourceLootLocation source,
            LootBoxFabric lootBoxFabric,
            string nameGlobalLocation,
            InputForLootLocation input,
            bool isMobleСontrol,
            BlueprintObserver blueprintObserver,
            List<int> openBlueprints)
        {
            _source = source;
            _source.Init(
                lootBoxFabric,
                nameGlobalLocation,
                input,
                isMobleСontrol,
                blueprintObserver,
                openBlueprints);
        }
    }
}
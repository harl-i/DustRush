using Modules.Grih.Sity;
using System.Collections.Generic;

namespace Modules.Grih.LootLocation.Public.Interfaces
{
    public interface ISourceLootLocation
    {
        public void Init(
            LootBoxFabric lootBoxFabric,
            string nameGlobalLocation,
            InputForLootLocation input,
            bool isMoble—ontrol,
            BlueprintObserver blueprintObserver,
            List<int> openBlueprints)
        {
            lootBoxFabric.Init(nameGlobalLocation);
            input.Init(isMoble—ontrol);
            blueprintObserver.Init(openBlueprints);
        }
    }
}
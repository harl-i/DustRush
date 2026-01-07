using Modules.Grih.Sity.Public.Interfaces;
using System.Collections.Generic;
using Modules.Grih.Sity;
using YG;

namespace Game
{
    internal class SitySource : ISitySource
    {
        private Modules.Grih.Sity.Public.Interfaces.ISitySource _source;

        public void Init(
            ISitySource source,
            GarageInventoryPlayer invetoryPlayer,
           List<int> savedDataPlayerItems,
            BlueprintObserver blueprintObserver,
            List<int> savedBlueprint,
            CooldownDumpTimer cooldownDumb,
            int cooldownigValue)
        {
            _source = source;
            _source.Init(
                invetoryPlayer, 
                savedDataPlayerItems, 
                blueprintObserver, 
                savedBlueprint,
                cooldownDumb, 
                cooldownigValue);

        }

        public void OnBlueprintSave(List<int> openBluePrints)
        {
            YG2.saves.OpenBlueprint = openBluePrints;

            YG2.SaveProgress();
        }

        public void OnSavePlayerItem(List<int> saveData)
        {
            YG2.saves.SavedCell = saveData;

            YG2.SaveProgress();
        }

        public void OnSaveCooldown(int value)
        {
            YG2.saves.CooldownDump = value;

            YG2.SaveProgress();
        }
    }
}
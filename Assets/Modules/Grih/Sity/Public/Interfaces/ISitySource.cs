using System;
using System.Collections.Generic;
using UnityEngine;


namespace Modules.Grih.Sity.Public.Interfaces
{
    public interface ISitySource
    {
        public void Init(
            GarageInventoryPlayer invetoryPlayer,
            List<int> savedDataPlayerItems,
            BlueprintObserver blueprintObserver,
            List<int> savedBlueprint)
        {
            invetoryPlayer.Init(savedDataPlayerItems);
            invetoryPlayer.Saved += OnSavePlayerItem;
            blueprintObserver.Init(savedBlueprint);
            blueprintObserver.Saved += OnBlueprintSave;
        }

        public abstract void OnBlueprintSave(List<int> openBluePrints);

        public abstract void OnSavePlayerItem(List<int> saveData);

    }
}

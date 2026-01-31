using System.Collections.Generic;

namespace Modules.Grih.RoadTrain.Public.Interfaces
{
    public interface IFraneFabricSource
    {
        public void Init(
            FabricTrain fabricTrain,
            List<int> savedWagons,
            List<int> savedTower,
            string savedTrusk)
        {
            fabricTrain.Init(savedWagons, savedTower, savedTrusk);
            fabricTrain.Saved += OnSave;
        }

        public abstract void OnSave(List<int> list1, List<int> list2, string typeTrusk);
    }
}
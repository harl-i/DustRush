using System.Collections.Generic;

namespace Modules.Grih.RoadTrane.Public.Interfaces
{
    public interface IFraneFabricSource
    {
        public void Init(
            FabricTrane fabricTrane,
            List<int> savedWagons,
            List<int> savedTower,
            string savedTrusk)
        {
            fabricTrane.Init(savedWagons, savedTower, savedTrusk);
            fabricTrane.Saved += OnSave;
        }

        public abstract void OnSave(List<int> list1, List<int> list2, string typeTrusk);
    }
}
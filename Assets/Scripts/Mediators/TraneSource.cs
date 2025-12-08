using System.Collections.Generic;
using Modules.Grih.RoadTrane.Public.Interfaces;
using YG;

namespace Game
{
    internal class TraneSource : IFraneFabricSource
    {
        private Modules.Grih.RoadTrane.Public.Interfaces.IFraneFabricSource _source;

        public void Init(
            Modules.Grih.RoadTrane.Public.Interfaces.IFraneFabricSource source,
            Modules.Grih.RoadTrane.FabricTrane fabricTrane,
            List<int> savedWagons,
            List<int> savedTower,
            string savedTrusk)
        {
            _source = source;
            _source.Init(fabricTrane, savedWagons, savedTower, savedTrusk);
        }

        public void OnSave(List<int> savedWagons, List<int> savedTowers, string typeTrusk)
        {
            YG2.saves.SavedWagons = savedWagons;
            YG2.saves.SavedTowers = savedTowers;
            YG2.saves.TruskType = typeTrusk;
            YG2.SaveProgress();
        }
    }
}
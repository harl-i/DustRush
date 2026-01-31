using System.Collections.Generic;
using Modules.Grih.RoadTrain.Public.Interfaces;
using YG;

namespace Game
{
    internal class TrainSource : IFraneFabricSource
    {
        private Modules.Grih.RoadTrain.Public.Interfaces.IFraneFabricSource _source;

        public void Init(
            Modules.Grih.RoadTrain.Public.Interfaces.IFraneFabricSource source,
            Modules.Grih.RoadTrain.FabricTrain fabricTrane,
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
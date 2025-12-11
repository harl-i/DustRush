using Modules.Grih.GlobalMap;
using Modules.Grih.GlobalMap.Public.Interfaces;
using System;
using System.Collections.Generic;
using YG;

namespace Game
{
    internal class GlobalMapSource : IGlobalMapSource
    {
        private Modules.Grih.GlobalMap.Public.Interfaces.IGlobalMapSource _source;

        public void Init(Modules.Grih.GlobalMap.Public.Interfaces.IGlobalMapSource source,
            GlobalMap globalMap,
            bool isOnPath,
            string savedDeport,
            string savedPointToRoad,
            List<string> openLoads)
        {
            _source = source;
            _source.Init(
                globalMap,
                isOnPath,
                savedDeport,
                savedPointToRoad,
                openLoads);

        }

        public void OnSaveGlobalMap(bool isGoingToPath, string savedDeport, string savedPointToRoad, List<string> openLocals)
        {
            YG2.saves.IsGoingToPath = isGoingToPath;
            YG2.saves.SavedDeport = savedDeport;
            YG2.saves.SavedPointToRoad = savedPointToRoad;
            YG2.saves.OpenLocals = openLocals;
            YG2.SaveProgress();
        }
    }
}
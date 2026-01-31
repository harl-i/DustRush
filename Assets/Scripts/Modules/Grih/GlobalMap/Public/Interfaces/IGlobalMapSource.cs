using System.Collections.Generic;

namespace Modules.Grih.GlobalMap.Public.Interfaces
{
    public interface IGlobalMapSource
    {
        public void Init(
            GlobalMap globalMap,
            bool isGoingToPath,
            string savedDeport,
            string savedPointToRoad,
            List<string> savedTowns)
        {
            globalMap.Init(
                isGoingToPath,
                savedDeport,
                savedPointToRoad,
                savedTowns);

            globalMap.Saved += OnSaveGlobalMap;
        }

        public void OnSaveGlobalMap(
            bool arg1,
            string arg2,
            string arg3,
            List<string> list2);
    }
}
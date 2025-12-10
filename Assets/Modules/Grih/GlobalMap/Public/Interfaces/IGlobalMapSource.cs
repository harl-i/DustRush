using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Grih.GlobalMap.Public.Interfaces
{
    public interface IGlobalMapSource
    {
        public void Init(
            GlobalMap globalMap,
            bool isGoingToPath,
            string savedDeport,
            string savedPointToRoad,
            List<string> openLocals)
        {
            globalMap.Init(
                isGoingToPath,
                savedDeport,
                savedPointToRoad,
                openLocals);

            globalMap.Saved += OnSaveGlobalMap;
        }

        void OnSaveGlobalMap(bool arg1, string arg2, string arg3, List<string> list);
    }
}
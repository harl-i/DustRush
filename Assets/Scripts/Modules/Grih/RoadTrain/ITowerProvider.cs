using System.Collections.Generic;

namespace Modules.Grih.RoadTrain
{
    public interface ITowerProvider
    {
        IReadOnlyList<Tower> GetAliveTowers();
    }
}
using System.Collections.Generic;

namespace Modules.Grih.RoadTrane
{
    public interface ITowerProvider
    {
        IReadOnlyList<Tower> GetAliveTowers();
    }
}
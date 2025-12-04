using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        public int Money = 500;
        public int Metal = 500;

        public string TruskType = "Speeder";

        public List<int> SavedWagons = new List<int>();
        public List<int> SavedTowers = new List<int>();

        public List<int> SavedCell= new List<int>();

        public List<int> OpenBlueprint = new List<int>();

    }
}
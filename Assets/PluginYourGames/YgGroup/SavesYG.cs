using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        public int idSave;
        public string CurrentScene = "SampleScene";
        public int Money = 500;
        public int Metal = 500;
        public int Dollars = 2;

        public bool IsFirstTraneBuld = false;

        public string TruskType = "Speeder";

        public List<int> SavedWagons = new List<int>();
        public List<int> SavedTowers = new List<int>();

        public List<int> SavedCell = new List<int>();

        public List<int> OpenBlueprint = new List<int>();

        public bool IsGoingToPath;

        public string SavedDeport = "Lesson";

        public string SavedPointToRoad = "FirstSity";

        public List<string> OpenLocals = new List<string>(); 
        public List<string> SavedTowns = new List<string>();

        public int CooldownDump = 0;
    }
}
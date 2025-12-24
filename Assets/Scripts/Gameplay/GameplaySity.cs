using UnityEngine;
using YG;

namespace Game
{
    public class GameplaySity : MonoBehaviour
    {
        [SerializeField] private Modules.Grih.Sity.GarageInventoryPlayer _garageInventoryPlayer;
        [SerializeField] private Modules.Grih.Sity.BlueprintObserver _blueprintObserver;
        [SerializeField] private Modules.Grih.Sity.BackSity _backSity; 
        [SerializeField] private Modules.Grih.Sity.CooldownDumpTimer _cooldownDumpTimer; 

        private void Start()
        {
            SitySource sitySource = new SitySource();
            sitySource.Init(
                sitySource,
                _garageInventoryPlayer,
                YG2.saves.SavedCell,
                _blueprintObserver,
                YG2.saves.OpenBlueprint,
                _cooldownDumpTimer,
                YG2.saves.CooldownDump);

            _backSity.Init(YG2.saves.SavedDeport);
        }
    }
}
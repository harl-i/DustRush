using Modules.Grih.RoadTrane;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class GarageSaver : MonoBehaviour
    {
        [SerializeField] private FabricTrane _fabricTrane;
        [SerializeField] private GarageInventoryPlayer _inventoryPlayer;
        [SerializeField] private BlueprintObserver _blueprintObserver;

        private void OnDisable()
        {
            _fabricTrane.Save();
            _inventoryPlayer.Save();
            _blueprintObserver.Save();
        }
    }
}
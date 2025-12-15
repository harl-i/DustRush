using UnityEngine;
using YG;

namespace Game
{
    public class GameplayLootLocation : MonoBehaviour
    {

        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _money;
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _metal;
        [SerializeField] private Modules.Grih.SceneChanger.SceneChangerScript _sceneChangerScript;
        
        [SerializeField] private Modules.Grih.LootLocation.LootBoxFabric _lootBoxFabric;
        [SerializeField] private Modules.Grih.LootLocation.InputForLootLocation _input;
        [SerializeField] private Modules.Grih.Sity.BlueprintObserver _observer;

        private void Start()
        {
            SceneChangerSource changerSource = new SceneChangerSource();
            changerSource.Init(changerSource, _sceneChangerScript, YG2.saves.CurrentScene);

            CounerItemsSource counerItemsSource = new CounerItemsSource();
            counerItemsSource.Init(counerItemsSource, _money, _metal, YG2.saves.Money, YG2.saves.Metal);

            bool deviceIsMobile = YG2.envir.isMobile;
            LootLocationSource lootLocationSource = new LootLocationSource();
            lootLocationSource.Init(lootLocationSource, _lootBoxFabric, YG2.saves.SavedDeport, _input, deviceIsMobile, _observer, YG2.saves.OpenBlueprint);
        }
    }
}
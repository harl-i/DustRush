using UnityEngine;
using YG;

namespace Game
{
    public class GameplayLootLocation : MonoBehaviour
    {
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _money;
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _metal;
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _dollars;
        [SerializeField] private Modules.Grih.SceneChanger.SceneChangerScript _sceneChangerScript;
        
        [SerializeField] private Modules.Grih.LootLocation.LootBoxFabric _lootBoxFabric;
        [SerializeField] private Modules.Grih.LootLocation.InputForLootLocation _input;
        [SerializeField] private Modules.Grih.Sity.BlueprintObserver _observer;
        [SerializeField] private Joystick _joystick;

        [SerializeField] private bool _deviceIsMobile;

        private void Start()
        {
            SceneChangerSource changerSource = new SceneChangerSource();
            changerSource.Init(
                changerSource, 
                _sceneChangerScript, 
                YG2.saves.CurrentScene);

            CounerItemsSource counerItemsSource = new CounerItemsSource();
            counerItemsSource.Init(
                counerItemsSource, 
                _money, 
                _metal, 
                _dollars, 
                YG2.saves.Money, 
                YG2.saves.Metal,
                YG2.saves.Dollars);

#if !UNITY_EDITOR
            _deviceIsMobile = YG2.envir.isMobile;
#endif

            LootLocationSource lootLocationSource = new LootLocationSource();
            lootLocationSource.Init(
                lootLocationSource, 
                _lootBoxFabric, 
                YG2.saves.SavedDeport,
                _input, 
                _deviceIsMobile,
                _observer,
                YG2.saves.OpenBlueprint);
        }

        private void Update()
        {
            if (_deviceIsMobile)
            {
                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                    _input.JoustikUse(_joystick.Horizontal, _joystick.Vertical);
                }
            }
            else
            {
                _joystick.gameObject.SetActive(false);
            }
        }
    }
}
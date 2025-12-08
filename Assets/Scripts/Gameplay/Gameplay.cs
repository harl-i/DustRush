using UnityEngine;
using YG;

namespace Game
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _money;
        [SerializeField] private Modules.Grih.InventoryGroup.InventoryItem _metal;
        [SerializeField] private Modules.Grih.RoadTrane.FabricTrane _fabricTrane;
        [SerializeField] private Modules.Grih.SceneChanger.SceneChangerScript _sceneChangerScript;

        private void Start()
        {
            TraneSource traneSource = new TraneSource();
            traneSource.Init(traneSource, _fabricTrane, YG2.saves.SavedWagons, YG2.saves.SavedTowers, YG2.saves.TruskType);

            SceneChangerSource changerSource = new SceneChangerSource();
            changerSource.Init(changerSource, _sceneChangerScript, YG2.saves.CurrentScene);

            CounerItemsSource counerItemsSource = new CounerItemsSource();
            counerItemsSource.Init(counerItemsSource, _money, _metal, YG2.saves.Money, YG2.saves.Metal);
        }
    }
}
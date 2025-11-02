using Pool;
using UnityEngine;

namespace RoadTrane
{
    public class FabricTower : MonoBehaviour
    {
        private const string MashineGun1 = "MashineGun1";

        [SerializeField] private Tower _mashineGunPrefabTower1;

        private Pool<Tower> _mashineGunPoolTower1;

        public void Create(string result, Transform parent)
        {
            Tower tower = null;

            if (result == MashineGun1)
                tower = _mashineGunPoolTower1.GetItem().GetComponent<Tower>();
            
            if (tower == null)
                return;

            tower.transform.position = parent.position;
            tower.transform.SetParent(parent);
        }
    }
}
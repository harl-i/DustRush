using Modules.Grih.RoadTrane;
using UnityEngine;

namespace Modules.Grih.Sity
{
    public class Garage : MonoBehaviour
    {
        [SerializeField] private ConstuctorTrane _constuctorTrane; 

        private void OnEnable()
        {
            _constuctorTrane.ChangeView(true);
        }

        private void OnDisable()
        {
            _constuctorTrane.ChangeView(false);
        }
    }
}
using UnityEngine;

namespace Modules.Grih.RoadTrain
{
    public class HaveIdItem : MonoBehaviour
    {
        [SerializeField] private int _id;

        public int Id => _id;
    }
}

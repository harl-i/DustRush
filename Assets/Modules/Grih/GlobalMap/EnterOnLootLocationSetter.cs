using Common;
using System.Collections;
using UnityEngine;

namespace Modules.Grih.GlobalMap
{
    public class EnterOnLootLocationSetter : MonoBehaviour
    {
        private const int RandomValue = 1;
        private const string LessonLevel = "Lesson";

        [SerializeField] private GlobalMap _global;
        [SerializeField] private HashTableLocation _hashTableLocation;
        [SerializeField] private SceneChanger.ChangeOnLootLocation _enterOnLoot;
        [SerializeField] private int _randomValueProbabilityToOne = 5;
        [SerializeField] private Common.HashTableLocation _hashLocalName;

        [SerializeField] private int _delayShowingValue;
        [SerializeField] private int _lifeValue;

        private WaitForSeconds _waitStartDelay;
        private WaitForSeconds _waitLifeView;

        private bool _isStarted = false;

        private void FixedUpdate()
        {
            if (_isStarted)
                return;

            _isStarted = true;
            
            Init();
        }

        private void Init()
        {
            _waitStartDelay = new WaitForSeconds(_delayShowingValue);
            _waitLifeView = new WaitForSeconds(_lifeValue);
            _enterOnLoot.Activated += ActivatedEnter;

            if (Random.Range (0, _randomValueProbabilityToOne) != RandomValue)
            {
                _enterOnLoot.gameObject.SetActive(false);
                return;
            }
            Debug.Log(_global.SavedDeport.ToString());

            if (_global.IsGoingToPath 
                || _global.SavedDeport == LessonLevel
                || _hashLocalName.LocationIsSity[_global.SavedDeport])
            {
                _enterOnLoot.gameObject.SetActive(false);
                return;
            }

            StartCoroutine(ShowDoor());
        }

        private IEnumerator ShowDoor()
        {
            _enterOnLoot.gameObject.SetActive(false);
            yield return _waitStartDelay;
            _enterOnLoot.gameObject.SetActive(true);
            yield return _waitLifeView;
            _enterOnLoot.gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            _enterOnLoot.Activated -= ActivatedEnter;
        }

        private void ActivatedEnter()
        {
            _global.OnEnterOnLootInActionScene();
        }
    }
}
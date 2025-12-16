using Modules.Grih.SceneChanger;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOnLootLocation : MonoBehaviour
{
    [SerializeField] private SceneChangerScript _sceneChanger;
    [SerializeField] private Button _enterButton;

    private void Start()
    {
        _enterButton.onClick.AddListener(OnClickEnter);
    }

    private void OnDestroy()
    {
        _enterButton.onClick.RemoveListener(OnClickEnter);
    }

    private void OnClickEnter()
    {
        _sceneChanger.ChangeOnLootLocation();
    }
}

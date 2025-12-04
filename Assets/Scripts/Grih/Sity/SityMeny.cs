using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sity
{
    public class SityMeny : MonoBehaviour
    {
        [SerializeField] private Button _garageOpen;
        [SerializeField] private Button _hostelOpen;
        [SerializeField] private Button _bankOpen;
        [SerializeField] private Button _shopOpen;

        [SerializeField] private Garage _garage;
        [SerializeField] private Hostel _hostel;
        [SerializeField] private Bank _bank;
        [SerializeField] private Shop _shop;

        private void OnEnable()
        {
            _garageOpen.onClick.AddListener(OpenGarage);
            _hostelOpen.onClick.AddListener(OpenHostel);
            _bankOpen.onClick.AddListener(OpenBank);
            _shopOpen.onClick.AddListener(OpenShop);
        }


        private void OnDisable()
        {
            _garageOpen.onClick.RemoveListener(OpenGarage);
            _hostelOpen.onClick.RemoveListener(OpenHostel);
            _bankOpen.onClick.RemoveListener(OpenBank);
            _shopOpen.onClick.RemoveListener(OpenShop);
        }

        private void OpenShop()
        {
            _shop.gameObject.SetActive(!_shop.gameObject.activeSelf);
            _bank.gameObject.SetActive(false);
            _hostel.gameObject.SetActive(false);
        }

        private void OpenBank()
        {
            _bank.gameObject.SetActive(!_bank.gameObject.activeSelf);
            _shop.gameObject.SetActive(false);
            _garage.gameObject.SetActive(false);
        }

        private void OpenHostel()
        {
            _hostel.gameObject.SetActive(!_hostel.gameObject.activeSelf);
            _shop.gameObject.SetActive(false);
            _garage.gameObject.SetActive(false);
            _bank.gameObject.SetActive(false);
        }

        private void OpenGarage()
        {
            _garage.gameObject.SetActive(!_garage.gameObject.activeSelf);
            _bank.gameObject.SetActive(false);
            _hostel.gameObject.SetActive(false);
        }
    }
}
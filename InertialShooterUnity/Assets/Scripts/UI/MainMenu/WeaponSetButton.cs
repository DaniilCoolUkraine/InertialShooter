using InertialShooter.Chips.Weapons;
using InertialShooter.Player;
using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.MainMenu
{
    public class WeaponSetButton : MonoBehaviour
    {
        [SerializeField] private WeaponChip _weaponChip;
        [SerializeField] private PlayerController _playerController;
        
        [SerializeField] private GameObject _chooseScreen;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            Time.timeScale = 0;
            _button.onClick.AddListener(SetWeapon);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _button.onClick.RemoveListener(SetWeapon);
        }

        private void SetWeapon()
        {
            _playerController.SetWeaponChip(_weaponChip);
            
            _chooseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
}
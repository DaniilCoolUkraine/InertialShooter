using InertialShooter.Chips.Weapons;
using InertialShooter.Damageable;
using InertialShooter.ScriptableObjects;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Health events")] 
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private EventSO _onPlayerDie;

        [SerializeField] private DamageIndicator _indicator;

        [Header("Shoot events")] 
        [SerializeField] private PlayerShoot _playerShoot;
        
        [SerializeField] private PlayerDash _dash;
        [SerializeField] private PlayerReloadIndicator _reloadIndicator;
        [SerializeField] private ScreenShake _screenShake;

        private WeaponChip _weaponChip;

        private void OnEnable()
        {
            _playerHealth.OnDamaged += _indicator.Indicate;
            _playerHealth.OnDie += _onPlayerDie.Invoke;
            
            WeaponChip weaponChip = Instantiate(_weaponChip, transform);
            
            _playerShoot.SetWeaponChip(weaponChip);
            _dash.SetRecoil(weaponChip.WeaponChipData.Recoil);
            
            _playerShoot.WeaponChip.OnShoot += _dash.Dash;
            _playerShoot.WeaponChip.OnShoot += _screenShake.Shake;
            
            _playerShoot.WeaponChip.OnReload += _reloadIndicator.OnReload;
        }

        private void OnDisable()
        {
            _playerHealth.OnDamaged -= _indicator.Indicate;
            _playerHealth.OnDie -= _onPlayerDie.Invoke;
            
            _playerShoot.WeaponChip.OnShoot -= _dash.Dash;
            _playerShoot.WeaponChip.OnShoot -= _screenShake.Shake;

            _playerShoot.WeaponChip.OnReload -= _reloadIndicator.OnReload;
        }

        public void SetWeaponChip(WeaponChip chip)
        {
            _weaponChip = chip;
            gameObject.SetActive(true);
        }
    }
}
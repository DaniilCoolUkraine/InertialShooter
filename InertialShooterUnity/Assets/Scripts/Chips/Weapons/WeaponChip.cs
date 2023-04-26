using System;
using System.Collections;
using UnityEngine;

namespace InertialShooter.Chips.Weapons
{
    public class WeaponChip : Chip
    {
        public event Action<Vector2> OnShoot;
        public event Action<float> OnReload;
        
        private WeaponChipDataSO _weaponChipData;
        public WeaponChipDataSO WeaponChipData => _weaponChipData;

        private bool _canShoot = true;
        
        private void Awake()
        {
            _weaponChipData = (WeaponChipDataSO) _chipData;
        }
        
        public virtual void Shoot(Vector2 direction)
        {
            if (!_canShoot)
                return;

            _weaponChipData.ShootFunction.Shoot(transform.position, direction, _weaponChipData.ShootDistance, _weaponChipData.ShootLayers);
            
            OnShoot?.Invoke(direction);
            
            StartCoroutine(ShootCooldown());
        }

        private IEnumerator ShootCooldown()
        {
            OnReload?.Invoke(_weaponChipData.Cooldown);
            
            _canShoot = false;
            yield return new WaitForSeconds(_weaponChipData.Cooldown);
            _canShoot = true;
        }
    }
}
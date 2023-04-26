using System;
using System.Collections;
using InertialShooter.Chips.ScriptableObjects;
using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Chips
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

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -direction, _weaponChipData.ShootDistance,
                LayerMask.GetMask(_weaponChipData.ShootLayers));

            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    IDamageable damageable = hit.collider.GetComponent<IDamageable>();

                    if (damageable == null)
                        break;
                    damageable.TakeDamage(1);
                }
            }

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
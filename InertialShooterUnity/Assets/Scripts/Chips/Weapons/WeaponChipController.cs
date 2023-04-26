using System;
using UnityEngine;

namespace InertialShooter.Chips.Weapons
{
    public class WeaponChipController : MonoBehaviour
    {
        [SerializeField] private WeaponChip _weaponChip;
        [SerializeField] private BulletTracer _bulletTracer;

        private void OnEnable()
        {
            _weaponChip.OnShoot += _bulletTracer.CreateTrace;
        }

        private void OnDisable()
        {
            _weaponChip.OnShoot -= _bulletTracer.CreateTrace;
        }
    }
}